//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using BC_Functions;
//using NUnit.Framework;
////using Microsoft.Xna.Framework;

//namespace BC_FunctionsTest
//{
//    [TestFixture]
//    class PositionTest
//    {
//        Position2D position;
//        Position3D position3D;
//        //Vector2 vector2;

//        //private void SetUp()
//        //{
//        //    position = new Position2D(3, 5);
//        //    vector2 = new Vector2(2, 1);
//        //}

//        //[Test,Timeout(Shared.BASIC_TIMEOUT)]
//        //public void instantiate_position_one_parm()
//        //{
//        //    position = new Position2D(2);
//        //    Assert.AreEqual(2, position.X);
//        //    Assert.AreEqual(2, position.Y);
//        //}
//        [Test, Timeout(Shared.BASIC_TIMEOUT)]
//        public void instantiate_position_no_parm()
//        {
//            position = new Position2D();
//            Assert.AreEqual(0, position.X);
//            Assert.AreEqual(0, position.Y);
//        }
//        [Test, Timeout(Shared.BASIC_TIMEOUT)]
//        public void instantiate_position_two_parm()
//        {
//            position = new Position2D(5,3);
//            Assert.AreEqual(5, position.X);
//            Assert.AreEqual(3, position.Y);
//        }
//        [Test, Timeout(Shared.BASIC_TIMEOUT)]
//        public void set_position_one_parm()
//        {
//            position = new Position2D();
//            position.SetPosition(2);
//            Assert.AreEqual(2,position.X);
//            Assert.AreEqual(2, position.Y);
//        }
//        [Test, Timeout(Shared.BASIC_TIMEOUT)]
//        public void set_position_two_parm()
//        {
//            position = new Position2D();
//            position.SetPosition(5,3);
//            Assert.AreEqual(5, position.X);
//            Assert.AreEqual(3, position.Y);
//        }
//        [Test, Timeout(Shared.BASIC_TIMEOUT)]
//        public void position_to_string()
//        {
//            position = new Position2D(5,3);
//            Assert.AreEqual("(5,3)", position.ToString());
//        }
//        [Test, Timeout(Shared.BASIC_TIMEOUT)]
//        public void position_clone()
//        {
//            position = new Position2D(1,2);
//            Position2D newPosition = new Position2D(position);
//            Assert.AreEqual(1, newPosition.X);
//            Assert.AreEqual(2, newPosition.Y);
//            position.X = 3;
//            Assert.AreEqual(3, position.X);
//            Assert.AreEqual(1, newPosition.X,"did not clone");
//        }
//        [Test, Timeout(Shared.BASIC_TIMEOUT)]
//        public void area()
//        {
//            position = new Position2D(3, 5);
//            Assert.AreEqual(15, position.Area);
//        }

//        //[Test, Timeout(Shared.BASIC_TIMEOUT)]
//        //public void Vector2_to_Position2D()
//        //{
//        //    vector2 = new Vector2(5, 3);
//        //    position = (Position2D)vector2;
//        //    Assert.AreEqual(5, position.X);
//        //    Assert.AreEqual(3,position.Y);
//        //}
//        //[Test, Timeout(Shared.BASIC_TIMEOUT)]
//        //public void Position2D_to_Vector2()
//        //{
//        //    position = new Position2D(7, 4);
//        //    vector2 = (Vector2)position;
//        //    Assert.AreEqual(7, vector2.X);
//        //    Assert.AreEqual(4, vector2.Y);
//        //}
//        //[Test, Timeout(Shared.BASIC_TIMEOUT)]
//        //public void Position2D_plus()
//        //{
//        //    position = new Position2D(7, 3);
//        //    Position2D position2 = new Position2D(6, 2);
//        //    Position2D position3 = new Position2D();
//        //    position3 = position + position2;
//        //    Assert.AreEqual(13, position3.X);
//        //    Assert.AreEqual(5, position3.Y);
//        //}
//        //[Test, Timeout(Shared.BASIC_TIMEOUT)]
//        //public void Position2D_minus()
//        //{
//        //    position = new Position2D(7, 5);
//        //    Position2D position2 = new Position2D(5, 2);
//        //    Position2D position3 = new Position2D();
//        //    position3 = position - position2;
//        //    Assert.AreEqual(2, position3.X);
//        //    Assert.AreEqual(3, position3.Y);
//        //}
//        //[Test, Timeout(Shared.BASIC_TIMEOUT)]
//        //public void Position2D_multiply()
//        //{
//        //    position = new Position2D(3, 2);
//        //    position *= 5;
//        //    Assert.AreEqual(15, position.X);
//        //    Assert.AreEqual(10, position.Y);
//        //}
//    }
//}
