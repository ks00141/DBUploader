using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUploader.View;
using DBUploader.Service;
using DBUploader.Domain;

namespace DBUploader.Presenter
{
    class PpidPresenter
    {
        private readonly IPpidListView view;
        PpidService service = new PpidService();
        public PpidPresenter(IPpidListView view)
        {
            this.view = view;
        }

        public void PrintAllPpid()
        {
            foreach (RecipePpid ppid in service.CheckAll())
            {
                view.Ppid = new string[] { ppid.Device, ppid.Ppid };
            }
        }
    }
}
