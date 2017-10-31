using System.IO;
using System.Linq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TransmissionApp.Business.Logic.Configuration.Models;
using TransmissionApp.Business.Logic.Exceptions;

namespace TransmissionApp.Business.Logic.Configuration
{
    public class ConfigurationManager
    {
        private const string DefaultConfigFileLocation = "./transmissionrss-config/rssjobs.json";
        private readonly AppConfiguration appConfiguration;
        public string FileLocation => appConfiguration?.ConfigFileLocation ?? DefaultConfigFileLocation;

        private ClientConfiguration clientConfiguration;

        public ClientConfiguration ClientConfiguration
        {
            get { return clientConfiguration ?? (clientConfiguration = LoadConfiguration()); }
            set { clientConfiguration = value; }
        }

        public ConfigurationManager(AppConfiguration appConfiguration)
        {
            this.appConfiguration = appConfiguration;
        }

        public ClientConfiguration LoadConfiguration()
        {
            ClientConfiguration rssClientConfiguration = new ClientConfiguration();

            if (File.Exists(FileLocation))
            {
                using (StreamReader file = File.OpenText(FileLocation))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    rssClientConfiguration = (ClientConfiguration)serializer.Deserialize(file, typeof(ClientConfiguration));
                }
            }
            else
            {               
                WriteConfiguration(rssClientConfiguration);
            }
            return rssClientConfiguration;
        }

        public void WriteConfiguration(ClientConfiguration _config = null)
        {
           
            ClientConfiguration config =_config??clientConfiguration;
            var directory = Path.GetDirectoryName(FileLocation);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter file = File.CreateText(FileLocation))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, config);
            }
        }

        public void UpdateSettings(ClientConfiguration config)
        {
            var oldJobs = clientConfiguration.Jobs;
            clientConfiguration = config;
            clientConfiguration.Jobs = oldJobs;
            WriteConfiguration();
        }

        public void AddJob(JobConfiguration jobConfiguration)
        {
            var jobs = ClientConfiguration.Jobs.ToList();
            jobs.Add(jobConfiguration);
            ClientConfiguration.Jobs = jobs;
            WriteConfiguration();
        }

        public void DeleteJob(string id)
        {
            var oldConfigurationFile = clientConfiguration;
            var jobs = clientConfiguration.Jobs.Where(x => x.Id != id).ToList();
            clientConfiguration.Jobs = jobs;
            WriteConfiguration();
        }

        public void AddRule(string jobId, RuleConfiguration ruleConfiguration)
        {
            var job = ClientConfiguration.Jobs.FirstOrDefault(x => x.Id == jobId);
            if (job == null)
            {
                throw new JobNotFoundException(jobId);
            }

            var newRules = job.Rules.ToList();
            newRules.Add(ruleConfiguration);
            job.Rules = newRules;
            WriteConfiguration();           
        }

        public void DeleteRule(string jobId, string ruleId)
        {
            var job = ClientConfiguration.Jobs.FirstOrDefault(x => x.Id == jobId);
            if (job == null)
            {
                throw new JobNotFoundException(jobId);
            }

            var newRules = job.Rules.Where(x => x.Id != ruleId);
            job.Rules = newRules;
            WriteConfiguration();
        }
    }
}