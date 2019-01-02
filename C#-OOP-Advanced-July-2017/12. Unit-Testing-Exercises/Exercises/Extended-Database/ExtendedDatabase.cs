namespace Extended_Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendedDatabase
    {
        private readonly HashSet<Person> persons;

        public ExtendedDatabase(params Person[] persons)
        {
            this.persons = new HashSet<Person>(persons);
        }

        public Person[] Persons
        {
            get => this.persons.ToArray();
        }

        public void Remove(Person person)
        {
            if (this.persons.Contains(person))
            {
                this.persons.Remove(person);
            }
        }

        public void Add(Person person)
        {
            if (this.persons.Any(p => p.Username == person.Username))
            {
                throw new InvalidOperationException($"There is already person with this username: {person.Username}.");
            }

            if (this.persons.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException($"There is already person with this id: {person.Id}.");
            }

            this.persons.Add(person);
        }

        public Person Find(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            try
            {
                return this.persons.First(p => p.Username == username);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"There is no person with this username: {username}");
            }
        }

        public Person Find(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            try
            {
                return this.persons.First(p => p.Id == id);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"There is no person with this id: {id}");
            }
        }
    }
}