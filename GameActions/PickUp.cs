using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class PickUp : IAction
    {
        private IItem toBePicked;

        public PickUp(IItem toBePickedUp)
        {
            toBePicked = toBePickedUp;
        }

        public void Execute(AbstractActor actor)
        {
            if (actor is Princess princess)
            {
                if (princess.GetBackpack() != null)
                {
                    Console.WriteLine("My backpack is full.");
                    return;
                }

                var currentRoom = princess.GetCurrentRoom();
                if (currentRoom.GetObjects().Contains(toBePicked as AbstractObject))
                {
                    princess.AddToBackPack(toBePicked);
                    currentRoom.RemoveFromRoom(toBePicked as AbstractObject);
                    // Console.WriteLine($"The princess picks up the {toBePicked.ToString()}.");
                }
                
                else
                {
                    Console.WriteLine("I do not understand what you mean.");
                }
            }
        }
    }
}
