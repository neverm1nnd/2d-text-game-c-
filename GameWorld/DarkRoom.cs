using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameWorld
{
    public class DarkRoom : Room
    {
        public DarkRoom(string roomName, string description, World world) : base(roomName, description, world) { }

        public override List<string> GetObjectNames()
        {
            var torch = objects.OfType<Torch>().FirstOrDefault(t => t.IsActive());
            if (torch != null)
            {
                return base.GetObjectNames();
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
