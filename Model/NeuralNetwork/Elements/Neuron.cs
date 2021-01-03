using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.NeuralNetwork.Elements
{
    public class Neuron<V>
    {
        public int Id { get; set; }
        public int Layer { get; set; } = 1;
        public IEnumerable<Input<V>> Inputs { get; set; }
        public double EuclideanDistance { get; private set; } // Miara Euklidesa - miara podobieństwa

        public double? ExpectedValue { get; set; }

        public double CalculateEuclideanDistance(double conscienceValue = 0)
        {
            double result = 0;
            foreach (var input in Inputs)
            {
                result += Math.Pow(input.ResultValue() - input.Weight, 2);
            }

            EuclideanDistance = Math.Sqrt(result) + conscienceValue;
            return EuclideanDistance;
        }

        public virtual double OuterValue => Inputs.Sum(i => i.OuterValue);

        public double ErrorValue 
            => ExpectedValue.HasValue ? 0.5 * Math.Pow(OuterValue - ExpectedValue.Value, 2) : 0;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Codes.Separator);
            sb.AppendLine($"Neuron nr {Id}:");

            sb.AppendLine("Wejścia:");
            int inputCounter = 0;
            foreach (var input in Inputs)
            {
                sb.AppendLine($"{++inputCounter}. {input.ToString()}");
            }

            sb.AppendLine(Codes.Separator);
            return sb.ToString();
        }
    }
}
