 using System;
using System.Collections.Generic;

class Program
{
    static Queue<Appointment> queue = new Queue<Appointment>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("📋 Welcome to Smart Queue System");
            Console.WriteLine("1. Add Appointment");
            Console.WriteLine("2. Process Appointment");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAppointment();
                    break;
                case "2":
                    ProcessAppointment();
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("❌ Invalid choice. Please try again.");
                    Pause();
                    break;
            }
        }
    }

    static void AddAppointment()
    {
        Console.Clear();
        Console.WriteLine("➕ Add Appointment");
        Console.Write("Name: ");
        string name = Console.ReadLine();

        int age;
        while (true)
        {
            Console.Write("Age: ");
            if (int.TryParse(Console.ReadLine(), out age)) break;
            Console.WriteLine("❌ Invalid age. Please enter a number.");
        }

        Console.Write("Symptoms: ");
        string symptoms = Console.ReadLine();

        var appointment = new Appointment
        {
            Name = name,
            Age = age,
            Symptoms = symptoms
        };

        queue.Enqueue(appointment);
        Console.WriteLine("✔ Appointment added successfully.");
        Pause();
    }

    static void ProcessAppointment()
    {
        Console.Clear();
        if (queue.Count == 0)
        {
            Console.WriteLine("ℹ️ No appointments in the queue.");
        }
        else
        {
            Appointment appointment = queue.Dequeue();
            Console.WriteLine("✅ Processing appointment:");
            Console.WriteLine($"Name: {appointment.Name}");
            Console.WriteLine($"Age: {appointment.Age}");
            Console.WriteLine($"Symptoms: {appointment.Symptoms}");
        }
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}

class Appointment
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Symptoms { get; set; }
}
