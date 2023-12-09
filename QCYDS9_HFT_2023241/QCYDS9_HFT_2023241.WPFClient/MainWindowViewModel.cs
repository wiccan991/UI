using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using QCYDS9_HFT_2023241.Models;

using QCYDS9_HFT_2023241.WPFClient.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QCYDS9_HFT_2023241.WPFClient
{
    public class MainWindowViewModel
    {

        public ICommand astronautWindow { get; set; }
        public ICommand missionWindow { get; set; }
        public ICommand spaceshipWindow { get; set; }
        public ICommand extrainfoWindow { get; set; }
   

        public MainWindowViewModel()
        {
            astronautWindow = new RelayCommand(() => new AstronautWindow().Show());
            missionWindow = new RelayCommand(() => new MissionWindow().Show());
            spaceshipWindow = new RelayCommand(() => new SpaceshipWindow().Show());
            extrainfoWindow = new RelayCommand(() => new ExtraInfoWindow().Show());

        }
    }

}

