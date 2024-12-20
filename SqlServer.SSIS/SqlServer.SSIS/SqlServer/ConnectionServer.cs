using Microsoft.Data.SqlClient;
using System.Data;

namespace SqlServer.SSIS.SqlServer
{
    public class ConnectionServer : IDisposable
    {
        private const int Column_current_execution_status = 25;
        private const string ColumnName_current_execution_status = "current_execution_status";
        private const string ColumnName_execution_id = "execution_id";
        private const int Column_status = 8;

        protected readonly string sqlConnectionString;
        protected SqlCommand? command;
        protected SqlConnection? sqlConnection;

        public ConnectionServer(string connectionString)
        {
            sqlConnectionString = connectionString ?? throw new ArgumentException();
        }
        protected async Task<SqlDataReader> ExecuteSp(SqlCommand command, CancellationToken ct) => await command.ExecuteReaderAsync(ct);

        /// <summary>
        /// Open Connection with data base, if connection string of constructor is empty throw a ArgumentException.
        /// </summary>
        /// <param name="ct">Cancellation Token</param>
        /// <returns> SqlConnection Opened</returns>
        /// <exception cref="ArgumentException"></exception>
        protected async Task<bool> OpenConnection(CancellationToken ct)
        {
            if (string.IsNullOrEmpty(sqlConnectionString))
                throw new ArgumentException("Connection string is empty.");

            sqlConnection = new SqlConnection(sqlConnectionString);

            await sqlConnection.OpenAsync(ct);

            return sqlConnection.State == ConnectionState.Open;
        }

        //public bool ExecuteViewsReturnsExecutions(string projectName, string package_name)
        //{
        //    string status = GetStatusFromView_ReturnExecutions(projectName, package_name);

        //    while (status == nameof(StatusRunSSIS.Running))
        //    {
        //        Thread.Sleep(1000);
        //        status = GetStatusFromView_ReturnExecutions(projectName, package_name);
        //    }

        //    return status == nameof(StatusRunSSIS.Succeeded);
        //}

        //private string GetStatusFromView_ReturnExecutions(string projectName, string package_name)
        //{
        //    using SqlConnection connection = new SqlConnection(sqlConnectionString);

        //    SqlCommand command = new SqlCommand($"SELECT top 1 * FROM [SSISDB].[custom].[returnExecutions] where project_name like '%{projectName}%' and package_name like '%{package_name}%' order by execution_id desc", connection);
        //    command.CommandType = System.Data.CommandType.Text;

        //    try
        //    {
        //        connection.Open();
        //        using SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            string status = reader[Column_status].ToString() ?? throw new Exception("query result is empty");

        //            return status;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection?.Close();
        //        connection?.Dispose();
        //    }
        //    return string.Empty;
        //}

        //public async Task<int> ExecuteHelpJobActivity(string job_name)
        //{
        //    int statusId = 0;

        //    statusId = await QueryJobStatus(job_name);

        //    if (statusId == (int)StatusRunJob.Execution)
        //    {
        //        await Task.Delay(1000);
        //        statusId = await QueryJobStatus(job_name);

        //    }

        //    return statusId == (int)StatusRunJob.Inactive ? statusId : 0;
        //}

        //private async Task<int> QueryJobStatus(string job_name)
        //{
        //    int statusId = 0;

        //    using (SqlConnection connection = new SqlConnection(sqlConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("msdb.dbo.sp_help_job", connection);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@job_name", job_name);

        //        try
        //        {
        //            connection.Open();
        //            using (SqlDataReader reader = await command.ExecuteReaderAsync())
        //            {
        //                int resultSetIndex = 0;
        //                do
        //                {
        //                    Console.WriteLine($"Processing result set {resultSetIndex + 1}");
        //                    while (await reader.ReadAsync())
        //                    {
        //                        for (int i = 0; i < reader.FieldCount; i++)
        //                        {
        //                            if (reader.GetName(i) == ColumnName_current_execution_status)
        //                                return statusId = Convert.ToInt32(reader[i]);
        //                        }
        //                        resultSetIndex++;
        //                    }
        //                }
        //                while (await reader.NextResultAsync());
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error: " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection?.Close();
        //            connection?.Dispose();
        //        }
        //    }
        //    return statusId;
        //}
        //public async Task ExecuteJob(string job_name, string projectName, string packageName)
        //{

        //    while (!ExecuteViewsReturnsExecutions(projectName, packageName)) ;

        //    using (SqlConnection connection = new SqlConnection(sqlConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("msdb.dbo.sp_start_job", connection);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@job_name", job_name);

        //        try
        //        {
        //            connection.Open();
        //            var response = await command.ExecuteReaderAsync();

        //            while (await response.ReadAsync())
        //            {
        //                string message = response[0].ToString() ?? throw new Exception(message: "No hay resultado del status del job.");
        //                Console.WriteLine($"Job started successfully. {response}");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error: " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection?.Close();
        //            connection?.Dispose();
        //        }
        //    }
        //}

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }
}