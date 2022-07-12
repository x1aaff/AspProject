using System.Text.Json;

namespace AspProject.Model
{
    public class PhoneBook
    {
        public List<Contact> contacts;
        public PhoneBook()
        {
            contacts = ReadContacts("contacts.json");
        }

        public Contact GetContact(int id)
        {
            Contact contact = contacts[id];
            return contact;
        }

        public static List<Contact> GenContacts()
        {
            List<Contact> contacts = new List<Contact>();

            List<string> names = new List<string>() 
                {"Лофяон", "Працтал", "Фрактал", "Латкарф", "Латцарп", "Стал", "Добрый", "Норильск", "Сат", "Бэнкси", "Найк" };

            Random r = new();
            for (int i = 0; i < 35; i++)
            {
                contacts.Add(new Contact()
                {
                    Id = i,
                    LastName = names[r.Next(11)],
                    FirstName = names[r.Next(11)],
                    PName = names[r.Next(11)],
                    PhoneNumber = r.Next(100000, 1000000),
                    Adress = names[r.Next(11)] + ", " + r.Next(100),
                    Description = i.GetHashCode().ToString()
                });
            }

            return contacts;
        }

        public static void SaveContacts(List<Contact> contacts)
        {
            string jsonString = JsonSerializer.Serialize<List<Contact>>(contacts);
            File.WriteAllText("contacts.json", jsonString);
        }

        public static List<Contact> ReadContacts(string path)
        {
            string jsonString = File.ReadAllText(path);
            List<Contact> contacts = JsonSerializer.Deserialize<List<Contact>>(jsonString);
            return contacts;
        }
    }
}
