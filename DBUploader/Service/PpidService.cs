using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUploader.Repository;


namespace DBUploader.Service
{
    class PpidService
    {
        public ArrayList CheckAll()
        {
            return new PpidRepository().FindAllPpid();
        }
    }
}
