using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class PetEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        public List<PhotoEntity> Photos { get; set; } = new List<PhotoEntity>();

        [Required]
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}