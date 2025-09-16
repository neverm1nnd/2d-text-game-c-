using Assignment3.GameObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameWorld
{
    public class World
    {
        private List<Room> map;
        private bool won;
        private bool done;
        private bool lost;

        private ObjectFactory factory;

        public World(string mapPath)
        {
            won = false;
            done = false;
            lost = false;
            map = new List<Room>();
            factory = new ObjectFactory();
            LoadMap(mapPath);
        }

        public void SetWin()
        {
            won = true;
            done = true;
        }

        public void SetDone()
        {
            done = true;
        }

        public void SetLoss()
        {
            lost = true;
            done = true;
        }

        public Room GetRooms()
        {
            return map[0];
        }
        public void RunGame()
        {
            while (!won && !done && !lost)
            {
                foreach (Room room in map)
                {
                    foreach (AbstractObject obj in room.GetObjects().GetRange(0, room.GetObjects().Count))
                    {
                        obj.Update();
                    }
                }
            }

            if (won)
            {
                Console.WriteLine("YOU WIN!");
            }
            if (lost)
            {
                Console.WriteLine("YOU LOSE!");
            }
        }

        public void LoadMap(string mapPath)
        {
            var jsonData = File.ReadAllText(mapPath);
            var jsonArray = JArray.Parse(jsonData);

            var rooms = new List<Room>();
            var spikesMap = new Dictionary<string, Spikes>();

            foreach (var roomData in jsonArray)
            {
                var roomName = roomData["name"].ToString();
                var description = roomData["description"].ToString();
                var roomType = roomData["type"].ToString();
                Room room;

                if (roomType == "DarkRoom")
                {
                    room = new DarkRoom(roomName, description, this);
                }
                else
                {
                    room = new Room(roomName, description, this);
                }

                rooms.Add(room);
                map.Add(room);

                // Console.WriteLine($"Created room: {roomName}");
            }

            // Connect rooms
            for (int i = 0; i < jsonArray.Count; i++)
            {
                var roomData = jsonArray[i];
                var room = rooms[i];

                if (roomData["north"] != null)
                {
                    var northIndex = roomData["north"].ToObject<int>() - 1;
                    if (northIndex >= 0 && northIndex < rooms.Count)
                    {
                        room.AddNeighbor(rooms[northIndex], Directions.NORTH);
                        // Console.WriteLine($"Connected room {room.GetName()} to the north room {rooms[northIndex].GetName()}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Room index {northIndex + 1} not found for north neighbor of room {room.GetName()}");
                    }
                }
                if (roomData["east"] != null)
                {
                    var eastIndex = roomData["east"].ToObject<int>() - 1;
                    if (eastIndex >= 0 && eastIndex < rooms.Count)
                    {
                        room.AddNeighbor(rooms[eastIndex], Directions.EAST);
                        // Console.WriteLine($"Connected room {room.GetName()} to the east room {rooms[eastIndex].GetName()}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Room index {eastIndex + 1} not found for east neighbor of room {room.GetName()}");
                    }
                }
                if (roomData["south"] != null)
                {
                    var southIndex = roomData["south"].ToObject<int>() - 1;
                    if (southIndex >= 0 && southIndex < rooms.Count)
                    {
                        room.AddNeighbor(rooms[southIndex], Directions.SOUTH);
                        // Console.WriteLine($"Connected room {room.GetName()} to the south room {rooms[southIndex].GetName()}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Room index {southIndex + 1} not found for south neighbor of room {room.GetName()}");
                    }
                }
                if (roomData["west"] != null)
                {
                    var westIndex = roomData["west"].ToObject<int>() - 1;
                    if (westIndex >= 0 && westIndex < rooms.Count)
                    {
                        room.AddNeighbor(rooms[westIndex], Directions.WEST);
                        // Console.WriteLine($"Connected room {room.GetName()} to the west room {rooms[westIndex].GetName()}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Room index {westIndex + 1} not found for west neighbor of room {room.GetName()}");
                    }
                }
            }

            // Add objects to rooms
            for (int i = 0; i < jsonArray.Count; i++)
            {
                var roomData = jsonArray[i];
                var room = rooms[i];

                foreach (var objData in roomData["objects"])
                {
                    var actorType = objData["type"].ToString();
                    var name = objData["name"].ToString();
                    var description = objData["description"].ToString();
                    var obj = factory.CreateObject(actorType, name, description);
                    room.AddToRoom(obj);
                    // Console.WriteLine($"Added object {name} to room {room.GetName()}");

                    if (obj is Spikes spikes)
                    {
                        spikesMap[name] = spikes;
                    }
                }
            }

            for (int i = 0; i < jsonArray.Count; i++)
            {
                var roomData = jsonArray[i];
                var room = rooms[i];

                foreach (var objData in roomData["objects"])
                {
                    var name = objData["name"].ToString();
                    var obj = room.GetObjectWithName(name);

                    if (obj is Lever lever)
                    {
                        var spikesName = objData["spikes"].ToString();
                        if (spikesMap.TryGetValue(spikesName, out Spikes spikes))
                        {
                            lever.ConnectSpikes(spikes);
                            // Console.WriteLine($"Connected lever {name} to spikes {spikesName}");
                        }
                        else
                        {
                            Console.WriteLine($"Error: Spikes {spikesName} not found for lever {name}");
                        }
                    }
                }
            }
        }
    }
}
