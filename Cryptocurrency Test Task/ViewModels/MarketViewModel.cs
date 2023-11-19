using Cryptocurrency_Test_Task.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_Test_Task.ViewModels
{
    internal class MarketViewModel
    {
        private readonly ICollection<Market> markets = new ObservableCollection<Market>();

        public IEnumerable<Market> Markets => markets;
        public void AddMarket(Market c)
        {
            markets.Add(c);
        }
        public int CountMarkets()
        {
            return markets.Count;
        }
        public List<Market> GetMarkets()
        {
            return markets.ToList<Market>();
        }
        public void ClearMarkets()
        {
            markets.Clear();
        }
    }
}
