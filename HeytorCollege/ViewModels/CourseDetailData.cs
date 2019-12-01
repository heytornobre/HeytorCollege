using HeytorCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeytorCollege.ViewModels
{
    public class CourseDetailData
    {
        public Course Course { get; set; }
        public int? TeachersCount { get; set; }
        public int? StudentsCount { get; set; }
        public double? AverageGrade { get; set; }
    }
}