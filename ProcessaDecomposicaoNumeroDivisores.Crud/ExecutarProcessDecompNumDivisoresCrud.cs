using ProcessaDecomposicaoNumeroDivisores.Repository;
using ProcessaDecomposicaoNumeroDivisores.Util;
using System;

namespace ProcessaDecomposicaoNumeroDivisores.Crud
{
    public class ExecutarProcessDecompNumDivisoresCrud : IExecutarProcessDecompNumDivisores
    {
        public ExecutarProcessDecompNumDivisoresCrud() 
        {
            
        }
        public void ExecutarProcessDecompNumDivisores(int numeroEntrada)
        {
            try
            {
                ValidarNumeroPrimo validaNumeroPrimo = new ValidarNumeroPrimo();

                /*
                 * Variaveis que iram permitir efetuar as validações e calculos
                 * que forem nescessarios para obter o resultado.
                */
                string numerosDivisores = null;
                string divisoresPrimos = null;

                /* 
                 * Loop que efetua a divisão do numero de entrada pelo indice do "for"
                 * e aqueles que possuirem a divisão obtendo o resto = 0 são atribuidos 
                 * (incrementados) na variavel "numerosDivisores".
                 * 
                 * O metodo "ValidarNumeroPrimo" valida quais numeros contidos 
                 * na variavel "numerosDivisores" são divisores primos do numero de entrada.
                 */
                for (int i = 1; i <= numeroEntrada; i++)
                {
                    if (numeroEntrada % i == 0)
                    {
                        numerosDivisores += i.ToString() + ",";
                        if (validaNumeroPrimo.validarNumeroPrimo(Convert.ToInt32(i)))
                            divisoresPrimos = numerosDivisores.ToString();
                    }
                }

                /* 
                 * O remove é apenas para remover a ultima virgula de cada 
                 * array de strings "numerosDivisores" e "divisoresPrimos".
                 */
                if (numerosDivisores != null)
                    numerosDivisores = numerosDivisores.Remove(numerosDivisores.Length - 1);

                if (divisoresPrimos != null)
                    divisoresPrimos = divisoresPrimos.Remove(divisoresPrimos.Length - 1);


                /* 
                 * Este bloco apenas efetua a formatação das informações de retorno  
                 * na tela do console.
                 */
                Console.WriteLine();
                FileLog.EscreveLinha("##################################################################################", "");
                FileLog.EscreveLinha("NÚMERO DA ENTRADA : " + numeroEntrada, "");
                FileLog.EscreveLinha("NÚMEROS DIVISORES : " + numerosDivisores,"");
                FileLog.EscreveLinha("DIVISORES PRIMOS : " + divisoresPrimos, "");
                FileLog.EscreveLinha("##################################################################################", "");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                /* 
                 * Bloco que efetua a formatação da mensagem de erro apresentada no console.  
                 */
                Console.WriteLine();
                FileLog.EscreveLinha("##################################################################################", "");
                FileLog.EscreveLinha(ex.Message + Environment.NewLine + Environment.NewLine + "            PERMITIDO A ENTRADA DE APENAS NÚMEROS   ", "");
                FileLog.EscreveLinha("##################################################################################", "");
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
