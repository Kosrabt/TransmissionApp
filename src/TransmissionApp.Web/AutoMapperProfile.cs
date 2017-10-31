using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TransmissionApp.Api.Client.Models;

namespace TransmissionApp.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SettingsOutModel, ViewModels.Settings.IndexViewModel>();
            CreateMap<ViewModels.Settings.IndexViewModel, SettingsInModel>();

            CreateMap<JobOutModel, ViewModels.Jobs.JobViewModel>().ForMember(m => m.Rules, cfg => cfg.MapFrom(x => x.Rules));
            CreateMap<RuleOutModel, ViewModels.Jobs.RuleViewModel>();

            CreateMap<ViewModels.Jobs.JobViewModel, JobInModel>();

            CreateMap<RuleOutModel, ViewModels.Rules.RuleViewModel>();
            CreateMap<ViewModels.Rules.RuleViewModel, RuleInModel>();

        }
    }
}
