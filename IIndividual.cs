using System;


	public interface IIndividual
	{
        int Id {get;}
		IGenome getGenome();
		IIndividual Clone();
	}


