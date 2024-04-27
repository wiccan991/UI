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
    public class MissionViewModel : ObservableRecipient
    {

        public RestCollection<Mission> Missions { get; set; }



        public ICommand CreateMissionCommand { get; set; }
        public ICommand DeleteMissionCommand { get; set; }
        public ICommand UpdateMissionCommand { get; set; }




        private Mission selectedMission;

        public Mission SelectedMission
        {
            get { return selectedMission; }
            set
            {
                SetProperty(ref selectedMission, value);
                (DeleteMissionCommand as RelayCommand).NotifyCanExecuteChanged();
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


        public MissionViewModel()
        {

            if (!IsInDesignMode)
            {
                Missions = new RestCollection<Mission>("http://localhost:25601/", "Mission", "hub");


                CreateMissionCommand = new RelayCommand(() =>
                {

                    Missions.Add(new Mission()
                    {
                        Name = SelectedMission.Name,
                        Objective = SelectedMission.Objective,
                        SpaceshipId=SelectedMission.SpaceshipId,
                        
                    });
                });
                DeleteMissionCommand = new RelayCommand(() => Missions.Delete(SelectedMission.MissionId), () => { return SelectedMission != null; });
                UpdateMissionCommand = new RelayCommand(() => Missions.Update(SelectedMission));

                SelectedMission = new Mission();
            }

        }
    }
}
