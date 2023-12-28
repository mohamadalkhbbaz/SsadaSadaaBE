namespace Example_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }
        private static void Start()
        {
            var stopwatch1 = new Stopwatch();
            Console.WriteLine("Pls Click Enter To Start");
            Console.ReadKey();
            var start = stopwatch1.Start();
            Console.WriteLine(">>>>>The project is Start<<<<<");
            Console.WriteLine("Pls Click Enter To Stop And Return Duration Time");
            Console.ReadKey();
            var duration = stopwatch1.Stop(start);
            Console.WriteLine("The Duration Time : " + duration.ToString());
            Console.WriteLine("Pls Enter start To Do Again");

            var reStart = Console.ReadLine();
            if (reStart != null && reStart.Length != 0 && reStart.ToString().ToLower() == "start")
                Start();
        }
    }
}