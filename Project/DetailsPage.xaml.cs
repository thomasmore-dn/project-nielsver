using Project.Services;

namespace Project;

public partial class DetailsPage : ContentPage
{
	Team teamg;
    public IDataStore DataStore => DependencyService.Get<IDataStore>();
    public DetailsPage(Team team)
	{
		InitializeComponent();
        teamg = team;
		teamname.Text = team.TeamName;
		playersListView.ItemsSource = team.Players;
	}
	public void AddPlayerButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new AddPlayer(teamg));
	}
    public void OnDeleteTeam(object sender, EventArgs e)
    {
        DataStore.DeleteTeamAsync(teamg);
		Navigation.PopAsync();
    }

}