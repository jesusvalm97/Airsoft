using System;
using System.Collections.Generic;
using System.Text;

namespace AirsoftDeliciasChihuahua.Standard
{
    public class Replica
    {
        public Guid Id { get; set; }

        public string Modelo { get; set; }

        public string NumeroSerie { get; set; }

        public override string ToString()
        {
            return NumeroSerie;
        }
    }
}
