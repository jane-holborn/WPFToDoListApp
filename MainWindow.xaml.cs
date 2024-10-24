using System.Collections.ObjectModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFToDoListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Tasks { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<string>();
            TaskListBox.ItemsSource = Tasks;
            TextBoxAdd.Foreground = Brushes.Gray;
        }

        // This method is used to clear the placeholder text from the add task text box and make the text visible when adding a task.
        private void TextBoxAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxAdd.Text == "Type your task here.")
            {
                TextBoxAdd.Clear();
                TextBoxAdd.Foreground = Brushes.Black;
            }
        }

        // This method is used to add a new task.
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxAdd.Text) && TextBoxAdd.Text != "Type your task here.")
            {
                Tasks.Add(TextBoxAdd.Text);
                TextBoxAdd.Clear();
                TextBoxAdd_LostFocus(null, null);
            }
        }

        // This method is used to add the placeholder text back in if the user clicks away and has not started adding a task.
        private void TextBoxAdd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxAdd.Text == string.Empty)
            {
                TextBoxAdd.Text = "Type your task here.";
                TextBoxAdd.Foreground = Brushes.Gray;
            }
        }
    }
}