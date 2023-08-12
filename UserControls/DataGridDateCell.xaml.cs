using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace EmployeeEditorUWP.UserControls
{
    public sealed partial class DataGridDateCell : UserControl
    {
        public DataGridDateCell()
        {
            this.InitializeComponent();
        }

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

        public static readonly DependencyProperty EditModeProperty =
            DependencyProperty.Register("EditMode", typeof(bool), typeof(DataGridDateCell), new PropertyMetadata(false));

        public DateTime Date
        {
            get
            {
                return (DateTime)GetValue(DateProperty);
            }
            set
            {
                SetValue(DateProperty, value);
            }
        }

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(DateTime), 
            typeof(DataGridDateCell), 
            new PropertyMetadata(DateTime.Now));
    }
}
