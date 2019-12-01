using HeytorCollege.Models;
using System.Collections.Generic;

namespace HeytorCollege.ViewModels
{
    public class TeacherIndexData
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}