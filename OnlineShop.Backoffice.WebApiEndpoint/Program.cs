using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.UserManagement;
using OnlineShop.EFCore;
using OnlineShop.EFCore.Configurations.UserManagementConfigurations;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

#region [- EF Service Configuration -]
var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:Default");
builder.Services.AddDbContext<OnlineShopDbContext>(c => c.UseSqlServer(connectionString));
#endregion

#region [- Identity Service Configuration -]
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<OnlineShopDbContext>();
builder.Services.Configure<IdentityOptions>(c =>
{
    c.Password.RequireDigit = false;
    c.Password.RequireNonAlphanumeric = false;
    c.Password.RequiredLength = 3;
    c.Password.RequireUppercase = false;
    c.Password.RequireLowercase = false;
}
);

#endregion

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
