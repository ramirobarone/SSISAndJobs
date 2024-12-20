using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace SqlServer.SSIS.SqlServer
{
    public class JobService : ConnectionServer
    {

        public JobService(string connectionString) : base(connectionString)
        {

        }

        public new async Task<bool> OpenConnection(CancellationToken ct)
        {
            return await base.OpenConnection(ct);
        }
        /// <summary>
        /// Execute a Job in SQL Server
        /// </summary>
        /// <param name="jobName">The name of job in sql Server</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns>True or False if job is founded and execute, if Job is not founded throw an exception</returns>
        public async Task<bool> StartJob(string jobName, CancellationToken ct)
        {
            if (await OpenConnection(ct) is false)
                return false;

            command = new SqlCommand("sp_start_job", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@job_name", jobName);

            try
            {
                return await ExecuteSp(command, ct) is not null;
            }
            finally
            {
                Dispose();
            }
        }

        public async void StopJob(string jobName, CancellationToken ct)
        {
            command = new SqlCommand("sp_stop_job", sqlConnection);

            await ExecuteSp(command, ct);

            Dispose();
        }
    }
}