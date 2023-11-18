using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cryptocurrency_Test_Task.Models
{
    public class Market
    {
        private string exchangeId;
        public string ExchangeId
        {
            get { return exchangeId; }
            set
            {
                exchangeId = value;
                OnPropertyChanged("ExchangeId");
            }
        }
        private string priceUsd;
        public string PriceUsd
        {
            get { return priceUsd; }
            set
            {
                priceUsd = value;
                OnPropertyChanged("PriceUsd");
            }
        }
        private string quoteSymbol;
        public string QuoteSymbol
        {
            get { return quoteSymbol; }
            set
            {
                quoteSymbol = value;
                OnPropertyChanged("QuoteSymbol");
            }
        }
        public string MarketsForListBox => $"{exchangeId}: {priceUsd}$";
        public string NoMarketsFound => "No markets found!";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class MarketRootList
    {
        public List<Market> Data;
    }
}
