using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WarehouseRobot

{
    public class InputValidation
    {
        //Validates grid input so that it is entered in format "0-9 0-9"
        public static bool ValidGrid(string input)
        {
            var regex = new Regex(@"^[0-9][\ ][0-9]$");

            if (!regex.IsMatch(input))
            {
                return false;
            }
            return true;
        }

        //Validates robot position so that it is entered in format "0-9 0-9 N,E,S,W"
        public static bool ValidRobotInput(string input)
        {
            var regex = new Regex(@"^[0-9][\ ][0-9][\ ][NESW]$");

            if (!regex.IsMatch(input))
            {
                return false;
            }
            return true;
        }

        //Validates robot position so that it starts in a positon in the warehouse
        public static bool ValidRobotPosition(string input, WarehouseSize grid)
        {
            int inputWidth = (int)Char.GetNumericValue(input[0]);
            int inputHeight = (int)Char.GetNumericValue(input[2]);

            if (inputWidth > grid.Width | inputWidth < 0 | inputHeight > grid.Height | inputHeight < 0)
            {
                return false;
            }
            return true;
        }

        //Validates robot movement so that it only contains characters "<,>,^"
        public static bool ValidRobotMovement(string input)
        {
            var regex = new Regex(@"^[<>^]+$");

            if (!regex.IsMatch(input))
            {
                return false;
            }
            return true;
        }
    }
}
