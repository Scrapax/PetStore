using API.Models;
using AutoMapper;
using DB;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [PrimaryConstructor]
    public partial class PetsController : ControllerBase
    {
        private PetStoreContext DB { get; }
        private IMapper Mapper { get; }

        [HttpGet]
        public IEnumerable<GetPet> Get(int? offset, int? limit)
        {
            return Mapper.Map<IEnumerable<GetPet>>(DB.Pets.Skip(offset ?? 0).Take(limit ?? 10));
        }

        [HttpGet("{id}")]
        public ActionResult<GetPet> Get(Guid id)
        {
            var ent = DB.Pets.FirstOrDefault(entity => entity.Id == id);
            if (ent is null)
                NotFound();

            return Ok(Mapper.Map<GetPet>(ent));
        }

        [HttpPost]
        public ActionResult<GetPet> Post(PostPet Pet)
        {
            var ent = Mapper.Map<PetEntity>(Pet);
            DB.Add(ent);
            DB.SaveChanges();

            return Ok(Mapper.Map<GetPet>(ent));
        }

        [HttpPut("{id}")]
        public ActionResult<GetPet> Put(Guid id, PutPet Pet)
        {
            var ent = DB.Pets.FirstOrDefault(entity => entity.Id == id);
            if (ent is null)
                NotFound();

            ent = Mapper.Map<PetEntity>(Pet);
            DB.Update(ent);
            DB.SaveChanges();

            return Ok(Mapper.Map<GetPet>(ent));
        }
    }
}
