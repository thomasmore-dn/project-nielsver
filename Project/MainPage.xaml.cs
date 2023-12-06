namespace Project
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        public void CounterBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Standings());
        }

    }

}
