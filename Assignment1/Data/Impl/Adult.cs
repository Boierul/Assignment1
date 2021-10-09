using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assignment1.Models;

namespace Assignment1.Data.Impl
{
    public class Adult :  IAdult
    {
        public IList<Person> Persons { get; private set; }

        private string personsFile = "Adults.json";

        public Adult()
        {
            if (!File.Exists(personsFile))
            {
                Seed();
                string personsAsJson = JsonSerializer.Serialize(Persons);
                File.WriteAllText(personsFile, personsAsJson);
            }
            else
            {
                string content = File.ReadAllText(personsFile);
                Persons = JsonSerializer.Deserialize<List<Person>>(content);
            }
        }

        public void AddNewPerson(Person person)
        {
            Persons.Add(person);
            WriteTodosToFile();
        }
        
        private void WriteTodosToFile()
        {
            string todosAsJson = JsonSerializer.Serialize(Persons);
            File.WriteAllText(personsFile, todosAsJson);
        }
        
        private void Seed()
        {
            Person[] ps =
            {
                new Person()
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Charles",
                    HairColor = "black",
                    EyeColor = "blue",
                    Age = 22,
                    Weight = 72,
                    Sex = "M"
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Shrek",
                    LastName = "Shrek",
                    HairColor = "blonde",
                    EyeColor = "green",
                    Age = 52,
                    Weight = 169,
                    Sex = "M"
                }
            };
        
            Persons = ps.ToList();
        }
        
    }
}

