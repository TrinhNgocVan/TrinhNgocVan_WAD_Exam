using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using t2004_1.Models;

namespace t2004_1.Context
{
    public class DataContext  : DbContext
    {
        public DataContext() : base("T2004E_WAD")
        {

        }
        public DbSet<Faculty>  facultys { get; set; }
        public DbSet<ClassRoom> classRooms { get; set; }
        public DbSet<ExamSubject> examsubjects { get; set; }
        public DbSet<Exam> exams { get; set; }
    }
}