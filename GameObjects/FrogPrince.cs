using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class FrogPrince : AbstractActor, IPrince
    {
        public FrogPrince(string name, string description) : base(name, description)
        {
        }

        public void Kissed()
        {
            if (currentRoom != null)
            {
                var humanPrince = new HumanPrince(name, "A handsome prince");
                currentRoom.RemoveFromRoom(this);
                currentRoom.AddToRoom(humanPrince);
            }
        }
    }
}
