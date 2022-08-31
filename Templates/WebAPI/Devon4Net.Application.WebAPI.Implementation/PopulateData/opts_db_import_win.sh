#!/bin/bash
while getopts "d:c:s:" arg; do
  case $arg in
    d) db=$OPTARG;;
    c) csv=$OPTARG;;
    s) lite=$OPTARG;;
  esac
done

if test -z $db 
then
    echo "Please specify which db you want to use using the -d flag."
    exit 127
fi

if test -z $csv 
then
    echo "Please specify the directory which contains the csv files using the -c flag."
    exit 127
fi

if test -z $lite 
then
    echo "Please specify the directory that contains the sqllite3 installation -s flag."
    exit 127
fi

if test "$csv" == "."; 
then
	csv="$(cd "$(dirname "$csv")"; pwd)/$(basename "$csv")"
	csv="$(dirname "$csv")"
	csv=$(echo "$csv" | sed '/\/c/ s/\/c/C\:/')
fi

csvFiles=$(find $csv -type f -name "*.csv")
for file in $csvFiles; do
	filename=$(basename -- ${file})
	tablename="${filename%.*}"
	echo ".import $file $tablename --csv --skip 1" | $($lite $db)
	
done

echo "DONE."
echo "Checkout the inserted data in your Database: $db"