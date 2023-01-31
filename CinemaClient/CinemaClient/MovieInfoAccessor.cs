using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaClient
{
    internal class MovieInfoAccessor
    {

       public ObservableCollection<MovieInfo> MovieInfos { get; set; } = new ObservableCollection<MovieInfo>();

        public MovieInfoAccessor()
        {

        }

        public async void LoadMovieInfo(int id)
        {
            MovieInfos.Clear();

            var service = new RestService();
            var result = await service.RefreshMovieInfoAsync(id);

            MovieInfos.Add(result);
        }
    }
}
