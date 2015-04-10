using System;

namespace GeneticAlgorithms
{
	public interface IMatchValidator
	{
		bool canCrossover(IGenome[] parents);
	}
}

