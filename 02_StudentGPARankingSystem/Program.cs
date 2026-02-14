using System;
using Services;
using Domain;
using Exceptions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentUtility studentUtility = new StudentUtility();

            while (true)
            {
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        studentUtility.GetAll();
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Student Id:");
                            string id = Console.ReadLine();

                            Console.WriteLine("Enter Student Name:");
                            string name = Console.ReadLine();

                            Console.WriteLine("Enter Student GPA:");
                            double gpa = Convert.ToDouble(Console.ReadLine());

                            Student student = new Student()
                            {
                                Id = id,
                                Name = name,
                                GPA = gpa
                            };

                            studentUtility.AddStudent(student);
                            Console.WriteLine("Student added successfully.");
                        }
                        catch (InvalidGPAException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (DuplicateStudentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Enter Student Id:");
                            string key = Console.ReadLine();

                            Console.WriteLine("Enter Student UpdatedGPA:");
                            double GPA = Convert.ToDouble(Console.ReadLine());

                            studentUtility.UpdateGPA(key, GPA);
                            Console.WriteLine("GPA updated successfully.");
                        }
                        catch (InvalidGPAException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (StudentNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
