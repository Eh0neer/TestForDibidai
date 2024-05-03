using System.Collections.ObjectModel;
using System.Windows.Input;
using TestForDibiai.Model;
using TestForDibiai.Services;

namespace TestForDibiai.ViewModel
{
    public class SearchByNumberViewModel
    {
        private DataService dataService;

        public ObservableCollection<Abonent> MatchingAbonents { get; set; }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public ICommand SearchCommand { get; private set; }

        public SearchByNumberViewModel()
        {
            dataService = new DataService("Host=localhost;Port=5432;Database=mydatabase;Username=myuser;Password=mypassword;");
            MatchingAbonents = new ObservableCollection<Abonent>();

            SearchCommand = new RelayCommand(Search);
        }

        private void Search(object parameter)
        {
            // Выполнить поиск абонентов по номеру телефона
            MatchingAbonents.Clear();
            var abonents = dataService.ExecuteQuery<Abonent>("SELECT * FROM Abonent WHERE Id IN (SELECT AbonentId FROM PhoneNumber WHERE Number = @PhoneNumber)", new { PhoneNumber });

            foreach (var abonent in abonents)
            {
                MatchingAbonents.Add(abonent);
            }
        }
    }
}
