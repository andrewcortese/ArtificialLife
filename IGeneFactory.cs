using System;

namespace GeneticAlgorithms
{
	public interface IGeneFactory
	{
		IGene construct(Object geneticInformation);
		IGene constructRandom();
	}
}

