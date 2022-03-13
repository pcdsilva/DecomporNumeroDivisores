using ProcessaDecomposicaoNumeroDivisores.Crud;
using ProcessaDecomposicaoNumeroDivisores.Repository;
using ProcessaDecomposicaoNumeroDivisores.Service;
using ProcessaDecomposicaoNumeroDivisores.Util;
using System;

namespace ProcessaDecomposicaoNumeroDivisores.Biz
{
    public class ProcessaDecomposicaoNumeroDivisoresBiz : IProcessaDecomposicaoNumeroDivisoresService
    {
        private readonly IExecutarProcessDecompNumDivisores _iExecutarProcessDecompNumDivisores;

        public ProcessaDecomposicaoNumeroDivisoresBiz()
        {
            _iExecutarProcessDecompNumDivisores = new ExecutarProcessDecompNumDivisoresCrud();
        }

        public ProcessaDecomposicaoNumeroDivisoresBiz(IExecutarProcessDecompNumDivisores iExecutarProcessDecompNumDivisores)
        {
            _iExecutarProcessDecompNumDivisores = iExecutarProcessDecompNumDivisores;
        }
        public int ProcessaDecomposicaoNumeroDivisores(int numeroEntrada)
        {
            try
            {
                Console.WriteLine();
                FileLog.EscreveLinha("-------------------------------------------------------------------------", "");
                FileLog.EscreveLinha($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} - INICIO PROCESSA DECOMPOSIÇÃO DIVISORES BATCH ", "");
                FileLog.EscreveLinha("-------------------------------------------------------------------------", "");
                Console.WriteLine();
                FileLog.EscreveLinha("NÚMERO DA ENTRADA: " + numeroEntrada.ToString(), "ProcessaDecomposicaoNumeroDivisores.Bacth.Main");
                Console.WriteLine();

                if (numeroEntrada != 0)
                {
                    _iExecutarProcessDecompNumDivisores.ExecutarProcessDecompNumDivisores(numeroEntrada);
                }
                else
                {
                    Console.WriteLine();
                    FileLog.EscreveLinha($"Nenhum caminho de diretorio encontrado", "");
                    Console.WriteLine();
                    return Convert.ToInt32(CodigoRetorno.Errado);
                }

                return Convert.ToInt32(CodigoRetorno.Verdadeiro);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                FileLog.EscreveLinha("---------------------------------------------------------------------------------------", "");
                FileLog.EscreveLinha($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} - ERRO AO TENTAR PROCESSA COMPOSIÇÃO DIVISORES BATCH. ERRO:", "");
                FileLog.EscreveLinha($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} - {ex.Message}", "");
                FileLog.EscreveLinha("---------------------------------------------------------------------------------------", "");
                Console.WriteLine();
                return Convert.ToInt32(CodigoRetorno.Errado);
                throw;
            }
            finally
            {
                Console.WriteLine();
                FileLog.EscreveLinha("---------------------------------------------------------------------------------------", "");
                FileLog.EscreveLinha($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} - FIM DO PROCESSAMENTO DO PROCESSA COMPOSIÇÃO DIVISORES BATCH", "");
                FileLog.EscreveLinha("---------------------------------------------------------------------------------------\n", "");
                Console.WriteLine();
            }
        }
    }
}
