using System;
using System.Collections.Generic;
using System.Text;

namespace AirsoftDeliciasChihuahua.Standard
{
    public class PropietarioReplica
    {
        public Guid Id { get; set; }

        public Propietario Propietario { get; set; }

        public Replica Replica { get; set; }
    }
}
