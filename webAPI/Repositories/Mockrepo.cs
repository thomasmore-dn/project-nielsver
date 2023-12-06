using webAPI.Models;

namespace webAPI.Repositories
{
    public class MockRepo : IRepo
    {
        List<Team> Teamslist = new List<Team>();

        public MockRepo()
        {
            Teamslist.Add(new Team() { TeamId = 0, TeamName = "Team A", Wins = 5, Losses = 3});
            Teamslist.Add(new Team() { TeamId = 1,TeamName = "Team B", Wins = 7, Losses = 1 });
            Teamslist.Add(new Team() { TeamId = 2, TeamName = "Team C", Wins = 3, Losses = 5});
            Teamslist.Add(new Team() { TeamId = 3, TeamName = "Team D", Wins = 8, Losses = 0});
        }

        public IEnumerable<Team> GetAllTeams() {
            return Teamslist;
        }

        public Team GetTeamById(int id) {
            Team _team = Teamslist.FirstOrDefault<Team>(t => t.TeamId == id);
            return _team;
        }
        public void AddTeam(Team t){
            Teamslist.Add(t);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(Team t)
        {
            throw new NotImplementedException();
        }

        public void DeleteTodo(Team t)
        {
            throw new NotImplementedException();
        }
    }
}