using Model.NeuralNetwork.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.NeuralNetwork
{
    public abstract class BaseNeuralNetwork<V>
    {
        public IEnumerable<Neuron<V>> Neurons { get; set; }
        public double LearningPerformance { get; set; }
        public int Iterations { get; set; }
        public bool DisplayInitialValues { get; set; } = false;

        public abstract void Run();
    }
}
