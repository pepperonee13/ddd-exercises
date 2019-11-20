using System;
using System.Linq;

namespace ddd_exercise
{
    using static Locations;
    class Program
    {
        static void Main(string[] args)
        {
            var cargos = args[0].Split(",").Select(c => new Cargo(c.ToUpper(), Factory)).ToArray();
            var scenario = string.Concat(cargos.Select(c => c.Target));
            Logger.Init(scenario);

            var elapsedHours = Dispatcher.EstimateDuration(cargos);

            Console.WriteLine(elapsedHours);
        }
    }
}
