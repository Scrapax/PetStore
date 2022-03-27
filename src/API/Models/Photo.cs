using PetStore.Attributes;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Photo
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [ImageUrl]
        public string? Url { get; set; }
    }
}