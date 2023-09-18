using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using SGPE.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql("Server=localhost;uid=USUARIO;Pwd=SENHA123;Database=sgpe", new MySqlServerVersion("8.0.34"));
});
CreateDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

void CreateDatabase()
{
    


    using var myConnection = new MySqlConnection("Server=localhost;uid=USUARIO;Pwd=SENHA123;");

    var parameters = new DynamicParameters();
    parameters.Add("nome", "sgpe");

    var records = myConnection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @nome", parameters);

    if (!records.Any())
    {
        myConnection.Query($"CREATE DATABASE sgpe");
    }
}
