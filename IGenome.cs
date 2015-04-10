using System;

namespace GeneticAlgorithms
{
	public interface IGenome
	{
		IGene[] getGenes();
		int Size();
		bool numGenesDivisibleBy(int factor);
		String GenesToString();
		IGenome Clone();
	}
}

