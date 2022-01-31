namespace FurthestPoint.Utils.Messages
{
    internal static class AppConstants
    {
        public const string STORAGE = "Storage";
        public const string INPUT_FILE = "Coordinates.txt";
        public const string OUTPUT_FILE = "output.txt";
        public const string EXIT_WARNING_MSG = "Press any key to exit the program.";
        public const string NO_POINTS_EXCEPTION_MSG = "There are no Point(s) coordinates in the current document.";
        public const string REGEX = @"[pP]oint(\d+)[(]{1}([-]?\d+[.]*\d*[,]{1}\s?[-]?\d+[.]*\d*)[)]{1}";
    }
}
