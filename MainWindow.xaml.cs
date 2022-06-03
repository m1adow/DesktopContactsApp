using DesktopContactsApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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
            List<Contact> contacts;

            using (SQLiteConnection connection = new(App.GetDatabasePath()))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();
            }

            if (contacts is null)
                return;

            /*foreach (var contact in contacts)
            {
                contactsListView.Items.Add(new ListViewItem()
                {
                    Content = contact.ToString()
                });
            }*/

            contactsListView.ItemsSource = contacts;
        }
    }
}
