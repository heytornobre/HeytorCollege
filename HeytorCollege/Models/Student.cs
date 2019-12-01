using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeytorCollege.Models
{
    public class Student:Person
    {
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}