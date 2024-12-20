namespace SqlServer.SSIS.Dtos
{

    public record JobActivity(
        int SessionId, Guid JobId, string JobName, DateTime RunRequestedDate, int RunRequestedSource,
        DateTime? QueuedDate, DateTime StartExecutionDate, int LastExecutedStepId, DateTime LastExecutedStepDate,
        DateTime StopExecutionDate, DateTime NextScheduledRunDate, int JobHistoryId, string Message, int RunStatus,
        int OperatorIdEmailed, int OperatorIdNetsent, int OperatorIdPaged);

    public record JobHistory(
        int InstanceId, Guid JobId, string JobName, int StepId, string StepName, int SqlMessageId, int SqlSeverity,
        string Message, int RunStatus, int RunDate, int RunTime, int RunDuration, string OperatorEmailed,
        string OperatorNetsent, string OperatorPaged, int RetriesAttempted, string Server);
}
