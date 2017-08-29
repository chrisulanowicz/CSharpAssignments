using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var foundArtists = from artist in Artists
                                where artist.Hometown == "Mount Vernon"
                                select new { artist.ArtistName, artist.Age};

            foreach(var artist in foundArtists)
            {
                Console.WriteLine("{0} is {1} years old from Mount Vernon", artist.ArtistName, artist.Age);
            }
            // another way to do it is
            // Artist FromMtVernon = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();


            //Who is the youngest artist in our collection of artists?
            Artist Youngest = Artists.OrderBy(artist => artist.Age).First();
            Console.WriteLine($"The youngest artist is {Youngest.ArtistName} at {Youngest.Age} years old");
            
            
            //Display all artists with 'William' somewhere in their real name
            var williamArtists = from artist in Artists
                                    where artist.RealName.Contains("William")
                                    select new { artist.ArtistName, artist.RealName};
            foreach(var artist in williamArtists)
            {
                Console.WriteLine($"{artist.ArtistName} is actually {artist.RealName}");
            }
            // another way to do it is
            // List<Artist> Williams = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            


            //Display the names of all groups less than 8 characters in length
            List<Group> LessThan8 = Groups.Where(group => group.GroupName.Length < 8).ToList();
            Console.WriteLine("Groups with less than 8 characters in their name include: ");
            foreach(Group group in LessThan8)
            {
                Console.WriteLine(group.GroupName);
            }

            //Display the names of artists in the group D-12
            // List<Artist> MembersOfD12 = Ar
            // Group D12 = Groups.Where(group => group.GroupName == "D-12").Single();
            List<Artist> D12 = Artists.Where(artist => artist.GroupId == 6).ToList();
            Console.WriteLine("Members of D-12 are: ");
            foreach(Artist artist in D12)
            {
                Console.WriteLine($"{artist.ArtistName} aka {artist.RealName}");
            }



            //Display the 3 oldest artist from Atlanta
            List<Artist> Oldest = Artists.Where(artist => artist.Hometown == "Atlanta")
                                    .OrderByDescending(artist => artist.Age)
                                    .Take(3)
                                    .ToList();
            Console.WriteLine("The oldest artists from Atlanta are: ");
            foreach(Artist artist in Oldest)
            {
                Console.WriteLine($"{artist.ArtistName} is {artist.Age} years old from {artist.Hometown}");
            }


            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<string> NoNewYorkers = Artists
                                        .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist; })
                                        .Where(artist => artist.Hometown != "New York City" && artist.Group != null)
                                        .Select(artist => artist.Group.GroupName)
                                        .Distinct()
                                        .ToList();
            Console.WriteLine("Groups with at least one member not from New York: ");
            foreach(var group in NoNewYorkers)
            {
                Console.WriteLine(group);
            }


            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            Group WuTang = Groups.Where(group => group.GroupName == "Wu-Tang Clan")
                            .GroupJoin(Artists, group => group.Id, artist => artist.GroupId, (group, artists) => { group.Members = artists.ToList(); return group;})
                            .Single();
            Console.WriteLine("Wu-Tang Clan Members are: ");
            foreach(Artist artist in WuTang.Members)
            {
                Console.WriteLine(artist.ArtistName);
            }
        
        
        }
    }
}
