﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Employees")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [StringLength(255)]
        [Column(TypeName ="nvarchar")]
        [Required]
        public string FullName { get; set; }

        public int Salary { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public bool Status { get; set; }

    }
}
