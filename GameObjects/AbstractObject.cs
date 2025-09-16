using Assignment3.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public abstract class AbstractObject
    {
        protected string name;
        protected string description;
        protected Room currentRoom;

        protected AbstractObject(string name, string description)
        {
            this.name = name;
            this.description = description;
            currentRoom = null;
        }

        public void AddToRoom(Room room)
        {
            currentRoom = room;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDescription()
        {
            return description;
        }
        public string GetObjectWithName()
        {
            return name + " - " + description;
        }

        public virtual void Update() { }
    }
}