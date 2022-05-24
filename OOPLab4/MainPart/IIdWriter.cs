using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPart
{
    public interface IIdWriter
    {
        public string Id { get; }

        public void Write();
    }
}
