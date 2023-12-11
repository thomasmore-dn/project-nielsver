using Project.Services;
using System.Collections.ObjectModel;
namespace Project;

public partial class Standings : ContentPage
{
    public ObservableCollection<Team> TeamList { get; set; } 
    public IDataStore DataStore => DependencyService.Get<IDataStore>();

    public Standings()
    {
		InitializeComponent();
        TeamList = new ObservableCollection<Team>();
        standingsListView.ItemsSource = TeamList;

        FillTeams();        

    }
    public async void FillTeams()
    {
        try
        {
            var teamsTask = DataStore.GetAllTeamsAsync();
            var teams = await teamsTask;

            foreach (Team team in teams)
            {
                TeamList.Add(team);
            }
            Console.WriteLine("completion of getting teams ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetAllTeamsAsync: {ex.Message}");

            Team team1 = new Team { TeamName = "BC Oostende", Loses = 5, Wins = 5 };
            team1.Players.Add(new Player { Name = "Thibaut tsjienda baloji", TotalPoints = 100, GamesPlayed = 10, Position = "Center" });
            team1.Players.Add(new Player { Name = "Sam Van Rossom", TotalPoints = 80, GamesPlayed = 10, Position = "Guard" });

            Team team2 = new Team { TeamName = "Kangoeroes Mechelen", Loses = 2, Wins = 8 };
            team2.Players.Add(new Player { Name = "Andrej Cuyvers", TotalPoints = 90, GamesPlayed = 10, Position = "Forward" });

            Team team3 = new Team { TeamName = "Circus Brussel", Wins = 7, Loses = 3 };
            team3.Players.Add(new Player { Name = "Godwin thimanga", TotalPoints = 95, GamesPlayed = 10, Position = "Forward" });

            TeamList.Add(team1);
            TeamList.Add(team2);
            TeamList.Add(team3);
        }

        // Sorting and updating the view
        TeamList = new ObservableCollection<Team>(TeamList.OrderByDescending(x => x.TotalPoints));
        standingsListView.ItemsSource = TeamList;
    }


    private async void OnTeamTapped(object sender, ItemTappedEventArgs e)
    {
        if(e.Item is Team team)
        {
            await Navigation.PushAsync(new DetailsPage(team));
        }
        ((ListView)sender).SelectedItem = null;
    }

    private void Button_Clicked_Add_Team(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddTeamPage());
    }
}
