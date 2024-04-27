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
    public class Crewnfo
    {
        public int MissionId { get; set; }
        public int MillioUSD { get; set; }
        public string SpacehshipName { get; set; }
    }

    public class ExtraInfoModel : ObservableRecipient
    {
        public RestCollection<Crewnfo> crewinfos { get; set; }

        private Crewnfo selectedcew;

        public Crewnfo Selectedcew
        {
            get { return selectedcew; }
            set
            {
                SetProperty(ref selectedcew, value);
               
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

        public ExtraInfoModel()
        {
            if (!IsInDesignMode)
            {
                crewinfos = new RestCollection<Crewnfo>("http://localhost:25601/", "CrewInfo/CrewInfo");
            }
        }


    }
}
