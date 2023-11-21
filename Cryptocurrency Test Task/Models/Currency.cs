using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Cryptocurrency_Test_Task.Models
{
    public class Currency
    {
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string rank;
        public string Rank
        {
            get { return rank; }
            set
            {
                rank = value;
                OnPropertyChanged("Rank");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
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
        private string volumeUsd24Hr;
        public string VolumeUsd24Hr
        {
            get { return volumeUsd24Hr; }
            set
            {
                volumeUsd24Hr = value;
                OnPropertyChanged("VolumeUsd24Hr");
            }
        }
        private string changePercent24Hr;
        public string ChangePercent24Hr
        {
            get { return changePercent24Hr; }
            set
            {
                changePercent24Hr = value;
                OnPropertyChanged("ChangePercent24Hr");
            }
        }
        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set
            {
                symbol = value;
                OnPropertyChanged("Symbol");
            }
        }
        public string InfoForListBox => $"{Rank}: {Name}";
        public string InfoForDetailsLabel => $"Name: {Name}\nPrice: {PriceUsd.Substring(0, PriceUsd.Length - 10)}$\nVolume: {VolumeUsd24Hr.Substring(0, VolumeUsd24Hr.Length - 6)}\nPrice change: {ChangePercent24Hr.Substring(0, ChangePercent24Hr.Length - 10)}%";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class CurrencyRoot
    {
        public Currency Data;
    }
    public class CurrencyRootList
    {
        public List<Currency> Data;
    }
}
