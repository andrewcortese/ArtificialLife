using System;

namespace GeneticAlgorithms
{
	public class MatchValidator : IMatchValidator
	{
	 /*
	 * Method to determine whether a set of parents can crossover.
	 * A set is capable of crossover if
	 *    (1) The number of genes is equivalent
	 *    (2) The IGenome implementations are the same Class
	 *    
	 * @return true if capable, false otherwise
	 */
		public bool canCrossover(IGenome[] parents)
		{
			bool valid = true;
			int genomeSize = -1;
			IGenome first;
			if(parents == null || parents.Length == 0)
			{
				//NOTE: should this be true or false?
				return true;
			}
			else
			{
				first = parents[0];
				genomeSize = first.Size();
			}

			foreach(IGenome i in parents)
			{
				//if the genomes are different sizes, not valid
				if(i.Size() != genomeSize)
				{
					valid = false;
				}

				//if the genomes are different types, not valid
				if(false == i.GetType().Equals(first.GetType()))
				{
					valid = false;
				}	 
			}

			return valid;
		}
	}
}

