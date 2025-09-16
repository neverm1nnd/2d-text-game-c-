using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Spikes : AbstractObject
    {
        private bool active;

        public Spikes(string name, string description) : base(name, description)
        {
            this.active = false;
        }

        public void Toggle()
        {
            active = !active;
            // Console.WriteLine($"{name} is now {(active ? "active" : "inactive")}");
        }

        public override void Update()
        {
            if (active && currentRoom != null)
            {
                var princess = currentRoom.GetObjects().FirstOrDefault(obj => obj is Princess) as Princess;
                if (princess != null)
                {
                    princess.ChangeHealth(-100);
                }
            }
        }

        public bool IsActive()
        {
            return active;
        }
    }
}
