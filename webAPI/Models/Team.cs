namespace webAPI.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }
        
        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Points
        {
            get { return Wins * 3 + Losses; }

        }
        public int Games
        {
            get { return Wins + Losses; }

        }
        public List<Player> Players { get; set; } = new List<Player>();
    }
    public class Player
    {
        public int PlayerId {get; set;}
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int TotalPoints { get; set; }
        public int GamesPlayed { get; set; }
        public string Position { get; set; }
    }
}