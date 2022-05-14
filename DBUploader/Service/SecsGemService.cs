using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DBUploader.Domain;
using Secs4Net;
using DBUploader.Repository;
using DBUploader.SecsGemMessage;


namespace DBUploader.Service
{
    class SecsGemService
    {
        SecsGem driver;
        public event EventHandler<RecipeParam> RecipeParamUploadHandler;

        public SecsGemService()
        {

            driver = new SecsGem(false, IPAddress.Any, 5000);
            driver.PrimaryMessageReceived += MsgReceived;
        }

        public void SecsGemStart()
        {
            driver.Start();
        }

        public void MsgReceived(object sender, PrimaryMessageWrapper pMsg)
        {
            int F = pMsg.Message.F;
            int S = pMsg.Message.S;

            switch (S)
            {
                case 1:
                    switch (F)
                    {
                        case 13:
                            pMsg.ReplyAsync(new S1F14
                                {
                                    MDLN =  "ARMS",
                                    SOFTREV = "0.1.0",
                                    COMACK = 0
                                }
                            .Message);
                            break;
                    }
                    break;
                case 2:
                    switch (F)
                    {
                        case 41:
                            pMsg.ReplyAsync(new S2F42
                            {
                                HCACK = 0
                            }
                            .Message);
                            RecipeParam param = new SecsGemParamRepository(pMsg).GetRecipeParam();
                            RecipeParamUploadHandler?.Invoke(this, param);

                            break;

                    }
                    break;
            }
        }
        public void RecipeParamRequest(string ppid)
        {
            driver.SendAsync(new S6F11
            {
                DATAID = 0,
                CEID = 3000,
                RPTID = 1,
                PPID = ppid
            }.Message);
        }
    }
}
