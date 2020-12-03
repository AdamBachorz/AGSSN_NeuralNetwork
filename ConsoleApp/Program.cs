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
            var neurons = new List<Neuron>
            {
                new Neuron
                {
                    Id = 1,
                    LearningVectors = new List<LearningVector>
                    {
                        new LearningVector { Value = 0.4f, Weight = 0.2f },
                        new LearningVector { Value = 0.3f, Weight = 0.8f },
                        new LearningVector { Value = 0.1f, Weight = 0.7f },
                        new LearningVector { Value = 0.7f, Weight = 0.1f }
                    }
                },
                new Neuron
                {
                    Id = 2,
                    LearningVectors = new List<LearningVector>
                    {
                        new LearningVector { Value = 0.8f, Weight = 0.4f },
                        new LearningVector { Value = 0.8f, Weight = 0.4f },
                        new LearningVector { Value = 0.7f, Weight = 0.2f },
                        new LearningVector { Value = 0.1f, Weight = 0.8f }
                    }
                },
                new Neuron
                {
                    Id = 3,
                    LearningVectors = new List<LearningVector>
                    {
                        new LearningVector { Value = 0.2f, Weight = 0.8f },
                        new LearningVector { Value = 0.5f, Weight = 0.8f },
                        new LearningVector { Value = 0.2f, Weight = 0.1f },
                        new LearningVector { Value = 0.1f, Weight = 0.5f }
                    }
                }
            };

            var wta = new WTA()
            {
                Neurons = neurons,
                LearningPerformance = 0.5f,
                Iterations = 4
            };

            wta.Run();

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