using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUploader.SecsGemMessage
{
    class S2F42 : IS2F42
    {
        public uint HCACK { get; set; }

        public SecsMessage Message
            => new SecsMessage(
                2,
                42,
                "S2F42",
                Item.L(
                    Item.U4(HCACK)
                    )
                );
    }
}
