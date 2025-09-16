using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public interface IUsable
    {
        public void Use();

        public bool WasUsed();
    }
}
