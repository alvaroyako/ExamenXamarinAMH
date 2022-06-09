using Autofac;
using ExamenXamarinAMH.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenXamarinAMH.Services
{
    public class ServiceIoC
    {
        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }
        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ServiceApiSeries>();
            //VIEWMODELS
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<InsertarPersonajeViewModel>();
            builder.RegisterType<ModificarPersonajeViewModel>();
            this.container = builder.Build();
        }

        public MenuViewModel MenuViewModel
        {
            get
            {
                return this.container.Resolve<MenuViewModel>();
            }
        }

        public InsertarPersonajeViewModel InsertarPersonajeViewModel
        {
            get
            {
                return this.container.Resolve<InsertarPersonajeViewModel>();
            }
        }

        public ModificarPersonajeViewModel ModificarPersonajeViewModel
        {
            get
            {
                return this.container.Resolve<ModificarPersonajeViewModel>();
            }
        }

    }
}
