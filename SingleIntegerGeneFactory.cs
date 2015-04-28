using System;


	public class SingleIntegerGeneFactory : IGeneFactory
	{
        private Random r;

        public SingleIntegerGeneFactory()
        {
            r = new Random();
        }

		public IGene construct(Object geneticInformation) {

			int value = -1;
			if(geneticInformation.GetType().Equals((new Int32()).GetType()))
			{
				value = (Int32)geneticInformation;

			}
			else
			{
				throw new Exception("Cannot cast genetic information to appropriate type");
			}


			IGene gene = new SingleIntegerGene(value);
			return gene;
		}

	
		public IGene constructRandom() {
			
			int value = r.Next (9);
			IGene gene = new SingleIntegerGene(value);
			return gene;
		}
	}


