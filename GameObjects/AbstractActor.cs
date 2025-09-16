using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.GameWorld;

namespace Assignment3.GameObjects
{
    public abstract class AbstractActor : AbstractObject
    {
        protected int health;

        public AbstractActor(string name, string description) : base(name, description)
        {
            health = 100;
        }

        public virtual void ChangeHealth(int delta)
        {
            health = Math.Max(0, Math.Min(health + delta, 100));
        }

        public bool IsAlive()
        {
            return health > 0;
        }
        public Room GetCurrentRoom()
        {
            return currentRoom;
        }
    }
}
