// See https://aka.ms/new-console-template for more information
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

Console.WriteLine("Hello, World!");

public class PetStoreContextFactory : IDesignTimeDbContextFactory<PetStoreContext>
{
    public PetStoreContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PetStoreContext>();
        optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=petstore;User=root;Password=password;", MySqlServerVersion.LatestSupportedServerVersion);

        return new PetStoreContext(optionsBuilder.Options);
    }
}