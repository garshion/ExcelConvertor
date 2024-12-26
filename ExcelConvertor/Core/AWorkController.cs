using Bass.Tools.Config;
using Bass.Tools.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bass.Tools.Core
{
    public abstract class AWorkController
    {
        public abstract bool Process(List<WorkData> datas);

        protected void CheckExportFolder(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName))
                return;

            string exportFolder = Path.Combine(ConfigManager.Setting.ExportFolder, folderName);
            if (!Directory.Exists(exportFolder))
                Directory.CreateDirectory(exportFolder);
        }

        protected bool RemoveFiles(string folderName)
        {
            if(string.IsNullOrWhiteSpace(folderName))
                return false;

            string exportFolder = Path.Combine(ConfigManager.Setting.ExportFolder, folderName);
            if (!Directory.Exists(exportFolder))
                return false;

            var files = Directory.GetFiles(exportFolder);
            foreach (var file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception e)
                {
                    Logger.Log("Delete File Error : " + e.Message);
                    Logger.Trace(e);
                }
            }

            return true;

        }

    }
}
