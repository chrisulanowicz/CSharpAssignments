using System.Collections.Generic;

namespace JsonData
{

    public class Group
    {
        public int Id;
        public string GroupName;
        public List<Artist> Members;
        public Group()
        {
            Members = new List<Artist>();
        }
        
    }

}