using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EfCodeFirstApp.Models
{
    public class StudenContext : DbContext
    {
        public DbSet<Student>Students { get; set; }                  //Students object will receive all the rows from the student model
    }
}