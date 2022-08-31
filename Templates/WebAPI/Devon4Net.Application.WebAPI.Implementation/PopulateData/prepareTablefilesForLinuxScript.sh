SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )

csvFiles=$(find $SCRIPT_DIR -type f -name "*.csv")
mkdir LFConvertedFiles
for file in $csvFiles; do
	filename=$(basename -- ${file})
	absFilename=$(readlink -f "$file")
	tr -d '\015' < $filename  > LFConvertedFiles/$filename
	echo "Newlines CR LF --> LF for file: $filename"	
done
#tr -d '\015' <DOS-file >UNIX-file
echo "DONE."