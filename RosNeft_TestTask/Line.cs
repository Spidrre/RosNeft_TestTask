using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosNeft_TestTask
{
    public class Line
    {
        public MyPoint p1 { get; private set; }
        public MyPoint p2 { get; private set; }
        public bool inArea { get; set; }

        public Line(MyPoint _p1, MyPoint _p2)
        {
            this.p1 = _p1;
            this.p2 = _p2;
            inArea = false;
        }
    }
}
