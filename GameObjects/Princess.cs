using Assignment3.GameWorld;
using Assignment3.GameActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Princess : AbstractActor
    {
        private IItem backpack;
        private IAction lastAction;

        public Princess(string name, string description) : base(name, description)
        {
            backpack = null;
            lastAction = null;
        }

        public void AddToBackPack(IItem toBeAdded)
        {
            if (backpack != null && currentRoom != null)
            {
                currentRoom.AddToRoom(backpack as AbstractObject);
            }
            backpack = toBeAdded;
        }

        public void EmptyBackPack()
        {
            if (backpack != null && currentRoom != null)
            {
                currentRoom.AddToRoom(backpack as AbstractObject);
                backpack = null;
            }
        }

        public override void ChangeHealth(int delta)
        {
            base.ChangeHealth(delta);
            if (health <= 0)
            {
                World world = currentRoom.GetWorld();
                world.SetLoss();
            }
        }

        public void MoveToRoom(Room newRoom)
        {
            if (currentRoom != null)
            {
                currentRoom.RemoveFromRoom(this);
                if (backpack != null)
                {
                    currentRoom.RemoveFromRoom(backpack as AbstractObject);
                }
            }
            newRoom.AddToRoom(this);
            if (backpack != null)
            {
                newRoom.AddToRoom(backpack as AbstractObject);
            }
            currentRoom = newRoom;
        }

        public void ProcessInput(string userInput)
        {
            var parts = userInput.Split(' ');
            var command = parts[0].ToLower();
            string argument = null;

            if (parts.Length > 1)
            {
                argument = string.Join(' ', parts.Skip(1));
            }

            IAction action = null;

            if (command == "exit")
            {
                action = new Exit();
            }
            else if (command == "check" && argument == "bag")
            {
                action = new CheckBag();
            }
            else if (command == "inspect" && argument != null)
            {
                var obj = currentRoom.GetObjectWithName(argument) ?? (backpack as AbstractObject);
                if (obj != null)
                {
                    action = new Inspect(obj);
                }
            }
            else if (command == "kiss")
            {
                var prince = currentRoom.GetObjects().OfType<IPrince>().FirstOrDefault(p => (p as AbstractObject)?.GetName() == argument);
                if (prince != null)
                {
                    action = new Kiss(prince);
                }
            }
            else if (command == "look" && argument == "around")
            {
                action = new LookAround();
            }
            else if (command == "move")
            {
                Directions parsedDirection;
                if (Enum.TryParse(argument, true, out parsedDirection))
                {
                    action = new Move(parsedDirection);
                }
            }
            else if (command == "pick" && argument.StartsWith("up "))
            {
                var item = currentRoom.GetObjectWithName(argument.Substring(3)) as IItem;
                if (item != null)
                {
                    action = new PickUp(item);
                }
            }
            else if (command == "put" && argument == "down")
            {
                action = new PutDown();
            }
            else if (command == "use")
            {
                var usable = currentRoom.GetObjectWithName(argument) as IUsable ?? (backpack as IUsable);
                if (usable != null)
                {
                    action = new Use(usable);
                }
            }

            if (action != null)
            {
                action.Execute(this);
                lastAction = action;
            }
            else
            {
                Console.WriteLine("I do not understand what you mean.");
            }
        }

        public override void Update()
        {
            if(currentRoom.GetObjects().OfType<Dragon>().Any() && lastAction is Move)
            {
                Console.WriteLine("Oh no! The dragon is here. Princess has to fight him.");
            }
            Console.WriteLine($"You are currently in {currentRoom.GetName()}.");
            Console.WriteLine("Enter command:");
            var userInput = Console.ReadLine();
            ProcessInput(userInput);
        }

        public void SetWorldDone()
        {
            var world = currentRoom.GetWorld();
            world.SetDone();
        }
        public Room GetCurrentRoom()
        {
            return currentRoom;
        }
        public IItem GetBackpack()
        {
            return backpack;
        }
    }
}
