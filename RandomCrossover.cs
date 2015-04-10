using System;

namespace GeneticAlgorithms
{
	public class RandomCrossover : ICrossover
	{
		IMatchValidator matchValidator = new MatchValidator();


	
		public IGenome crossover(IGenome[] parents, IGenomeFactory childFactory) {

			int numGenes;

			//validate
			if(matchValidator.canCrossover(parents))
			{
				numGenes = parents[0].Size();
			}
			else
			{
				throw new Exception();
			}

			//perform crossover
			IGene[] childGenes = new IGene[numGenes];
			for(int i=0; i<numGenes; i++)
			{
				int parent = (new Random()).Next(parents.Length);
				childGenes[i] = parents[parent].getGenes()[i];
			}

			//construct and return
			IGenome child = childFactory.construct(childGenes);
			return child;
		}
	}
}

