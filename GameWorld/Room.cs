using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameWorld
{
    public class Room
    {
        protected string name;
        protected string description;
        protected World world;

        protected Room north;
        protected Room south;
        protected Room east;
        protected Room west;

        protected List<AbstractObject> objects;

        public Room(string roomName, string description, World world)
        {
            name = roomName;
            this.description = description;
            this.world = world;
            objects = new List<AbstractObject>();
        }

        public void AddToRoom(AbstractObject obj)
        {
            if (!objects.Contains(obj))
            {
                objects.Add(obj);
                obj.AddToRoom(this);
            }
        }

        public void RemoveFromRoom(AbstractObject obj)
        {
            if (objects.Contains(obj))
            {
                objects.Remove(obj);
            }
        }

        public void AddNeighbor(Room room, Directions direction)
        {
            switch (direction)
            {
                case Directions.NORTH:
                    north = room;
                    break;
                case Directions.SOUTH:
                    south = room;
                    break;
                case Directions.EAST:
                    east = room;
                    break;
                case Directions.WEST:
                    west = room;
                    break;
            }
        }

        public AbstractObject GetObjectWithName(string name)
        {
            return objects.FirstOrDefault(obj => obj.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public virtual List<string> GetObjectNames()
        {
            return objects.Select(obj => obj.GetName()).ToList();
        }

        public List<string> GetDirections()
        {
            List<string> directions = new List<string>();
            if (north != null) directions.Add("north");
            if (east != null) directions.Add("east");
            if (south != null) directions.Add("south");
            if (west != null) directions.Add("west");
            return directions;
        }

        public Room GetNeighbor(Directions direction)
        {
            return direction switch
            {
                Directions.NORTH => north,
                Directions.SOUTH => south,
                Directions.EAST => east,
                Directions.WEST => west,
                _ => null,
            };
        }

        public List<AbstractObject> GetObjects()
        {
            return objects;
        }

        public string GetName()
        {
            return name;
        }
        public string GetDescription()
        {
            return description;
        }
        public Room GetRoom()
        {
            return this;
        }
        public World GetWorld()
        {
            return world;
        }
    }
}
