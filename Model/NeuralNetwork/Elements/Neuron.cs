using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.NeuralNetwork.Elements
{
    public class Neuron
    {
        public int Id { get; set; }
        public IEnumerable<LearningVector> LearningVectors { get; set; }
        public double EuclideanDistance { get; private set; } // Miara Euklidesa - miara podobieństwa

        public double? ExpectedValue { get; set; }

        public double CalculateEuclideanDistance(double conscienceValue = 0)
        {
            double result = 0;
            foreach (var learningVector in LearningVectors)
            {
                result += Math.Pow(learningVector.Value - learningVector.Weight, 2);
            }

            EuclideanDistance = Math.Sqrt(result) + conscienceValue;
            return EuclideanDistance;
        }
        
        public double OuterValue {
            get
            {
                double result = 0;
                foreach (var learningVector in LearningVectors)
                {
                    result += learningVector.Value * learningVector.Weight;
                }
                return result;
            }
        }

        public double ErrorValue 
            => ExpectedValue.HasValue ? 0.5 * Math.Pow(OuterValue - ExpectedValue.Value, 2) : 0;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Codes.Separator);
            sb.AppendLine($"Neuron nr {Id}:");

            sb.AppendLine("Wejścia:");
            int inputCounter = 0;
            foreach (var input in LearningVectors)
            {
                sb.AppendLine($"{++inputCounter}. {input.ToString()}");
            }

            sb.AppendLine(Codes.Separator);
            return sb.ToString();
        }
    }
}
