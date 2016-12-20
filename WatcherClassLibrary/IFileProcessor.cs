using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatcherClassLibrary
{
    public interface IFileProcessor
    {
        void Process(string path);
    }
}
