using Cryptocurrency_Test_Task.Models;
using Cryptocurrency_Test_Task.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private MarketViewModel viewModel;
        private HttpClient httpClient;
        public CurrencyDetails(string currencyName, string price, string volume, string priceChange)
        {
            viewModel = new MarketViewModel();
            httpClient = new HttpClient();
            InitializeComponent();
            GetCurrencyMarketsAPI(currencyName);
            ShowCurrencyInfo(price, volume, priceChange);
        }
        void MoveToMainPage(Object sender, EventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new MainPage());
        }
        private async void GetCurrencyMarketsAPI(string currencyName)
        {
            try
            {
                string responseBody = await httpClient.GetStringAsync($"https://api.coincap.io/v2/markets?baseId={currencyName}");
                var list = JsonConvert.DeserializeObject<MarketRootList>(responseBody).Data;
                foreach (Market market in list)
                {
                    if (market.QuoteSymbol.Equals("USD"))
                    {
                        market.PriceUsd = market.PriceUsd.Substring(0, market.PriceUsd.Length - 13);
                        viewModel.AddMarket(market);
                    }
                    MarketInfoListBox.DisplayMemberPath = nameof(Market.MarketsForListBox);
                }
                if (viewModel.CountMarkets() == 0)
                {
                    viewModel.AddMarket(new Market());
                    MarketInfoListBox.DisplayMemberPath = nameof(Market.NoMarketsFound);
                }
                this.DataContext = viewModel;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        private void ShowCurrencyInfo(string price, string volume, string priceChange)
        {
            CurrencyDetailsLabel.Content = $"Price: {price.Substring(0, price.Length-13)}$\nVolume: {volume.Substring(0, price.Length - 5)}\nPrice change: {priceChange.Substring(0, price.Length - 10)}";
        }
    }
}
