using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Sword : AbstractObject, IItem, IUsable
    {
        private int damage;

        public Sword(string name, string description, int damage) : base(name, description)
        {
            this.damage = damage;
        }

        public void Use()
        {
            if (currentRoom != null)
            {
                var enemy = currentRoom.GetObjects()
                               .OfType<Dragon>()
                               .FirstOrDefault(dragon => dragon.GetName() == "Smaug");
                if (enemy != null)
                {
                    enemy.ChangeHealth(-damage);
                }
            }
        }

        public bool WasUsed()
        {
            return false;
        }
    }
}
