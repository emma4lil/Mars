using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MARS.Models
{
    public class School
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public string Address{ get; set; }
        public string Accesskey { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expire { get; set; }



    }
}
    
