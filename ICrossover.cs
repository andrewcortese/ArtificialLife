using System;

namespace GeneticAlgorithms
{
	public interface ICrossover
	{
		IGenome crossover(IGenome[] parents, IGenomeFactory childFactory);
	}
}

