using LogReplacer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LogsReplacerService
{
    public partial class Service1 : ServiceBase
    {
        ArchiveOperations archiveOperations = new ArchiveOperations();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            archiveOperations.Run();
        }

        protected override void OnStop()
        {
            archiveOperations.Stop();
        }
    }
}
