using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//using Inputvalidation;

namespace WarehouseRobot
{
    public class MainProgram
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Input");

            //creates a warehouse object using the console input
            String gridInput = GridInput();
            WarehouseSize grid = new WarehouseSize((int)Char.GetNumericValue(gridInput[0]), (int)Char.GetNumericValue(gridInput[2]));

            //declares the number of robots, could be set using a console input
            int numRobots = 2;
            //An array to store the curernt position and orientation of each robot
            Robot[] robotObjects = new Robot[numRobots];
            //An array to store the movement sequence of each robot
            string[] movements = new string[numRobots];

            //Get robots starting positions and movement sequence
            for (int i = 0; i < numRobots; i++)
            {
                //creates a robot object using the console input
                string robotInput = RobotInput(grid);
                Robot robot = new Robot((int)Char.GetNumericValue(robotInput[0]), (int)Char.GetNumericValue(robotInput[2]), robotInput[4]);
                robotObjects[i] = robot;

                //gets the movement sequence from the input
                string robotMovement = MovementInput();
                movements[i] = robotMovement;
            }

            Console.WriteLine("Output");

            //move each robot and print final position and orientation of each robot
            for (int i = 0; i < numRobots; i++)
            {
                robotObjects[i].MoveRobot(robotObjects[i], grid, movements[i]);
                Console.WriteLine(robotObjects[i].ToString());
            }

            Console.ReadLine();
        }

        //Gets an input for the warehouse size
        static String GridInput()
        {
            //Get the grid dimensions from the input
            string gridInput = Console.ReadLine();
            //validate grid dimensions input
            while (!InputValidation.ValidGrid(gridInput))
            {
                Console.WriteLine("Invalid Grid Input, must be of format '0-9 0-9 e.g 5 5'");
                gridInput = Console.ReadLine();
            }
            return gridInput;
        }

        //Gets an input for the robot starting position and facing direction
        static String RobotInput(WarehouseSize grid)
        {
            string robotInput = Console.ReadLine();
            //validate robot's starting position is in the warehouse and the input
            while (!InputValidation.ValidRobotInput(robotInput) | !InputValidation.ValidRobotPosition(robotInput, grid))
            {
                if (!InputValidation.ValidRobotInput(robotInput))
                {
                    Console.WriteLine("Invalid Robot Position Input, must be of format '0-9 0-9 N,E,S,W e.g. 3 3 E'");
                }
                else
                {
                    Console.WriteLine("Invalid starting position, robot must start within the warehouse");
                }
                robotInput = Console.ReadLine();
            }
            return robotInput;
        }

        //Gets an input for a robots movement
        static String MovementInput()
        {
            string robotMovement = Console.ReadLine();
            //validate robot movement input
            while (!InputValidation.ValidRobotMovement(robotMovement))
            {
                Console.WriteLine("Invalid Robot Movement, must only contain following instructions '<,>,^ e.g. <<>^'");
                robotMovement = Console.ReadLine();
            }
            return robotMovement;
        }

    }
}
