# PetStore

### Run DB Locally using docker
```
docker run -d --name petstoredb -p 3306:3306 -e MYSQL_ROOT_PASSWORD=password mysql:5.7
```


### Database Changes
When making changes to the database classes, a new migration must be created and deployed to the database.

```
dotnet ef migrations add <migration-name> -p src/DB -s src/Migrator -v
```

### Swagger documentation
[Link to Swagger Editor](https://editor.swagger.io/?url=https://raw.githubusercontent.com/Scrapax/PetStore/master/docs/swagger.json)
![Swagger documentation of the Pet Store](/docs/swagger.png?raw=true)
