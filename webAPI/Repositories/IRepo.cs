using webAPI.Models;

namespace webAPI.Repositories
{
    public interface IRepo
    {
         IEnumerable<Team> GetAllTeams();

         Team GetTeamById(int id);

         void AddTeam(Team t);

        void SaveChanges();

        void UpdateTeam(Team t);

        void DeleteTodo(Team t);
    }
}