using API.Models;
using AutoMapper;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStore.Controllers;
using System;
using Xunit;

namespace API.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var controller = new CategoriesController(Context, Mapper);
            var rawResult = controller.Post(new Models.PostCategory
            {
                Description = "test category",
                Name = "test"
            });

            var result = rawResult.Result as ObjectResult;
            var category = result?.Value as GetCategory;

            Assert.NotNull(category);
            Assert.Equal(200, result?.StatusCode);
            Assert.NotEqual(Guid.Empty, category?.Id);
        }

        public static PetStoreContext Context { get; } = ConfigureContext();
        private static PetStoreContext ConfigureContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PetStoreContext>()
                .UseMySql("Server=localhost;Port=3306;Database=petstore;User=root;Password=password;", MySqlServerVersion.LatestSupportedServerVersion);

            PetStoreContext ctx = new PetStoreContext(optionsBuilder.Options);
            ctx.Database.EnsureDeleted();
            ctx.Database.Migrate();

            return ctx;
        }

        public static IMapper Mapper { get; } = ConfigureMapper();
        private static IMapper ConfigureMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });

            return new AutoMapper.Mapper(configuration);
        }
    }
}