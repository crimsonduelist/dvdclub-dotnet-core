using Microsoft.AspNetCore.Authorization;
using test.Authorization;
using static test.Authorization.HRManagerProbationRequirement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//auth add 1
//auth add 2 "MyCookieAuth" default scheme
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options => {
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/Account/Login";//explicitly specifying the login path to redirect if [Authorize] is used
    options.AccessDeniedPath = "/AccessDenied";//explicitly specifying the access denied path to redirect if [Authorize] is used
});

//auth add 3
builder.Services.AddAuthorization(options => {
    options.AddPolicy("MustBelongToHRDep",
        policy => policy.RequireClaim("Department", "HR"));//Claim type, Claim Value

    options.AddPolicy("AdminOnly",
        policy => policy.RequireClaim("Admin"));//Claim type, Claim Value

    options.AddPolicy("HRManager",
        policy => policy
        //these 2 are claim requirements
        .RequireClaim("Department", "HR")//Claim type, Claim Value
        .RequireClaim("HRManager")//chain another

        //auth add 4
        //this one is a custom requirement
        .Requirements.Add(new HRManagerProbationRequirement(3)));
});
//auth add 4
builder.Services.AddSingleton<IAuthorizationHandler, HRManagerProbationRequirementHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if( !app.Environment.IsDevelopment() ) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//auth add 2
app.UseAuthentication();//translate the cookie to security context(claims principle)

app.UseAuthorization();

app.MapRazorPages();

app.Run();
