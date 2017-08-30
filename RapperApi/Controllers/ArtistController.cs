using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace RapperApi.Controllers
{

    public class ArtistController : Controller
    {

        private List<Artist> allArtists;

        public ArtistController()
        {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        // This method is shown to the user navigating to the default API domain name
        // It just displays some basic information about how this API functions
        [HttpGet]
        [Route("")]
        public string Index()
        {
            // String describing the API functionality
            string instructions = "Welcome to the Rapper API~~\n==============================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        // Create a route for /artists that returns all artists as JSON
        [HttpGet]
        [Route("artists")]
        public JsonResult Artist()
        {
            return Json(allArtists);
        }

        // Create a route for /artists/name/{name} that returns all artists that match the provided name
        [HttpGet]
        [Route("artists/name/{name}")]
        public JsonResult MatchArtistName(string name)
        {
            var artists = allArtists.Where(artist => artist.ArtistName.Contains(name));
            return Json(artists);
        }

        // Create a route for /artists/realname/{name} that returns all artists whose real names match the provided name
        [HttpGet]
        [Route("artists/realname/{name}")]
        public JsonResult MatchArtistRealName(string name)
        {
            var artists = allArtists.Where(artist => artist.RealName.Contains(name));
            return Json(artists);
        }

        // Create a route for /artists/hometown/{town} that returns all artists who are from the provided town
        [HttpGet]
        [Route("artists/hometown/{town}")]
        public JsonResult MatchArtistTown(string town)
        {
            var artists = allArtists.Where(artist => artist.Hometown.Contains(town));
            return Json(artists);
        }

        // Create a route for /artists/groupid/{id} that returns all artists who have a GroupId that matches id
        [HttpGet]
        [Route("artists/groupid/{id}")]
        public JsonResult MatchArtistGroup(string id)
        {
            int groupId;
            int.TryParse(id, out groupId);
            var artists = allArtists.Where(artist => artist.GroupId == groupId);
            return Json(artists);
        }

    }

}