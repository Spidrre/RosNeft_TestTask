using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosNeft_TestTask
{
    public sealed class SelectionArea
    {
        private static SelectionArea instance = null;

        public MyPoint p1 { get; private set; }
        public MyPoint p2 { get; private set; }
        public MyPoint p3 { get; private set; }
        public MyPoint p4 { get; private set; }

        private SelectionArea(MyPoint _p1, MyPoint _p4)
        {
            this.p1 = _p1; //top-left Point of rectangle
            this.p2 = new MyPoint(_p4.X, _p1.Y); //top-right Point of rectangle
            this.p3 = new MyPoint(_p1.X, _p4.Y); //bottom-left Point of rectangle
            this.p4 = _p4; //bottom-right Point of rectangle

        }

        public static SelectionArea getInstance(MyPoint _p1, MyPoint _p2)
        {
            if (instance == null)
                instance = new SelectionArea(_p1, _p2);
            return instance;
        }

        public void deleteInstance()
        {
            instance = null;
            p1 = null;
            p2 = null;
            p3 = null;
            p4 = null;
        }

        public void updatePoints(MyPoint _p1, MyPoint _p4)
        {
            this.p1 = _p1; //top-left Point of rectangle
            this.p2 = new MyPoint(_p4.X, _p1.Y); //top-right Point of rectangle
            this.p3 = new MyPoint(_p1.X, _p4.Y); //bottom-left Point of rectangle
            this.p4 = _p4; //bottom-right Point of rectangle
        }
    }
}
