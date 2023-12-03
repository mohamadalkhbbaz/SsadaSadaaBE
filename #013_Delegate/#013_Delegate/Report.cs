using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_Delegate
{
    public class Report
    {
        public delegate bool IlegebalTest(Employee e);
        public void ProcessEmpWith6000PlusSales(Employee[] employees, string title, IlegebalTest ilegebal)
        {
            Console.WriteLine(title);
            Console.WriteLine("_______________________________");

            foreach (Employee e in employees)
            {
                if (ilegebal(e))
                {
                    Console.WriteLine($"{e.Id}|{e.Name}|{e.Gender}|{e.TotoalSales}");
                }
            }
            Console.WriteLine("\n\n");
        }

        //public void ProcessEmpWith3000PlusSales(Employee[] employees)
        //{
        //    Console.WriteLine("Employees with 3000 plus sales");
        //    Console.WriteLine("_______________________________");

        //    foreach (Employee e in employees)
        //    {
        //        if (e.TotoalSales >= 3000)
        //        {
        //            Console.WriteLine($"{e.Id}|{e.Name}|{e.Gender}|{e.TotoalSales}");
        //        }
        //    }
        //    Console.WriteLine("\n\n");
        //}

        //public void ProcessEmpWith1000PlusSales(Employee[] employees)
        //{
        //    Console.WriteLine("Employees with 3000 plus sales");
        //    Console.WriteLine("_______________________________");

        //    foreach (Employee e in employees)
        //    {
        //        if (e.TotoalSales >= 1000)
        //        {
        //            Console.WriteLine($"{e.Id}|{e.Name}|{e.Gender}|{e.TotoalSales}");
        //        }
        //    }
        //    Console.WriteLine("\n\n");
        //}

    }
}
