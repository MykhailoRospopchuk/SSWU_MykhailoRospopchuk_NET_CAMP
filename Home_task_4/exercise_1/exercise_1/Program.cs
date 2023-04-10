using System.Text;

namespace exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            FileWorker.InitFile();

            //For convenience, text input takes place through a text file.
            //Which will be automatically created when the program is launched using the "FileWorker.InitFile()" method.
            //Enter text through a file or as shown below


            Console.WriteLine("Ukrainian examples");
            string input_text_ua = "Сонце почало (повертать) на вечірній круг!\n" +
                "Кайдашиха вийшла з хати і прикрила очі (долонею. Вона була вже не молода, але й не стара, висока, рівна, з довгастим лицем, з сірими очима, з тонкими губами та блідим лицем.\n" +
                "Маруся Кайдашиха замолоду довго) служила в дворі,\n" +
                "у пана? куди її взяли дівкою. Вона вміла дуже добре куховарить і ще й тепер її\n" +
                "брали до панів та до попів за куховарку на весілля, на хрестини та на храми?\n" +
                "Вона довго терлась коло панів і набралась од їх трохи панства. До неї прилипла якась облесливість у розмові й повага до панів.\n" +
                "Вона любила цілувать їх в руки, кланятись, підсолоджувала свою розмову з ними.\n" +
                "Попаді й небагаті панії частували її в покоях, садовили поруч з собою на стільці як потрібну людину.";
            FileWorker.WriteFile(input_text_ua); //Write text in file
            string[] text_ua = FileWorker.ReadFile(); //For example read text from file and save in variable
            FileWorker.PrintFile(); //Method for printing text from file
            TextParser.FindText(text_ua); //Method for finding and outputting to the console sentences that have text in parentheses

            Console.WriteLine("English examples");
            FileWorker.ClearFile();
            string input_text_eng = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.\n" +
                "Lorem Ipsum has been the industry's (standard dummy text ever since) the 1500s,\n" +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.\n" +
                "It was popularised in the (1960s with the release of Letraset sheets containing Lorem Ipsum passages,\n" +
                "and more recently with desktop publishing software like Aldus) PageMaker including versions of Lorem Ipsum.";
            FileWorker.WriteFile(input_text_eng);
            string[] text_eng = FileWorker.ReadFile();
            FileWorker.PrintFile();
            TextParser.FindText(text_eng);
        }
    }
}
