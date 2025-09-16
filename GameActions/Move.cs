using Assignment3.GameObjects;
using Assignment3.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class Move : IAction
    {
        private Directions direction;

        public Move(Directions direction)
        {
            this.direction = direction;
        }

        public void Execute(AbstractActor actor)
        {
            if (actor is Princess princess)
            {
                var currentRoom = princess.GetCurrentRoom();
                var newRoom = currentRoom.GetNeighbor(direction);

                if (newRoom == null)
                {
                    Console.WriteLine("I cannot go there.");
                    return;
                }

                var dragon = currentRoom.GetObjects().FirstOrDefault(obj => obj is Dragon);
                if (dragon != null)
                {
                    Console.WriteLine("The dragon prevents you from moving.");
                    return;
                }
                
                princess.MoveToRoom(newRoom);
            }
        }
    }
}
