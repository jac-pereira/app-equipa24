using System;
using System.Diagnostics;
using System.IO;

namespace FolhetosPDF.Utilitarios_Interfaces
{
    internal class AbrirFicheiro : IAbrirFicheiro
    {

        public string Abrir(string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho))
                return "Caminho do ficheiro não especificado.";

            if (!File.Exists(caminho))
                return $"Ficheiro não encontrado: {caminho}";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = caminho,
                    UseShellExecute = true
                });

                return $"A visualizar o ficheiro: {Path.GetFileName(caminho)}";
            }
            catch (Exception ex)
            {
                return $"Erro ao abrir o ficheiro: {ex.Message}";
            }
        }

    }
}
