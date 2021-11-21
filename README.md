# Catalog
This is a Rest-API-Server in C# with mongodb. You can create new database-entries, called 'services' with attributes name, description and price.


## Requirements
* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Visual Studio Code](https://code.visualstudio.com)
    * Packages: C#, MongoDb
* [Docker](https://docs.docker.com/get-docker)

### Recommandation
* [Postman](https://www.postman.com/downloads)

## Usage:
Start the Server with ```F5``` in VS Code. Wait until the Terminal has finished. 

You can find the Swagger-UI on https://localhost:5001/swagger/index.html .

For debugging and testing I recommend Postman. You can easily make GET, PUT, POST, DELETE requests and also fill the requested JSON data.

### GET
**1.)** ```https://localhost:5001/``` -> get all services__
**2.)** ```https://localhost:5001/{id}``` -> get the service with the given id
**3.)** ```https://localhost:5001/{id}/image``` -> get the image of the service with the given id

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

