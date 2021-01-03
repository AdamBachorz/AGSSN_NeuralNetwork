using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.NeuralNetwork.Elements
{
    public class LearningVector : Input<double>
    {
        public override double ResultValue() => Value;

        public override string ToString()
        {
            return $"Wartość: {Math.Round(Value, 2)} Waga: {Math.Round(Weight, 2)}";
        }
    }
}
