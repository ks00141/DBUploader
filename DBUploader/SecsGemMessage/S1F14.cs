using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUploader.SecsGemMessage
{
    public class S1F14:IS1F14
    {
        public byte COMACK { get; set; }
        public string MDLN { get; set; }
        public string SOFTREV { get; set; }

        public SecsMessage Message
            => new SecsMessage(
                1,
                14,
                "S1F14",
                Item.L(
                    Item.B(COMACK),
                    Item.L(
                        Item.A(MDLN),
                        Item.A(SOFTREV)
                        )
                    )
                );
    }
}
