using System;
using System.IO;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //координаты и радиус окружности
            float Xc;
            float Yc;
            float r;

            //координаты точки
            float Xp;
            float Yp;

            //чтение инфы об окружности
            string[] lines = new string[2];

            int i = 0;

            foreach (string line in File.ReadLines(args[0]))
            {
                lines[i] = line;
                i++;
            }

            string[] coords = lines[0].Split(" ");

            Xc = float.Parse(coords[0]);
            Yc = float.Parse(coords[1]);
            r = float.Parse(lines[1]);

            //чтение инфы о точках
            i = 0;

            foreach (string line in File.ReadLines(args[1]))
            {
                string[] linesP = new string[100];

                linesP[i] = line;

                string[] coordsP = linesP[i].Split(" ");

                Xp = float.Parse(coordsP[0]);
                Yp = float.Parse(coordsP[1]);

                //определние позиции точки относительно окружности
                // 0 - на 
                // 1 - внутри
                // 2 - снаружи

                if (((Xp - Xc) * (Xp - Xc) + (Yp - Yc) * (Yp - Yc)) < r * r)
                {
                    Console.WriteLine("1");
                }
                else if (((Xp - Xc) * (Xp - Xc) + (Yp - Yc) * (Yp - Yc)) == r * r)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine("2");
                }

                i++;
            }
        }
    }
}
