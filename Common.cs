using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Common
    {
       public static void test_1()
        {
            Car_1 obj = new Car_1("Frank",55,"Red");
            //Console.WriteLine("Name:{0} Speed:{1} Color:{2}",obj.PetName,obj.Speed,obj.Color);

            obj.DisplayStats();

            Console.ReadLine();
        }

        public static void test_2() {

            Car_1 obj = new Car_1("BMW", 45, "Blue");

            obj.Accelerate(10);
            Console.ReadLine();
        }

        public static void test_3() {

            Manager chcucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            chcucky.GiveBonus(300);
            chcucky.DisplayStats();
            Console.WriteLine();

            SalesPerson fred = new SalesPerson("Fred",43,93,3000,"932-32-3232",31);
            fred.GiveBonus(200);
            fred.DisplayStats();

            Console.ReadLine();
        }

        public static void test_4()
        {
            Hexagon hex = new Hexagon("Beth");

            hex.Draw();

            Circle c = new Circle("Cindy");
            c.Draw();

            Console.ReadLine();
        }

        public static void test_5()
        {
            Shape[] myShapes = { new Hexagon(),new Circle(),new Hexagon("Mick"),new Circle("Beth"),
            new Hexagon("Linda")};

            foreach (Shape c in myShapes)
            {
                c.Draw();
            }
            Console.ReadLine();

        }

        public static void test_6()
        {
            ThreeDCircle d = new ThreeDCircle();
            d.Draw();

            ((Circle)d).Draw();
            Console.ReadLine();
        }
    }

    public class Car_1
    {
        public Car_1() { }

        public Car_1(string name,int sp,string c) {
            PetName = name;
            Speed = sp;
            Color = c;
        }

        public const int MaxSpeed = 100;
        
        
        
        
          
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }

        private bool CarIsDead;

        private Radio theMusicBox = new Radio();




        public void DisplayStats()
        {
            Console.WriteLine("Car Name: {0}",PetName);
            Console.WriteLine("Speed: {0}",Speed);
            Console.WriteLine("Color: {0}",Color);
        }

        public void CrankTunes(bool state) {
            theMusicBox.TurnOn(state);
        }

        public void Accelerate(int delta) {

            if (CarIsDead)
                Console.WriteLine("{0} is out of order.....", PetName);
            else
            {
                Speed += delta;
                if (Speed >= MaxSpeed)
                {

                    CarIsDead = true;
                    Speed = 0;
                    Exception ex = new Exception(string.Format("{0} has overheated!", PetName));
                    Console.WriteLine(ex.Message);
                }
            else
              Console.WriteLine("=>CurrentSpeed={0} ", Speed);
            } 
        }
    }

    public class Radio
    {
        public void TurnOn(bool turnOn) {
            if (turnOn)
                Console.WriteLine("Jamming....");
            else
                Console.WriteLine("Stopped...");
        }
    }

    public class Employee
    {
        protected string empName;
        protected int empID;
        protected int empAge;
        protected float currPay;
        protected string empSSN;
        

        public Employee() { }

        public Employee(string fName,int ID,int eage,float p,string ssn) {
            Name = fName;
            EmpID = ID;
            Age = eage;
            Pay = p;
            SSN = ssn;
        }


        public string Name
        {
            get { return empName; }
            set { empName = value; }
        }

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        public int Age
        {
            get { return empAge; }
            set { empAge = value; }
        }

        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }

        public string SSN
        {
            get { return empSSN; }
            set { empSSN = value; }
        }


        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine("Name: {0}",Name);
            Console.WriteLine("ID: {0}",EmpID);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Pay: {0}",Pay);
            Console.WriteLine("SSN: {0}", SSN);

        } 



    }


    public class BenefitPackage
    {
        public enum BenefitPackageLevel
        {
            Standard, Gold, Platinum
        }



        public double ComputePayDeduction()
        {
            return 125.0;
        }
    }

    public class SalesPerson:Employee {

        public int SalesNumber { get; set; }

        public SalesPerson() { }

        public SalesPerson(string fName,int age, int empID,float currPay,string ssn,int numOfSales):
            base(fName,age,empID,currPay,ssn){

            SalesNumber = numOfSales;


        }

        public override void GiveBonus(float amount)
        {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
                salesBonus = 10;
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 100)

                    salesBonus = 15;
                else
                    salesBonus = 20;
            }
            base.GiveBonus(amount * salesBonus);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number Of Sales: {0}", SalesNumber);
           
        }
    }

    public class Manager:Employee {

        public int StockOptions { get; set; }
        public Manager() { }

        public Manager(string fName,int age,int empID,float currPay,string ssn,int numOfOpts):
            base(fName,age,empID,currPay,ssn)
        {
            StockOptions = numOfOpts;
        }

        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number of Stock Options: {0}", StockOptions);
        
        }




    }

    public abstract class Shape
    {

        public Shape(string name="NoName")
        {
            PetName = name;
        }

        public string PetName { get; set; }

        public abstract void Draw();

    }

    public class Circle:Shape
    {
        public Circle() { }

        public Circle(string name):base(name) {

        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle",PetName);
        }
    }

    public class Hexagon:Shape
    {

        public Hexagon() { }

        public Hexagon(string name):base(name) { }


        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon",PetName);
        } 
        
    }

    public class ThreeDCircle:Circle
    {
        public void Draw()
        {

            Console.WriteLine("Drawing a 3D Circle");
        }
    }




}
