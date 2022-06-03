using DesktopContactsApp.Models;
using SQLite;
using System;
using System.IO;
using System.Windows;


namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Save contact
            Contact contact = new()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };

            using (SQLiteConnection connection = new(App.GetDatabasePath()))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            this.Close();
        }
    }
}
