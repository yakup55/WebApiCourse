using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Project
    {
        [Column("ProjectId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Project Name is Required")]
        [MaxLength(60,ErrorMessage ="Maximumu length of the name is 60 characters")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Field { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
