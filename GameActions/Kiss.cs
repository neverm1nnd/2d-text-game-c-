using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class Kiss : IAction
    {
        private IPrince toBeKissed;

        public Kiss(IPrince toBeKissed)
        {
            this.toBeKissed = toBeKissed;
        }

        public void Execute(AbstractActor actor)
        {
            if (actor is Princess princess)
            {
                var currentRoom = princess.GetCurrentRoom();
                var objects = currentRoom.GetObjects();
                if (objects.Contains(toBeKissed as AbstractObject))
                {
                    toBeKissed.Kissed();
                }
                else
                {
                    Console.WriteLine("I do not understand what you mean.");
                }
            }
        }
    }
}
