using Cryptocurrency_Test_Task.Models;
using Cryptocurrency_Test_Task.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptocurrency_Test_Task
{
    public partial class SearchPage : Page
    {
        public string searchedText;
        private CurrencyViewModel viewModel;
        public string SearchedText
        {
            get { return searchedText; }
            set
            {
                searchedText = value;
                OnPropertyChanged("SearchedText");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public SearchPage()
        {
            viewModel = new CurrencyViewModel();
            InitializeComponent();
            SearchTextBox.DataContext = this;
        }
        void NavigateToMainPage(Object sender, EventArgs e)
        {
            GetNav().Navigate(new MainPage());
        }
        void NavigateToDetailsPage(Object sender, EventArgs e)
        {
            GetNav().Navigate(new CurrencyDetails(CurrencyViewModel.SelectedCurrency));
        }
        void NavigateToExchangePage(Object sender, EventArgs e)
        {
            GetNav().Navigate(new ExchangePage());
        }
        private NavigationService GetNav()
        {
            return NavigationService.GetNavigationService(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchAssetsAPIAsync();
        }
        public async Task SearchAssetsAPIAsync()
        {
            try
            {
                string responseBody = await HttpController.httpClient.GetStringAsync($"https://api.coincap.io/v2/assets/{SearchedText}");
                UpdateList(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        private void UpdateList(string responseBody)
        {
            viewModel.ClearCurrencies();
            var curr = JsonConvert.DeserializeObject<CurrencyRoot>(responseBody).Data;
                viewModel.AddCurrency(curr);
            CurrenciesListBox.DisplayMemberPath = nameof(Currency.InfoForListBox);
            this.DataContext = viewModel;
        }
    }
}
