using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Project.Services
{
    class MysqlDataStore : IDataStore
    {
        public List<Team> TeamList {get; set;}

        public async Task<Team> GetTeamAsync(Team team)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync("http://10.0.2.2:5000/api/teams/" + team.TeamId);
            Console.WriteLine("HTTPCLient repsonse: " + response);
            return JsonConvert.DeserializeObject<Team>(response);
        }
        public async void AddTeamAsync(Team t)
        {
            HttpClient client = new HttpClient();
            string jsonTeam = JsonConvert.SerializeObject(t);

            StringContent content = new StringContent(jsonTeam, Encoding.UTF8, "application/json");

            Console.WriteLine(t);
            string apiUrl = "http://10.0.2.2:5000/api/teams/";
            Console.WriteLine(apiUrl);

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response content: {responseContent}");
        }

        public async void DeleteTeamAsync(Team t)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync("http://10.0.2.2:5000/api/teams/" + t.TeamId);
            Console.WriteLine("HTTPCLient repsonse: " + response);
        }


        public async Task<List<Team>> GetAllTeamsAsync()
        {
            HttpClient client = new HttpClient();
            /*string response = await client.GetStringAsync("http://localhost:5000/api/teams");*/
            string response = await client.GetStringAsync("http://10.0.2.2:5000/api/teams");
            Console.WriteLine("HTTPCLient repsonse: " + response);
            return JsonConvert.DeserializeObject<List<Team>>(response);  
        }
        public async void UpdateTeamAsync(Team team) {
            try
            {
                HttpClient client = new HttpClient();
                string jsonTeam = JsonConvert.SerializeObject(team);

                StringContent content = new StringContent(jsonTeam, Encoding.UTF8, "application/json");

                Console.WriteLine(team);
                string apiUrl = "http://10.0.2.2:5000/api/teams/" + team.TeamId;
                Console.WriteLine(apiUrl);

                HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Team updated successfully!");
                }
                else
                {
                    // Handle failure
                    Console.WriteLine($"Failed to update team. Status code: {response.StatusCode}");

                    // Log the response content for further analysis
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response content: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }
    }
}
