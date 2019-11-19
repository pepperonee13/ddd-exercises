using System.Collections.Generic;
using System.Linq;

namespace ddd_exercise
{
    using static Locations;

    internal class Dispatcher
    {
        public static int _elapsedHours = 0;
        private static Cargo[] _cargos;

        public static int EstimateDuration(Cargo[] cargos)
        {
            _cargos = cargos;
            var trucks = new List<Truck>
            {
                new Truck("T1", Factory),
                new Truck("T2", Factory),
            };

            var ferries = new List<Ferry>
            {
                new Ferry("F1",Port)
            };


            while (cargos.Any(c => !c.IsDelivered))
            {
                trucks.ForEach(t => t.Work());
                ferries.ForEach(t => t.Work());

                if (cargos.Any(c => !c.IsDelivered))
                {
                    _elapsedHours++;
                }
            }

            return _elapsedHours;
        }

        public static Cargo GetCargo(string from)
        {
            return _cargos.FirstOrDefault(c => c.Location == from);
        }

        public static bool IsCargoWaitingToBeDeliveredTo(string target)
        {
            return _cargos.Any(c => !c.IsDelivered && c.Target == target);
        }

        public static bool IsCargoWaitingToBeDeliveredFrom(string location)
        {
            return _cargos.Any(c => c.Location == location);
        }

        internal static int GetDistance(string location, string currentTarget)
        {
            if (location == Factory)
            {
                if (currentTarget == Port) return 1;
                if (currentTarget == B) return 5;
            }

            if (location == B)
            {
                if (currentTarget == Factory) return 5;
            }

            if (location == Port)
            {
                if (currentTarget == Factory) return 1;
                if (currentTarget == A) return 4;
            }

            if (location == A)
            {
                if (currentTarget == Port) return 4;
            }

            return 0;
        }
    }
}
