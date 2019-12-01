using System;
using System.ComponentModel.DataAnnotations;

namespace HeytorCollege.ViewModels
{
    public class BirthdayDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        public int StudentCount { get; set; }
    }
}