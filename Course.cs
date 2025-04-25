// ✅ Student.cs
public class Student
{
    public string StudentId { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Student ID: {StudentId}, Name: {Name}";
    }
}

// ✅ Course.cs
using System.Collections.Generic;

public class Course
{
    public string CourseId { get; set; }
    public string CourseName { get; set; }
    public string Lecturer { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

    public override string ToString()
    {
        return $"Course ID: {CourseId}, Course Name: {CourseName}, Lecturer: {Lecturer}";
    }
}

// ✅ Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static List<Course> courses = new List<Course>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n📚 Course Manager\n");
            Console.WriteLine("1. Add course");
            Console.WriteLine("2. Register student to course");
            Console.WriteLine("3. View all courses");
            Console.WriteLine("4. Search course by ID or name");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddCourse(); break;
                case "2": RegisterStudent(); break;
                case "3": ViewCourses(); break;
                case "4": SearchCourse(); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void AddCourse()
    {
        Console.Write("Enter course ID: ");
        string id = Console.ReadLine();
        Console.Write("Enter course name: ");
        string name = Console.ReadLine();
        Console.Write("Enter lecturer name: ");
        string lecturer = Console.ReadLine();

        courses.Add(new Course { CourseId = id, CourseName = name, Lecturer = lecturer });
        Console.WriteLine("✅ Course added.");
    }

    static void RegisterStudent()
    {
        Console.Write("Enter course ID: ");
        string courseId = Console.ReadLine();
        Course course = courses.Find(c => c.CourseId == courseId);
        if (course == null)
        {
            Console.WriteLine("❌ Course not found.");
            return;
        }

        Console.Write("Enter student ID: ");
        string studentId = Console.ReadLine();
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        course.Students.Add(new Student { StudentId = studentId, Name = name });
        Console.WriteLine("✅ Student registered to course.");
    }

    static void ViewCourses()
    {
        foreach (var course in courses)
        {
            Console.WriteLine("\n" + course);
            foreach (var student in course.Students)
            {
                Console.WriteLine("  - " + student);
            }
        }
    }

    static void SearchCourse()
    {
        Console.Write("Enter course ID or name: ");
        string input = Console.ReadLine().ToLower();
        var results = courses.FindAll(c => c.CourseId.ToLower().Contains(input) || c.CourseName.ToLower().Contains(input));

        if (results.Count == 0)
        {
            Console.WriteLine("❌ No courses found.");
            return;
        }

        foreach (var course in results)
        {
            Console.WriteLine("\n" + course);
            foreach (var student in course.Students)
            {
                Console.WriteLine("  - " + student);
            }
        }
    }
}
