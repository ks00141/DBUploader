using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUploader.Domain;
using Secs4Net;

namespace DBUploader.Repository
{
    class SecsGemParamRepository
    {
        PrimaryMessageWrapper pMsg;
        public SecsGemParamRepository(PrimaryMessageWrapper pMsg)
        {
            this.pMsg = pMsg;
        }

        public RecipeParam GetRecipeParam()
        {
            RecipeParam param = new RecipeParam();
            Item items = pMsg.Message.SecsItem.Items[1].Items[0].Items[3];
            param.ClusterRecipe = pMsg.Message.SecsItem.Items[1].Items[0].Items[0].GetValue<String>();
            foreach (var item in items.Items)
            {
                if (item.Items[0] == "Frontside\\RecipeName")
                {
                    param.FrontsideRecipe = item.Items[1].Items[0].GetValue<string>();
                }
                if (item.Items[0] == "Frontside\\TestableDies")
                {
                    param.InspectionDies = item.Items[1].Items[0].GetValue<string>();
                }
                if (item.Items[0] == "Frontside\\ColumnNumber")
                {
                    param.InspectionColumns = item.Items[1].Items[0].GetValue<string>();
                }
                if (item.Items[0] == "Frontside\\RowNumber")
                {
                    param.InspectionRows = item.Items[1].Items[0].GetValue<string>();
                }
            }
            return param;
        }
    }
}
