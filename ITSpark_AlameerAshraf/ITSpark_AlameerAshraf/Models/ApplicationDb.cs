using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ITSpark_AlameerAshraf.Models
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb() : base("Conn") { }
        public static ApplicationDb Create()
        {
            return new ApplicationDb();
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
    }
}