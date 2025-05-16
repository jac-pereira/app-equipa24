using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhetosPDF
{
    internal interface IPdf
    {
        public string Exportar();
        public string ExportarFoto();

    }
}
