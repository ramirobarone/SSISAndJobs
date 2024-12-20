namespace SqlServer.SSIS.Dtos
{
    public class JobHelp
    {
        public JobHelp(string? jobId,
                       string? originatingServer,
                       string? name,
                       byte enabled,
                       string? description,
                       int startStepId,
                       string? category,
                       string? owner,
                       int notifyLevelEventlog,
                       int notifyLevelEmail,
                       int notifyLevelNetsend,
                       int notifyLevelPage,
                       string? notifyEmailOperator,
                       string? notifyNetsendOperator,
                       string? notifyPageOperator,
                       int deleteLevel,
                       DateTime dateCreated,
                       DateTime dateModified,
                       int versionNumber,
                       int lastRunDate,
                       int lastRunTime,
                       int lastRunOutcome,
                       int nextRunDate,
                       int nextRunTime,
                       int nextRunScheduleId,
                       int currentExecutionStatus,
                       string? currentExecutionStep,
                       int currentRetryAttempt,
                       int hasStep,
                       int hasSchedule,
                       int hasTarget,
                       int type)
        {
            JobId = jobId;
            OriginatingServer = originatingServer ?? "";
            Name = name;
            Enabled = enabled;
            Description = description;
            StartStepId = startStepId;
            Category = category;
            Owner = owner;
            NotifyLevelEventlog = notifyLevelEventlog;
            NotifyLevelEmail = notifyLevelEmail;
            NotifyLevelNetsend = notifyLevelNetsend;
            NotifyLevelPage = notifyLevelPage;
            NotifyEmailOperator = notifyEmailOperator;
            NotifyNetsendOperator = notifyNetsendOperator;
            NotifyPageOperator = notifyPageOperator;
            DeleteLevel = deleteLevel;
            DateCreated = dateCreated;
            DateModified = dateModified;
            VersionNumber = versionNumber;
            LastRunDate = lastRunDate;
            LastRunTime = lastRunTime;
            LastRunOutcome = lastRunOutcome;
            NextRunDate = nextRunDate;
            NextRunTime = nextRunTime;
            NextRunScheduleId = nextRunScheduleId;
            CurrentExecutionStatus = currentExecutionStatus;
            CurrentExecutionStep = currentExecutionStep;
            CurrentRetryAttempt = currentRetryAttempt;
            HasStep = hasStep;
            HasSchedule = hasSchedule;
            HasTarget = hasTarget;
            Type = type;
        }

        public int StartStepId { get; set; }
        public int NotifyLevelEventlog { get; set; }
        public int NotifyLevelEmail { get; set; }
        public int NotifyLevelNetsend { get; set; }
        public int NotifyLevelPage { get; set; }
        public int DeleteLevel { get; set; }
        public int VersionNumber { get; set; }
        public int LastRunDate { get; set; }
        public int LastRunTime { get; set; }
        public int LastRunOutcome { get; set; }
        public int NextRunDate { get; set; }
        public int NextRunTime { get; set; }
        public int NextRunScheduleId { get; set; }
        public int CurrentExecutionStatus { get; set; }
        public int CurrentRetryAttempt { get; set; }
        public int HasStep { get; set; }
        public int HasSchedule { get; set; }
        public int HasTarget { get; set; }
        public int Type { get; set; }
        public byte Enabled { get; set; }
        public string? JobId { get; set; }
        public string? OriginatingServer { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Owner { get; set; }
        public string? NotifyEmailOperator { get; set; }
        public string? NotifyNetsendOperator { get; set; }
        public string? CurrentExecutionStep { get; set; }
        public string? NotifyPageOperator { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
