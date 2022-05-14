using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUploader.Repository;
using DBUploader.Domain;

namespace DBUploader.Service
{
    class DBUploadService
    {
        DBUploadRepository repo;

        public DBUploadService()
        {
            repo = new DBUploadRepository();
        }

        public bool DBUpload(RecipeParam param)
        {
            try
            {
                repo.DBParamUpload(param);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
