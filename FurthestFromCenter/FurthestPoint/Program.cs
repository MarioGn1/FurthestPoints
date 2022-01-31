using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using FurthestPoint.Models;
using FurthestPoint.Core.Contracts;
using FurthestPoint.Core;

namespace FurthestPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
