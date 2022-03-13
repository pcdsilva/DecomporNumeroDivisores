using System;
using System.Configuration;

namespace ProcessaDecomposicaoNumeroDivisores.Util
{
    public class AppSettings
    {
        protected AppSettings()
        {
        }

        private static string _patchNomeArquivoLog;
        public static string PatchNomeArquivoLog
        {
            get
            {
                if (_patchNomeArquivoLog == null)
                    _patchNomeArquivoLog = ConfigurationManager.AppSettings["patchNomeArquivoLog"];
                return _patchNomeArquivoLog;
            }
        }

        private static string _PatternLayout;
        public static string PatternLayout
        {
            get
            {
                if (_PatternLayout == null)
                    _PatternLayout = ConfigurationManager.AppSettings["PatternLayout"];
                return _PatternLayout;
            }
        }

        private static string _TamanhoMaximoLog;
        public static string TamanhoMaximoLog
        {
            get
            {
                if (_TamanhoMaximoLog == null)
                    _TamanhoMaximoLog = ConfigurationManager.AppSettings["TamanhoMaximoLog"];
                return _TamanhoMaximoLog;
            }
        }

        private static int _QtdeMaximaArquivoLog;
        public static int QtdeMaximaArquivoLog
        {
            get
            {
                if (_QtdeMaximaArquivoLog == 0)
                    _QtdeMaximaArquivoLog = Convert.ToInt32(ConfigurationManager.AppSettings["QtdeMaximaArquivoLog"]);
                //
                return _QtdeMaximaArquivoLog;
            }
        }
    }
}
