using AspProject.Entities;
using System.Text.Json;
using AspProject.ContextFolder;

namespace AspProject.Model
{
    public class PhoneBook
    {
        public static DataContext context;
        public PhoneBook()
        {
            context = new DataContext();
        }

        public static void GenContacts()
        {
            List<string> names = new List<string>() 
                {"Лофяон", "Працтал", "Фрактал", "Латкарф", "Латцарп", "Стал", "Добрый", "Норильск", "Сат", "Бэнкси", "Найк" };

            Random r = new();
            for (int i = 0; i < 35; i++)
            {
                context.Contacts.Add(new Contact()
                {
                    LastName = names[r.Next(11)],
                    FirstName = names[r.Next(11)],
                    PName = names[r.Next(11)],
                    PhoneNumber = r.Next(100000, 1000000),
                    Adress = names[r.Next(11)] + ", " + r.Next(100),
                    Description = i.GetHashCode().ToString()
                });
                context.SaveChanges();
            }
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
