namespace Workshop.Models
{
    public class Invitation
    {
        public Invitation()
        {
            this.IsActive = true;
        }

        public int Id { get; set; }

        public int InvitedUserId { get; set; }
        public User InvitedUSer { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public bool IsActive { get; set; }
    }
}
