using System;


	public interface IGeneFactory
	{
		IGene construct(Object geneticInformation);
		IGene constructRandom();
	}


