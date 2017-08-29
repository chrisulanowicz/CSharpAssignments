using System;
using DbConnection;

namespace simpleCrudWithMySQL
{
    class Program
    {

        public static void Read()
        {
            // query when expecting data back 
            // returns a List of Dictionaries
            var Users = DbConnector.Query("SELECT * FROM users");
            foreach(var user in Users)
            {
                foreach(var entry in user)
                {
                    Console.WriteLine(entry.Key + " " + entry.Value);
                }
            }
        }

        public static void Create(string firstName, string lastName, string favedNumber)
        {
            int faveNumber = 0;
            int.TryParse(favedNumber, out faveNumber);
            string query = $"INSERT INTO `Users`(`FirstName`,`LastName`, `FavoriteNumber`) VALUES ('{firstName}', '{lastName}', {faveNumber})";
            // query when no data is coming back
            Console.WriteLine(query);
            DbConnector.Execute(query);
        }

        public static void Update(int ID, int number)
        {
            string query = $"UPDATE `Users` SET `FavoriteNumber`={number} WHERE id={ID}";
            DbConnector.Execute(query);
        }

        public static void Delete(int ID)
        {
            string query = $"DELETE FROM `Users` WHERE id={ID}";
            DbConnector.Execute(query);
        }
        static void Main(string[] args)
        {
            Read();
            Console.WriteLine("Add a first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Add a last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Add a favorite number: ");
            string faveNumber = Console.ReadLine();
            Create(firstName,lastName,faveNumber);
            Read();
            Delete(6); // id has to be known and hardcoded here
            Read();
            Update(3, 33); // hardcoded for now
            Read();
        }
    }
}
