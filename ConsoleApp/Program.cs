using Model.NeuralNetwork.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var neurons = new List<Neuron<double>>
            {
                new Neuron<double>
                {
                    Id = 1,
                    Layer = 1,
                    Inputs = new List<LearningVector>
                    {
                        new LearningVector { Value = 0.4f, Weight = 0.2f },
                        new LearningVector { Value = 0.3f, Weight = 0.8f },
                        new LearningVector { Value = 0.1f, Weight = 0.7f },
                        new LearningVector { Value = 0.7f, Weight = 0.1f }
                    }
                },
                new Neuron<double>
                {
                    Id = 2,
                    Layer = 1,
                    Inputs = new List<LearningVector>
                    {
                        new LearningVector { Value = 0.8f, Weight = 0.4f },
                        new LearningVector { Value = 0.8f, Weight = 0.4f },
                        new LearningVector { Value = 0.7f, Weight = 0.2f },
                        new LearningVector { Value = 0.1f, Weight = 0.8f }
                    }
                },
                new Neuron<double>
                {
                    Id = 3,
                    Layer = 1,
                    Inputs = new List<LearningVector>
                    {
                        new LearningVector { Value = 0.2f, Weight = 0.8f },
                        new LearningVector { Value = 0.5f, Weight = 0.8f },
                        new LearningVector { Value = 0.2f, Weight = 0.1f },
                        new LearningVector { Value = 0.1f, Weight = 0.5f }
                    }
                }
            };

            var network = new WTA<double>()
            {
                Neurons = neurons,
                LearningPerformance = 0.5f,
                Iterations = 4
            };

            network.Run();

            Console.ReadKey();
        }
    }
}
//const int inputs = 4;
//const int neurons = 3;

//double[,] w = new double[inputs, neurons]
//{
//    {0.2f, 0.4f, 0.8f},
//    {0.8f, 0.4f, 0.8f},
//    {0.7f, 0.2f, 0.1f},
//    {0.1f, 0.8f, 0.5f},
//};

//double[] x1 = new double[inputs] { 0.4f, 0.3f, 0.1f, 0.7f };
//double[] x2 = new double[inputs] { 0.8f, 0.8f, 0.7f, 0.1f };
//double[] x3 = new double[inputs] { 0.2f, 0.5f, 0.2f, 0.1f };
//double[] x4 = new double[inputs] { 0.5f, 0.3f, 0.2f, 0.7f };