using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class MathematicOperations
    {

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Summarize(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Divide(double x, double y)
        {
            if (y != 0)
                return x / y;
            else
                throw new DivideByZeroException();
        }

        public double ToPow(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}
