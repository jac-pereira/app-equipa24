﻿// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using Equipa24_Eventos_Delegados.Model;
using Equipa24_Eventos_Delegados.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equipa24_Eventos_Delegados.Controller
{
    class Controlador
    {
        //bool sair;
        Modelo modelo;
        Visao visao;

        public delegate void AtivacaoInterface(object origem);
        //public event AtivacaoInterface AtivarInterface;


        public Controlador()
        {
            //sair = false;
            visao = new Visao(modelo);
            modelo = new Modelo(visao);

            modelo.ListaDeProdutosAlterada += visao.AtualizarListaDeProdutos;
            
            visao.UtilizadorClicouEmSair += UtilizadorClicouEmSair;
            visao.UtilizadorClicouImportar += UtilizadorClicouImportar;
            visao.PrecisoDeProdutos += modelo.SolicitarListaProdutos;


            visao.UtilizadorClicouEmGravar += modelo.Gravar; 
        }

        public void IniciarPrograma()
        {
            visao.AtivarInterface();
        }

        private void UtilizadorClicouEmSair(object sender, EventArgs e)
        {
            //sair = true;
            visao.Encerrar();
        }

        public void UtilizadorClicouImportar(object fonte, System.EventArgs args)
        {
            //Implementar....
            string ficheiro = null;
            visao.NomeDoFicheiroParaImportar(ref ficheiro);
            if (ficheiro != null)
            {
                modelo.Importar(ficheiro);

            }
        }


    }
}
