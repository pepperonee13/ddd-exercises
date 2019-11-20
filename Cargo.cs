namespace ddd_exercise
{
    internal class Cargo
    {
        private static int nextId = 1;
        public int Id { get; }
        public string Target { get; }
        public string Location { get; set; }
        public string Origin { get; }


        public Cargo(string target, string location)
        {
            Id = nextId++;
            Target = target;
            Location = location;
            Origin = location;
        }

        public bool IsDelivered => Location == Target;

    }
}
