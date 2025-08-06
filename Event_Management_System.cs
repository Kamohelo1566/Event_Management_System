using System;
using System.Collections.Generic;  //list package


public class Program
    {
        public static void Main()
        {
            EventManager eventManager = new EventManager();
            eventManager.Run();
        }
    }

    // Base class 
    public abstract class Event
    {
        public string EventName { get; set; }
        public int EventID { get; set; }
        public int Capacity { get; set; }

        //constructor
        public Event(string eventName, int eventID, int capacity)
        {

            // Handle exceptions(throw exception when the is empty)
            if (string.IsNullOrWhiteSpace(eventName))
            {
                throw new ArgumentException("Event name cannot be empty.");
            }

            // Handle exceptions(throw exception when the capacity is not a negative number)
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be a positive integer.");
            }

            this.EventName = eventName;
            this.EventID = eventID;
            this.Capacity = capacity;
        }

        //method to be overrided
        public virtual void DisplayEvent()
        {
            Console.WriteLine($"Event Name: {EventName}");
            Console.WriteLine($"Event ID: {EventID}");
            Console.WriteLine($"Capacity: {Capacity}");
        }
    }

    // Derived class for Workshops
    public class Workshop : Event
    {
        public string Topic { get; set; }
        public string Company { get; set; }

        //constructor
        public Workshop(string eventName, int eventID, int capacity, string topic, string company) : base(eventName, eventID, capacity)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentException("Topic cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(company))
            {
                throw new ArgumentException("Company cannot be empty.");
            }

            this.Topic = topic;
            this.Company = company;
        }

        // method displayevent override 
        public override void DisplayEvent()
        {
            base.DisplayEvent();
            Console.WriteLine($"Topic: {Topic}");
            Console.WriteLine($"Company: {Company}");
        }
    }

    // Derived class for Seminars
    public class Seminar : Event
    {
        public string Speaker { get; set; }

        //constructor
        public Seminar(string eventName, int eventID, int capacity, string speaker) : base(eventName, eventID, capacity)
        {
            if (string.IsNullOrWhiteSpace(speaker))
            {
                throw new ArgumentException("Speaker cannot be empty.");
            }

            this.Speaker = speaker;
        }

        public override void DisplayEvent()
        {
            base.DisplayEvent();
            Console.WriteLine($"Speaker: {Speaker}");
        }
    }

    public class EventManager
    {
        //creating a list
        public List<Event> events;

        public EventManager()
        {
            events = new List<Event>();
        }


        //method to run the menu of choices
        public void Run()
        {
            while (true)
            {
                try
                {
                    //menu options
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Add a Workshop");
                    Console.WriteLine("2. Add a Seminar");
                    Console.WriteLine("3. View all events");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddWorkshop();
                            break;

                        case 2:
                            AddSeminar();
                            break;

                        case 3:
                            ViewAllEvents();
                            break;

                        case 4:
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        //method to add the workshop
        public void AddWorkshop()
        {
            //taking user input
            Console.Write("Enter workshop name: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter workshop ID: ");
            int eventID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter workshop capacity: ");
            int capacity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter workshop topic: ");
            string topic = Console.ReadLine();

            Console.Write("Enter workshop company: ");
            string company = Console.ReadLine();

            Workshop workshop = new Workshop(eventName, eventID, capacity, topic, company);
            events.Add(workshop);
            Console.WriteLine("Workshop added successfully!");
        }

        //method to add a seminar
        public void AddSeminar()
        {
            //taking user input
            Console.Write("Enter seminar name: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter seminar ID: ");
            int eventID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter seminar capacity: ");
            int capacity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter seminar speaker: ");
            string speaker = Console.ReadLine();

            Seminar seminar = new Seminar(eventName, eventID, capacity, speaker);
            events.Add(seminar);
            Console.WriteLine("Seminar added successfully!");
        }

        //method to view all events
        public void ViewAllEvents()
        {
            if (events.Count == 0)
            {
                Console.WriteLine("No events to display.");
            }
            else
            {
                // foreach loop to print all the elements in the list
                foreach (Event e in events)
                {
                    e.DisplayEvent();
                    Console.WriteLine();
                }
            }
        }
    }
