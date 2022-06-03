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

            string databaseName = "Contacts.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string databasePath = Path.Combine(folderPath, databaseName);

            SQLiteConnection connection = new(databasePath);
            connection.CreateTable<Contact>();
            connection.Insert(contact);
            connection.Close();

            this.Close();
        }
    }
}
