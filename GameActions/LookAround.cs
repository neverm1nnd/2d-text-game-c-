using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class LookAround : IAction
    {
        public LookAround() { }

        public void Execute(AbstractActor actor)
        {
            if (actor is Princess princess)
            {
                var room = actor.GetCurrentRoom();
                Console.WriteLine(room.GetDescription());

                var backpackItem = princess.GetBackpack() as AbstractObject;
                var backpackItemName = backpackItem?.GetName();

                var objectNames = room.GetObjectNames()
                                      .Where(name => name != princess.GetName() && 
                                                     name != backpackItemName)
                                      .ToList();

                if (objectNames.Any())
                {
                    Console.WriteLine("You see: " + string.Join(" ", objectNames));
                }
                else
                {
                    Console.WriteLine("You don’t see anything.");
                }
            }
        }
    }
}
