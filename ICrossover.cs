using System;


	public interface ICrossover
	{
		IGenome crossover(IGenome[] parents, IGenomeFactory childFactory);
	}


