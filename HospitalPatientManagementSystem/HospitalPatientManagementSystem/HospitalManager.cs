class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmntQueue = new Queue<Patient>();
    
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (!_patients.ContainsKey(id))
        {
            Patient newPatient = new Patient(id, name, age, condition);
            _patients.Add(id, newPatient);
            Console.WriteLine($"Patient {name} has been registered");
        }
       
    }
    public void ScheduleAppointment(int PatientId)
    {
        if (_patients.TryGetValue(PatientId, out Patient patient))
        {
            _appointmntQueue.Enqueue(patient);
            Console.WriteLine($"Patient {patient.Name} added to the appointment queue");
        }
    }
    public Patient ProcessNextAppointment()
    {
        if (_appointmntQueue.Count > 0)
        {
            Patient nextPatient = _appointmntQueue.Dequeue();
            return nextPatient;
        }
        return null;
    }
    public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values.Where(p=>p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}