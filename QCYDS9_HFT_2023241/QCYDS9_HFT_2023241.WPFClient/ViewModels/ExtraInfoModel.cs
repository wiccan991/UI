using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using QCYDS9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QCYDS9_HFT_2023241.WPFClient.ViewModels
{
    public class YoungestAstonautAge
    {
        public double Age { get; set; }
       
    }
    public class ExtraInfoModel : ObservableRecipient
    {
        public RestCollection<Astronaut> Astronauts { get; set; }
        public RestCollection<Mission> Missons { get; set; }
        public RestCollection<Spaceship> Spaceships { get; set; }
        public RestService NonCrud { get; set; }

        public ObservableCollection<YoungestAstonautAge> YoungestAstonautAgeNonCrud { get; set; }
        public ICommand YoungestAstonautAgeCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ExtraInfoModel()
        {
            if (!IsInDesignMode)
            {
                //Astronauts = new RestCollection<Astronaut>("http://localhost:25601/", "Astronaut");
                //Missons = new RestCollection<Mission>("http://localhost:25601/", "Mission");
                NonCrud = new RestService("http://localhost:25601");
                YoungestAstonautAgeCommand = new RelayCommand(
                   () =>
                    {
                        var a = NonCrud.Get<double>("Extrainfo/GetYoungestAstonautAge");
                        List<string> list = new List<string>();
                        foreach (var item in Astronauts)
                        {
                            list.Add(item.Name);
                        }
                        int i = 0;
                        foreach (var item in a)
                        {
                            YoungestAstonautAge avaragePointClass = new YoungestAstonautAge();
                            avaragePointClass.Age = item;

                            YoungestAstonautAgeNonCrud.Add(avaragePointClass);
                            i++;
                        }
                    }
                    );
            }

        }
    }
}
