using System;

namespace ddd_exercise
{
    internal abstract class Transport
    {
        private string _name;
        protected string _location;

        protected int _remainingTravelTime;
        protected string _currentTarget;
        private bool Arrived => _remainingTravelTime == 0;
        protected Cargo _cargo;

        public Transport(string name, string location)
        {
            _name = name;
            _location = location;
        }

        private bool HasTarget()
        {
            return _currentTarget != null;
        }

        private void Move()
        {
            _remainingTravelTime--;
        }

        private void HandleArrived()
        {
            _location = _currentTarget;
            Console.WriteLine($"{Dispatcher._elapsedHours}: {_name} arrived at {_location}");
        }

        private void TryUnload()
        {
            if (_cargo != null)
            {
                Unload();
            }
        }

        private void Unload()
        {
            _cargo.Location = _location;
            Console.WriteLine($"{Dispatcher._elapsedHours}: {_name} unloaded {_cargo.Target} in {_cargo.Location}");
            _currentTarget = null;
            _cargo = null;
        }

        internal void Work()
        {
            if (HasTarget())
            {
                Move();
                if (Arrived)
                {
                    HandleArrived();
                    TryUnload();
                }
                else
                {
                    Console.WriteLine($"{Dispatcher._elapsedHours}: {_name} has {_remainingTravelTime} more hour(s) to go to reach {_currentTarget}");
                }
            }

            if (!HasTarget() || Arrived)
            {
                _currentTarget = PlanNextTarget();
                if (_currentTarget != _location)
                {
                    _remainingTravelTime = Dispatcher.GetDistance(_location, _currentTarget);
                }
            }
        }


        protected void Load(Cargo cargo)
        {
            _cargo = cargo;
            _cargo.Location = _name;
            Console.WriteLine($"{Dispatcher._elapsedHours}: {_name} picked up {_cargo.Target} at {_location}");
        }

        protected abstract string PlanNextTarget();
    }
}