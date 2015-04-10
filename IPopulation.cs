using System;
using System.Collections.Generic;
namespace GeneticAlgorithms
{
	public interface IPopulation
	{
		IIndividual get(int index);
		void add(IIndividual newIndividual);
		int count();
		List<IIndividual> getIterator();
		IPopulation clone();

	}
}

