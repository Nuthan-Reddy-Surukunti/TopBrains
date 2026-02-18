using System;
using System.Collections.Generic;
using System.Linq;

#region Custom Exceptions
class DoctorNotAvailableException : Exception
{
    public DoctorNotAvailableException(string message) : base(message) { }
}

class InvalidAppointmentException : Exception
{
    public InvalidAppointmentException(string message) : base(message) { }
}

class PatientNotFoundException : Exception
{
    public PatientNotFoundException(string message) : base(message) { }
}

class DuplicateMedicalRecordException : Exception
{
    public DuplicateMedicalRecordException(string message) : base(message) { }
}
#endregion

#region Base Class
class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
#endregion

#region Derived Classes
class Doctor : Person
{
    public string Specialty { get; set; }
    public double ConsultationFee { get; set; }
}

class Patient : Person
{
    public string Disease { get; set; }
    public DateTime AdmissionDate { get; set; }
}
#endregion

#region Interface
interface IBillable
{
    double CalculateBill();
}
#endregion

#region Appointment
class Appointment : IBillable
{
    public int AppointmentId { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public DateTime AppointmentDate { get; set; }
    public double Fee { get; set; }

    public double CalculateBill()
    {
        return Fee;
    }
}
#endregion

#region MedicalRecord
class MedicalRecord : IBillable
{
    public int RecordId { get; set; }
    public Patient Patient { get; set; }
    public string Diagnosis { get; set; }
    public string Treatment { get; set; }
    public double BillAmount { get; set; }

    public double CalculateBill()
    {
        // TODO: implement billing logic
        return BillAmount;
    }
}
#endregion

#region Hospital System
class HospitalSystem
{
    public List<Doctor> doctors = new List<Doctor>();
    public List<Patient> patients = new List<Patient>();
    public List<Appointment> appointments = new List<Appointment>();
    public Dictionary<int, MedicalRecord> medicalRecords = new Dictionary<int, MedicalRecord>();

    public void AddDoctor(Doctor doctor)
    {
        // TODO
        var check = doctors.Any(i=>i.Id==doctor.Id);
        if (check)
        {
            Console.WriteLine("Doctor with this ID already exists.");
            return;
        }
        doctors.Add(doctor);
    }

    public void AddPatient(Patient patient)
    {
        // TODO
        var check = patients.Any(i => i.Id == patient.Id);
        if (check)        {
            Console.WriteLine("Patient with this ID already exists.");
            return;
        }
        patients.Add(patient);
    }

    public void ScheduleAppointment(Appointment appointment)
    {
        // TODO
        // Check overlapping appointments
        // Throw DoctorNotAvailableException if needed
        var doctorAppointments = appointments.Where(i => i.Doctor.Id == appointment.Doctor.Id);
        foreach (var app in doctorAppointments)        {
            if (app.AppointmentDate == appointment.AppointmentDate)
            {
                throw new DoctorNotAvailableException("Doctor is not available at this time.");
            }
        }
        appointments.Add(appointment);
    }

    public void AddMedicalRecord(MedicalRecord record)
    {
        // TODO
        // Prevent duplicate records
        if (medicalRecords.ContainsKey(record.RecordId))
        {
            throw new DuplicateMedicalRecordException("Medical record with this ID already exists.");
        }
        medicalRecords.Add(record.RecordId, record);
    }

    #region LINQ Methods

    public void GetBusyDoctors()
    {
        // TODO: doctors with more than 10 appointments
        var busyDoctors = appointments.GroupBy(a => a.Doctor)
                                      .Where(g => g.Count() > 10)
                                      .Select(g => g.Key);
        Console.WriteLine("Busy Doctors:");
        foreach (var doctor in busyDoctors)        {
            Console.WriteLine($"{doctor.Name} - {doctor.Specialty}");
        }
        
    }

    public void GetRecentPatients()
    {
        // TODO: patients treated in last 30 days
        var recentPatients = patients.Where(i=>i.AdmissionDate>=DateTime.Now.AddDays(-30));
        Console.WriteLine("Recent Patients:");
        foreach (var patient in recentPatients)
        {
            Console.WriteLine($"{patient.Name} - {patient.AdmissionDate}");
        }
    }

