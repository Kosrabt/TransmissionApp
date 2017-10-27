using System;
using System.Collections.Generic;
using System.Text;

namespace TransmissionApp.Business.Logic.Exceptions
{
    public class JobNotFoundException : ApplicationException
    {
        public JobNotFoundException(string jobId)
            : base($"Job with id: {jobId} not found")
        {          
        }
    }
}
