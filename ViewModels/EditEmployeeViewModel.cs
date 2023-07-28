using CommunityToolkit.Mvvm.ComponentModel;
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
            appView.Title = "Edit employee";
        }
    }
}
