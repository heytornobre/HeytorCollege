using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeytorCollege.Models
{
    public class Teacher:Person
    {   
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        
    }
}