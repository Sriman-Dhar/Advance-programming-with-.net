using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.EF.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public virtual ICollection<CollectRequest> CollectRequests { get; set; }

        public Employee()
        {
            CollectRequests = new List<CollectRequest>();
        }
    }
}