namespace CinemaClient;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new AllScreenings();
    }


    protected override void OnAppearing()
    {
        ((AllScreenings)BindingContext).LoadScreenings();
    }

    async void OnScreeningClicked(object sender, EventArgs args)
    {

        var button = sender as Button;
        var bindingContext = (ScreeningInfo) button.BindingContext;

        if (bindingContext != null)
        {
            var id = bindingContext.Id;
            Application.Current.MainPage.Navigation.PushModalAsync(new MovieInfoPage(id), true);
        }

    }

      

}

