using ExamenXamarinAMH.Base;
using ExamenXamarinAMH.Models;
using ExamenXamarinAMH.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExamenXamarinAMH.ViewModels
{
    public class ModificarPersonajeViewModel:ViewModelBase
    {
        private ServiceApiSeries service;
        public ModificarPersonajeViewModel(ServiceApiSeries service)
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

        private Personaje _SelectedPersonaje;
        public Personaje SelectedPersonaje
        {
            get { return this._SelectedPersonaje; }
            set
            {
                this._SelectedPersonaje = value;
                OnPropertyChanged("SelectedPersonaje");
            }
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

        private Serie _SelectedSerie;
        public Serie SelectedSerie
        {
            get { return this._SelectedSerie; }
            set
            {
                this._SelectedSerie = value;
                OnPropertyChanged("SelectedSerie");
            }
        }

        public async Task LoadSeries()
        {
            List<Serie> series = await this.service.GetSeriesAsync();
            List<Personaje> personajes = await this.service.GetPersonajesAsync();
            this.Series = new ObservableCollection<Serie>(series);
            this.Personajes = new ObservableCollection<Personaje>(personajes);
            this.SelectedSerie = new Serie();
            this.SelectedPersonaje = new Personaje();
        }

        public Command ModificarPersonaje
        {
            get
            {
                return new Command(async () =>
                {
                    await this.service.ModificarPersonaje(this.SelectedPersonaje.IdPersonaje, this.SelectedSerie.IdSerie);
                    await Application.Current.MainPage.DisplayAlert("Ok", "Personaje modificado", "Aceptar");
                });
            }
        }
    }
}
