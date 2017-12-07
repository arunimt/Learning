using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculateAll.Menu;
using CalculateAll.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculateAll
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> MenuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            MenuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var pageCalc = new MasterPageItem() { Title = "Calculator", Icon = "icon_cal.png", TargetType = typeof(Calculator) };
            var pageArea = new MasterPageItem() { Title = "Area", Icon = "icon_area.png", TargetType = typeof(Area) };
            var pageVol = new MasterPageItem() { Title = "Volume", Icon = "", TargetType = typeof(Volume) };

            // Adding menu items to menuList
            MenuList.Add(pageCalc);
            MenuList.Add(pageArea);
            MenuList.Add(pageVol);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Calculator)));

        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}