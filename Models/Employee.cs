using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EmployeeEditorUWP.Models
{
    public partial class Employee : ObservableObject
    {
        private int id;
        public int Id => id;

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        [ObservableProperty]
        private string surname;

        [ObservableProperty]
        private DateTime birthday;
        public Employee() { }
        public Employee(int id) { this.id = id; }
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
