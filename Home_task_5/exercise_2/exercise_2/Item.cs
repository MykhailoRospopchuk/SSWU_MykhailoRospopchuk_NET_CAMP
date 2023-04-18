//
using System.Text;

namespace exercise_2
{
    internal class Item
    {
        private bool _box;
        private bool _product_inside;
        private int _lenght;
        private int _heigth;
        private int _width;
        private List<Item> _items = new List<Item>();
        private string _title;

        public Item(bool box, string title, int lenght = 0, int heigth = 0, int width = 0)
        {
            _box = box;
            _lenght = lenght;
            _heigth = heigth;
            _width = width;
            _title = title;
        }

        public void CreatePath(string[] path, int i)
        {
            Item temp = null;
            if (i < path.Length)
            {
                if (!_items.Any(ite => ite.Title == path[i]))
                {
                    var result = this.PutItem(new Item(true, path[i]));
                    if (!result)
                    {
                        throw new Exception("A box can contain either product boxes or department boxes.\nYou cannot put a product and a department in the same box");
                    }
                    temp = _items.LastOrDefault();
                }
                else
                {
                    temp = _items.Find(ite => ite.Title == path[i]);
                }
                
                temp.CreatePath(path, ++i);
            }
        }

        public Item SetItemInDepart(string depart, Item income_item)
        {
            if (depart != "")
            {
                foreach (Item item in _items)
                {
                    if (item.Title == depart)
                    {
                        var result = item.PutItem(income_item);
                        if (!result)
                        {
                            throw new Exception("A box can contain either product boxes or department boxes.\nYou cannot put a product and a department in the same box");
                        }
                        return item;
                    }
                }
                foreach (Item item in _items)
                {
                    if (item._items.Count() != 0)
                    {
                        var result = item.SetItemInDepart(depart, income_item);
                        if (result != null)
                        {
                            return item;
                        }
                    }
                }
            }
            return null;
        }

        public bool PutItem(Item item)
        {
            if (!_box)
            {
                return false;
            }

            if (_items.Count() == 0)
            {
                _items.Add(item);
                _product_inside = !item.IsBox;
                return true;
            }
            else
            {
                if (item.IsBox && !_product_inside)
                {
                    _items.Add(item);
                    _product_inside = !item.IsBox;
                    return true;
                }
                else if (!item.IsBox && _product_inside)
                {
                    _items.Add(item);
                    _product_inside = !item.IsBox;
                    return true;
                }
            }
            return false;
        }

        public void CountMetrix()
        {
            CountHeight();
            CountWidth();
            CountLenght();
        }
        public int CountHeight()
        {

            if (_items.Count != 0)
            {
                _items.ForEach(item =>
                {
                    item.CountHeight();
                    
                });
                _heigth = _items.Sum(item => item.Heigth);
            }
            return _heigth;
        }
        public int CountWidth()
        {
            if (_items.Count != 0)
            {
                _items.ForEach(item =>
                {
                    item.CountWidth();
                });
                _width = _items.Max(item => item.Width);
            }
            
            return _width;
        }
        public int CountLenght()
        {

            if (_items.Count != 0)
            {
                _items.ForEach(item => item.CountLenght());
                _lenght = _items.Max(item => item.Lenght);
            }
            return _lenght;
        }

        public bool IsBox
        { get { return _box; } }

        public int Lenght
        {
            get { return _lenght; }
            set { _lenght = value; }
        }
        public int Heigth
        {
            get { return _heigth; }
            set { _heigth = value; }
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public string Title
        {
            get { return _title; } 
            set { _title = value; }
        }

        public string? Print(int i)
        {
            i += 1;
            CountMetrix();
            StringBuilder sb = new StringBuilder();
            string title = _box ? $"Department: {_title}" : $"Product: {_title}";
            sb.Append(title);
            sb.Append($"\tHeight: {_heigth}; Width: {_width}; Lenght: {_lenght}\n");
            _items.ForEach(item => sb.Append($"{new string('\t', i)}" + item.Print(i)));
            return sb.ToString();
        }
    }
}
