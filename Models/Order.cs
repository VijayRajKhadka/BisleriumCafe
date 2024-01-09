using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Models
{
    public class CoffeeOrder
    {
      
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Guid AddinsId { get; set; }
        public Guid MemberId { get; set; }
        public Double TotalPrice { get; set; }
        public Double Discount {  get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;




    }
}
