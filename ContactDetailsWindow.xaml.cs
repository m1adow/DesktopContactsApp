using DesktopContactsApp.Models;
using SQLite;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact _contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            _contact = contact;
            ShowContactDetails(contact);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new(App.GetDatabasePath()))
            {
                connection.CreateTable<Contact>();
                connection.Delete(_contact);
            }

            this.Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeContactWithTextBoxes(_contact);

            using (SQLiteConnection connection = new(App.GetDatabasePath()))
            {
                connection.CreateTable<Contact>();
                connection.Update(_contact);
            }

            this.Close();
        }

        private void ShowContactDetails(Contact contact)
        {
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;
        }

        private void ChangeContactWithTextBoxes(Contact contact)
        {
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneTextBox.Text;
        }
    }
}