    public void GroupAppointmentsByDoctor()
    {
        // TODO
        var appointmentsByDoctor = appointments.GroupBy(a => a.Doctor);
        Console.WriteLine("Appointments Grouped by Doctor:");
        foreach (var group in appointmentsByDoctor)
        {
            Console.WriteLine($"Doctor: {group.Key.Name}");
            foreach (var appointment in group)
            {
                Console.WriteLine($"  Patient: {appointment.Patient.Name}, Date: {appointment.AppointmentDate}");
            }
        }
    }

    public void GetTopEarningDoctors()
    {
        // TODO
        var topEarningDoctors = appointments.GroupBy(g => g.Doctor).Select(g => new
        {
            Doctor = g.Key,
            TotalEarning = g.Sum(i=>i.Fee)
        }).OrderByDescending(i=>i.TotalEarning).Take(3);
        Console.WriteLine("Top Earning Doctors:");
        foreach (var doctor in topEarningDoctors)
        {
            Console.WriteLine($"{doctor.Doctor.Name} - {doctor.TotalEarning}");
        }
    }

    public void GetPatientsByDisease(string disease)
    {
        // TODO
        var patientsByDisease = patients.Where(i => i.Disease.Equals(disease, StringComparison.OrdinalIgnoreCase));
        foreach (var patient in patientsByDisease)
        {
            Console.WriteLine($"{patient.Name} - {patient.Disease}");
        }
    }

    public void GetTotalRevenue()
    {
        // TODO
        var totalRevenue = appointments.Sum(i => i.Fee) + medicalRecords.Sum(i => i.Value.BillAmount);
        Console.WriteLine($"Total Revenue: {totalRevenue}");
    }

    #endregion
}
#endregion

class Program
{
    static void Main()
    {
        HospitalSystem system = new HospitalSystem();

        // TODO:
        // 1. Add doctors
        Doctor doc1 = new Doctor { Id = 1, Name = "Dr. Smith", Age = 45, Specialty = "Cardiology", ConsultationFee = 200 };
        Doctor doc2 = new Doctor { Id = 2, Name = "Dr. Johnson", Age = 50, Specialty = "Neurology", ConsultationFee = 250 };
        system.AddDoctor(doc1);
        system.AddDoctor(doc2);
        // 2. Add patients
        Patient pat1 = new Patient { Id = 1, Name = "Alice", Age = 30, Disease = "Flu", AdmissionDate = DateTime.Now.AddDays(-5) };
        Patient pat2 = new Patient { Id = 2, Name = "Bob", Age = 40, Disease = "Diabetes", AdmissionDate = DateTime.Now.AddDays(-20) };
        system.AddPatient(pat1);
        system.AddPatient(pat2);
        // 3. Schedule appointments
        Appointment app1 = new Appointment { AppointmentId = 1, Doctor = doc1, Patient = pat1, AppointmentDate = DateTime.Now.AddDays(1), Fee = doc1.ConsultationFee };
        Appointment app2 = new Appointment { AppointmentId = 2, Doctor = doc2, Patient = pat2, AppointmentDate = DateTime.Now.AddDays(2), Fee = doc2.ConsultationFee };
        system.ScheduleAppointment(app1);
        system.ScheduleAppointment(app2);
        // 4. Add medical records
        MedicalRecord rec1 = new MedicalRecord { RecordId = 1, Patient = pat1, Diagnosis = "Flu", Treatment = "Rest and hydration", BillAmount = 100 };
        MedicalRecord rec2 = new MedicalRecord { RecordId = 2, Patient = pat2, Diagnosis = "Diabetes", Treatment = "Medication and diet", BillAmount = 500 };
        system.AddMedicalRecord(rec1);
        system.AddMedicalRecord(rec2);
        // 5. Trigger exception
        try
        {
            Appointment app3 = new Appointment { AppointmentId = 3, Doctor = doc1, Patient = pat2, AppointmentDate = app1.AppointmentDate, Fee = doc1.ConsultationFee };
            system.ScheduleAppointment(app3);
        }
        catch (DoctorNotAvailableException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        // 6. Run LINQ reports
        system.GetBusyDoctors();
        system.GetRecentPatients();
        system.GetTopEarningDoctors();
        system.GroupAppointmentsByDoctor();
        system.GetPatientsByDisease("Flu");
        system.GetTotalRevenue();
    }
}
