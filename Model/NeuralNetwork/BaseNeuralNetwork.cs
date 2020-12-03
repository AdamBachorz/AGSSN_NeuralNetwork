using Model.NeuralNetwork.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.NeuralNetwork
{
    public abstract class BaseNeuralNetwork
    {
        public IEnumerable<Neuron> Neurons { get; set; }
        public double LearningPerformance { get; set; }
        public int Iterations { get; set; }
        public bool DisplayInitialValues { get; set; } = false;
        public IDictionary<Neuron, int> ScoreBoard { get; protected set; }

        public abstract void Run();
    }
}
