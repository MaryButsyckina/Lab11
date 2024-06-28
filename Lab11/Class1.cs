using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab1
{
    abstract class Product
    {
        //fields
        public string name;
        public int id;
        public string product_type;

        //constructors
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
        } //default constructor

        //getters
        public string GetName() { return name; }
        public int GetId() { return id; }
        public string GetProductType() { return product_type; }

        //setters
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

        //virtual method, prints the product info
        virtual public void Print()
        {
            Console.WriteLine("Name: {0}; Id: {1}; Type: {2}", name, id, product_type);
        }
    }

    class Detail : Product
    {
        //constructors
        public Detail() : base() { } //dafault constructor
        public Detail(string name, int id, string type) : base(name, id, type)
        { }

        //override method Print
        public override void Print()
        {
            base.Print();
        }
    }

    interface IEquipment
    {
        void AddEquipment(Detail detail); //add detail
        void AddEquipment(string name, int id, string type); //construct and add detail
        void ClearEquipment(); //clear equipmnet list
        void RemoveEquipment(Detail detail); //remove exact detail
    }

    class Furniture : Product, IEquipment
    {
        //fields
        public List<Detail> equipment; 

        //constructors
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

        //override method Print
        public override void Print()
        {
            Console.WriteLine("Name: {0}; Id: {1}; Type: {2}", GetName(), GetId(), GetProductType());
            Console.WriteLine("Equipment: ");
            foreach (Detail item in equipment) { Console.WriteLine(item.GetName()); };
        }

        //setter and getter for equipmnet
        public void SetEquipment(List<Detail> dd) 
        { 
            equipment = new List<Detail>();
            foreach (Detail item in dd)
            {
                equipment.Add(item);
            }
        }
        public List<Detail> GetEquipment() { return equipment; }

        //IEquipmnet methods
        public void ClearEquipment() { equipment.Clear(); }
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
