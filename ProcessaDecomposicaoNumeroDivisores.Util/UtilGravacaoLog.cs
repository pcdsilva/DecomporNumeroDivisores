﻿using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;

namespace ProcessaDecomposicaoNumeroDivisores.Util
{
    public class UtilGravacaoLog
    {
        public static class LogMaster
        {
            #region Const
            private const string RollingFileAppenderNameDefault = "Rolling";
            private const string MemoryAppenderNameDefault = "Memory";
            #endregion


            #region Constructors
            static LogMaster()
            {
            }
            #endregion


            #region Public Methods

            public static ILog GetLogger(string name)
            {
                //It will create a repository for each different arg it will receive
                string arg = string.Format(AppSettings.PatchNomeArquivoLog, DateTime.Now.ToString("yyyyMMdd"));

                var repositoryName = arg + DateTime.Now.ToString("yyyyMMdd") + "_ProcessaDecomposicaoNumeroDivisores_LOG.log";

                ILoggerRepository repository = null;

                var repositories = LogManager.GetAllRepositories();
                foreach (var loggerRepository in repositories)
                {
                    if (loggerRepository.Name.Equals(repositoryName))
                    {
                        repository = loggerRepository;
                        break;
                    }
                }

                Hierarchy hierarchy = null;
                if (repository == null)
                {
                    //Create a new repository
                    repository = LogManager.CreateRepository(repositoryName);

                    hierarchy = (Hierarchy)repository;
                    hierarchy.Root.Additivity = false;

                    //Add appenders you need: here I need a rolling file and a memoryappender
                    var rollingAppender = GetRollingAppender(repositoryName);
                    hierarchy.Root.AddAppender(rollingAppender);

                    var memoryAppender = GetMemoryAppender(repositoryName);
                    hierarchy.Root.AddAppender(memoryAppender);

                    BasicConfigurator.Configure(repository);
                }

                //Returns a logger from a particular repository
                //Logger with same name but different repository will log using different appenders
                return LogManager.GetLogger(repositoryName, name);
            }
            #endregion


            #region Private Methods
            private static IAppender GetRollingAppender(string arg)
            {
                var level = Level.All;
                var rollingFileAppenderLayout = new PatternLayout(AppSettings.PatternLayout);
                rollingFileAppenderLayout.ActivateOptions();

                var rollingFileAppenderName = string.Format("{0}{1}", RollingFileAppenderNameDefault, arg);

                var rollingFileAppender = new RollingFileAppender();
                rollingFileAppender.Encoding = System.Text.Encoding.UTF8;
                rollingFileAppender.Name = rollingFileAppenderName;
                rollingFileAppender.Threshold = level;
                rollingFileAppender.CountDirection = 0;
                rollingFileAppender.AppendToFile = true;
                rollingFileAppender.LockingModel = new FileAppender.MinimalLock();
                rollingFileAppender.StaticLogFileName = true;
                rollingFileAppender.RollingStyle = RollingFileAppender.RollingMode.Size;
                rollingFileAppender.DatePattern = ".yyyy-MM-dd'.log'";
                rollingFileAppender.Layout = rollingFileAppenderLayout;
                rollingFileAppender.File = arg;
                rollingFileAppender.MaximumFileSize = AppSettings.TamanhoMaximoLog;
                rollingFileAppender.MaxSizeRollBackups = AppSettings.QtdeMaximaArquivoLog;
                rollingFileAppender.ActivateOptions();
                return rollingFileAppender;
            }

            private static IAppender GetMemoryAppender(string station)
            {
                //MemoryAppender
                var memoryAppenderLayout = new PatternLayout("%date{HH:MM:ss} | %message%newline");
                memoryAppenderLayout.ActivateOptions();

                var memoryAppenderWithEventsName = string.Format("{0}{1}", MemoryAppenderNameDefault, station);
                var levelRangeFilter = new LevelRangeFilter();
                levelRangeFilter.LevelMax = Level.Fatal;
                levelRangeFilter.LevelMin = Level.Info;

                var memoryAppenderWithEvents = new MemoryAppenderWithEvents();
                memoryAppenderWithEvents.Name = memoryAppenderWithEventsName;
                memoryAppenderWithEvents.AddFilter(levelRangeFilter);
                memoryAppenderWithEvents.Layout = memoryAppenderLayout;
                memoryAppenderWithEvents.ActivateOptions();

                return memoryAppenderWithEvents;
            }

            public class MemoryAppenderWithEvents : MemoryAppender
            {
                //public event EventHandler Updated
            }
            #endregion
        }
    }
}
