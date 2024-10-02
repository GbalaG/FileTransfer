using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Problem_Sloving.Problems
{
    internal class FileOperations
    {
        public void CreateTextFile()
        {
            string filePath = @"D:\Learning\test.txt";
            string data = "ABCD";
            File.WriteAllText(filePath, data);
            Console.WriteLine("File is created..");
        }

        // 5 Sec
        public async void CreateTextFile_With_Async()
        {
            try
            {
                DateTime startDateTime = DateTime.Now;
                Console.WriteLine("File creation started at : " + startDateTime);
                string filePath = @"D:\Learning\1GB_Txt.txt";
                string newFilePath = @"D:\Learning\Test.txt";
                var fileData = File.ReadAllBytes(filePath);
                File.WriteAllBytesAsync(newFilePath, fileData);
                DateTime endDateTime = DateTime.Now;
                Console.WriteLine("File created at : " + endDateTime);
                Console.WriteLine("===> Time Taken is : " + endDateTime.Subtract(startDateTime).TotalSeconds + " Sec");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //15 - 20 Sec
        public async void CreateTextFile_By_Lines_With_Parallel_ForEach()
        {
            try
            {
                DateTime startDateTime = DateTime.Now;
                Console.WriteLine("File creation started at : " + startDateTime);
                string filePath = @"D:\Learning\2GB_Txt.txt";
                string newFilePath = @"D:\Learning\Test.txt";

                var lines = File.ReadAllLines(filePath);
                var processedLines = new ConcurrentBag<string>();
                //Console.WriteLine("Read All Lines at : " + DateTime.Now);
                Parallel.ForEach(lines, line =>
                {
                    processedLines.Add(line);
                });
                //Console.WriteLine("Parallel ForEach at : " + DateTime.Now);

                File.WriteAllLines(newFilePath, processedLines);
                //Console.WriteLine("Write All Lines at : " + DateTime.Now);

                DateTime endDateTime = DateTime.Now;
                Console.WriteLine("File created at : " + endDateTime);
                Console.WriteLine("===> Time Taken is : " + endDateTime.Subtract(startDateTime).TotalSeconds + " Sec");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //25 - 30 Sec
        public async void CreateTextFile_By_Bytes_With_Parallel_ForEach()
        {
            try
            {
                DateTime startDateTime = DateTime.Now;
                Console.WriteLine("File creation started at : " + startDateTime);
                string filePath = @"D:\Learning\1GB_Txt.txt";
                string newFilePath = @"D:\Learning\Test.txt";

                var lines = File.ReadAllBytes(filePath);
                var processedLines = new ConcurrentBag<byte>();
                //Console.WriteLine("Read All Lines at : " + DateTime.Now);
                Parallel.ForEach(lines, line =>
                {
                    processedLines.Add(line);
                });
                //Console.WriteLine("Parallel ForEach at : " + DateTime.Now);

                byte[] data = new byte[] { };
                foreach (byte line in processedLines)
                {
                    data.Append(line);
                }
                //Console.WriteLine("Create byte[] data at : " + DateTime.Now);
                File.WriteAllBytes(newFilePath, data);
                //Console.WriteLine("Write All Lines at : " + DateTime.Now);

                DateTime endDateTime = DateTime.Now;
                Console.WriteLine("File created at : " + endDateTime);
                Console.WriteLine("===> Time Taken is : " + endDateTime.Subtract(startDateTime).TotalSeconds + " Sec");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void CreateTextFile_By_Lines_With_MemoryStream()
        {
            try
            {
                DateTime startDateTime = DateTime.Now;
                Console.WriteLine("File creation started at : " + startDateTime);
                string filePath = @"D:\Learning\2GB_Txt.txt";
                string newFilePath = @"D:\Learning\Test.txt";
                Regex startRegex = new Regex("^(Test|Demo)");

                using (var ms1 = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                {
                    using (var ms = new MemoryStream(File.ReadAllBytes(filePath)))
                    {
                        using (var sr = new StreamReader(ms))
                        using (var sw = new StreamWriter(ms1, Encoding.UTF8))
                        {
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();
                                if (startRegex.IsMatch(line, 0))
                                {
                                    //Console.WriteLine(line);
                                    sw.WriteLine(line);
                                }
                            }
                            sw.Flush();
                        }
                    }
                }

                DateTime endDateTime = DateTime.Now;
                Console.WriteLine("File created at : " + endDateTime);
                Console.WriteLine("===> Time Taken is : " + endDateTime.Subtract(startDateTime).TotalSeconds + " Sec");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CreateTextFile_By_Lines_With_MemoryStream_Chunks()
        {
            try
            {
                DateTime startDateTime = DateTime.Now;
                Console.WriteLine("File creation started at : " + startDateTime);
                string filePath = @"D:\Learning\2GB_Txt.txt";
                Regex startRegex = new Regex("^(Test|Demo)");
                int buffer = 100000; 

                using (var sr = new StreamReader(filePath, Encoding.UTF8, true, buffer))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (startRegex.IsMatch(line, 0))
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                DateTime endDateTime = DateTime.Now;
                Console.WriteLine("File created at : " + endDateTime);
                Console.WriteLine("===> Time Taken is : " + endDateTime.Subtract(startDateTime).TotalSeconds + " Sec");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public async Task CreateTextFile_ByAsync_Lines_With_MemoryStream_Chunks()
        {
            DateTime startDateTime = DateTime.Now;
            Console.WriteLine("File creation started at : " + startDateTime);
            string filePath = @"D:\Learning\2GB_Txt.txt";
            Regex startRegex = new Regex("^(Test|Demo)");
            int buffer = 100000;

            await ReadMatchingLinesAsync(filePath, startRegex, buffer, startDateTime);
        }

        private static async Task ReadMatchingLinesAsync(string filePath, Regex regex, int buffer,DateTime startDateTime)
        {
            using (var sr = new StreamReader(filePath, Encoding.UTF8, true, buffer))
            {
                while (!sr.EndOfStream) // Loop until the end of the stream
                {
                    string line = await sr.ReadLineAsync(); // Read a line from the file asynchronously
                    if (regex.IsMatch(line)) // Check if the line matches the regex
                    {
                        Console.WriteLine(line); // Output the matching line
                    }
                }
            }


            DateTime endDateTime = DateTime.Now;
            Console.WriteLine("File created at : " + endDateTime);
            Console.WriteLine("===> Time Taken is : " + endDateTime.Subtract(startDateTime).TotalSeconds + " Sec");
        }
    }
}
