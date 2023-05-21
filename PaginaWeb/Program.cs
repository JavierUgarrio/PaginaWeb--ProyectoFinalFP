var builder = WebApplication.CreateBuilder(args);
//configuracion CORS
string cors = "ConfigurarCors";

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: cors, builder =>
    {
        //permite peticiones de todos los sitios
        builder.WithOrigins("*");
        //permite peticiones tipo post, put, delete
        builder.WithHeaders("*");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(cors);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
