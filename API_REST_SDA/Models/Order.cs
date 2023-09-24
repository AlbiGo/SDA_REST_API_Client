using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_REST_SDA.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
