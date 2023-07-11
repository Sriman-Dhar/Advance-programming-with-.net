using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.EF.Models
{
    public class CollectRequest
    {
        [Key]
        public int CollectRequestId { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<FoodDistribution> FoodDistributions { get; set; }

        public CollectRequest()
        {
            FoodDistributions = new List<FoodDistribution>();
        }
    }
}