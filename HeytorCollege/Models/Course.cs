using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeytorCollege.Models
{
    public class Course
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}