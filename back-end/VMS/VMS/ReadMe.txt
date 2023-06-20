1. Open appsettings.json and update "DefaultConnection" based on your local database setting.

2. Create Migrations
dotnet ef migrations add init-commit --context VMS.Models.VMSDbContext

3. Create/Update database structure
dotnet ef database update

