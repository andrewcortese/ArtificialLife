using System;
using System.Collections.Generic;

	public class Population : IPopulation
	{
		private List<IIndividual> members;
		private int numGenesPerIndividual;

		/*		*
	 * Construct a population with the specifies number of individuals.
	 * Each individual will have the specifies genome size and their genes will have random values.
	 * @param numIndividuals
	 * @param numGenesPerIndividual
	 */
		public Population(int numIndividuals, int numGenesPerIndividual)
		{
			this.members = new List<IIndividual>();
			this.numGenesPerIndividual = numGenesPerIndividual;
		}

		/*		*
	 * Construct an EMPTY population with the specifies genome size
	 * @param numGenesPerIndividual the genome size of each individual
	 */
		public Population(int numGenesPerIndividual)
		{
			this.members = new List<IIndividual>();
			this.numGenesPerIndividual = numGenesPerIndividual;
		}

		/*		*
	 * Size of the genome of each individual in this population.
	 * @return the number of genes in the genome
	 */
		public int getNumGenesPerIndividual() {
			return numGenesPerIndividual;
		}

		/*		*
	 * 
	 * @param numGenesPerIndividual
	 */
		public void setNumGenesPerIndividual(int numGenesPerIndividual) {
			this.numGenesPerIndividual = numGenesPerIndividual;
		}


	
		public void add(IIndividual newIndividual) {
			members.Add(newIndividual);
		}

	
		public int count() {
			return members.Count;
		}

	
		public IIndividual get(int index) {
			return members[index];
		}


		public List<IIndividual> getIterator() {
			List<IIndividual> iterator = members;
			return iterator;
		}

		/*		*
	 * Create a shallow copy of this population.
	 * Each individual in the new population will have the same genetic information as the corresponding
	 *  	individual in this one.
	 *  
	 *  @return a shallow copy of this population, whose members are shallow copies of the members of thie one.
	 */

		public IPopulation clone()
		{
			int numGenes = this.getNumGenesPerIndividual();
			IPopulation population2 = new Population(numGenes);
			List<IIndividual> iterator = this.getIterator();
			foreach(IIndividual i in iterator)
			{
				population2.add(i.Clone());
			}

			return population2;
		}


		public String toString()
		{
			String populationString = String.Empty;
			List<IIndividual> iterator = this.getIterator();
			foreach(IIndividual i in iterator)
			{
				populationString += i.getGenome().ToString() + "\n";
			}

			return populationString;
		}
	}


