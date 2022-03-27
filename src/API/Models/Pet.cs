using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class BasePet
    {
        [Required]
        public string? Name { get; set; }

        [MinLength(1, ErrorMessage = "At least 1 photo of the pet must be provided.")]
        [MaxLength(3, ErrorMessage = "No more than 3 photos of the pet")]
        public List<Photo> Photos { get; set; } = new List<Photo>();
    }

    public class PostPet : BasePet
    {
    }

    public class PutPet : BasePet
    {

    }

    public class GetPet : BasePet
    {
        public Guid Id { get; set; }
    }
}