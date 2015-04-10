using System;

namespace GeneticAlgorithms
{
	public class SimpleIndividual : IIndividual
	{
		private IGenome genome;


        public int Id{get; set;}

		public SimpleIndividual(IGenome genome)
		{
			this.genome = genome;
		}

		/*		*
	 * generates a SimpleIndividual with a random genome
	 */
		public SimpleIndividual()
		{

		}

		public IGenome getGenome()
		{
			return this.genome;
		}

		public IIndividual Clone()
		{
			IGenome newGenome = this.genome.Clone();
			IIndividual newIndividual = new SimpleIndividual(newGenome);
			return newIndividual;
		}

		public String toString()
		{
			return this.getGenome().ToString();
		}
	}
}

