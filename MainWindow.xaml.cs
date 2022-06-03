using DesktopContactsApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> _contacts;

        public MainWindow()
        {
            InitializeComponent();

            _contacts = new List<Contact>();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        private void ReadDatabase()
        {
            using (SQLiteConnection connection = new(App.GetDatabasePath()))
            {
                connection.CreateTable<Contact>();
                _contacts = connection.Table<Contact>().OrderBy(c => c.Name).ToList();
            }

            if (_contacts is null)
                return;

            contactsListView.ItemsSource = _contacts;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox? searchTextBox = sender as TextBox;

            var filteredList = _contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            contactsListView.ItemsSource = filteredList;
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact? selectedContact = contactsListView.SelectedItem as Contact;

            if (selectedContact is null)
                return;

            ContactDetailsWindow contactDetailsWindow = new(selectedContact);
            contactDetailsWindow.ShowDialog();

            ReadDatabase();
        }
    }
}
