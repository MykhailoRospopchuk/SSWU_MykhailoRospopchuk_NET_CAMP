using System.Text;


namespace exercise_1
{
    internal delegate void Reaction(in Person person);
    internal class People
    {
        public static DateOnly WAR_DATE = new DateOnly(2022, 02, 24);
        private List<Person> _people;
        public event Reaction WarBegin;
        public People()
        {
            _people = new List<Person>();
            
        }
        public void AddPerson(in Person person)
        {
            if (person != null)
            {
                person.DecrementAge += ChangeAge;
                
                if (person.BirthDate == WAR_DATE)
                {
                    WarBegin?.Invoke(person);
                }
                else
                {
                    //Check age only if we add Person to People
                    person.CheckAge();
                    _people.Add(person);
                }
            }
        }
        public void ChangeAge(Person person)
        {
            //Created new method in Person to awoid recursion with Age property
            person.DecreaseAge();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Person person in _people)
            {
                sb.Append(person.ToString() + "\n");
            }
            return sb.ToString();
        }
    }
}
