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
    public partial class ExchangePage : Page
    {
        public List<string> availableCurrencies { get; set; }
        public string CurrencyFrom { get; set; } 
        private double CurrencyFromPriceUsd;
        public string CurrencyTo { get; set; }
        private double CurrencyToPriceUsd;
        public string ExchangeInfo { get; set; }
        public string CurrencyAmount { get; set; }
        public ExchangePage()
        {
            availableCurrencies = new List<string>();
            InitializeComponent();
            FillComboBoxesAsync();
            DataContext = this;
        }

        void NavigateToMainPage(Object sender, EventArgs e)
        {
            GetNav().Navigate(new MainPage());
        }
        void NavigateToDetailsPage(Object sender, EventArgs e)
        {
            GetNav().Navigate(new CurrencyDetails(CurrencyViewModel.SelectedCurrency));
        }
        void NavigateToSearchPage(Object sender, EventArgs e)
        {
            GetNav().Navigate(new SearchPage());
        }
        private NavigationService GetNav()
        {
            return NavigationService.GetNavigationService(this);
        }

        private void CurrencyFromComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!CheckIfEmptySelection())
            {
                GetExchangeInfoAPIAsync();
            }
        }

        private void CurrencyToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!CheckIfEmptySelection())
            {
                GetExchangeInfoAPIAsync();
            }
        }
        private async void GetExchangeInfoAPIAsync()
        {
            try
            {
                string responseBody = await HttpController.httpClient.GetStringAsync($"https://api.coincap.io/v2/assets/{CurrencyFrom}");
                UpdateCurrencyFrom(responseBody);
                responseBody = await HttpController.httpClient.GetStringAsync($"https://api.coincap.io/v2/assets/{CurrencyTo}");
                UpdateCurrencyTo(responseBody);
                UpdateExchangeInfo();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        private bool CheckIfEmptySelection()
        {
            if(CurrencyFromComboBox.SelectedItem == null || CurrencyToComboBox.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void UpdateCurrencyFrom(string responseBody)
        {
            Currency temp = JsonConvert.DeserializeObject<CurrencyRoot>(responseBody).Data;
            temp.PriceUsd = temp.PriceUsd.Replace('.', ',');
            CurrencyFromPriceUsd = double.Parse(temp.PriceUsd);
        }
        private void UpdateCurrencyTo(string responseBody)
        {
            Currency temp = JsonConvert.DeserializeObject<CurrencyRoot>(responseBody).Data;
            temp.PriceUsd = temp.PriceUsd.Replace('.', ',');
            CurrencyToPriceUsd = double.Parse(temp.PriceUsd);
        }
        private void UpdateExchangeInfo()
        {
            if(!double.TryParse(CurrencyAmount, out double amount))
            {
                amount = 1;
            }
            ExchangeInfo = $"Converting {amount} {CurrencyFrom} to {CurrencyTo}\nResult: {(amount * CurrencyFromPriceUsd)/CurrencyToPriceUsd} {CurrencyTo}";
            ExchangeResult.Text = ExchangeInfo;
        }
        private async void FillComboBoxesAsync()
        {
            string responseBody = await HttpController.httpClient.GetStringAsync($"https://api.coincap.io/v2/assets/");
            var list = JsonConvert.DeserializeObject<CurrencyRootList>(responseBody).Data;
            foreach(Currency curr in list )
            {
                availableCurrencies.Add(curr.Id);
            }
        }
    }
}
