﻿using System.Threading.Tasks;
using Bit.Core;
using Bit.Core.Jobs;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Bit.Notifications.Jobs
{
    public class LogConnectionCounterJob : BaseJob
    {
        private readonly ConnectionCounter _connectionCounter;

        public LogConnectionCounterJob(
            ILogger<LogConnectionCounterJob> logger,
            ConnectionCounter connectionCounter)
            : base(logger)
        {
            _connectionCounter = connectionCounter;
        }

        protected override Task ExecuteJobAsync(IJobExecutionContext context)
        {
            _logger.LogInformation(Constants.BypassFiltersEventId,
                "Connection count: {0}", _connectionCounter.GetCount());
            return Task.FromResult(0);
        }
    }
}