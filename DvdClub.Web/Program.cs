using Autofac.Extensions.DependencyInjection;
using Autofac;
using DvdClub.Domain.Entities;
using DvdClub.Infrastructure.Data;
using DvdClub.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServies();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var db = scope.ServiceProvider.GetRequiredService<DvdClubDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    await SeedData.SeedAsync(db, userManager, roleManager);
}

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Map("/Movies", context => {
    var qs = context.Request.QueryString.Value ?? "";
    context.Response.Redirect("/Movies/Movies/Index" + qs, permanent: false);
    return Task.CompletedTask;
});

app.Map("/Rentals", context => {
    var qs = context.Request.QueryString.Value ?? "";
    context.Response.Redirect("/Rentals/Rentals/Index" + qs, permanent: false);
    return Task.CompletedTask;
});

app.Map("/Customers", context => {
    var qs = context.Request.QueryString.Value ?? "";
    context.Response.Redirect("/Customers/Customers/Index" + qs, permanent: false);
    return Task.CompletedTask;
});

app.Run();
