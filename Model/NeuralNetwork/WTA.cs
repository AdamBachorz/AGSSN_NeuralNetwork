using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.NeuralNetwork.Elements
{
    public class WTA<V> : BaseNeuralNetwork<V>
    {
        public IDictionary<Neuron<V>, int> ScoreBoard { get; private set; }
        public double ConscienceChance { get; set; } = 1;

        private int _currentIteration;

        public WTA()
        {
            ScoreBoard = new Dictionary<Neuron<V>, int>();
        }

        public override void Run()
        {
            _currentIteration = 0;

            // Inicjalizacja punktacji
            foreach (var neuron in Neurons)
            {
                ScoreBoard.Add(neuron, 0);
            }

            DisplayScoreBoard();
            if (DisplayInitialValues)
            {
                Console.WriteLine("Dane wejściowe:");
                DisplayAllNeuronsDetails(); 
            }
            Console.WriteLine($"Pierwsze podejście");
            Console.WriteLine("Wygrał neuron nr " + WinnerNeuron().Id);
            for (int i = 0; i < Iterations; i++)
            {
                _currentIteration++;
                Console.WriteLine();
                Console.WriteLine($"Iteracja nr {_currentIteration}");

                CalculateAndDisplayEuclideanDistances();
                var winnerNeuron = WinnerNeuron();
                Console.WriteLine("Wygrał neuron nr " + winnerNeuron.Id);
                ScoreBoard[winnerNeuron]++;
                UpdateWeights();
            }
            DisplayScoreBoard();
        }

        private Neuron<V> WinnerNeuron()
        {
            var minimumNeuronsEuclideanDistance = Neurons.Select(n => n.EuclideanDistance).Min();
            var winnerNeuron = Neurons.First(n => n.EuclideanDistance == minimumNeuronsEuclideanDistance);
            return winnerNeuron;
        }

        private void CalculateAndDisplayEuclideanDistances()
        {
            var sb = new StringBuilder("{");

            foreach (var neuron in Neurons)
            {
                double conscienceValue = ConscienceValue(neuron);
                double euclideanDistance = neuron.CalculateEuclideanDistance(conscienceValue);

                sb.Append($" d{neuron.Id} = {Math.Round(euclideanDistance, 2)} ");
            }
            sb.Append("}");
            Console.WriteLine(sb.ToString());
        }

        public void UpdateWeights()
        {
            foreach (var neuron in Neurons)
            {
                foreach (var input in neuron.Inputs)
                {
                    input.Weight += LearningPerformance * (input.ResultValue() - input.Weight);
                }
            }
        }

        private void DisplayAllNeuronsDetails()
        {
            foreach (var neuron in Neurons)
            {
                Console.WriteLine(neuron.ToString());
            }
        }

        private double ConscienceValue(Neuron<V> neuron)
        {
            var hitConscience = Codes.Random.NextDouble() <= ConscienceChance;
            var lead = PickLead();

            // Warunki włączenia mechanizmu sumienia
            if (lead.Id == neuron.Id && _currentIteration >= 1 && hitConscience)
            {
                var wins = ScoreBoard[lead]; // Pobieramy liczbę zwycięstw

                var resultValue = wins * 0.5; // Obliczamy wartość sumienia
                return resultValue;
            }
            else
            {
                return 0;
            }
        }

        private void DisplayScoreBoard()
        {
            var sb = new StringBuilder();

            foreach (var neuron in ScoreBoard.Keys)
            {
                sb.AppendLine($"Neuron nr {neuron.Id} zwycięstwa: {ScoreBoard[neuron]}");
            }

            Console.WriteLine(sb.ToString());
        }

        private Neuron<V> PickLead()
        {
            return Neurons.First(n => n.Id == ScoreBoard.OrderByDescending(sb => sb.Value).First().Key.Id);
        }
    }
}
