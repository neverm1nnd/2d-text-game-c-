using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.GameWorld;

namespace Assignment3.GameObjects
{
    public class Dragon : AbstractActor
    {
        public Dragon(string name, string description) : base(name, description)
        {
        }

        public override void ChangeHealth(int delta)
        {
            base.ChangeHealth(delta);
            if (health <= 0 && currentRoom != null)
            {
                currentRoom.RemoveFromRoom(this);
                Console.WriteLine($"{name} was killed.");
            }
        }

        public override void Update()
        {
            if (currentRoom != null)
            {
                var princess = currentRoom.GetObjects().FirstOrDefault(obj => obj is Princess) as Princess;
                if (princess != null)
                {
                    princess.ChangeHealth(-20);
                    Console.WriteLine($"{name} attacks the princess, reducing her health by 20.");
                }
            }
        }

        public void GetDragonName()
        {
            Console.WriteLine("Smaug");
        }
        public int GetHealth()
        {
            return health;
        }
    }
}
