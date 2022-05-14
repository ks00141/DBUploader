using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUploader.Domain
{
    class RecipeParam : IRecipeParam
    {
        private string clusterRecipe;
        public string ClusterRecipe
        {
            get
            {
                return this.clusterRecipe;
            }
            set
            {
                this.clusterRecipe = value.Replace('\\', '/');
            }
        }
        private string frontsideRecipe;
        public string FrontsideRecipe 
        {
            get
            {
                return this.frontsideRecipe;
            }
            set
            {
                this.frontsideRecipe = value.Replace('\\', '/');
            }
        }
        public string InspectionDies { get; set; }
        public string InspectionColumns { get; set; }
        public string InspectionRows { get; set; }
    }
}
