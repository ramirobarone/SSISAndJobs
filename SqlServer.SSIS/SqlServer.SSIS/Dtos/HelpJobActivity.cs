using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServer.ApiService.Dtos
{
    internal class JobActivity
    {
        //public JobActivity(int sessionId, 
        //    int runRequestedSource, 
        //    int jobHistoryId, 
        //    int lastExecutedStepId, 
        //    int runStatus, 
        //    int operatorIdEmailed, 
        //    int operatorIdNetsent, 
        //    int operatorIdPaged, 
        //    string? jobName, 
        //    string? message, 
        //    Guid jobId, 
        //    DateTime runRequestedDate, 
        //    DateTime? queuedDate, 
        //    DateTime startExecutionDate, 
        //    DateTime lastExecutedStepDate, 
        //    DateTime stopExecutionDate, 
        //    DateTime nextScheduledRunDate)
        //{
        //    SessionId = sessionId;
        //    RunRequestedSource = runRequestedSource;
        //    JobHistoryId = jobHistoryId;
        //    LastExecutedStepId = lastExecutedStepId;
        //    RunStatus = runStatus;
        //    OperatorIdEmailed = operatorIdEmailed;
        //    OperatorIdNetsent = operatorIdNetsent;
        //    OperatorIdPaged = operatorIdPaged;
        //    JobName = jobName;
        //    Message = message;
        //    JobId = jobId;
        //    RunRequestedDate = runRequestedDate;
        //    QueuedDate = queuedDate;
        //    StartExecutionDate = startExecutionDate;
        //    LastExecutedStepDate = lastExecutedStepDate;
        //    StopExecutionDate = stopExecutionDate;
        //    NextScheduledRunDate = nextScheduledRunDate;
        //}

        public int SessionId { get; private set; }
        public int RunRequestedSource { get; private set; }
        public int JobHistoryId { get; private set; }
        public int LastExecutedStepId { get; private set; }
        public int RunStatus { get; private set; }
        public int OperatorIdEmailed { get;  private set; }
        public int OperatorIdNetsent { get; private set; }
        public int OperatorIdPaged { get; private set; }
        public string? JobName { get; private set; }
        public string? Message { get; private set; }
        public Guid JobId { get; private set; }
        public DateTime RunRequestedDate { get; private set; }
        public DateTime? QueuedDate { get; private set; }
        public DateTime StartExecutionDate { get; private set; }
        public DateTime LastExecutedStepDate { get; private set; }
        public DateTime StopExecutionDate { get; private set; }
        public DateTime NextScheduledRunDate { get; private set; }
    }
}