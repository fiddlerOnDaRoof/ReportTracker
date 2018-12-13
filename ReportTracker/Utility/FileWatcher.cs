using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportTracker.Utility
{
    public class FileWatcher
    {
        public void Watch(string _path, EventHandler _onChanged)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = _path;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(_onChanged);
            watcher.EnableRaisingEvents = true;
        }
    }
}
