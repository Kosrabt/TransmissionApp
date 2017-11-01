using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransmissionApp.TorrentClients.Models;

namespace TransmissionApp.TorrentClients.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Transmission.API.RPC.Entity.TorrentInfo, TorrentInfo>();
            CreateMap<TorrentInfo, Transmission.API.RPC.Entity.TorrentInfo>();

            CreateMap<Transmission.API.RPC.Entity.TransmissionTorrentFileStats, TorrentFileStats>();
            CreateMap<TorrentFileStats, Transmission.API.RPC.Entity.TransmissionTorrentFileStats>();

            CreateMap<Transmission.API.RPC.Entity.TransmissionTorrentFiles, TorrentFiles>();
            CreateMap<TorrentFiles, Transmission.API.RPC.Entity.TransmissionTorrentFiles>();

            CreateMap<Transmission.API.RPC.Entity.TransmissionTorrentPeers, TorrentPeers>();
            CreateMap<TorrentPeers, Transmission.API.RPC.Entity.TransmissionTorrentPeers>();

            CreateMap<Transmission.API.RPC.Entity.TransmissionTorrentPeersFrom, TorrentPeersFrom>();
            CreateMap<TorrentPeersFrom, Transmission.API.RPC.Entity.TransmissionTorrentPeersFrom>();

            CreateMap<Transmission.API.RPC.Entity.TransmissionTorrentTrackers, TorrentTrackers>();
            CreateMap<TorrentTrackers, Transmission.API.RPC.Entity.TransmissionTorrentTrackers>();

            CreateMap<Transmission.API.RPC.Entity.TransmissionTorrentTrackerStats, TorrentTrackerStats>();
            CreateMap<TorrentTrackerStats, Transmission.API.RPC.Entity.TransmissionTorrentTrackerStats>();


            CreateMap<Transmission.API.RPC.Entity.SessionInfo, SessionInfo>();
            CreateMap<Task<Transmission.API.RPC.Entity.SessionInfo>, Task<SessionInfo>>();

            CreateMap<SessionSettings, Transmission.API.RPC.Arguments.SessionSettings>();

            CreateMap<Transmission.API.RPC.Entity.TransmissionTorrents, AllTorrents>()
                .ForMember(dest => dest.Torrents, cfg => cfg.MapFrom(d => d.Torrents))
                .ForMember(dest => dest.Removed, cfg => cfg.MapFrom(d => d.Removed));

            CreateMap<Task<Transmission.API.RPC.Entity.TransmissionTorrents>, Task<AllTorrents>>();
            CreateMap<NewTorrent, Transmission.API.RPC.Entity.NewTorrent>();

            CreateMap<Task<Transmission.API.RPC.Entity.NewTorrentInfo>, Task<NewTorrentInfo>>();
            CreateMap<Transmission.API.RPC.Entity.NewTorrentInfo, NewTorrentInfo>();
            CreateMap<NewTorrentInfo, Transmission.API.RPC.Entity.NewTorrentInfo>();
        }
    }
}
