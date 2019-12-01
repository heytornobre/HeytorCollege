using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeytorCollege.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The name cannot be longer than 100 characters.", MinimumLength = 2)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Birthday { get; set; }
    }
}