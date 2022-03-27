using API.Models;
using AutoMapper;
using DB.Models;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostCategory, CategoryEntity>();
            CreateMap<PutCategory, CategoryEntity>();
            CreateMap<CategoryEntity, GetCategory>();

            CreateMap<PostPet, PetEntity>();
            CreateMap<PutPet, PetEntity>();
            CreateMap<PetEntity, GetPet>();
            CreateMap<PhotoEntity, Photo>();
            CreateMap<Photo, PhotoEntity>();
        }
    }
}