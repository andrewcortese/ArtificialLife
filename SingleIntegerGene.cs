using System;

namespace GeneticAlgorithms
{
	public class SingleIntegerGene : IGene
	{
		//FIELDS
		private int value;


		//CONSTRUCTORS
		public SingleIntegerGene(int value)
		{
			this.value = value;
		}

		/*		*
	 * Construct a Gene with a random integer value.
	 * The value will be in: minVal <= x <= maxVal
	 * @param minVal the minumum possible value
	 * @param maxVal the maxmimum possible value
	 */
		public SingleIntegerGene(int minVal, int maxVal)
		{

		}

		//METHODS





		//INHERITED METHODS FROM IGene


		public Object getGeneticInformation() {
			return (Object)this.value;
		}

	
		public void setGeneticInformation(Object newGeneticInformation) {
			this.value = (Int32)newGeneticInformation;
		}


        public override string ToString()
        {
            return this.value.ToString();
        }

	
		public IGene clone()
		{
			IGene clone = new SingleIntegerGene(this.value);
			return clone;
		}
	}
}

