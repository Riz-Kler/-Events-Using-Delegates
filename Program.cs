using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication25
{
    class Program
    {
        static void Main(string[] args)
        {
            // wire up
            var tower = new ClockTower();
            var riz = new Person("Riz", tower);
            var cindy = new Person("Cindy", tower);

            
            tower.ChimeSixAM();
            tower.ChimeFivePM();

            Console.ReadLine();

        }
    }

    public class Person
    {
        private string _name;
        private ClockTower _tower;

        public Person(string name, ClockTower tower)
        {
            _name = name;
            _tower = tower;

            // ad here any delegate, annonymous expression or lambda expression covered previously
            // create empty lambda expression

            _tower.Chime += (object sender, ClockTowerEventArgs args) =>
            {
                Console.WriteLine("{0} heard the clock chime.", _name);
                switch (args.Time)
                {
                    case 6: Console.WriteLine("{0} is waking up.", _name);
                        break;
                    case 17: Console.WriteLine("{0} is going home.", _name);
                        break;
                }
            };
        }
    }

    public class ClockTowerEventArgs : EventArgs
    {
        public int Time { get; set; }
    }

    public delegate void ChimeEventHandler(object sender, ClockTowerEventArgs args);
    
    public class ClockTower
    {
        
        public event ChimeEventHandler Chime;

        public void ChimeFivePM()
        {
            Chime(this, new ClockTowerEventArgs{ Time = 17});
    }

        
        public void ChimeSixAM()
        {
            Chime(this, new ClockTowerEventArgs{ Time = 6});

        }
    }
}
