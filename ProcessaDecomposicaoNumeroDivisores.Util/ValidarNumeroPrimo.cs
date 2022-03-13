using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessaDecomposicaoNumeroDivisores.Util
{
    public class ValidarNumeroPrimo
    {
        /* Metodo que validar se o numero de entrada é primo ou não */
        public Boolean validarNumeroPrimo(int n)
        {
            Boolean numeroPrimo = true;
            for (int j = 2; j <= (int)Math.Sqrt(n); j++)
            {
                if (n % j == 0)
                {
                    numeroPrimo = false;
                    break;
                }
            }

            return numeroPrimo;
        }
    }
}
