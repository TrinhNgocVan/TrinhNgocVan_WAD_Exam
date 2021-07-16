using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace t2004_1.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        public int ExamSubjectId { get; set; }
        public int FacultyId { get; set; }
        public int ClassroomId { get; set; }
        [Required(ErrorMessage ="Vui long chon thoi gian bat dau thi")]
        public String StartTime { get; set; }
        public String ExamDate { get; set; }
        public int Status { get; set; }
        [Required(ErrorMessage = "Vui long chon thoi gian thi")]
        public int Duration { get; set; }
        
        public virtual ExamSubject ExamSubject { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }


    }
}