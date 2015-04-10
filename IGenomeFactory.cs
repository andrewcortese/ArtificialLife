using System;

namespace GeneticAlgorithms
{
	public interface IGenomeFactory
	{
		IGenome construct(IGene[] genes);
		IGenome constructRandom(IGeneFactory geneFactory, int size);
	}
}

