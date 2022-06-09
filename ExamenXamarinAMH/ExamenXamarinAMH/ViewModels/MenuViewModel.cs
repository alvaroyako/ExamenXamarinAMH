using ExamenXamarinAMH.Base;
using ExamenXamarinAMH.Models;
using ExamenXamarinAMH.Services;
using ExamenXamarinAMH.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExamenXamarinAMH.ViewModels
{
   public class MenuViewModel: ViewModelBase
    {
        private ServiceApiSeries service;
        public MenuViewModel(ServiceApiSeries service)
        {
            this.service = service;
            Task.Run(async () =>
            {
                await this.LoadSeries();
            });
            //MessagingCenter.Subscribe<MenuViewModel>
            //    (this, "RELOAD", async (sender) =>
            //    {
            //        await this.LoadSeries();
            //    });
        }

        private async Task LoadSeries()
        {
            List<Serie> series =
                await this.service.GetSeriesAsync();
            this.Series =
                new ObservableCollection<Serie>(series);
        }

        private async Task BuscarPersonaje(int id)
        {
            List<Personaje> personajes = await this.service.GetPersonajesSerieAsync(id);
            this.Personajes = new ObservableCollection<Personaje>(personajes);
        }

        private ObservableCollection<Serie> _Series;

        public ObservableCollection<Serie> Series
        {
            get { return this._Series; }
            set
            {
                this._Series = value;
                OnPropertyChanged("Series");
            }
        }

        private ObservableCollection<Personaje> _Personajes;

        public ObservableCollection<Personaje> Personajes
        {
            get { return this._Personajes; }
            set
            {
                this._Personajes = value;
                OnPropertyChanged("Personajes");
            }
        }

        public Command VerPersonajes
        {
            get
            {
                return new Command(async (serie) =>
                {
                    Serie ser = serie as Serie;
                    await this.BuscarPersonaje(ser.IdSerie);
                });
            }
        }



    }
}
