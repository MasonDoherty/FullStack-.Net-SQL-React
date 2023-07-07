#Get your project started easily with this repo. 
just insert your connection string into DbContext and your set and table name. 

this is the .net using react set up however the components have been converted to funtional components.

to get your connection string, run the query in sql. 
select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name()


if local db you can add this to your string "Integrated Security=SSPI;TrustServerCertificate=True"
this helps with loging into sql, not recommended for anything BUT local db projects.

Also CORS has been enabled within program.cs.
