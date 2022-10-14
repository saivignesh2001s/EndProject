using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;

namespace Adddepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            start:
            MyContext context=new MyContext();  
            DeptMaster deptMaster=new DeptMaster();
            Console.WriteLine("Enter dept code");
            deptMaster.deptcode=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter dept name");
            deptMaster.deptname = Console.ReadLine();
            context.DeptMasters.Add(deptMaster);
            Console.WriteLine("Do you want to add more");
            string m=Console.ReadLine();
            if (m == "Y"|| m=="y")
            {
                goto start;
            }
            context.SaveChanges();
        }
    }
}
