using SQLite;

namespace DesktopContactsApp.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}.\nEmail: {Email}.\nPhone: {Phone}";
        }
    }
}
