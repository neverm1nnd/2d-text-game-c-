using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Key : AbstractObject, IItem, IUsable
    {
        public Key(string name, string description) : base(name, description)
        {
        }

        public void Use()
        {
            if (currentRoom != null)
            {
                var cage = currentRoom.GetObjects().FirstOrDefault(obj => obj is Cage) as Cage;
                if (cage != null)
                {
                    cage.Open();
                }
            }
        }

        public bool WasUsed()
        {
            return false;
        }
    }
}
