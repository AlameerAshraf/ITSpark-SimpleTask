using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITSpark_AlameerAshraf.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string University { get; set; }
        public string Track { get; set; }
        public string Course { get; set; }

        [ForeignKey("Countries")]
        public Guid? CId { get; set; }
        public virtual Country Countries { get; set; }
    }

}