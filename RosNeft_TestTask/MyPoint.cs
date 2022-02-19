using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosNeft_TestTask
{
    public class MyPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public MyPoint(int _x, int _y)
        {
            this.X = _x;
            this.Y = _y;
        }
    }
}
