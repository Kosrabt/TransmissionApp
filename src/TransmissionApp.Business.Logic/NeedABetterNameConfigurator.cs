using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using TransmissionApp.Business.Logic.Configuration;
using TransmissionApp.Business.Logic.Configuration.Models;
using TransmissionApp.Business.Logic.Exceptions;

namespace TransmissionApp.Business.Logic
{

    public class NeedABetterNameConfigurator
    {
        ConfigurationManager configurationManager = null;

        public NeedABetterNameConfigurator(IOptions<AppConfiguration> appConfigurationAccessor)
        {
            configurationManager = new ConfigurationManager(appConfigurationAccessor.Value);
        }

        public ClientConfiguration GetClientConfiguration()
        {
            return configurationManager.ClientConfiguration;
        }

        public void SetClientConfiguration(ClientConfiguration clientConfiguration)
        {
            configurationManager.UpdateSettings(clientConfiguration);
        }

        public JobConfiguration GetJob(string id)
        {
            var job = configurationManager.ClientConfiguration.Jobs.FirstOrDefault(x => x.Id == id);
            if (job == null)
                throw new JobNotFoundException(id);

            return job; 
        }

        public void SetJob(JobConfiguration job)
        {
            var oldJob = configurationManager.ClientConfiguration.Jobs.FirstOrDefault(x => x.Id == job.Id);
            if (oldJob == null)
            {
                configurationManager.AddJob(job);
            }
            else
            {
                configurationManager.DeleteJob(oldJob.Id);
                configurationManager.AddJob(job);               
            }
        }

        public void DeleteJob(string id)
        {
            var job = GetJob(id);
            configurationManager.DeleteJob(id);
        }

        public RuleConfiguration GetRule(string jobId, string id)
        {
            var job = configurationManager.ClientConfiguration.Jobs.FirstOrDefault(x => x.Id == jobId);
            if (job == null)
                throw new JobNotFoundException(jobId);

            var rule = job.Rules.FirstOrDefault(x => x.Id == id);
            if (rule == null)
                throw new RuleNotFoundException(jobId, id);
            return rule;
        }


        public void SetRule(string jobId, RuleConfiguration rule)
        {
            var job = configurationManager.ClientConfiguration.Jobs.FirstOrDefault(x => x.Id == jobId);
            if (job == null)
                throw new JobNotFoundException(jobId);

            var oldRule = job.Rules.FirstOrDefault(x => x.Id == rule.Id);
            if (oldRule == null)
            {
                configurationManager.AddRule(jobId, rule);
            }
            else
            {
                configurationManager.DeleteRule(jobId, oldRule.Id);
                configurationManager.AddRule(jobId, rule);              
            }           

        }

        public void DeleteRule(string jobId, string id)
        {
            var rule = GetRule(jobId, id);
            configurationManager.DeleteRule(jobId, id);
        }
    }
}
