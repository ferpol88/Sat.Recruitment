using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sat.Recruitment.Services.Helpers
{
    public static class FileHelper
    {
        public static StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
