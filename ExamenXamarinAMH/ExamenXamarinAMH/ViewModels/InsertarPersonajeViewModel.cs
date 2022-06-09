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
    public class InsertarPersonajeViewModel: ViewModelBase
    {
        private ServiceApiSeries service;
        public InsertarPersonajeViewModel(ServiceApiSeries service)
        {
            this.service = service;
            Task.Run(async () =>
            {
                await this.LoadSeries();
            });
        }

        private Personaje _Personaje;
        public Personaje Personaje
        {
            get { return this._Personaje; }
            set
            {
                this._Personaje = value;
                OnPropertyChanged("Personaje");
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
            List<Serie> series =
                await this.service.GetSeriesAsync();
            this.Series = new ObservableCollection<Serie>(series);
            this.SelectedSerie = new Serie();
            this.Personaje = new Personaje();
        }

        public Command InsertarPersonaje
        {
            get
            {
                return new Command(async (id) =>
                {
                    Personaje per = new Personaje();
                    per.IdPersonaje = 0;
                    per.Nombre = this.Personaje.Nombre;
                    per.Imagen = this.Personaje.Imagen;
                    per.IdSerie = SelectedSerie.IdSerie;
                    await this.service.CrearPersonaje(per);
                    await Application.Current.MainPage.DisplayAlert("Ok", "Personaje insertado", "Aceptar");
                });
            }
        }
    }
}
