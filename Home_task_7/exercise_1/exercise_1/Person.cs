

namespace exercise_1
{
    internal delegate void ChangingData(Person person);
    internal class Person
    {
        private string _name;
        private DateOnly _birthDate;
        private uint _age;
        public event ChangingData DecrementAge;
        public uint Age
        {
            get { return _age; }
            set
            {
                _age = value < 60 ? value : 0;
                //Call every time when change age of person
                CheckAge();
            }
        }

        public void CheckAge()
        {
            if (_age >= 18)
            {
                //If we add Person to People, we call this event
                DecrementAge.Invoke(this);
            }
        }
        public void DecreaseAge()
        {
            _age -= 1;
        }

        public DateOnly BirthDate
        {
            get { return _birthDate; }
        }
        public Person(DateOnly birthDate, string name = "", uint age = 0)
        {
            _birthDate = birthDate;
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"{_name} {_birthDate.ToString("dd.MM.yy")} {_age}";
        }
    }
}
