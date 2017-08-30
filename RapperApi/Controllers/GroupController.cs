using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace RapperApi.Controllers
{

    public class GroupController : Controller
    {

        List<Group> allGroups { get; set; }
        List<Artist> allArtists { get; set; }
    
        public GroupController() 
        {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        // Create a route for /groups that returns all groups as JSON
        [HttpGet]
        [Route("groups")]
        public JsonResult Groups()
        {
            return Json(allGroups);
        }

        // Create a route for /groups/name/{name} that returns all groups that match the provided name
        [HttpGet]
        [Route("groups/name/{name}")]
        public JsonResult MatchGroupName(string name)
        {
            var groups = allGroups.Where(group => group.GroupName.Contains(name));
            return Json(groups);
        }

        // Create a route for /groups/id/{id} that returns all groups with the provided value
        [HttpGet]
        [Route("groups/id/{id}")]
        public JsonResult MatchGroupId(string id)
        {
            int groupId;
            int.TryParse(id, out groupId);
            var groups = allGroups.Where(group => group.Id == groupId);
            return Json(groups);
        }

        // Add an extra boolean parameter to group routes that will include members for all JSON responses
        [HttpGet]
        [Route("groups/name/{name}/{members}")]
        public JsonResult MatchGroupName(string name, string members)
        {
            bool getMembers;
            Boolean.TryParse(members, out getMembers);
            var groups = allGroups.Where(group => group.GroupName.Contains(name));
            if(getMembers == true)
            {
                groups = groups.GroupJoin(allArtists, group => group.Id, artist => artist.GroupId, (group, artists) => {group.Members = artists.ToList(); return group;});
            }

            return Json(groups);
        }
        
        
        [HttpGet]
        [Route("groups/id/{id}/{members}")]
        public JsonResult MatchGroupId(string id, string members)
        {
            int IdOfGroup;
            int.TryParse(id, out IdOfGroup);
            bool getMembers;
            Boolean.TryParse(members, out getMembers);
            var groups = allGroups.Where(group => group.Id == IdOfGroup);
            if(getMembers == true)
            {
                groups = groups.GroupJoin(allArtists, group => group.Id, artist => artist.GroupId, (group, artists) => {group.Members = artists.ToList(); return group;});
            }
            return Json(groups);
        }


    }

}