# Rhinodoor server app

# Initialize the database
- 

## How to start database
- sudo docker ps -a
- sudo docker start \<container_id>

## How to make migraiton
- dotnet ef migrations add OrderDoorOptionMigration
- dotnet ef database update