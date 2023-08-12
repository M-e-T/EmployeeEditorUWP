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

    public partial class AddEmployeeViewModel : ObservableObject
    {
        [ObservableProperty]
        private Employee employee;
        public AddEmployeeViewModel(int id)
        {
            Employee = new Employee(id) { Birthday = DateTime.Now };
        }
    }
}
