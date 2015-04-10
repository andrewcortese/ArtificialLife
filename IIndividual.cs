using System;

namespace GeneticAlgorithms
{
	public interface IIndividual
	{
        int Id {get;}
		IGenome getGenome();
		IIndividual Clone();
	}
}

