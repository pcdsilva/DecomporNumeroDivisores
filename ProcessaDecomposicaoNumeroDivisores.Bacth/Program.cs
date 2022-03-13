using ProcessaDecomposicaoNumeroDivisores.Biz;
using ProcessaDecomposicaoNumeroDivisores.Util;
using System;

namespace ProcessaDecomposicaoNumeroDivisores.Bacth
{
    class Program
    {
        static void Main(string[] args)
        {
            int retorno = 1;
            int numeroEntrada;
            try
            {
                {
                    /* Mensagem informativa do console */
                    Console.Write("INFORME O NÚMERO: ");
                    numeroEntrada = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    retorno = new ProcessaDecomposicaoNumeroDivisoresBiz().ProcessaDecomposicaoNumeroDivisores(numeroEntrada);
                }
                Environment.Exit(retorno);
            }
            catch (Exception e)
            {
                FileLog.EscreveLinha("##################################################################################", "");
                FileLog.EscreveLinha("ERRO AO EXECUTAR A PROCESSA DECOMPOSIÇÃO DIVISORES BACH: ", "");
                FileLog.EscreveLinha(e.Message + Environment.NewLine + Environment.NewLine + "            PERMITIDO A ENTRADA DE APENAS NÚMEROS   ", "");
                FileLog.EscreveLinha("##################################################################################", "");

                Environment.Exit(1000);
            }
        }
    }
}
