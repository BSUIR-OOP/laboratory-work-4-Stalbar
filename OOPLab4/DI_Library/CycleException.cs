using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Library
{
    public class CycleException: Exception
    {
        public CycleException(string msg)
            : base(msg)
        {

        }
    }
}
