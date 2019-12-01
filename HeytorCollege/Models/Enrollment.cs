using System.ComponentModel.DataAnnotations;

namespace HeytorCollege.Models
{
    
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int SubjectID { get; set; }
        public int StudentID { get; set; } //registration number
        [DisplayFormat(NullDisplayText = "No grade")]
        [Range(0,10,ErrorMessage ="Grade must be between 0 and 10")]
        public double? Grade { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}