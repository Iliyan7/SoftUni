using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data;
using System;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new HospitalContext())
            {
                try
                {
                    db.Database.Migrate();

                    Console.WriteLine("Database successfully created!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
