using Autofac.Extensions.DependencyInjection;
using Autofac;
using dvdclub.Web;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);//it s implied that we re in main

// Add services to the container.
builder.ConfigureServies();


var app = builder.Build();


// Configure the HTTP request pipeline.
if( !app.Environment.IsDevelopment() ) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();//2 must be before userouting ??adds the static file handler Microsoft.AspNetCore.StaticFiles

app.UseRouting();//3 must be after usestaticfiles adds routing

app.UseAuthorization();

app.MapControllerRoute(//app_start routeconfig
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Movies",
    pattern: "{area:exists}/{controller=MoviesController}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Rentals",
    pattern: "{area:exists}/{controller=RentalsController}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Members",
    pattern: "{area:exists}/{controller=MembersController}/{action=Index}/{id?}");

app.Run();
