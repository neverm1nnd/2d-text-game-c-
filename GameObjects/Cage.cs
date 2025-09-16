using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Cage : AbstractObject
    {
        private bool locked;
        private IPrince captive;

        public Cage(string name, string description) : base(name, description)
        {
            locked = true;
            captive = new FrogPrince("prince", "enchanted prince in frog form");
        }

        public void Open()
        {
            if (locked && currentRoom != null)
            {
                locked = false;
                currentRoom.AddToRoom(captive as AbstractActor);
            }
        }

        public bool IsLocked()
        {
            return locked;
        }
        public IPrince GetCaptive()
        {
            return captive;
        }
    }
}
