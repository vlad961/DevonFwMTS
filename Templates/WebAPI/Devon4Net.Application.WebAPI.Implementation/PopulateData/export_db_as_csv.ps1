$server = "127.0.0.1,1433"
$database = "MyThaiStar"
$tablequery = "SELECT schemas.name as schemaName, tables.name as tableName from sys.tables inner join sys.schemas ON tables.schema_id = schemas.schema_id"
$user="sa"
$password="C@pgemini2017"
$outputdir="C:\Users\vsehtman\source\repos\DevonFwMTS\Templates\WebAPI\Devon4Net.Application.WebAPI.Implementation\PopulateData\Tables"
#Delcare Connection Variables
$connectionTemplate = "Data Source={0};Initial Catalog={1};User={2};Password={3};"
$connectionString = [string]::Format($connectionTemplate, $server, $database, $user, $password)
$connection = New-Object System.Data.SqlClient.SqlConnection
$connection.ConnectionString = $connectionString

$command = New-Object System.Data.SqlClient.SqlCommand
$command.CommandText = $tablequery
$command.Connection = $connection

#Load up the Tables in a dataset
$SqlAdapter = New-Object System.Data.SqlClient.SqlDataAdapter
$SqlAdapter.SelectCommand = $command
$DataSet = New-Object System.Data.DataSet
$SqlAdapter.Fill($DataSet)
$connection.Close()

if (Test-Path -Path $outputdir) {

} 
else
{
	New-Item -Path $outputdir -ItemType Directory
}


# Loop through all tables and export a CSV of the Table Data
foreach ($Row in $DataSet.Tables[0].Rows)
{
    $queryData = "SELECT * FROM [$($Row[0])].[$($Row[1])]"

    #Specify the output location of your dump file
    $extractFile = "$outputdir\$($Row[1]).csv"

    $command.CommandText = $queryData
    $command.Connection = $connection

    $SqlAdapter = New-Object System.Data.SqlClient.SqlDataAdapter
    $SqlAdapter.SelectCommand = $command
    $DataSet = New-Object System.Data.DataSet
    $SqlAdapter.Fill($DataSet)
    $connection.Close()

    $DataSet.Tables[0]  | Export-Csv $extractFile -NoTypeInformation -Encoding UTF8
	# If you want to remove the CR of windows new lines uncomment the statement beneath:
	
}	

# taken and adopted from Stackoverflow - https://stackoverflow.com/a/37407406