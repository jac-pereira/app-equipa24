using Equipa24_FolhetosPDF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhetosPDF
{
    internal interface IPdfMetodo
    {
        string ExportarComImagem(Produto artigo, string str1, string str2);
    }
}
