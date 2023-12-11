using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using webAPI.Contexts;
using webAPI.Models;

namespace webAPI.Repositories
{
    public class MysqlRepo : IRepo
    {
        private readonly TeamsContext _context;

        public MysqlRepo(TeamsContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Teams.Include(t => t.Players);
        }

        public Team GetTeamById(int id)
        {
            return _context.Teams.FirstOrDefault<Team>(t => t.TeamId == id);
        }
        public void AddTeam(Team t) {
            _context.Teams.Add(t);
        }
 

         public void SaveChanges() {
            _context.SaveChanges();
         }

        public void UpdateTeam(Team t)
        {
            _context.Teams.Update(t);
        }

        public void DeleteTodo(Team t)
        {
            _context.Teams.Remove(t);
        }
    }
}