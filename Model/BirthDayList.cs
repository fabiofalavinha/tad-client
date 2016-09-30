using System.Collections.Generic;
using System.Linq;

namespace TadManagementTool.Model
{
    public class BirthdayList
    {
        private readonly List<Person> personList;

        public MonthOfBirthday CurrentMonth { get; private set; }
        public Person[] People { get { return personList.OrderBy(p => p.BirthDate.Day).ToArray(); } }

        public BirthdayList(MonthOfBirthday monthOfBirthday)
        {
            CurrentMonth = monthOfBirthday;
            this.personList = new List<Person>();
        }

        public void Add(Person person)
        {
            if (CurrentMonth.IsFrom(person.BirthDate))
            {
                if (!personList.Any(p => p.Equals(person)))
                {
                    personList.Add(person);
                }
            }
        }
    }
}
