using EvolutionSimulationCore.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulationCore.Models
{
    public class Gene
    {
        public DNAString dna;

        public Gene()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.dna = new DNAString();
        }
    }

    public class DNAString
    {
        public Nucleotide[] nucleotides;

        public DNAString()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.nucleotides = new Nucleotide[260869];
            for (int i = 0; i < nucleotides.Length; i++)
            {
                nucleotides[i] = new Nucleotide();
            }
        }
    }

    public class Nucleotide
    {
        public int value;

        public Nucleotide()
        {
            this.Initialize();
        }

        #region Private functions
        private void Initialize()
        {
            this.value = RandomProvider.GetRandomNumber(0, 100);
        }
        #endregion
    }
}
