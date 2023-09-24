using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_REST_SDA.Models
{
    public class Country
    {
        public Name name { get; set; } = new Name();
        public string status { get; set; }
        public bool independent { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
    }
}
