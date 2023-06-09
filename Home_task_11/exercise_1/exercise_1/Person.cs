//For example created class Person with IConparable interface

namespace exercise_1
{

    internal class Person : IComparable
    {
        public string Name { get; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
        public int CompareTo(object? o)
        {
            if (o == null) return 1;

            if (o is Person person) return Age.CompareTo(person.Age);
            else throw new ArgumentException("Incorrect value");
        }

        public override string? ToString()
        {
            return $"Name: {Name,10}; Age: {Age,3}";
        }
    }
}
