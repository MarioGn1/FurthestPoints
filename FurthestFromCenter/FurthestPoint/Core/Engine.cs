using FurthestPoint.Core.Contracts;
using FurthestPoint.IO;
using FurthestPoint.IO.Contracts;
using System;
using System.IO;
using System.Text.RegularExpressions;

using static FurthestPoint.Utils.Messages.AppConstants;

namespace FurthestPoint.Core
{
    internal class Engine : IEngine
    {
        private IWriter consoleWriter;
        private IWriter fileWriter;
        private IReader consoleReader;
        private IReader fileReader;
        private IController controller;

        public Engine()
        {
            this.consoleWriter = new ConsoleWriter();
            this.fileWriter = new FileWriter();
            this.consoleReader = new ConsoleReader();
            this.fileReader = new FileReader();
            this.controller = new Controller();
        }
        public void Run()
        {
            string inputPath = Path.Combine(STORAGE, INPUT_FILE);
            string destPath = Path.Combine(STORAGE, OUTPUT_FILE);
            string inputText = fileReader.Read(inputPath);

            try
            {
                MatchCollection matches = controller.GetPointsMatches(inputText);
                controller.SearchFurthestPoints(matches);                
            }
            catch (Exception e)
            {
                consoleWriter.Write(e.Message);
                fileWriter.Write(e.Message, destPath);
                Environment.Exit(0);
            }
            string searchResult = controller.Report();

            consoleWriter.Write(searchResult);
            fileWriter.Write(searchResult, destPath);
            consoleWriter.Write(EXIT_WARNING_MSG);
            consoleReader.Dispose();
        }
    }
}
