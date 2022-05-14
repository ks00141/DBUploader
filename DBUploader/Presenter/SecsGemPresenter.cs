using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUploader.Service;
using DBUploader.View;
using DBUploader.Domain;

namespace DBUploader.Presenter
{
    class SecsGemPresenter
    {
        IRecipeParamUploadView view;
        SecsGemService secsGemService;
        DBUploadService dbService;

        public SecsGemPresenter(IRecipeParamUploadView view)
        {
            this.view = view;
            this.dbService = new DBUploadService();
            this.secsGemService = new SecsGemService();
            this.secsGemService.RecipeParamUploadHandler += Service_RecipeParamUploadHandler;
        }

        private void Service_RecipeParamUploadHandler(object sender, RecipeParam e)
        {
            view.RecipeParam = new string[]
            {
                e.ClusterRecipe,
                e.FrontsideRecipe,
                e.InspectionDies,
                e.InspectionColumns,
                e.InspectionRows
            };

            if (this.dbService.DBUpload(e))
            {
                view.Result = "DB Upload Succ";
            }
            else
            {
                view.Result = "DB Upload Fail";
            }
        }
    }
}
