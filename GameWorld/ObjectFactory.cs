using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameWorld
{
    public class ObjectFactory
    {
        public ObjectFactory(){ }

        public AbstractObject CreateObject(string actorType, string name, string description)
        {
            switch (actorType.ToLower())
            {
                case "cage":
                    return new Cage(name, description);
                case "dragon":
                    return new Dragon(name, description);
                case "key":
                    return new Key(name, description);
                case "princess":
                    return new Princess(name, description);
                case "spikes":
                    return new Spikes(name, description);
                case "lever":
                    return new Lever(name, description, null);
                case "sword":
                    return new Sword(name, description, 50);
                case "torch":
                    return new Torch(name, description);
                default:
                    throw new ArgumentException($"Unknown actor type {actorType}");
            }
        }
    }
}
