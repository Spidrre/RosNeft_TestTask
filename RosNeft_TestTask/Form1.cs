using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RosNeft_TestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Line> lines;    // list for storing Lines
        private SelectionArea area;  // rectangle Area
        private MyPoint tmpPoint;    // temporary Point for creation of Line
        private MyPoint startPoint;  // starting Point to create Line between first and last Points
        private Rectangle areaRect;

        private void Form1_Load(object sender, EventArgs e)
        {
            lines = new List<Line>();
            tmpPoint = null;
            areaRect = new Rectangle();
            area = null;
        }

        private Point clickedPoint;
        private void pb_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            Point coordinates = this.PointToClient(Cursor.Position);
            var clickX = coordinates.X - this.pb.Location.X;
            var clickY = coordinates.Y - this.pb.Location.Y;
            clickedPoint = new Point(clickX, clickY);
            

            // if radioButton for Line creation is checked
            // add Line
            if (rbLine.Checked)
                if (mouseEventArgs.Button == MouseButtons.Left) // if we are creating new Lines
                {
                    if (tmpPoint == null) // if this is first point to be created for this loop
                    {
                        tmpPoint = new MyPoint(clickX, clickY);   // set tmpPoint
                        startPoint = new MyPoint(clickX, clickY); // set startPoint
                        pb.Invalidate(); // invalidate pictureBox and return
                        return; 
                    }
                    // else add new Line between tmpPoint and clickedPoint
                    lines.Add(new Line(tmpPoint, new MyPoint(clickX, clickY))); 

                    tmpPoint = new MyPoint(clickX, clickY); // clickedPoint is now tmpPoint
                }
                else if (mouseEventArgs.Button == MouseButtons.Right) // if we want to stop creating new Lines click RMB
                {
                    tmpPoint = null;
                    var indOfLastLine = lines.Count - 1;
                    if (startPoint != null)
                        lines.Add(new Line(lines[indOfLastLine].p2, startPoint)); // add new Line between last clicked Point and startPoint to finish loop
                    startPoint = null;
                }

            pb.Invalidate();
        }
        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            Point coordinates = this.PointToClient(Cursor.Position);
            var clickX = coordinates.X - this.pb.Location.X;
            var clickY = coordinates.Y - this.pb.Location.Y;
            clickedPoint = new Point(clickX, clickY); 
        }

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (rbSelectionArea.Checked)
            {
                if (e.Button != MouseButtons.Left) // check if wee are drawing Area
                    return;
                Point coordinates = this.PointToClient(Cursor.Position);
                var clickX = coordinates.X - this.pb.Location.X;
                var clickY = coordinates.Y - this.pb.Location.Y;
                Point tempEndPoint = new Point(clickX, clickY);
                // set Points for areaRectangle
                areaRect.Location = new Point(
                    Math.Min(clickedPoint.X, tempEndPoint.X),
                    Math.Min(clickedPoint.Y, tempEndPoint.Y));
                areaRect.Size = new Size(
                    Math.Abs(clickedPoint.X - tempEndPoint.X),
                    Math.Abs(clickedPoint.Y - tempEndPoint.Y));
            }
            pb.Invalidate();
        }

        private void btnClearLines_Click(object sender, EventArgs e)
        {
            // clear List, set tmpPoint to null
            lines.Clear();
            tmpPoint = null;
            pb.Invalidate();
        }

        private void btnDeleteArea_Click(object sender, EventArgs e)
        {
            // delete Area, set property inArea for each Line to false
            area.deleteInstance();
            areaRect = new Rectangle();
            foreach (Line l in lines)
            {
                l.inArea = false;
            }
            pb.Invalidate();
        }

        private void pb_Paint(object sender, PaintEventArgs e)
        {
            // visualisation
            Pen penDefaultLine = new Pen(Color.Blue);
            Pen penCollisionLine = new Pen(Color.Red);
            Brush brushPoint = new SolidBrush(Color.Blue);
            if (tmpPoint != null)
            {
                var pointRect = new Rectangle(tmpPoint.X, tmpPoint.Y, 4, 4);
                e.Graphics.DrawRectangle(penDefaultLine, pointRect);
                e.Graphics.FillRectangle(brushPoint, pointRect);
            }
            foreach (Line l in lines)
            {
                if (l.inArea) // if Line is in Area we paint it with red color
                    e.Graphics.DrawLine(penCollisionLine,
                    l.p1.X,
                    l.p1.Y,
                    l.p2.X,
                    l.p2.Y);
                else
                    e.Graphics.DrawLine(penDefaultLine,
                    l.p1.X,
                    l.p1.Y,
                    l.p2.X,
                    l.p2.Y);

                var point1Rect = new Rectangle(l.p1.X,
                    l.p1.Y, 4, 4);
                e.Graphics.DrawRectangle(penDefaultLine, point1Rect);
                e.Graphics.FillRectangle(brushPoint, point1Rect);

                var point2Rect = new Rectangle(l.p2.X,
                    l.p2.Y, 4, 4);
                e.Graphics.DrawRectangle(penDefaultLine, point2Rect);
                e.Graphics.FillRectangle(brushPoint, point2Rect);
            }

            if (areaRect != null && areaRect.Width > 0 && areaRect.Height > 0)
            {
                var penArea = new Pen(Color.Green);
                e.Graphics.DrawRectangle(penArea, areaRect);
                if (area == null)
                {
                    area = SelectionArea.getInstance(new MyPoint(areaRect.X, areaRect.Y),
                        new MyPoint(areaRect.X+areaRect.Width, areaRect.Y+areaRect.Height));
                }
                else
                    area.updatePoints(new MyPoint(areaRect.X, areaRect.Y),
                        new MyPoint(areaRect.X + areaRect.Width, areaRect.Y + areaRect.Height));
            }
        }

        private void btnAlgo_Click(object sender, EventArgs e)
        {
            // run algorithm for each line in List
            foreach (Line l in lines)
            {
                // if true, then Line within/intersects with Area
                bool if_hits = collision(l.p1.X, l.p1.Y, l.p2.X, l.p2.Y, area); 
                if (if_hits)
                    l.inArea = true; // set property inArea to be true
                
            }
            pb.Invalidate();
        }

        bool collision(int x1, int y1, int x2, int y2, SelectionArea sa)
        {
            // check if boundaries of Line lie within Area
            if (areaRect.Contains(x1, y1) || areaRect.Contains(x2, y2))
                return true;
            // variable equals TRUE if line collides with any side of area
            bool left = calcDirection(x1, y1, x2, y2, sa.p1.X, sa.p1.Y, sa.p3.X, sa.p3.Y);   // left side of area
            bool right = calcDirection(x1, y1, x2, y2, sa.p2.X, sa.p2.Y, sa.p4.X, sa.p4.Y);  // right side of area
            bool top = calcDirection(x1, y1, x2, y2, sa.p1.X, sa.p1.Y, sa.p2.X, sa.p2.Y);    // top side of area
            bool bottom = calcDirection(x1, y1, x2, y2, sa.p3.X, sa.p3.Y, sa.p4.X, sa.p4.Y); // bottom side of area

            // if any of bools are true, line collides with area
            if (left || right || top || bottom)
            {
                return true;
            }
            return false;
        }


        bool calcDirection(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            // calculate the direction of the lines
            // formula from 
            // https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection#Given_two_points_on_each_line
            float t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / ((x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4));
            float u = ((x1 - x3) * (y1 - y2) - (y1 - y3) * (x1 - x2)) / ((x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4));

            // if t and u are between 0-1, lines are colliding
            if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
            {
                return true;
            }
            return false;
        }
    }
}
