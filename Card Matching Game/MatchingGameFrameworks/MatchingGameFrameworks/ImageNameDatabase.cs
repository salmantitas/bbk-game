using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MatchingGameFrameworks.Exceptions;

namespace MatchingGameFrameworks
{
    public class ImageNameDatabase
    {
        private string[] imageName;

        public string[] ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }

        public ImageNameDatabase()
        {
        }

        public ImageNameDatabase(string[] imageName)
        {
            this.imageName = imageName;
        }

        public void LoadList(string fileName)
        {
            StreamReader reader = null;
            int listCount = 0;
            try
            {
                reader = new StreamReader(fileName);
                while (!reader.EndOfStream)
                {
                    listCount++;
                    reader.ReadLine();
                }
                reader.Close();
                reader = new StreamReader(fileName);
                imageName = new string[listCount];
                for (int x = 0; x < listCount; x++)
                {
                    imageName[x] = reader.ReadLine();
                }
            }
            catch(Exception exception)
            {
                //throw new FailToLoadException(exception);
                throw exception;
            }
            finally
            {
                reader.Close();
            }
        }

        public void SaveList(string fileName)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName);
                for(int x=0;x<imageName.Length;x++)
                {
                    writer.WriteLine(imageName[x]);
                }
            }
            catch(Exception exception)
            {
                //throw new FailToSaveException(exception);
                throw exception;
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
