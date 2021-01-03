using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.NeuralNetwork.Elements
{
    public abstract class Input<V>
    {
        public V Value { get; set; }
        public double Weight { get; set; }

        public virtual double OuterValue => ResultValue() * Weight;

        public abstract double ResultValue();

    }
}
