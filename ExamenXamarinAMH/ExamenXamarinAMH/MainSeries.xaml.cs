using ExamenXamarinAMH.Code;
using ExamenXamarinAMH.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenXamarinAMH
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainSeries : MasterDetailPage
    {
        public MainSeries()
        {
            InitializeComponent();
            ObservableCollection<MenuPageItem> menu =
                new ObservableCollection<MenuPageItem>
                {
                 new MenuPageItem{
                Titulo = "Home", TypePage=typeof(MenuPrincipal)},
                new MenuPageItem{
                Titulo = "Crear Personaje", TypePage=typeof(CrearPersonajeView)},
                new MenuPageItem{
                Titulo = "Modificar Personaje", TypePage=typeof(ModificarPersonajeView)},
                };
            this.lsvMenu.ItemsSource = menu;
            Detail =
                new NavigationPage
                ((Page)Activator.CreateInstance(typeof(MenuPrincipal)));
            this.lsvMenu.ItemSelected += LsvMenu_ItemSelected;
        }

        private void LsvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MenuPageItem item = e.SelectedItem as MenuPageItem;
            Detail =
                new NavigationPage((Page)Activator.CreateInstance(item.TypePage));
            IsPresented = false;
        }
    }
}