using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOPProject
{
    [TestClass]
    public class FileOperations
    {

        
        public void DirectoryPath_Test(string path)
        {
         
                // ... Set to folder path we must ensure exists.
                try
                {
                    // ... If the directory doesn't exist, create it.
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
                catch (Exception)
                {
                    // Fail silently.
                }
            }

        [TestMethod]
        public void EnsurePathOfFileExists()
        {
            // Test the method.
            DirectoryPath_Test(@"C:\FileOperationTraining\MindMajix1.txt");
                Console.WriteLine("DONE");
            

        }
        [TestMethod]
        public void CREATEBLANKTextFile()
        {
            FileStream fs = new FileStream(@"C:\FileOperationTraining\MindMajix.txt", FileMode.Create);
            fs.Close();
            Console.Write("File has been created and the Path is D:\\MindMajix.txt");

        }

        [TestMethod]
        public void OPENTXTFile_WRITE()
        {
            FileStream fs = new FileStream(@"C:\FileOperationTraining\MindMajix.txt", FileMode.Append);
            byte[] bdata = Encoding.Default.GetBytes("Hello File Handling!");
            fs.Write(bdata, 0, bdata.Length);
            fs.Close();
            Console.WriteLine("Successfully saved file with data : Hello File Handling!");

        }

        [TestMethod]
        public void ReadData_TextFile()
        {
            string data;
            FileStream fsSource = new FileStream(@"C:\FileOperationTraining\MindMajix.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fsSource))
            {
                data = sr.ReadToEnd();
            }
            Console.WriteLine(data);

        }

        [TestMethod]
        public void StreamReader_ReadingTextfile()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(@"C:\FileOperationTraining\MindMajix.txt"))
                {
                    string line;

                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadToEnd()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
           
        }


        [TestMethod]
        public void StreamWriter_Reading_WritingFile()
        {
            string[] names = new string[] { "KrishnaGoute", "MindMajix" };

            string path = @"C:\FileOperationTraining\MindMajix.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {

                foreach (string s in names)
                {
                    sw.WriteLine(s);
                }
            }

            // Read and show each line from the file.
            string line = "";
            using (StreamReader sr = new StreamReader("names.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

        }

    }
}

