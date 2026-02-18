using System;
using System.Collections.Generic;
using System.Linq;

#region Custom Exception
class LateSubmissionException : Exception
{
    public LateSubmissionException(string message) : base(message) { }
}
#endregion

#region Entities
class Course : IComparable<Course>
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public Instructor Instructor { get; set; }
    public int MaxCapacity { get; set; }
    public double Rating { get; set; }

    public int CompareTo(Course other)
    {
        // TODO: custom sorting logic (e.g., by rating)
        return this.Rating.CompareTo(other.Rating);
        
    }   
}

class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
}

class Instructor
{
    public int InstructorId { get; set; }
    public string Name { get; set; }
}

class Enrollment
{
    public int EnrollmentId { get; set; }
    public Student Student { get; set; }
    public Course Course { get; set; }
    public DateTime EnrollmentDate { get; set; }
}

class Assignment
{
    public int AssignmentId { get; set; }
    public Course Course { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime SubmissionDate { get; set; }

    public void Submit()
    {
        // TODO: throw LateSubmissionException if late
        if (SubmissionDate > Deadline)
        {
            throw new LateSubmissionException("Assignment submitted after the deadline.");
        }
    }
}
#endregion

#region Generic Repository
class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        // TODO
        if(!items.Contains(item))
        {
            items.Add(item);
        }
    }

    public IEnumerable<T> GetAll()
    {
        // TODO
        return items.Select(i=>i);
    }
}
#endregion

#region Learning Platform System
class LearningPlatform
{
    public List<Course> courses = new List<Course>();
    public List<Student> students = new List<Student>();
    public List<Instructor> instructors = new List<Instructor>();
    public List<Enrollment> enrollments = new List<Enrollment>();

    public void EnrollStudent(Enrollment enrollment)
    {
        // TODO:
        // 1. Prevent duplicate enrollment
        // 2. Check course capacity
        if (enrollments.Any(e => e.Student.StudentId == enrollment.Student.StudentId && e.Course.CourseId == enrollment.Course.CourseId))
        {
            Console.WriteLine("Student is already enrolled in this course.");
            return;
        }
        if (enrollment.Course.MaxCapacity <= enrollments.Count(e => e.Course.CourseId == enrollment.Course.CourseId))
        {
            Console.WriteLine("Course has reached maximum capacity.");
            return;
        }
        enrollments.Add(enrollment);

        

    }

    public void SubmitAssignment(Assignment assignment)
    {
        // TODO:
        // Validate deadline
        try
        {
            assignment.Submit();
            Console.WriteLine("Assignment submitted successfully.");
        }
        catch (LateSubmissionException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    #region LINQ Methods

    public void GetLargeCourses()
    {
        // TODO: courses with more than 50 students
    }

    public void GetStudentsInMultipleCourses()
    {
        // TODO: students enrolled in more than 3 courses
    }

    public void GetMostPopularCourse()
    {
        // TODO
    }

    public void GetAverageCourseRating()
    {
        // TODO
    }

    public void GetTopInstructors()
    {
        // TODO: instructors with highest enrollments
    }

    #endregion
}
#endregion

class Program
{
    static void Main()
    {
        LearningPlatform platform = new LearningPlatform();

        // TODO:
        // 1. Add instructors
        // 2. Add courses
        // 3. Add students
        // 4. Enroll students
        // 5. Submit assignments
        // 6. Trigger late submission exception
        // 7. Run LINQ reports
    }
}
