using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARS.Models
{
    public class Ward
    {

        [Key]
        public string id { get; set; }
        [ForeignKey("id")]
        public School CurrentSchool { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Sex { get; set; }
        public string Level { get; set; }


    }
}
