using DesktopContactsApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl? control = d as ContactControl;

            if (control is null)
                return;

            Contact? contact = e.NewValue as Contact;

            if (contact is null)
                return;

            control.nameTextBlock.Text = contact.Name;
            control.emailTextBlock.Text = contact.Email;
            control.phoneTextBlock.Text = contact.Phone;
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
