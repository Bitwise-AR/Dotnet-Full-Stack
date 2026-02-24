using System;
using System.Collections.Generic;
using System.Text;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }

    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
    }
}

public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    public void RegisterPatient(int id, string name, int age, string condition)
    {
        var patient = new Patient(id, name, age, condition);
        _patients[id] = patient;
    }

    public void ScheduleAppointment(int patientId)
    {
        if (_patients.TryGetValue(patientId, out var patient))
        {
            _appointmentQueue.Enqueue(patient);
        }
    }

    public Patient ProcessNextAppointment()
    {
        var patient = _appointmentQueue.Peek();
        _appointmentQueue.Dequeue();
        return patient;
    }

    public List<Patient> FindPatientsByCondition(string condition)
    {
        var patients = new List<Patient>();
        foreach (var patient in _patients.Values)
        {
            if (patient.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase))
            {
                patients.Add(patient);
            }
        }
        return patients;
    }
}

