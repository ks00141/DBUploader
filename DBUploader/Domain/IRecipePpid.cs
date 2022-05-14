using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUploader.Domain
{
    interface IRecipePpid
    {
        
        string Ppid { get; set; }
        string Device { get; set; }
    }
}
