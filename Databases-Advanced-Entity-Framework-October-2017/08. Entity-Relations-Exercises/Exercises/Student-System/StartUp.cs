﻿namespace P01_StudentSystem
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new StudentSystemContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}