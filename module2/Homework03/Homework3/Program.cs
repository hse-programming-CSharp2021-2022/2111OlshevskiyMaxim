using System;
using static System.Console;

namespace Homework3
{
    public class Program
    {
        private static readonly Random s_random = new();

        private static void Main()
        {
            VideoFile videoFile = new("Отдельный видеофайл", 210, 550);
            WriteLine($"{videoFile}\n\nМассив видеофайлов:");
            VideoFile[] videoFiles = new VideoFile[s_random.Next(5, 16)];
            for (int i = 0; i < videoFiles.Length; i++)
            {
                videoFiles[i] = new(GetRandomName(), s_random.Next(60, 361), s_random.Next(100, 1001));
                WriteLine($"{i + 1}. {videoFiles[i]}");
            }
            WriteLine("\nВидеофайлы, размер которых больше, чем размер отдельного видеофайла:");
            for (int i = 0; i < videoFiles.Length; i++)
            {
                if (videoFiles[i].Size > videoFile.Size)
                    WriteLine($"{i + 1}. {videoFiles[i]}");
            }
        }

        public static string GetRandomName()
        {
            char[] name = new char[s_random.Next(2, 10)];
            for (int i = 0; i < name.Length; i++)
            {
                int randomCase = s_random.Next(1, 3);
                if (randomCase == 1)
                    name[i] = (char)s_random.Next('A', 'Z' + 1);
                else
                    name[i] = (char)s_random.Next('a', 'z' + 1);
            }
            return new(name);
        }
    }

    public class VideoFile
    {
        public string Name { get; private set; }
        public int Duration { get; private set; }
        public int Quality { get; private set; }
        public int Size => Duration * Quality;
        public VideoFile(string name, int duration, int quality) =>
            (Name, Duration, Quality) = (name, duration, quality);
        public override string ToString() =>
            $"Наименование видеофайла: {Name}; Длительность: {Duration} с; Качество: {Quality}; Размер: {Size}.";
    }
}
