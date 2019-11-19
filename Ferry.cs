namespace ddd_exercise
{
    using static Locations;

    internal class Ferry : Transport
    {
        public Ferry(string name, string location) : base(name, location)
        {
        }

        protected override string PlanNextTarget()
        {
            if (_location == Port && TryLoad()) return A;
            if (_location == A && Dispatcher.IsCargoWaitingToBeDeliveredTo(A)) return Port;

            return null;
        }

        private bool TryLoad()
        {
            var cargo = Dispatcher.GetCargo(Port);
            if (cargo != null)
            {
                Load(cargo);
            }

            return cargo != null;
        }
    }
}
