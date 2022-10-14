using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimplilearnPhase3EndProject.Models
{
    public class deptmodel
    {
        [Required()]
        public int deptcode { get; set; }
        [MaxLength(20, ErrorMessage = "Can't be more than 20")]
        public string deptname { get; set; }
    }
}