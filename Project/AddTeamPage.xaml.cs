using Project.Services;

namespace Project;

public partial class AddTeamPage : ContentPage
{
    public IDataStore DataStore => DependencyService.Get<IDataStore>();
    public AddTeamPage()
	{
		InitializeComponent();
	}
	public void OnSubmitClicked(object sender, EventArgs e)
	{
        string name = Name.Text;


        if (int.TryParse(Wins.Text, out int Win) && int.TryParse(Losses.Text, out int loss))
        {
            if (name != null && Win != null && loss != null)
            {
                DisplayAlert("Form Submitted", $"Name: {name}\nWins: {Win}\nLosses: {loss}", "OK");

                Team newTeam = new Team
                {
                    TeamName = name,
                    Wins = Win,
                    Loses = loss,
                };
                DataStore.AddTeamAsync(newTeam);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Invalid or empty Form.", "OK");
            }

        }
        else
        {
            DisplayAlert("Error", "Please enter valid integer values.", "OK");
        }
    }
}