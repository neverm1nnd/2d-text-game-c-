using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Lever : AbstractObject, IUsable
    {
        private bool active;
        private Spikes spikes;

        public Lever(string name, string description, Spikes spikes) : base(name, description)
        {
            this.active = true;
            // this.spikes = spikes;
            ConnectSpikes(spikes);
        }

        public void ConnectSpikes(Spikes spikes)
        {
            this.active = true;
            this.spikes = spikes;
            if (spikes != null)
            {
                spikes.Toggle();
                // Console.WriteLine($"{name} is now connected to {spikes.GetName()}");
            }
            // else
            // {
            //     Console.WriteLine($"{name} is not connected to any spikes.");
            // }
        }

        public void Use()
        {
            active = !active;
            if (spikes != null)
            {
                spikes.Toggle();
                // Console.WriteLine($"{name} has been used. Spikes are now {(spikes.IsActive() ? "active" : "inactive")}");
            }
            else
            {
                Console.WriteLine($"{name} is not connected to any spikes.");
            }
        }

        public bool WasUsed()
        {
            return false;
        }

        public bool IsActive()
        {
            return active;
        }
    }
}
