![.NET Core](https://github.com/aimenux/EntityFrameworkCoreCosmosDemo/workflows/.NET%20Core/badge.svg)
# EntityFrameworkCoreCosmosDemo
```
Using entity framework core to make CRUD operations on CosmosDb
```

I m using [EF Core CosmosDb Provider](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Cosmos) in order to make some dummy CRUD operations.

2 configuration choices are proposed via `DbContextName` field in order to indicate the storing way : 
- `CosmosDbContextOne` will store in the same collection both `author` and `book` documents.
- `CosmosDbContextTwo` will store in the same collection only `author` documents with `book` documents expanded inside.

**`Tools`** : vs19, net core 3.1, efcore3.1