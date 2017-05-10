using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITSpark_AlameerAshraf.Models
{
    public class Country
    {
        [Key]
        public Guid CId { get; set; }
        public String Name { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}