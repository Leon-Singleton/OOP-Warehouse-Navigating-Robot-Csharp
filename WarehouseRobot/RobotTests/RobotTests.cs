using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarehouseRobot;

namespace RobotTests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void TestRobotMovement()
        {
            //initialise test conditions
            WarehouseSize grid = new WarehouseSize(5, 5);
            Robot robot1 = new Robot(1, 2, 'N');
            String robotMovement1 = ("<^<^<^<^^");

            Robot robot2 = new Robot(3, 3, 'E');
            String robotMovement2 = ("^^>^^>^>>^");

            //Perform movement
            robot1.MoveRobot(robot1, grid, robotMovement1);
            robot2.MoveRobot(robot2, grid, robotMovement2);

            //Assert correct movement
            Assert.AreEqual("1 3 N", robot1.ToString());
            Assert.AreEqual("5 1 E", robot2.ToString());
        }
        [TestMethod]
        public void TestValidGrid()
        {
            //valid conditions
            Assert.IsTrue(InputValidation.ValidGrid("0 0"));
            Assert.IsTrue(InputValidation.ValidGrid("9 9"));
            Assert.IsTrue(InputValidation.ValidGrid("6 3"));

            //invalid conditions
            Assert.IsFalse(InputValidation.ValidGrid("axs 5 5"));
            Assert.IsFalse(InputValidation.ValidGrid("50"));
            Assert.IsFalse(InputValidation.ValidGrid("50"));
            Assert.IsFalse(InputValidation.ValidGrid("05"));
            Assert.IsFalse(InputValidation.ValidGrid("55"));
        }
        [TestMethod]
        public void TestRobotInput()
        {
            //valid conditions
            Assert.IsTrue(InputValidation.ValidRobotInput("0 0 S"));
            Assert.IsTrue(InputValidation.ValidRobotInput("9 9 E"));
            Assert.IsTrue(InputValidation.ValidRobotInput("6 3 N"));
            Assert.IsTrue(InputValidation.ValidRobotInput("2 1 W"));

            //invalid conditions
            Assert.IsFalse(InputValidation.ValidRobotInput("axs 5 5"));
            Assert.IsFalse(InputValidation.ValidRobotInput("0 0 Z"));
            Assert.IsFalse(InputValidation.ValidRobotInput("2 0 F"));
            Assert.IsFalse(InputValidation.ValidRobotInput("10 0 N"));
        }

        [TestMethod]
        public void TestRobotPosition()
        {
            //valid conditions
            WarehouseSize grid = new WarehouseSize(5, 7);
            Assert.IsTrue(InputValidation.ValidRobotPosition("2 3 S", grid));

            //invalid conditions
            Assert.IsFalse(InputValidation.ValidRobotPosition("2 8 N", grid));
            Assert.IsFalse(InputValidation.ValidRobotPosition("6 4 N", grid));
        }
        [TestMethod]
        public void TestMovementInput()
        {
            //valid conditions
            Assert.IsTrue(InputValidation.ValidRobotMovement("<>^"));
            Assert.IsTrue(InputValidation.ValidRobotMovement("<"));
            Assert.IsTrue(InputValidation.ValidRobotMovement(">"));
            Assert.IsTrue(InputValidation.ValidRobotMovement("<>>>^^^^>^^>^>>^"));

            //invalid conditions
            Assert.IsFalse(InputValidation.ValidRobotMovement(">se"));
            Assert.IsFalse(InputValidation.ValidRobotMovement("<se"));
            Assert.IsFalse(InputValidation.ValidRobotMovement("^se"));
            Assert.IsFalse(InputValidation.ValidRobotMovement("d<>>>df^^^^>^^>^>>^er"));
        }
    }
}
