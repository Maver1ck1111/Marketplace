using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Discount
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Percentage { get; set; }
        public DateTime Expired { get; set; }
        public bool IsActive => DateTime.UtcNow < Expired;

    }
}
