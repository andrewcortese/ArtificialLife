using System;

namespace GeneticAlgorithms
{
	public class GenomeFactory : IGenomeFactory
	{
		public IGenome construct(IGene[] genes)
		{
			IGenome genome = new Genome(genes);
			return genome;
		}

		public IGenome constructRandom(IGeneFactory geneFactory, int size)
		{
			IGene[] genes = new IGene[size];
			for(int i=0; i<size; i++)
			{
				genes[i] = geneFactory.constructRandom();
			}
			return this.construct(genes);
		}
	}
}

