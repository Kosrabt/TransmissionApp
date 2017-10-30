using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Business.Logic.Exceptions
{
    public class RuleNotFoundException : ApplicationException
    {
        public RuleNotFoundException(string jobId, string ruleId)
            : base($"Rule with id: {ruleId} not found in job: {jobId}")
        {          
        }
    }
}
