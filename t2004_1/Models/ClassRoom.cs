using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace t2004_1.Models
{
    public class ClassRoom
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui long nhap ten lop ")]
        public string ClassroomName { get; set; }
        //  public virtual Exam Exam { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}