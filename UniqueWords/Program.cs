using System;

namespace UniqueWords
{
    class Program
    {
        static void Main(string[] args)
        {
            const string outputFile = "count.txt";
            
            try
            {
                if (args.Length == 0)
                {
                    throw new ArgumentException("Input file name not specified.");
                }
                
                var inputFile = args[0];
                var inputOutputFileHandler = new InputOutputFileHandler();
                inputOutputFileHandler.Handle(inputFile, outputFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}