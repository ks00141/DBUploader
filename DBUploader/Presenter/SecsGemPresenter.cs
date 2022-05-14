using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUploader.Service;
using DBUploader.View;
using DBUploader.Domain;
using System.Threading;

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
            this.secsGemService.SecsGemStart();
            this.secsGemService.RecipeParamUploadHandler += Service_RecipeParamUploadHandler;
        }

        private void Service_RecipeParamUploadHandler(object sender, RecipeParam e)
        {
            

            if (this.dbService.DBUpload(e))
            {
                view.RecipeParam = new string[]
                {
                    e.ClusterRecipe,
                    e.FrontsideRecipe,
                    e.InspectionDies,
                    e.InspectionColumns,
                    e.InspectionRows,
                    "PASS"
                };
            }
            else
            {
                view.RecipeParam = new string[]
                {
                    e.ClusterRecipe,
                    e.FrontsideRecipe,
                    e.InspectionDies,
                    e.InspectionColumns,
                    e.InspectionRows,
                    "NG"
                };
            }
        }

        public void SecsGemParamRequest(string[] uploadParams)
        {
            foreach(string ppid in uploadParams)
            {
                secsGemService.RecipeParamRequest(ppid);
                Thread.Sleep(10000);
            }
        }
    }
}
