using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class InterfaceProgramming
    {

        public static void test_8()
        {
            string mystr = "Hello";

            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();


            I1.CloneMe(mystr);
            I1.CloneMe(unixOS);
            I1.CloneMe(sqlConn);
            Console.ReadLine();
        }

        public static void test_9() {

            Traingle t = new OOP.Traingle();
            Console.WriteLine("Traingle points {0} ", t.Points);

            Hexagon1 hex = new Hexagon1();
            Console.WriteLine("Hexagon points: {0}",hex.Points);
            Console.ReadLine();
        }
    }



    public class I1
    {
        public static void CloneMe(ICloneable c)
        {
            object theClone = c.Clone();
            Console.WriteLine("Your clone is a : {0} ",theClone.GetType().Name);
        }
    }

    public interface IPointy
    {

        byte Points { get; }
        byte GetNumberOfPoints();
    }

    public class Pencil { }

    public class SwitchBlade { }
    
    public class Fork { } 

    public struct PitchFork { }

    public class Traingle :Shape,IPointy
    {
        public Traingle() { }

        public Traingle(string name) : base(name) { } 

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Triangle",PetName);
        }

        public byte Points
        {
            get { return 3; }
        }

        public byte GetNumberOfPoints()
        {
            return 3;
        }

    }

    public class Hexagon1:Shape,IPointy
    {
        public Hexagon1() { }

        public Hexagon1(string name):base(name)
        {
            PetName = name;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon",PetName);
        }

        public byte Points
        {
            get { return 6; }
        }

        public byte GetNumberOfPoints()
        {
            return 6;
        }


    }







}
