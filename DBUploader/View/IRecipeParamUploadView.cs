using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUploader.View
{
    interface IRecipeParamUploadView
    {
        string[] RecipeParam { set; }

        string[] UploadParams { get;}
    }
}
