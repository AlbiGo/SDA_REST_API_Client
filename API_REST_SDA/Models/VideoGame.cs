using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_REST_SDA.Models
{
    public class VideoGame
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Studio { get; set; }
    }
}
