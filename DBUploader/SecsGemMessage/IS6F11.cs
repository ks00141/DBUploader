using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUploader.SecsGemMessage
{
    interface IS6F11:ISecsGemMessage
    {
        uint DATAID { get; set; }
        uint CEID { get; set; }
        uint RPTID { get; set; }
    }
}
