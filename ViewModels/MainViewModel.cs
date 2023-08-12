using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using EmployeeEditorUWP.Models;
using EmployeeEditorUWP.Views.Dialog;

namespace EmployeeEditorUWP.ViewModels
{

    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>()
        {
            new Employee(1) { Name = "Name1", Surname = "Surname1", Birthday = DateTime.Now },
            new Employee(2) { Name = "Name2", Surname = "Surname2", Birthday = DateTime.Now },
            new Employee(3) { Name = "Name3", Surname = "Surname3", Birthday = DateTime.Now },
        };

        [ObservableProperty]
        private bool editMode = false;
        public MainViewModel() { }

        [RelayCommand]
        public async Task AddEmployee()
        {
            var dialogViewModel = new AddEmployeeViewModel(Employees.Count);
            var result = await AddDialog(dialogViewModel);

            if(result == ContentDialogResult.Primary)
            {
                Employees.Add(dialogViewModel.Employee);
            }
        }
        [RelayCommand]
        public async Task RemoveEmployee(Employee employee)
        {
            if(await DialogRemove(employee) == ContentDialogResult.Primary)
                Employees.Remove(employee);
        }
        private async Task<ContentDialogResult> AddDialog(AddEmployeeViewModel viewModel)
        {
            var dialog = new AddEmployeeDialog();
            dialog.DataContext = viewModel;
            return await dialog.ShowAsync();
        }
        private async Task<ContentDialogResult> DialogRemove(Employee employee)
        {
            var dialog = new RemoveEmployeeDialog();
            dialog.DataContext = new EditEmployeeViewModel(employee);
            return await dialog.ShowAsync();
        }
    }
}