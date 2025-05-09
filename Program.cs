using Agri_Energy_Connect.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Set up your DbContexts
builder.Services.AddDbContext<AgriDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Identity with Roles support
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // ?? Enable roles
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ?? Create roles and seed default employee user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRolesAndEmployeeUserAsync(services);
}

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // ?? Authentication before Authorization
app.UseAuthorization();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapControllerRoute(
    name: "farmer",
    pattern: "farmer/{action=Index}/{id?}",
    defaults: new { controller = "Farmer" });

app.MapControllerRoute(
    name: "product",
    pattern: "product/{action=Index}/{id?}",
    defaults: new { controller = "Product" });

app.Run();


// ? Role & User Seeding Method
async Task SeedRolesAndEmployeeUserAsync(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

    // Create roles
    string[] roles = { "farmer", "employee" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Create default employee user
    string employeeEmail = "employee@agri.com";
    string employeePassword = "Agri123!"; // Must meet Identity's password rules

    var existingUser = await userManager.FindByEmailAsync(employeeEmail);
    if (existingUser == null)
    {
        var user = new IdentityUser
        {
            UserName = employeeEmail,
            Email = employeeEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, employeePassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "employee");
        }
        else
        {
            throw new Exception("Failed to create seed employee user: " +
                string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
