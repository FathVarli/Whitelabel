# Whitelabel

Simple .Net 8 Mvc Whitelabel Process with SignalR


## Docker Command For Database

```
docker compose up -d
```

## Migration Commands

```
dotnet ef migrations add TestMig -c AppDbContext --project Whitelabel.Persistance --startup-project Whitelabel.UI
```

```
dotnet ef database update -c AppDbContext --project Whitelabel.Persistance --startup-project Whitelabel.UI
```

