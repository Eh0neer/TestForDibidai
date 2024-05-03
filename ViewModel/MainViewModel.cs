using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using TestForDibiai.Model;
using TestForDibiai.Services;

namespace TestForDibiai.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DataService dataService;

        public ObservableCollection<Abonent> Abonents { get; set; }
        public ICollectionView AbonentsView { get; set; }

        private string searchQuery;

        public string SearchQuery
        {
            get { return searchQuery; }
            set
            {
                searchQuery = value;
                AbonentsView.Refresh(); // Обновляем представление при изменении запроса поиска
                OnPropertyChanged(nameof(SearchQuery));
            }
        }

        public MainViewModel()
        {
            dataService = new DataService("Host=localhost;Port=5432;Database=mydatabase;Username=myuser;Password=mypassword;");
            LoadAbonents();
        }

        private void LoadAbonents()
        {
            var abonents = dataService.ExecuteQuery<Abonent>("SELECT * FROM Abonent");
            Abonents = new ObservableCollection<Abonent>(abonents);
            AbonentsView = CollectionViewSource.GetDefaultView(Abonents);

            // Применяем фильтр поиска
            AbonentsView.Filter = AbonentFilter;
        }

        private bool AbonentFilter(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
                return true;

            var abonent = obj as Abonent;
            if (abonent != null)
            {
                // Фильтруем по ФИО абонента
                return abonent.LName.ToLower().Contains(SearchQuery.ToLower());
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
