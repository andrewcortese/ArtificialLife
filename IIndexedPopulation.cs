
using System;
using GeneticAlgorithms;
namespace AssemblyCSharp
{
	public interface IIndexedPopulation : IPopulation
	{
		IIndividual find(int key);
		bool containsKey(int key);
		void add(int key, IIndividual newIndividual);
        void Remove(int key);
	}
}

