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

namespace QCYDS9_HFT_2023241.WPFClient.ViewModels
{
    class SpaceshipViewModel : ObservableRecipient
    {
        public RestCollection<Spaceship> Spaceships { get; set; }



        public ICommand CreateSpaceshipCommand { get; set; }
        public ICommand DeleteSpaceshipCommand { get; set; }
        public ICommand UpdateSpaceshipCommand { get; set; }




        private Spaceship selectedSpaceship;

        public Spaceship SelectedSpaceship
        {
            get { return selectedSpaceship; }
            set
            {
                SetProperty(ref selectedSpaceship, value);
                (DeleteSpaceshipCommand as RelayCommand).NotifyCanExecuteChanged();
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


        public SpaceshipViewModel()
        {

            if (!IsInDesignMode)
            {
                Spaceships = new RestCollection<Spaceship>("http://localhost:25601/", "Spaceship");


                CreateSpaceshipCommand = new RelayCommand(() =>
                {

                    Spaceships.Add(new Spaceship()
                    {
                        Name = SelectedSpaceship.Name,
                        MakeYear = SelectedSpaceship.MakeYear,
                        Speed = SelectedSpaceship.Speed,
                        Id = SelectedSpaceship.Id,
                    });
                });
                DeleteSpaceshipCommand = new RelayCommand(() => Spaceships.Delete(SelectedSpaceship.Id), () => { return SelectedSpaceship != null; });
                UpdateSpaceshipCommand = new RelayCommand(() => Spaceships.Update(SelectedSpaceship));

                SelectedSpaceship = new Spaceship();
            }

        }
    }
}
