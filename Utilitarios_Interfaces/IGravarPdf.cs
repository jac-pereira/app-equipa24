using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhetosPDF.Utilitarios_Interfaces
{
    internal interface IGravarPdf
    {
        void Gravar();
        string Mensagem { get; }
        bool Sucesso { get; }
        string Caminho { get; }
    }
}
