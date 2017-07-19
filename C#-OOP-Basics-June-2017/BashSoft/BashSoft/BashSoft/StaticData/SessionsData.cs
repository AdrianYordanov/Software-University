namespace BashSoft.StaticData
{
    using System.IO;

    public static class SessionsData
    {
        private static string currentPath = Directory.GetCurrentDirectory();

        // ReSharper disable once ConvertToAutoProperty
        public static string CurrentPath
        {
            get => currentPath;
            set => currentPath = value;
        }      
    }
}