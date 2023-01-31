namespace CinemaClient;

public partial class MovieInfoPage : ContentPage
{
	public int Id { get; set; }

	public MovieInfo MovieInfo { get; set; }
	public MovieInfoPage(int id)
	{
		Id = id;
		InitializeComponent();
		BindingContext = new MovieInfoAccessor();
	}

    protected override async void OnAppearing()
    {
        ((MovieInfoAccessor)BindingContext).LoadMovieInfo(Id);
    }


    async void GoBack(object sender, EventArgs args)
    {

        Application.Current.MainPage.Navigation.PopModalAsync();

    }

}