using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiToProject.Models
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ClientSector { get; set; }
        public string Technologies { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ProfileProject ProfileProject { get; set; }

        public IList<Profile> Profiles { get; set; }
        public IList<ProfileTechnology> Technology { get; set; }
    }
}
