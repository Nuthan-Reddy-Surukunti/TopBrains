class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int  Age { get; set; }
    public string Condition { get; set; }
    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
    }
}