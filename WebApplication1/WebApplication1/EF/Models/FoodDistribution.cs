using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.EF.Models
{
    public class FoodDistribution
    {
        [Key]
        public int FoodDistributionId { get; set; }

        [Required]
        [ForeignKey("CollectRequest")]
        public int CollectRequestId { get; set; }

        [Required]
        public DateTime DistributionDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual CollectRequest CollectRequest { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}