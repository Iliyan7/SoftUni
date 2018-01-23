using System.Collections.Generic;
using Workshop.Models.Enums;

namespace Workshop.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Event> CreatedEvents { get; set; } = new List<Event>();

        public ICollection<Team> CreatedTeams { get; set; } = new List<Team>();

        public ICollection<Invitation> ReceivedInvitations { get; set; } = new List<Invitation>();

        public ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();
    }
}
