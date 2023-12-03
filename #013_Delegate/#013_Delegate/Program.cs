namespace _013_Delegate
{
    public delegate void EmpHelper(List<Employee> employees, string name);
    internal class Program
    {
        static void Main(string[] args)
        {
            // Delegate المفوض 

            var emps = new Employee[]
            {
                 new Employee { Id = 1, Name = "mhd", Gender="M",TotoalSales=1000 },
                 new Employee { Id = 2, Name = "ssada", Gender="M",TotoalSales=2000 },
                 new Employee { Id = 3, Name = "fate", Gender="F",TotoalSales=4000 },
                 new Employee { Id = 4, Name = "reta", Gender="F",TotoalSales=3000 },
                 new Employee { Id = 5, Name = "assed", Gender="F",TotoalSales=5000 },
                 new Employee { Id = 6, Name = "anas", Gender="M",TotoalSales=1000 }
            };

            var report = new Report();
            report.ProcessEmpWith6000PlusSales(emps, "Report For Pluse 1000", IsGreateThan); // delegate 
            report.ProcessEmpWith6000PlusSales(emps, "Report For Pluse 1000", delegate (Employee emp) { return emp.TotoalSales >= 4000; }); //AnonymousDelegate
            report.ProcessEmpWith6000PlusSales(emps, "Report For Pluse 1000", (e) => e.TotoalSales >= 4000); // Lamda Expression

            //report.ProcessEmpWith3000PlusSales(emps);
            //report.ProcessEmpWith1000PlusSales(emps);

            /// ReportMutiCastDelegate
            var reportMutiCastDelegate = new ReportMutiCastDelegate();


            EmpHelper empHelper;
            empHelper = reportMutiCastDelegate.PrintEmpName;
            empHelper += reportMutiCastDelegate.PrintSalesByName;


            empHelper(emps.ToList(), "reta");

            Console.ReadKey();
        }

        static bool IsGreateThan(Employee emp) => emp.TotoalSales >= 4000;

    }
    public class ReportMutiCastDelegate
    {
        public void PrintEmpName(List<Employee> emps, string name)
        {
            Console.WriteLine("PrintEmpName");
            foreach (var item in emps.Where(e => e.Name.Contains(name)))
            {
                Console.WriteLine("|" + item.Name);
            }
            Console.WriteLine("\n\n");
        }
        public void PrintSalesByName(List<Employee> emps, string? name)
        {
            Console.WriteLine("PrintSalesByName");
            foreach (var item in emps.Where(e => e.Name.Contains(name)))
            {
                Console.WriteLine("|" + item.TotoalSales);
            }
        }
    }

}