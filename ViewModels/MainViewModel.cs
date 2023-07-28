using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;


using EmployeeEditorUWP.Models;
using EmployeeEditorUWP.Views;
using Windows.ApplicationModel.Core;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EmployeeEditorUWP.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainViewModel
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
        public MainViewModel()
        {
        }
        private async Task<bool> OpenPageAsWindowAsync(Type t)
        {
            var view = CoreApplication.CreateNewView();
            int id = 0;

            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(t, null);
                Window.Current.Content = frame;
                Window.Current.Activate();
                id = ApplicationView.GetForCurrentView().Id;
            });

            return await ApplicationViewSwitcher.TryShowAsStandaloneAsync(id);
        }

        [RelayCommand]
        public async void AddEmployee()
        {
            
            var dialog = new EmployeeDialog();
            dialog.Title = "Add employee";
            var dialogViewModel = new AddEmployeeViewModel();

            dialog.DataContext = dialogViewModel;
            var result = await dialog.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                Employees.Add(dialogViewModel.Employee);
            }
        }
        [RelayCommand]
        public async void EditEmployee(Employee employee)
        {
            var dialog = new EmployeeDialog();
            dialog.Title = "Edit employee";
            var dialogViewModel = new EditEmployeeViewModel(employee);
            dialog.DataContext = dialogViewModel;
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Employees[employees.IndexOf(employee)] = dialogViewModel.Employee;
            }
        }
        [RelayCommand]
        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        } 
    }
}