using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.EF.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        public virtual ICollection<CollectRequest> CollectRequests { get; set; }

        public Restaurant()
        {
            CollectRequests = new List<CollectRequest>();
        }
    }
}