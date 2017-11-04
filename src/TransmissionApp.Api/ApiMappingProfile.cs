
using AutoMapper;
using TransmissionApp.Business.Logic.Configuration.Models;
using TransmissionApp.Api.Client.Contracts;
using TransmissionApp.Business.Logic.Models;

namespace TransmissionApp.Api
{

    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            //  CreateMap<User, UserDto>();  CreateMap<UserDto, User>();
            CreateMap<ClientConfiguration, SettingsOutModel>();
            CreateMap<JobConfiguration, JobOutModel>().ForMember(dest => dest.Rules, cfg => cfg.MapFrom(s => s.Rules));
            CreateMap<RuleConfiguration, RuleOutModel>();

            CreateMap<ResolvedRssItem, TestRssItemModel>();

            CreateMap<ManagedItem, TestOutModel>().ForMember(dest => dest.StateInt, cfg => cfg.MapFrom(x => (int)x.State));
        }
    }
}
