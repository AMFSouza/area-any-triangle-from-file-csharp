using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TrianglesFromFile.Entities.Exceptions;

namespace TrianglesFromFile.Entities
{
    class Triangle
    {
        public string Code { get; set; }
        public double MeasureA { get; set; }
        public double MeasureB { get; set; }
        public double MeasureC { get; set; }

        public Triangle()
        {

        }

        public Triangle(string code, double a, double b, double c)
        {

            MeasureA = a;
            VerifyMeasure(a);
            MeasureB = b;
            VerifyMeasure(b);
            MeasureC = c;
            VerifyMeasure(c);

            if (!IsTriangle())
            {
                throw new TriangleMeasureException("Is not a triangle.");
                
            }

        }
        public double Area()
        {
            double p = Factor();
            return Math.Sqrt(p * (p - MeasureA) * (p - MeasureB) * (p - MeasureC));


        }

        private double Factor()
        {
            double p = (MeasureA + MeasureB + MeasureC) / 2;

            if (p <= 0.0)
            {
                throw new FactorZeroException("The factor p must be greater than zero");
            }

            return p;
        }
        public override string ToString()
        {
            return $"Area = {Area().ToString("F4", CultureInfo.InvariantCulture)}";
        }

        private bool IsTriangle()
        {
            bool measuresDefineTriangle = false;

            measuresDefineTriangle = MeasureA + MeasureB > MeasureC &&
                                     MeasureA + MeasureC > MeasureB &&
                                     MeasureB + MeasureC > MeasureA ? true : false;

            return measuresDefineTriangle;
        }

        private void VerifyMeasure(double measure)
        {
            if (measure <= 0.0)
            {
                throw new MeasuresException("measure must be greater than zero.");
            }
        }
    }
}
