using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.Configuration;
using SqlServer.ApiService.SqlServer;
using SqlServer.SSIS.Dtos;
using SqlServer.SSIS.Enums;
using SqlServer.SSIS.SqlServer;

namespace SqlServer.ApiService.UnitTest
{
    public class StartAndStopJobs_Test
    {
        string connectionString = "";
        const string JobName = "JobPrueba";
        const string JobNameFail = "JobPruebaFail";

        public StartAndStopJobs_Test()
        {
            var configuration = new ConfigurationBuilder()
               .AddUserSecrets<StartAndStopJobs_Test>()
               .Build();

            connectionString = configuration.GetSection("connectionString").Value ?? throw new InvalidConfigurationException();

        }
        [Fact]
        public async void OpenConnectionWithDataBase_Ok()
        {
            var _jobService = new JobService(connectionString);

            Assert.True(await _jobService.OpenConnection(CancellationToken.None));
        }

        [Fact]
        public async void ExecuteJob_Fail()
        {
            var _jobService = new JobService(connectionString);

            await Assert.ThrowsAnyAsync<Exception>(async () => await _jobService.StartJob(JobNameFail, CancellationToken.None));

        }
        [Fact]
        public async void ExecuteJob_ResultTrue()
        {
            var _jobService = new JobService(connectionString);

            Assert.True(await _jobService.StartJob(JobName, CancellationToken.None));
        }
        [Fact]
        public async void HelpJob_Ok()
        {
            var _jobService = new HelpJobService(connectionString);

            var jobHelp = await _jobService.HelpJob(JobName, CancellationToken.None);


            Assert.NotNull(jobHelp);
            Assert.True(jobHelp.CurrentExecutionStatus == (int)StatusRunJob.Inactive);
        }
    }
}