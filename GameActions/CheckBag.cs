using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class CheckBag : IAction
    {
        public CheckBag() { }

        public void Execute(AbstractActor actor)
        {
            if (actor is Princess princess)
            {
                var backpackItem = princess.GetBackpack();
                if (backpackItem != null)
                {
                    Console.WriteLine($"The princess has {(backpackItem as AbstractObject).GetName()} in her backpack.");
                }
                else
                {
                    Console.WriteLine("The princess's backpack is empty.");
                }
            }
        }
    }
}
