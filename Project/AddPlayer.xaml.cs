using Microsoft.Maui.ApplicationModel.Communication;
using Project.Services;

namespace Project;

public partial class AddPlayer : ContentPage
{
    Team NewTeam;
    public IDataStore DataStore => DependencyService.Get<IDataStore>();
    public AddPlayer(Team team)
	{
		InitializeComponent();
		addplayer.Text = team.TeamName;
        NewTeam = team;
        

	}
	public void OnSubmitClicked(object sender, EventArgs e)
	{
        string name = Name.Text;
        string position = Position.Text;

        if (int.TryParse(TotalPoints.Text, out int totalpoints) && int.TryParse(GamesPlayed.Text, out int played))
        {
            if(name != null && position != null)
            {
                DisplayAlert("Form Submitted", $"Name: {name}\nPosition: {position}\nTotalPoints: {totalpoints}\nplayed: {played}", "OK");
                Console.WriteLine(NewTeam.TeamId);
                NewTeam.Players.Add(new Player { Name = name, Position = position, GamesPlayed = played, TotalPoints = totalpoints, TeamId = NewTeam.TeamId });
                DataStore.UpdateTeamAsync(NewTeam);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Invalid or empty Form.","OK");
            }
            
        }
        else
        {
            DisplayAlert("Error", "Please enter valid integer values.", "OK");
        }
    }

}