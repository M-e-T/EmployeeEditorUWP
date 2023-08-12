using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace EmployeeEditorUWP.UserControls
{
    public sealed partial class DataGridTextCell : UserControl
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text",
            typeof(string), 
            typeof(DataGridTextCell), 
            new PropertyMetadata(null));
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public static readonly DependencyProperty EditModeProperty =
            DependencyProperty.Register("EditMode",
            typeof(bool), 
            typeof(DataGridTextCell), 
            new PropertyMetadata(null));


        public bool EditMode
        {
            get
            {
                return (bool)GetValue(EditModeProperty);
            }
            set
            {
                SetValue(EditModeProperty, value);
            }
        }
        public DataGridTextCell()
        {
            this.InitializeComponent();
        }
    }
}
