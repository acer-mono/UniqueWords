using System;
using System.IO;

namespace UniqueWords
{
    public class InputOutputFileHandler
    {
        private TextParser _textParser;
        
        public void Handle(string inputPath, string outputPath)
        {
            _textParser = new TextParser();
            
            EnsureFilesExist(new[] { inputPath });

            using var input = File.OpenText(inputPath);
            using var output = File.CreateText(outputPath);
            
            while (!input.EndOfStream)
            {
                var line = input.ReadLine();
                _textParser.Parse(line);
            }
            output.Write(_textParser);
            Console.WriteLine("Done!");
        }
        
        private static void EnsureFilesExist(string[] paths)
        {
            foreach (string path in paths)
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"File {path} not found");
                }
            }
        }
        
    }
}