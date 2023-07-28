using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EmployeeEditorUWP.Models
{
    public partial class Employee : ObservableObject
    {
        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        [ObservableProperty]
        private string surname;

        [ObservableProperty]
        private DateTimeOffset birthday;
        public Employee() { }
        public Employee(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }
        public Employee(Employee employee)
        {
            Name = employee.name;
            Surname = employee.surname;
            Birthday = employee.birthday;
        }
    }
}
