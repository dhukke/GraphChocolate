## GraphQL w/ HotChocolate

Playing around with graphQL/HotChocolate querying over EF Context.

## Docker

### SQL Server

`docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server`

## Database

```

dotnet tool install --global dotnet-ef

cd GraphChocolate

dotnet ef migrations add InitialCreate

dotnet ef database update

```

## Endpoint

https://localhost:5001/graphql/

## Query samples

```
{
  pizzas
  {
    name
  }
}
```

```
{
  pizzas(where: { topping: { name: { contains: "First Topping"} } })
  {
    id
    name
    topping
    {
      name
    }
  }
}
```
