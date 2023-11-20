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
    /// <summary>
    /// Interaction logic for CurrencyDetails.xaml
    /// </summary>
    public partial class CurrencyDetails : Page
    {
        public Currency selectedCurrency;
        private MarketViewModel viewModel;
        private MarketViewModel filteredMarkets;
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
        public List<string> availableCurrencies { get; set; }
        private HttpClient httpClient;
        public CurrencyDetails(Currency passedCurrency)
        {
            selectedCurrency = passedCurrency;
            viewModel = new MarketViewModel();
            filteredMarkets = new MarketViewModel();
            availableCurrencies = new List<string>();
            httpClient = new HttpClient();
            InitializeComponent();
            GetCurrencyMarketsAPI(selectedCurrency.Id);
        }
        void NavigateToMainPage(Object sender, EventArgs e)
        {
            //NavigationService ns = NavigationService.GetNavigationService(this);
            GetNav().Navigate(new MainPage());
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
            return NavigationService.GetNavigationService(this);
        }
        private async void GetCurrencyMarketsAPI(string currencyName)
        {
            try
            {
                string responseBody = await httpClient.GetStringAsync($"https://api.coincap.io/v2/markets?baseId={currencyName}");
                var list = JsonConvert.DeserializeObject<MarketRootList>(responseBody).Data;
                availableCurrencies.Add("All");
                foreach (Market market in list)
                {
                    viewModel.AddMarket(market);
                    if (!availableCurrencies.Contains(market.QuoteSymbol))
                    {
                        availableCurrencies.Add(market.QuoteSymbol);
                    }
                }
                MarketInfoListBox.DisplayMemberPath = nameof(Market.MarketsForListBox);
                if (viewModel.CountMarkets() == 0)
                {
                    viewModel.AddMarket(new Market());
                    MarketInfoListBox.DisplayMemberPath = nameof(Market.NoMarketsFound);
                }
                CurrencyDetailsTextBox.DataContext = selectedCurrency;
                CurrencyFilterComboBox.DataContext = this;
                MarketInfoListBox.DataContext = viewModel;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private void FilterCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedBox.Equals("All"))
            {
                MarketInfoListBox.DataContext = viewModel;
            }
            else
            {
                filteredMarkets.ClearMarkets();
                List<Market> tempList = viewModel.GetMarkets();
                foreach (Market market in tempList)
                {
                    if (market.QuoteSymbol.Equals(selectedBox))
                    {
                        filteredMarkets.AddMarket(market);
                    }
                }
                MarketInfoListBox.DataContext = filteredMarkets;
            }
        }
    }
}
