namespace ddd_exercise
{
    using static Locations;

    internal class Truck : Transport
    {
        public Truck(string name, string location) : base(name, location)
        {
        }

        protected override string PlanNextTarget()
        {
            if (_location == Factory && TryLoad())
            {
                if (_cargo.Target == B) return B;
                if (_cargo.Target == A) return Port;
            }
            if (Dispatcher.IsCargoWaitingToBeDeliveredFrom(Factory))
            {
                return Factory;
            }

            return null;
        }

        private bool TryLoad()
        {
            var cargo = Dispatcher.GetCargo(Factory);
            if (cargo != null)
            {
                Load(cargo);
            }

            return cargo != null;
        }
    }
}
