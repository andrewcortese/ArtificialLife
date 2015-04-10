using System;
using System.Collections.Generic;
namespace GeneticAlgorithms
{
	/// <summary>
	/// Immutable collection of IGene objects
	/// </summary>
	public class Genome : IGenome
	{
		private List<IGene> genes;
		private int size = 0;

		/// <summary>
		/// Construct a genome from the array of genes
		/// </summary>
		/// <param name="genes">Genes.</param>
		public Genome(IGene[] genes)
		{
			this._setGenes(genes);
		}


		/// <summary>
		/// Construct an empty genome.
		/// The genome will have size 0.
		/// </summary>
		public Genome()
		{
			this._setGenes((new IGene[0]));
		}

		/// <summary>
		/// Protected constructor-helper for setting the genes.
		/// Only consructors should call this.
		/// </summary>
		/// <param name="genes">Genes.</param>
		protected void _setGenes(IGene[] genes)
		{
			this.genes = new List<IGene>();
			foreach(IGene g in genes)
			{
				this.genes.Add(g);
			}
			this.size = genes.Length;
		}


		/// <summary>
		/// Returns an array of shallow copies of the genes.
		/// (modifying the returned genes will not modify this object's genes).
		/// </summary>
		/// <returns>The genes.</returns>
		public IGene[] getGenes()
		{
			IGene[] genes = new IGene[this.size];
			for(int i=0; i<size; i++)
			{
				genes[i] = this.genes[i].clone();
			}
			return genes;
		}


		public int Size()
		{
			return this.size;
		}


		public bool numGenesDivisibleBy(int factor)
		{
			return ((this.Size() % factor) == 0);
		}

		public override string ToString ()
		{
			String s = String.Empty;
			foreach(IGene gene in this.getGenes())
			{
				s += " " + gene.ToString();
			}
			return s;
		}

        public string GenesToString()
        {
            String s = String.Empty;
            foreach(IGene gene in this.getGenes())
            {
                s += " " + gene.ToString();
            }
            return s;
        }

		public virtual IGenome Clone()
		{
			IGene[] newGenes = new IGene[this.size];
			for(int i=0; i<this.size; i++)
			{
				newGenes[i] = this.getGenes()[i].clone();
			}

			IGenome newGenome = new Genome(newGenes);
			return newGenome;
		}

	}
}

