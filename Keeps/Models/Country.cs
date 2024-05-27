using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Keeps.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

    }
}
