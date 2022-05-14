using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUploader.Domain
{
    interface IRecipeParam
    {
        string ClusterRecipe { get; set; }
        string FrontsideRecipe { get; set; }
        string InspectionDies { get; set; }
        string InspectionColumns { get; set; }
        string InspectionRows { get; set; }
    }
}
