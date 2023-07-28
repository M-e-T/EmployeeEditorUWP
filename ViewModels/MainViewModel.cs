using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using EmployeeEditorUWP.Models;
using EmployeeEditorUWP.Views;

namespace EmployeeEditorUWP.ViewModels
{
    //[INotifyPropertyChanged]
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>()
        {
            new Employee() { Name = "Name1", Surname = "Surname2", Birthday = DateTime.Now },
            new Employee() { Name = "Name2", Surname = "Surname2", Birthday = DateTime.Now },
        };

        [ObservableProperty]
        private Employee selectedEmployee;
        //public Developer SelectedDeveloper
        //{
        //    get => selectedDeveloper;
        //    set
        //    {
        //        SetProperty(ref selectedDeveloper, value);
        //    }
        //}
        //private int _index;
        ////[ObservableProperty]
        //public int Index
        //{
        //    get => _index;
        //    set
        //    {
        //        SetProperty(ref _index, value);
        //        Debug.WriteLine(value);
        //    }
        //}
        private readonly ResourceLoader resourceLoader;
        public MainViewModel()
        {
            resourceLoader = new ResourceLoader();
        }

        [RelayCommand]
        public async void AddEmployee()
        {           
            var dialogViewModel = new AddEmployeeViewModel();
            string title = resourceLoader.GetString("AddEmployee");
            var result = await ShowDialog(title, dialogViewModel);

            if(result == ContentDialogResult.Primary)
            {
                Employees.Add(dialogViewModel.Employee);
            }
        }
        [RelayCommand]
        public async void EditEmployee(Employee employee)
        {
            string title = new ResourceLoader().GetString("EditEmployee");
            var dialogViewModel = new EditEmployeeViewModel(employee);
            var result = await ShowDialog(title, dialogViewModel);

            if (result == ContentDialogResult.Primary)
            {
                Employees[Employees.IndexOf(employee)] = dialogViewModel.Employee;
            }
        }
        [RelayCommand]
        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        } 
        private async Task<ContentDialogResult> ShowDialog(string title, object viewModel)
        {
            var dialog = new EmployeeDialog();
            dialog.Title = dialog.Title = title;
            dialog.PrimaryButtonText = resourceLoader.GetString("Ok");
            dialog.SecondaryButtonText = resourceLoader.GetString("Cancel");
            dialog.DataContext = viewModel;
            var result = await dialog.ShowAsync();

            return result;
        }
    }
}