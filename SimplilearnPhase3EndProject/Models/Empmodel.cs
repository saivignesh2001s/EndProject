using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimplilearnPhase3EndProject.Models
{
    public class Empmodel
    {
        [Required]
        public int EmpCode
        {
            get;
            set;
        }
        [MaxLength(30, ErrorMessage = "Can't be more than 30")]
        public string EmpName
        {
            get;
            set;
        }

        public DateTime DOB
        {
            get;
            set;
        }
        [EmailAddress]
        public string email
        {
            get;
            set;
        }

        public int deptcode
        {
            get;
            set;
        }
    }
}