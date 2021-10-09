using System.Collections;
using System.Collections.Generic;
using Assignment1.Models;

namespace Assignment1.Data
{
    public interface IAdult
    {
        public IList<Person> Persons { get; }
        public void AddNewPerson(Person person);
    }
}