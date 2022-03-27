using API.Models;
using AutoMapper;
using DB;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [PrimaryConstructor]
    [Authorize]
    public partial class CategoriesController : ControllerBase
    {
        private PetStoreContext DB { get; }
        private IMapper Mapper { get; }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<GetCategory> Get(int? offset, int? limit)
        {
            return Mapper.Map<IEnumerable<GetCategory>>(DB.Categories.Skip(offset ?? 0).Take(limit ?? 10));
        }

        [HttpGet("{id}")]
        public ActionResult<GetCategory> Get(Guid id)
        {
            var ent = DB.Categories.FirstOrDefault(entity => entity.Id == id);
            if (ent is null)
                NotFound();

            return Ok(Mapper.Map<GetCategory>(ent));
        }

        [HttpPost]
        public ActionResult<GetCategory> Post(PostCategory category)
        {
            var ent = Mapper.Map<CategoryEntity>(category);
            DB.Add(ent);
            DB.SaveChanges();

            return Ok(Mapper.Map<GetCategory>(ent));
        }

        [HttpPut("{id}")]
        public ActionResult<GetCategory> Put(Guid id, PutCategory category)
        {
            var ent = DB.Categories.FirstOrDefault(entity => entity.Id == id);
            if (ent is null)
                NotFound();

            ent = Mapper.Map<CategoryEntity>(category);
            DB.Update(ent);
            DB.SaveChanges();

            return Ok(Mapper.Map<GetCategory>(ent));
        }
    }
}
