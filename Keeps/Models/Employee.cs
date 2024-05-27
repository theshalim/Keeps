using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Keeps.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Required *")]
        [Display(Name = "Employee Code")]
        public int EmpCode { get; set; }
        [Required(ErrorMessage = "Required *")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required *")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Department")]
        public int DeptId { get; set; }
        [NotMapped]
        public string DeptName { get; set; }

    }
}