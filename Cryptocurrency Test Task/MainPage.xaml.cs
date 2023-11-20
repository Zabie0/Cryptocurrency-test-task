using Cryptocurrency_Test_Task.Models;
using Cryptocurrency_Test_Task.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private CurrencyViewModel viewModel;
        private HttpClient httpClient;
        private string selectedBox;
        public string SelectedBox
        {
            get { return selectedBox; }
            set
            {
                selectedBox = value;
                OnPropertyChanged("SelectedBox");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public MainPage()
        {
            viewModel = new CurrencyViewModel();
            httpClient = new HttpClient();
            InitializeComponent();
            GetAllAssetsAPIAsync();
        }
        public async Task GetAllAssetsAPIAsync()
        {
            try
            {
                string responseBody = await httpClient.GetStringAsync("https://api.coincap.io/v2/assets?limit=10");
                UpdateList(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)CurrenciesAmountComboBox.SelectedItem;
            int amount = Int32.Parse(selectedItem.Content.ToString());
            CurrencyListLabel.Content = $"Top {amount} currencies:";
            string responseBody = await httpClient.GetStringAsync($"https://api.coincap.io/v2/assets?limit={amount}");
            UpdateList(responseBody);
        }
        private void UpdateList(string responseBody)
        {
            viewModel.ClearCurrencies();
            var list = JsonConvert.DeserializeObject<CurrencyRootList>(responseBody).Data;
            foreach(Currency curr in list)
            {
                viewModel.AddCurrency(curr);
            }
            currencyListBox.DisplayMemberPath = nameof(Currency.InfoForListBox);
            this.DataContext = viewModel;
        }
        void NavigateToCurrencyDetailsPage(Object sender, EventArgs e)
        {
            //NavigationService ns = NavigationService.GetNavigationService(this);
            GetNav().Navigate(new CurrencyDetails(CurrencyViewModel.SelectedCurrency));
        }
        void NavigateToExchangePage(Object sender, EventArgs e)
        {
            //NavigationService ns = NavigationService.GetNavigationService(this);
            GetNav().Navigate(new ExchangePage());
        }
        void NavigateToSearchPage(Object sender, EventArgs e)
        {
            //NavigationService ns = NavigationService.GetNavigationService(this);
            GetNav().Navigate(new SearchPage());
        }
        private NavigationService GetNav()
        {
            if(CurrencyViewModel.SelectedCurrency == null)
            {
                CurrencyViewModel.SelectedCurrency = viewModel.GetFirstCurrency();
            }
            return NavigationService.GetNavigationService(this);
        }
    }
}
