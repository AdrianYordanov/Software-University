namespace BashSoft.Static_data
{
    using System.IO;

    public static class SessionsData
    {
        private static string currentPath;

        public static string CurrentPath
        {
            get => currentPath;

            // ReSharper disable once ValueParameterNotUsed
            set => currentPath = Directory.GetCurrentDirectory();
        }
    }
}