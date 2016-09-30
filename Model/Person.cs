using System;

namespace TadManagementTool.Model
{
    public class Person
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }

        public Person(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;
            if (other == null) return false;
            if (!object.Equals(Name, other.Name)) return false;
            if (!object.Equals(BirthDate, other.BirthDate)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            var hash = 3;
            hash += 17 * (string.IsNullOrWhiteSpace(Name) ? 0 : Name.GetHashCode());
            hash += 17 * (BirthDate == null ? 0 : BirthDate.GetHashCode());
            return hash;
        }
    }
}
