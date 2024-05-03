using System.Collections.ObjectModel;
using TestForDibiai.Model;
using TestForDibiai.Services;


namespace TestForDibiai.ViewModel
{
    public class StreetsViewModel
    {
        private DataService dataService;

        public ObservableCollection<Street> Streets { get; set; }

        public StreetsViewModel()
        {
            dataService = new DataService("Host=localhost;Port=5432;Database=mydatabase;Username=myuser;Password=mypassword;");
            LoadStreets();
        }

        private void LoadStreets()
        {
            var streets = dataService.ExecuteQuery<Street>("SELECT * FROM Street");
            Streets = new ObservableCollection<Street>(streets);
        }
    }
}
