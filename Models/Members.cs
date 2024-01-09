using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Models
{
    public class Members
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String? Username { get; set; }
        public String? PhoneNumber { get; set; }
        public bool FreeCoffeeStatus { get; set; } = false;
        public DateTime ExpiryDate { get; set; } = DateTime.Now;
        public String? CreatedBy {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
