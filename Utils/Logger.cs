using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChat_NameChecker.Utils
{
    internal class Logger
    {
        public enum Type
        {
            Info,
            Error,
            Warn,
            Success,
        }
        public static void Log(object Object, Type LogType = Type.Info)
        {
            switch (LogType)
            {
                case Type.Info:
                    Write(ConsoleColor.Yellow, "Info", Object.ToString());
                    break;
                case Type.Error:
                    Write(ConsoleColor.Red, "Error", Object.ToString());
                    break;
                case Type.Warn:
                    Write(ConsoleColor.Yellow, "Warn", Object.ToString());
                    break;
                case Type.Success:
                    Write(ConsoleColor.Green, "Success", Object.ToString());
                    break;

            }
        }

        private static void Write(ConsoleColor TypeColor, string Type, string Text)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write("[");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write(DateTime.Now.ToString("HH:mm:ss"));
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write("] ");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write("[");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("KARMA");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write("] ");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write("[");
            System.Console.ForegroundColor = TypeColor;
            System.Console.Write(Type);
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write("] ");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine(Text);
        }

        public static void WriteToFile(string text, string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(text);
                sw.Close();
            }
        }
    }
}
