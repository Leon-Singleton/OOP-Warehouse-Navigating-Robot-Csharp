using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    public class WarehouseSize
    {

        private int width; // field
        public int Width // property
        {
            get { return width; }   // get method
            set { width = value; }  // set method
        }

        private int height; // field
        public int Height // property
        {
            get { return height; }   // get method
            set { height = value; }  // set method
        }

        //default constructor
        public WarehouseSize()
        {
            Height = 5;
            Width = 5;
        }

        // Constructor that takes two arguments:
        public WarehouseSize(int width, int height)
        {
            Height = height;
            Width = width;
        }
    }
}
