using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    public class Robot
    {
        private int yposition; // field
        public int Yposition // property
        {
            get { return yposition; }   // get method
            set { yposition = value; }  // set method
        }

        private char direction; // field
        public char Direction // property
        {
            get { return direction; }   // get method
            set { direction = value; }  // set method
        }

        private int xposition; // field
        public int Xposition // property
        {
            get { return xposition; }   // get method
            set { xposition = value; }  // set method
        }

        // Constructor that takes three argument:
        public Robot(int xposition, int yposition, char direction)
        {
            Xposition = xposition;
            Yposition = yposition;
            Direction = direction;
        }

        public override string ToString()
        {
            return Xposition + " " + Yposition + " " + Direction;
        }

        public void MoveRobot(Robot robot, WarehouseSize grid, String movement)
        {
            Char[] charArr = movement.ToCharArray();

            foreach (char ch in charArr)
            {
                //rotate left 90 degrees
                if (ch == '<')
                {
                    switch (robot.Direction)
                    {
                        case 'N':
                            robot.Direction = 'W';
                            break;
                        case 'E':
                            robot.Direction = 'N';
                            break;
                        case 'S':
                            robot.Direction = 'E';
                            break;
                        case 'W':
                            robot.Direction = 'S';
                            break;
                    }
                }
                //rotate right 90 degrees
                else if (ch == '>')
                {
                    switch (robot.Direction)
                    {
                        case 'N':
                            robot.Direction = 'E';
                            break;
                        case 'E':
                            robot.Direction = 'S';
                            break;
                        case 'S':
                            robot.Direction = 'W';
                            break;
                        case 'W':
                            robot.Direction = 'N';
                            break;
                    }
                }
                //move forward one space
                //validates out of bounds movement
                else if (ch == '^')
                {
                    switch (robot.Direction)
                    {
                        case 'N':
                            if (robot.Yposition + 1 > grid.Height)
                            {
                                break;
                            }
                            robot.Yposition += 1;
                            break;
                        case 'E':
                            if (robot.Xposition + 1 > grid.Width)
                            {
                                break;
                            }
                            robot.Xposition += 1;
                            break;
                        case 'S':
                            if (robot.Yposition - 1 < 0)
                            {
                                break;
                            }
                            robot.Yposition -= 1;
                            break;
                        case 'W':
                            if (robot.Xposition - 1 < 0)
                            {
                                break;
                            }
                            robot.Xposition -= 1;
                            break;
                    }
                }
            }
        }

    }
}
