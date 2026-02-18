namespace Domain
{
    public class Patient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int SecurityLevel { get; set; }

        public Patient(string id, string name, int securityLevel)
        {
            Id = id;
            Name = name;
            SecurityLevel = securityLevel;
        }
    }
}
