using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TrianglesFromFile.Entities;
using TrianglesFromFile.Entities.Exceptions;

namespace TrianglesFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeaderMessage();

            try
            {
                List<Triangle> triangles = GetTrianglesFromFile();
                double biggestArea;
                CalculateArea(triangles, out biggestArea);
                DisplayBiggestArea(biggestArea);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error in format: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error found " + e.Message);
            }
            catch (MeasuresException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (TriangleMeasureException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ApplicationException e)
            {
                Console.WriteLine("Error unknown: " + e.Message);
            }

        }

        static void PrintHeaderMessage()
        {
            Console.WriteLine("Calculates triangles area and find out the biggest one");
            Console.WriteLine("");

        }

        static List<Triangle> GetTrianglesFromFile()
        {
            string resourcePath = GetFullResourcePath();
            List<Triangle> triangles = new List<Triangle>();

                using (StreamReader sr = new FileInfo(resourcePath).OpenText()) 
                {
                    while (!sr.EndOfStream)
                    {
                        string[] splittedLine = sr.ReadLine().Split(',');
                        string code = splittedLine[0];
                        double measureA = double.Parse(splittedLine[1], CultureInfo.InvariantCulture);
                        double measureB = double.Parse(splittedLine[2], CultureInfo.InvariantCulture);
                        double measureC = double.Parse(splittedLine[3], CultureInfo.InvariantCulture);
                        triangles.Add(new Triangle(code, measureA, measureB, measureC));
                    }
                }

            return triangles;
        }

        static void CalculateArea(List<Triangle> triangles, out double biggestArea)
        {
            biggestArea = 0.0;

            int count = 1;

            foreach (Triangle shape in triangles)
            {
                double area = shape.Area();
                Console.WriteLine($"Triangle #{count} area = {area.ToString("F4", CultureInfo.InvariantCulture)}");
                count++;
                if (area > biggestArea)
                {
                    biggestArea = area;
                }
            }

        }

        static void DisplayBiggestArea(double area)
        {
            Console.WriteLine($"The biggest area is: {area.ToString("F4", CultureInfo.InvariantCulture)}");
        }

        static string GetFullResourcePath()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var endPosition = path.IndexOf("bin");
            var basePath = path.Substring(0, endPosition);
            return basePath + "Resources\\triangle-measures.txt";
        }
    }
}
