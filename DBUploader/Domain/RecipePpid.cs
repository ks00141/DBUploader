using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUploader.Domain
{
    class RecipePpid : IRecipePpid
    {
        public string Ppid { get; set; }
        public string Device { get; set; }
    }
}
