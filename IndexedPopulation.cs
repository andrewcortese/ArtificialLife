// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using GeneticAlgorithms;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
namespace AssemblyCSharp
{
	/// <summary>
	/// Class to serve as a collection of IIndividuals that can be looked by by their GUID.
	/// 
	/// </summary>
	public class IndexedPopulation : IIndexedPopulation
	{

		Dictionary<int,IIndividual> members = new Dictionary<int,IIndividual>();
		IGUIDGenerator guidGenerator;

		/// <summary>
		/// Initializes an empty IndexedPopulation
		/// </summary>
		public IndexedPopulation(IGUIDGenerator guidGenerator)
		{
			this.members = new Dictionary<int,IIndividual>();
		}

		/// <summary>
		/// Generates a population with randomized genomes.
		/// </summary>
		public IndexedPopulation(int numIndividuals, IIndividualFactory individualFactory, IGUIDGenerator guidGenerator)
		{
			this.guidGenerator = guidGenerator;

			for(int i=0; i<numIndividuals; i++)
			{
				IIndividual individual = individualFactory.constructRandom();
                int guid = ((LifeAgentIndividual)individual).Id;

				this.members.Add(guid, individual);
			}
		}


		public IIndividual find(int key)
		{
			return this.members[key];
		}

		public bool containsKey(int key)
		{
			return this.members.ContainsKey(key);
		}

		public void add(int key, IIndividual newIndividual)
		{
			this.members.Add(key, newIndividual);
		}

		/// <summary>
		/// Get the individual at the specified index.
		/// NOTE: This behaves like a List or array in the sense that:
		///    (a) The first element has index 0.
		///    (b) Each element has 1+index of the previous element.
		/// 
		/// i.e. indexes are the classic {0,1,2,...}
		/// This is NOT a key-based lookup method.
		/// </summary>
		/// <param name="index">Index.</param>
		public IIndividual get (int index)
		{
			int i=0;
			foreach(IIndividual individual in this.members.Values)
			{
				if(i==index)
				{
					return individual;
				}
				else
				{
					i++;
				}

			}

			return null;
		}




		/// <summary>
		///
		/// </summary>
		/// <param name="newIndividual">New individual.</param>

		public void add (IIndividual newIndividual)
		{
			int key = guidGenerator.generateGUID();
			this.members.Add(key, newIndividual);
		}

        public void Remove(int key)
        {
            this.members.Remove(key);
        }

		public int count ()
		{
			return this.members.Count;
		}



		public System.Collections.Generic.List<IIndividual> getIterator ()
		{
			List<IIndividual> list = new List<IIndividual>();
			foreach(IIndividual i in this.members.Values)
			{
				list.Add(i);
			}
			return list;
		}

		public IPopulation clone ()
		{
			return (IPopulation)this.MemberwiseClone();
		}
		}
}

