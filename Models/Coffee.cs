using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Models
{
   public  class Coffee
   { 
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public String Description { get; set; }
        public Double Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastModifiedAt { get; set; }

    }
}
