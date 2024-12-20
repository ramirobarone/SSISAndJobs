using Microsoft.Data.SqlClient;
using SqlServer.SSIS.Dtos;
using SqlServer.SSIS.SqlServer;
using System.Data;
using System.Diagnostics;

namespace SqlServer.ApiService.SqlServer
{
    public class HelpJobService : ConnectionServer
    {
        public HelpJobService(string connectionString) : base(connectionString)
        {
        }

        public async Task<JobHelp?> HelpJob(string job_name, CancellationToken ct)
        {
            await OpenConnection(ct);
            JobHelp? jobHelp = null;
            command = new SqlCommand("sp_help_job", sqlConnection);
            command?.Parameters.AddWithValue("@job_name", job_name);
            command?.Parameters.AddWithValue("@job_aspect", "JOB");

            SqlDataReader reader = await ExecuteSp(command ?? new SqlCommand(), ct);

            do
            {
                while (await reader.ReadAsync())
                {
                    jobHelp = new JobHelp(reader[0]?.ToString() ?? "",
                        reader[1]?.ToString() ?? "",
                        reader[2]?.ToString() ?? "",
                        (byte)reader[3],
                        reader[4].ToString() ?? "",
                        (int)reader[5],
                        reader[6]?.ToString() ?? "",
                        reader[7]?.ToString() ?? "",
                        (int)reader[8],
                        (int)reader[9],
                        (int)reader[10],
                        (int)reader[11],
                        reader[12]?.ToString() ?? "",
                        reader[13]?.ToString() ?? "",
                        reader[14]?.ToString() ?? "",
                        (int)reader[15],
                        Convert.ToDateTime(reader[16]?.ToString()),
                        Convert.ToDateTime(reader[17]),
                        (int)reader[18],
                        (int)reader[19],
                        (int)reader[20],
                        (int)reader[21],
                        (int)reader[22],
                        (int)reader[23],
                        (int)reader[24],
                        (int)reader[25],
                        reader[26]?.ToString() ?? "",
                        (int)reader[27],
                        (int)reader[28],
                        (int)reader[29],
                        (int)reader[30],
                        (int)reader[31]);

                }
            }
            while (await reader.NextResultAsync());

            return jobHelp;
        }
        public async Task<JobActivity> HelpJobActivity(string jobName, CancellationToken ct)
        {
            command = new SqlCommand("msdb.dbo.sp_help_jobactivity", sqlConnection);

            SqlDataReader reader = await ExecuteSp(command, ct);

            JobActivity? jobActivity = null;

            do
            {
                while (await reader.ReadAsync())
                {
                    jobActivity = new JobActivity(
                         (int)reader[0],
                         (Guid)reader[1],
                         reader[2].ToString() ?? "",
                         Convert.ToDateTime(reader[3]),
                         (int)reader[4],
                         Convert.ToDateTime(reader[5]),
                         Convert.ToDateTime(reader[6]),
                         (int)reader[7],
                         Convert.ToDateTime(reader[8]),
                         Convert.ToDateTime(reader[9]),
                         Convert.ToDateTime(reader[10]),
                         (int)reader[11],
                         reader[12].ToString() ?? "",
                         (int)reader[13],
                         (int)reader[14],
                         (int)reader[15],
                         (int)reader[16]);
                }
            }
            while (await reader.NextResultAsync());

            return jobActivity ?? throw new ArgumentNullException();
        }
    }
}