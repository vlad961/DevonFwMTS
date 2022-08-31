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
	echo "abscsvPath : " "$(readlink -f $csv)"

fi

csvFiles=$(find $csv -type f -name "*.csv")
for file in $csvFiles; do
	filename=$(basename -- ${file})
	tablename="${filename%.*}"
	absDb=$(readlink -f "$db")
	absFilename=$(readlink -f "$file")
	echo -e ".mode csv \n.separator \",\"\n.headers on\n.import $absFilename $tablename" | $($lite $absDb)
done

echo "DONE."
echo "Checkout the inserted data in your Database: $absDb"