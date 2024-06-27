using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class Product
    {
        private string name;
        private int id;
        private string product_type;

        public Product(string name, int id, string type)
        {
            SetName(name);
            SetId(id);
            SetType(type);
        }
        public Product()
        {
            name = string.Empty;
            id = 0;
            product_type = string.Empty;
        }

        public string GetName() { return name; }
        public int GetId() { return id; }
        public string GetProductType() { return product_type; }

        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetId(int id)
        {
            if (id < 0) { throw new WrongIdException(); }
            this.id = id;
        }
        public void SetType(string type)
        {
            this.product_type = type;
        }

        virtual public void Print()
        {
            Console.WriteLine("Name: {0}; Id: {1}; Type: {2}", name, id, product_type);
        }
    }

    class Detail : Product
    {
        public Detail() : base() { }
        public Detail(string name, int id, string type) : base(name, id, type)
        { }

        public override void Print()
        {
            base.Print();
        }
    }

    interface IEquipment
    {
        void AddEquipment(Detail detail);
        void AddEquipment(string name, int id, string type);
        void ClearEquipment();
        void RemoveEquipment(Detail detail);
    }

    class Furniture : Product, IEquipment
    {
        private List<Detail> equipment;

        public Furniture(string name, int id, string type, List<Detail> equipment) : base(name, id, type)
        {
            this.equipment = equipment;
        }

        public Furniture(string name, int id, string type) : base(name, id, type)
        {
            this.equipment = new List<Detail>();
        }

        public Furniture(int id) : base()
        {
            this.SetId(id);
            this.equipment = new List<Detail>();
        }

        public Furniture() : base()
        {
            equipment = new List<Detail>();
        }

        public override void Print()
        {
            Console.WriteLine("Name: {0}; Id: {1}; Type: {2}", GetName(), GetId(), GetProductType());
            Console.WriteLine("Equipment: ");
            foreach (Detail item in equipment) { Console.WriteLine(item.GetName()); };
        }

        public void SetEquipment(List<Detail> dd) 
        { 
            equipment = new List<Detail>();
            foreach (Detail item in dd)
            {
                equipment.Add(item);
            }
        }
        public void ClearEquipment() { equipment.Clear(); }
        public List<Detail> GetEquipment() { return equipment; }
        public void AddEquipment(Detail detail) { equipment.Add(detail); }
        public void AddEquipment(string name, int id, string type)
        {
            equipment.Add(new Detail(name, id, type));
        }
        public void RemoveEquipment(Detail detail) { equipment.Remove(detail); }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Detail detail1 = new Detail("plank", 11, "detail");
    //        Detail detail2 = new Detail("screw", 12, "detail");

    //        List<Detail> details = new List<Detail>() { detail1, detail2 };

    //        Furniture furniture1 = new Furniture("table", 1, "table");
    //        Furniture furniture2 = new Furniture("table", 1, "table", details);
    //        Furniture furniture3 = new Furniture();

    //        furniture1.AddEquipment(detail1);
    //        furniture1.AddEquipment("TableLeg", 13, "TableLeg");

    //        detail1.Print();
    //        furniture1.Print();

    //    }
    //}
}
