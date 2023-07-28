using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using EmployeeEditorUWP.Models;

namespace EmployeeEditorUWP.ViewModels
{
    public partial class EditEmployeeViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private Employee employee;
        public EditEmployeeViewModel(Employee employee)
        {
            Employee = new Employee(employee);
            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = "Edit employee page";
        }
    }
}
