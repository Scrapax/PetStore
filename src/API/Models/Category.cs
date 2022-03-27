using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public abstract class BaseCategory
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class PostCategory : BaseCategory
    {
    }

    public class PutCategory : BaseCategory
    {

    }

    public class GetCategory : BaseCategory
    {
        public Guid Id { get; set; }
    }
}