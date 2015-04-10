using System;

namespace GeneticAlgorithms
{
	public interface IGene
	{
		Object getGeneticInformation();
		void setGeneticInformation(Object newGeneticInformation);
		IGene clone();
	}
}

