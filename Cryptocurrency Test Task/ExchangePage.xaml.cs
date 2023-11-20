using Cryptocurrency_Test_Task.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ExchangePage.xaml
    /// </summary>
    public partial class ExchangePage : Page
    {
        public ExchangePage()
        {
            InitializeComponent();
        }
        void NavigateToMainPage(Object sender, EventArgs e)
        {
            //NavigationService ns = NavigationService.GetNavigationService(this);
            GetNav().Navigate(new MainPage());
        }
        void NavigateToDetailsPage(Object sender, EventArgs e)
        {
            //NavigationService ns = NavigationService.GetNavigationService(this);
            GetNav().Navigate(new CurrencyDetails(CurrencyViewModel.SelectedCurrency));
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
    }
}
