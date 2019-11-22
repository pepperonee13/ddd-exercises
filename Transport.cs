using System;

namespace ddd_exercise
{
    internal abstract class Transport
    {
        private static int nextId = 1;
        public int Id { get; }
        private string _name;
        protected string _location;

        protected int _remainingTravelTime;
        protected string _currentTarget;
        private bool Arrived => _remainingTravelTime == 0;
        protected Cargo _cargo;

        public Transport(string name, string location)
        {
            Id = nextId++;
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
            Log(EventType.ARRIVE);
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
            }

            if (!HasTarget() || Arrived)
            {
                _currentTarget = PlanNextTarget();
                if (_currentTarget != null && _currentTarget != _location)
                {
                    _remainingTravelTime = Dispatcher.GetDistance(_location, _currentTarget);
                    Log(EventType.DEPART);
                }
            }
        }

        private void Log(string eventType)
        {
            Logger.Log(new LogMessage
            {
                Event = eventType,
                Kind = this is Truck ? "TRUCK" : "SHIP",
                TransportId = Id,
                Destination = _currentTarget,
                Location = _location,
                Time = Dispatcher._elapsedHours,
                Cargo = _cargo != null ? new CargoLog[]
                {
                            new CargoLog
                            {
                                CargoId = _cargo.Id,
                                Destination = _cargo.Target,
                                Origin = _cargo.Origin
                            }
                } : null
            });
        }

        protected void Load(Cargo cargo)
        {
            _cargo = cargo;
            _cargo.Location = _name;
        }

        protected abstract string PlanNextTarget();
    }
}
