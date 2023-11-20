using Cryptocurrency_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_Test_Task.ViewModels
{
    internal class CurrencyViewModel
    {
        private readonly ICollection<Currency> currencies = new ObservableCollection<Currency>();

        public IEnumerable<Currency> Currencies => currencies;
        public static Currency? SelectedCurrency { get; set; }
        public void AddCurrency(Currency c)
        {
            currencies.Add(c);
        }
        public void ClearCurrencies()
        {
            currencies.Clear();
        }
        public Currency GetFirstCurrency()
        {
            if (currencies.Count == 0)
            {
                return new Currency();
            }
            else
            {
                return currencies.First<Currency>();
            }
        }
    }
}
