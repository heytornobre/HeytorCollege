using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeytorCollege.Models
{
    public class Subject
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int SubjectID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }
        public int CourseID { get; set; }
        //[ForeignKey("Teacher")]
        public int? TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}