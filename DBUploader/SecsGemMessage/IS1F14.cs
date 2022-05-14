using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUploader.SecsGemMessage
{
    interface IS1F14: ISecsGemMessage
    {
        byte COMACK { get; set; }
        string MDLN { get; set; }
        string SOFTREV { get; set; }
    }
}
