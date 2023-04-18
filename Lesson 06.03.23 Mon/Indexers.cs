using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_06._03._23_Mon
{
    public class Company
    {
        Person[] personal;

        public string this[int index]
        {
            get => personal[index].Name;
            set => personal[index].Name = value;
        }

        public Person this[string name]
        {
            get
            {
                foreach (Person person in personal)
                    if (person.Name == name) return person;

                return null;
            }

            set
            {
                foreach (Person person in personal)
                {
                    if (person.Name == name)
                        person.Name = value.Name;
                }
            }
        }

        public Company(Person[] people) => personal = people;
    }

    public class Person
    {
        public string Name { get; set; }

        public Person(string name) => Name = name;
    }

}
