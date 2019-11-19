namespace ddd_exercise
{
    internal class Cargo
    {
        public string Target { get; }
        public string Location { get; set; }

        public Cargo(string target, string location)
        {
            Target = target;
            Location = location;
        }

        public bool IsDelivered => Location == Target;
    }
}
