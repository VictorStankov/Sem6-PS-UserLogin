# Sem6-PS-UserLogin
## Requirements
Create a `connections.config` file in the base folder with the following contents:
```xml
<connectionStrings>
  <add name="DbConnection"
       connectionString=""
       providerName="System.Data.SqlClient" />
</connectionStrings>
```
The file will be linked automatically to all projects in the solution. Fill in the `connectionString` parameter in the format shown [here](https://www.connectionstrings.com/sqlconnection/connect-via-an-ip-address/).

The application is intended to work with an MS SQL Server 2019 database. It generates all necessary tables on its own so no further configuration is needed.
