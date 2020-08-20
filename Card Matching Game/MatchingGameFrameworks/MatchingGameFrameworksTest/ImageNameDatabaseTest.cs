using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatchingGameFrameworks;
using MatchingGameFrameworks.Exceptions;
using NUnit.Framework;
using System.IO;

//  C:\Test\Matching Game File Name Test

namespace MatchingGameFrameworksTest
{
    [TestFixture]
    class ImageNameDatabaseTest
    {
        ImageNameDatabase ind;

        [Test,Timeout(3000)]
        public void load_database()
        {
            ind = new ImageNameDatabase();
            ind.LoadList("C:\\Test\\Matching Game File Name Test");
            Assert.AreEqual("brains.jpg",ind.ImageName[0],"Fail to load image name");
            Assert.AreEqual("drunk.jpg", ind.ImageName[1], "Fail to load image name");
            Assert.AreEqual("game.png", ind.ImageName[2], "Fail to load image name");
        }

        [Test, Timeout(3000)]
        public void save_database()
        {
            ind = new ImageNameDatabase();
            ind.ImageName = new string[] {"brady.jpg","Brian.png","Card.jpg" };

            ind.SaveList("C:\\Test\\Matching Game File Name Test 2");

            if (!File.Exists("C:\\Test\\Matching Game File Name Test 2"))
            {
                Assert.Fail("Failed to save list");
            }

            ImageNameDatabase ind2 = new ImageNameDatabase();

            ind2.LoadList("C:\\Test\\Matching Game File Name Test 2");

            Assert.AreEqual("brady.jpg", ind2.ImageName[0], "Fail to load image name");
            Assert.AreEqual("Brian.png", ind2.ImageName[1], "Fail to load image name");
            Assert.AreEqual("Card.jpg", ind2.ImageName[2], "Fail to load image name");
        }


        [TearDown]
        public void TearDown()
        {
            if (File.Exists("C:\\Test\\Matching Game File Name Test 2"))
            {
                File.Delete("C:\\Test\\Matching Game File Name Test 2");
            }
        }
    }
}
