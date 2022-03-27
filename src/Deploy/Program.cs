using DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var optionsBuilder = new DbContextOptionsBuilder<PetStoreContext>();
optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=db;User=root;Password=password;", MySqlServerVersion.LatestSupportedServerVersion);

ServiceCollection sc = new ServiceCollection();
sc.AddIdentity();
sc.AddDbContext<PetStoreContext>(opts => opts.UseMySql("Server=localhost;Port=3306;Database=petstore;User=root;Password=password;", MySqlServerVersion.LatestSupportedServerVersion));


using (var scope = sc.BuildServiceProvider().CreateScope())
{
    var db = scope.ServiceProvider.GetService<PetStoreContext>();
    db.Database.Migrate();

    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
    var createRoleResult = roleManager.CreateAsync(new IdentityRole("admin")).Result;

    var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
    var user = new IdentityUser("admin");
    var createUserResult = userManager.CreateAsync(user, "Secretpassword123/").Result;
    var addRoleResult = userManager.AddToRoleAsync(user, "admin").Result;
}

Console.WriteLine("Database Migrated");