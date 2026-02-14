using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class StudentUtility
    {
        public static SortedDictionary<double, List<Student>> StudentsData = new SortedDictionary<double, List<Student>>();

        public void AddStudent( Student student)
        {
            // TODO: Validate entity
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            if(student.GPA<0 || student.GPA>10) throw new InvalidGPAException("Gpa should be between 0 and 10");
            if (StudentsData.ContainsKey(student.GPA))
            {
                var check = StudentsData[student.GPA].Any(i=>i.Id==student.Id);
                if(!check) throw new DuplicateStudentException("Student already exist");
                StudentsData[student.GPA].Add(student);
            }
            else
            {
                StudentsData[student.GPA]=new List<Student>(){student};
            }
        }

        public void UpdateGPA(string id,double Gpa)
        {
            // TODO: Update entity logic
            if(Gpa<0 || Gpa>10) throw new InvalidGPAException("Gpa must be between 0 and 10");
            var check = StudentsData.SelectMany(i=>i.Value).FirstOrDefault(g=>g.Id==id);
            if (check == null)
            {
                throw new StudentNotFoundException("Student not found");
            }
            StudentsData[check.GPA].Remove(check);
            if (!StudentsData.ContainsKey(Gpa))
            {
                StudentsData[Gpa] = new List<Student>();
            }
            StudentsData[Gpa].Add(new Student() { Id = check.Id, Name = check.Name, GPA = Gpa });


        }

        public void GetAll()
        {
            // TODO: Return sorted entities
            foreach(var student in StudentsData)
            {
                foreach(var i in student.Value)
                {
                    Console.WriteLine($"{i.Id} {i.Name} {i.GPA}");
                }
            }
        }
    }
}
