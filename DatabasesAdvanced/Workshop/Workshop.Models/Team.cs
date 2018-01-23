using System.Collections.Generic;

namespace Workshop.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

        public ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

        public ICollection<EventTeam> EventTeams { get; set; } = new List<EventTeam>();
    }
}
