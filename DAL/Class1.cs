using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  

    public class DeptMaster
    {
        [Key]
        [Required]
        public int deptcode { get; set; }
        [MaxLength(20,ErrorMessage ="Can't be more than 20")]
        public string deptname { get; set; }
       
     
        public virtual ICollection<EmpProfile> GetEmpProfiles
        {
            get;
            set;
        } 
    }
    public class EmpProfile
    {
        [Key]
        [Required]
        public int EmpCode
        {
            get;
            set;
        }
        [MaxLength(30,ErrorMessage ="Can't be more than 30")]
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
        
        [ForeignKey("deptcode")]
        public virtual DeptMaster DeptMaster
        {
            get;
            set;
        }
    }
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext")
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        }
        public virtual DbSet<DeptMaster> DeptMasters { get; set; }
        public virtual DbSet<EmpProfile> EmpProfiles { get; set; }

                        }
}
