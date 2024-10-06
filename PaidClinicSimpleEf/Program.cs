using Microsoft.EntityFrameworkCore;

#region ��� ������� �������� ����� ������� ����� � ���� ���� number
using System.Globalization;
using PaidClinicSimpleEf.Models;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ���������� ����������� EntityFramework Core ��� ������� ����������
var connection = "Server = (localdb)\\mssqllocaldb;Database = UserStore_db;Trusted_Connection=true";
builder.Services.AddDbContext<ApplicationContext>(
    options => options
        // ����������� lazy loading, ������� ���������� NuGet-����� Microsoft.EntityFrameworkCore.Proxies
        .UseLazyLoadingProxies()
        .UseSqlServer(connection)
);


var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
