using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secs4Net;

namespace DBUploader.SecsGemMessage
{
    interface ISecsGemMessage
    {
        SecsMessage Message { get; }
    }
}
