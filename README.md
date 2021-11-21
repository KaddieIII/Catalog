# Catalog
This is a Rest-API-Server in C# with mongodb. You can create new database-entries, called 'services' with attributes name, description and price.


## Requirements
* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Visual Studio Code](https://code.visualstudio.com)
    * Packages: C#, MongoDb (might not work with database running in docker)
* [Docker](https://docs.docker.com/get-docker)

## Setup:
For **Docker**: 
**1.)** ```docker run -d --rm --name mongo -p 27018:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=P1a2s3s4w5o6r7d8 mongo```
**2.)** ```dotnet user-secrets init```
**3.)** ```dotnet user-secrets set MongoDbSettings:Password P1a2s3s4w5o6r7d8```

You can also setup this database on a local MongoDB. Just switch the Port in appsettings.json to 27017 and create a local db called "Catalog".


## Usage:
Start the Server with ```F5``` in VS Code. Wait until the Terminal has finished. 

For debugging and testing I recommend Swagger UI. You can easily make GET, PUT, POST, DELETE requests and also fill the requested JSON data. You can find the Swagger-UI on https://localhost:5001/swagger/index.html.

### GET
**1.)** https://localhost:5001/ -> get all services<br />
**2.)** https://localhost:5001/{id} -> get the service with the given id<br />
**3.)** https://localhost:5001/{id}/image -> get the image of the service with the given id

### PUT
Link: https://localhost:5001/{id}

```
Body:
{
    "name" : "This is the name",
    "description" : This is a description",
    "price" : 20,
    "picture" : "This is the file-name of the image",
    "base64" : "This is the base64 code of the image"
}
```

Price is between 0 and 1000.

### POST
Link: https://localhost:5001/

```
Body:
{
    "name" : "This is the name of the service",
    "description" : This is a description",
    "price" : 20,
    "picture" : "This is the file-name of the image",
    "base64" : "This is the base64 code of the image"
}
```

Price is between 0 and 1000.

### DELETE
Link: https://localhost:5001/{id}

