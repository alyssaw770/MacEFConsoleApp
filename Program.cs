using System;
using System.Runtime.Intrinsics.Arm;
using DemoConsole.Entities;

namespace MacEFConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ActorDbContext())
            {
                //Seed
                db.Actors.AddRange(new Actor { Name = "Brue Lee", Age = 77, AcademyWinner = false },
                new Actor { Name = "Alec Baldwin", Age = 55, AcademyWinner = false });

                var count = db.SaveChanges();

                //Fetch and Write out data
                Console.WriteLine("{0} additional record saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All Actors now in database:");
                foreach (var Actor in db.Actors)
                {
                    System.Console.WriteLine($"Name - {Actor.Name},\t\t" + $"Age: {Actor.Age},\t\t" +
                    $"Academy Winner: {Actor.AcademyWinner}");

                }
                Console.ReadLine();
            }
        }
    }
}
