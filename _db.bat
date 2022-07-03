set datef=%date:~-4%%date:~3,2%%date:~0,2%
call dotnet clean
call dotnet build
call dotnet ef migrations add DB-%datef%
call dotnet ef database update
