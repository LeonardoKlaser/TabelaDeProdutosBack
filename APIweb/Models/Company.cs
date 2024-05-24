using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIweb.Models
    {
        [Table("bla")]
        public class Company
        {
        public Company()
        {
        }

        public int Id { get; set; }
            public string Name { get; set; }    

        }
    
}


