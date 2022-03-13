using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessaDecomposicaoNumeroDivisores.Util
{
    public class FileLog
    {
        public static void EscreveLinha(string pTexto, string source)
        {
            try
            {
                ILog log = UtilGravacaoLog.LogMaster.GetLogger(source);
                log.Info(pTexto);
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(source, "Ocorreu um erro ao gravar o log de sistema: " + ex.Message, EventLogEntryType.Error);
                throw;
            }
        }
    }
}
