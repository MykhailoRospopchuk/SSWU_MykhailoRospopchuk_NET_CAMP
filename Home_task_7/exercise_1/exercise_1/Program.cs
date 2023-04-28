
namespace exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            People people = new People();
            people.WarBegin += new Reaction(Print);
            people.WarBegin += new Reaction(PrintToFile);


            people.AddPerson(new Person(new DateOnly(2022, 02, 23), "Alex", 22));
            people.AddPerson(new Person(new DateOnly(2022, 02, 21), "Kaban", 24));
            people.AddPerson(new Person(new DateOnly(2022, 02, 24), "Liliia", 20));
            people.AddPerson(new Person(new DateOnly(2022, 02, 19), "Anton", 34));

            Console.WriteLine(people);
        }
        static void Print(in Person person)
        {
            Console.WriteLine($"We have the person {person}, whose date of the birth is equal to {People.WAR_DATE}");
        }
        static void PrintToFile(in Person person)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Log.txt");
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(person.ToString());
                sw.Close();
            }
            
            
        }
    }
}