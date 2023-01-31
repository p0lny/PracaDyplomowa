using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaClient
{
    internal class AllScreenings
    {
        public ObservableCollection<ScreeningInfo> Screenings { get; set; } = new ObservableCollection<ScreeningInfo>();
        
        public AllScreenings()
        {

        }

        public async void LoadScreenings()
        {
            Screenings.Clear();

            var service = new RestService();
            var results = await service.RefreshScreeningsAsync();

            foreach(var result in results)
            {
                Screenings.Add(result);
            }

        }
    }
}
