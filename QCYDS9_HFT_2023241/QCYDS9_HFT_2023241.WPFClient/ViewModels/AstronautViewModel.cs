using Microsoft.Toolkit.Mvvm.Input;
using QCYDS9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace QCYDS9_HFT_2023241.WPFClient.ViewModels
{
   public  class AstronautViewModel : ObservableRecipient
    {

        public RestCollection<Astronaut> Astronauts { get; set; }



        public ICommand CreateAstronautCommand { get; set; }
        public ICommand DeleteAstronautCommand { get; set; }
        public ICommand UpdateAstronautCommand { get; set; }


      

        private Astronaut selectedAstronaut;

        public Astronaut SelectedAstronaut
        {
            get { return selectedAstronaut; }
            set
            {
                SetProperty(ref selectedAstronaut, value);
                (DeleteAstronautCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public AstronautViewModel()
        {

            if (!IsInDesignMode)
            {
                Astronauts = new RestCollection<Astronaut>("http://localhost:25601/", "Astronaut");
              
               
                CreateAstronautCommand = new RelayCommand(() =>
                {

                    Astronauts.Add(new Astronaut()
                    {
                        Name = SelectedAstronaut.Name,
                        Country = SelectedAstronaut.Country
                    });
                });
                DeleteAstronautCommand = new RelayCommand(() => Astronauts.Delete(SelectedAstronaut.AstronautId), () => { return SelectedAstronaut != null; });
                UpdateAstronautCommand = new RelayCommand(() => Astronauts.Update(SelectedAstronaut));
               
                SelectedAstronaut = new Astronaut();
            }

        }
    }
}
