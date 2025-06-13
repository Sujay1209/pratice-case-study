using System;
using System.Collections.Generic;
using DAL.DataAccess;
using DAL.Models;
using DAL.Models.DAL.Models;

namespace AppUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEventDetailsRepo eventRepo = new EventDetailsRepo();
            EventDetailsBL eventBL = new EventDetailsBL(eventRepo);

            while (true)
            {
                Console.WriteLine("\n==== Event Management System ====");
                Console.WriteLine("1. Add Event");
                Console.WriteLine("2. Update Event");
                Console.WriteLine("3. Delete Event");
                Console.WriteLine("4. View All Events");
                Console.WriteLine("5. View Event by ID");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEvent(eventBL);
                        break;
                    case "2":
                        UpdateEvent(eventBL);
                        break;
                    case "3":
                        DeleteEvent(eventBL);
                        break;
                    case "4":
                        ViewAllEvents(eventBL);
                        break;
                    case "5":
                        ViewEventById(eventBL);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddEvent(EventDetailsBL bl)
        {
            var newEvent = new EventDetails();
            Console.Write("Event Name: ");
            newEvent.EventName = Console.ReadLine();
            Console.Write("Event Category: ");
            newEvent.EventCategory = Console.ReadLine();
            Console.Write("Event Date (yyyy-mm-dd): ");
            newEvent.EventDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Description: ");
            newEvent.Description = Console.ReadLine();
            Console.Write("Status (Active/In-Active): ");
            newEvent.Status = Console.ReadLine();

            var added = bl.AddEvent(newEvent);
            Console.WriteLine(added != null ? "✅ Event added." : "❌ Failed to add event.");
        }

        static void UpdateEvent(EventDetailsBL bl)
        {
            Console.Write("Enter Event ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var existing = bl.GetEventById(id);

            if (existing != null)
            {
                Console.Write("New Name: ");
                existing.EventName = Console.ReadLine();
                Console.Write("New Category: ");
                existing.EventCategory = Console.ReadLine();
                Console.Write("New Date (yyyy-mm-dd): ");
                existing.EventDate = DateTime.Parse(Console.ReadLine());
                Console.Write("New Description: ");
                existing.Description = Console.ReadLine();
                Console.Write("New Status: ");
                existing.Status = Console.ReadLine();

                var updated = bl.UpdateEvent(existing);
                Console.WriteLine(updated != null ? "✅ Event updated." : "❌ Update failed.");
            }
            else
            {
                Console.WriteLine("❌ Event not found.");
            }
        }

        static void DeleteEvent(EventDetailsBL bl)
        {
            Console.Write("Enter Event ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            var deleted = bl.DeleteEvent(id);
            Console.WriteLine(deleted != null ? "✅ Event deleted." : "❌ Event not found.");
        }

        static void ViewAllEvents(EventDetailsBL bl)
        {
            var events = bl.GetAllEvents();
            if (events.Count > 0)
            {
                Console.WriteLine("\n=== All Events ===");
                foreach (var evt in events)
                {
                    Console.WriteLine($"{evt.EventId} | {evt.EventName} | {evt.EventDate:yyyy-MM-dd} | {evt.Status}");
                }
            }
            else
            {
                Console.WriteLine("No events found.");
            }
        }

        static void ViewEventById(EventDetailsBL bl)
        {
            Console.Write("Enter Event ID: ");
            int id = int.Parse(Console.ReadLine());
            var evt = bl.GetEventById(id);

            if (evt != null)
            {
                Console.WriteLine($"\nID: {evt.EventId}");
                Console.WriteLine($"Name: {evt.EventName}");
                Console.WriteLine($"Category: {evt.EventCategory}");
                Console.WriteLine($"Date: {evt.EventDate:yyyy-MM-dd}");
                Console.WriteLine($"Status: {evt.Status}");
                Console.WriteLine($"Description: {evt.Description}");
            }
            else
            {
                Console.WriteLine("❌ Event not found.");
            }
        }
    }
}
