using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.GameWorld;
using Assignment3.GameActions;

namespace Assignment3.GameObjects
{
    public class Torch : AbstractObject, IItem, IUsable
    {
        private bool wasUsed;
        private bool isActive;
        private int running;

        public Torch(string name, string description) : base(name, description)
        {
            wasUsed = false;
            isActive = false;
            running = 0;
        }

        public void Use()
        {
            if (!wasUsed)
            {
                wasUsed = true;
                isActive = true;
                running = 0;
            }
        }

        public bool WasUsed()
        {
            return wasUsed;
        }

        public bool IsActive()
        {
            return isActive;
        }

        public override void Update()
        {
            if (isActive)
            {
                running++;
                if (running >= 3)
                {
                    isActive = false;
                }
            }
        }
        public int GetRunning()
        {
            return running;
        }
    }
}
