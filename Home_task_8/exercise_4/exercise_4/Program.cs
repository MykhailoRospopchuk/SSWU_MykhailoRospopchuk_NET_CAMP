namespace exercise_4
{
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/event
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes

    // В С# викликати івент можна тільки в каласі де івент задекларовано.
    // У випадку коли в дочірньому класі є потреба викликати івент з батьківського класу -
    // необхідно виконати деякі надбудови в батьківському класі.
    // А саме - помістити виклик івенту в окремий метод-обгортку.
    // Для збереження принципів ООП такий метод-обгортку надають модифікатор доступу protected.
    // В такому випадку доступ до викликання методу будуть мати тільки класи наслідники.
    // Що забезпечить виклик івенту тільки у випадках коли це передбачено в дочірньому класі.
    // Це унеможливлює доступ до методу суб'єкту дочірнього класу.

    public class ShapeEventArgs : EventArgs
    {
        public ShapeEventArgs(double area)
        {
            NewArea = area;
        }

        public double NewArea { get; }
    }

    // Base class event publisher
    public abstract class Shape
    {
        protected double _area;

        public double Area
        {
            get => _area;
            set => _area = value;
        }

        // Івент-Хендлер виокристовується замість власного делегата
        // Не має різниці який делегат буде використано для подальшого декларування івенту.
        // ShapeEventArgs унаслідується від EventArgs який є в свою чергу базовим класом для всіх івентів.
        // EventHandler використовуєтся для можливості перевірки який об'єкт викликав івенті і яка додаткова інформація про подію.
        // В цьому випадку додаткова інформація про подіюповинна бути типу ShapeEventArgs.
        // Такий підхід дозволяє вибудовувати чітку структуру логіки і зменшує ризики виникнення помилки.
        // У великому проекті наявність класу EventArgs допомагає мінімізувати код, який потрібно змінити,
        // коли подія потребує додаткових даних у деяких випадках.
        public event EventHandler<ShapeEventArgs> ShapeChanged;

        // Метод-обгортка. 
        // Цей метод буде викликатись в дочірніх класах у випадку потреби івенту.
        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            ShapeChanged?.Invoke(this, e);
        }
    }

    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
            _area = 3.14 * _radius * _radius;
        }

        public void Update(double d)
        {
            _radius = d;
            _area = 3.14 * _radius * _radius;
            base.OnShapeChanged(new ShapeEventArgs(_area)); 
            // або виконати викликання методу-обгортки безпосередньо тут
            // base.OnShapeChanget(new ShapeEventArgs(_area));
            // При потребі виконання додаткової логіки в дочірньому класі - необхідно виконувати перевизначення методу-обгортки 
        }

        // Перевизначення методу-обгортки виконують для збереження поліморфізму
        // в залежності від потреб конкретної програми виконати раннє або пізнє зв'язування.
        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            Console.WriteLine();
            base.OnShapeChanged(e);
        }
    }

    // Represents the surface on which the shapes are drawn
    // Subscribes to shape events so that it knows
    // when to redraw a shape.
    public class ShapeContainer
    {
        private readonly List<Shape> _list;

        public ShapeContainer()
        {
            _list = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            _list.Add(shape);

            // Виконуємо підписку на івент через публічний доступ в батьківському класі.
            shape.ShapeChanged += HandleShapeChanged;
        }

        private void HandleShapeChanged(object sender, ShapeEventArgs e)
        {
            if (sender is Shape shape)
            {
                Console.WriteLine($"Received event. Shape area is now {e.NewArea}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var circle = new Circle(54);
            var container = new ShapeContainer();

            container.AddShape(circle);

            // Викликаємо метод оновлення в дочірньому класі.
            // В якому викликається метод-обгортку виклику івенту з батьківського класу
            // Таким чином збережено поліморфізм і принцип інкапсуляції.
            circle.Update(57);


            // виконати підписку на івент можна завдяки публічності.
            circle.ShapeChanged += (object sender, ShapeEventArgs e) => { Console.WriteLine("Hello event"); };

            circle.Update(7);

            Console.WriteLine("End");
            Console.ReadKey();

        }
    }
}
/* Вивід програми в консоль: 
    Hello, World!
    Received event. Shape area is now 10201,86
    Received event. Shape area is now 153,86
    Hello event
    End
*/