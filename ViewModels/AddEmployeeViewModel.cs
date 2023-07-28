using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using EmployeeEditorUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.System;

namespace EmployeeEditorUWP.ViewModels
{

    [INotifyPropertyChanged]
    public partial class AddEmployeeViewModel
    {
        [ObservableProperty]
        private Employee employee = new Employee() { Birthday = DateTime.Now };
        public AddEmployeeViewModel()
        {
            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = "Add employee page";
        }
    }
}
