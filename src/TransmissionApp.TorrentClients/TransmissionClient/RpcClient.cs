using AutoMapper;
using System.Threading.Tasks;
using Transmission.API.RPC;
using TransmissionApp.TorrentClients.Mapper;
using TransmissionApp.TorrentClients.Models;

namespace TransmissionApp.TorrentClients.TransmissionClient
{
    public class RpcClient
    {
        Client client;
        IMapper mapper;

        public RpcClient(string host, string login, string pass)
        {          
            client = new Client(host, null, login, pass);
            mapper = MapperSingleton.MapperInstance;
        }

        public Task<SessionInfo> GetSessionInformationAsync()
        {
            return mapper.Map<Task<SessionInfo>>(client.GetSessionInformationAsync());
        }

        public void SetSessionSettingsAsync(SessionSettings info)
        {
            client.SetSessionSettingsAsync(mapper.Map<Transmission.API.RPC.Arguments.SessionSettings>(info));
        }

        public AllTorrents TorrentGet(int[] ids = null)
        {
            var torrents = client.TorrentGet(TorrentFields.USEFULL_FIELDS, ids);            
            return mapper.Map<AllTorrents>(torrents);
        }

        public Task<AllTorrents> TorrentGetAsync(int[] ids = null)
        {
            var torrents = client.TorrentGetAsync(TorrentFields.USEFULL_FIELDS, ids);
            return mapper.Map<Task<AllTorrents>>(torrents);
        }

        public Task<NewTorrentInfo> TorrentAddAsync(NewTorrent torrent)
        {
            return mapper.Map<Task<NewTorrentInfo>>(client.TorrentAddAsync(mapper.Map<Transmission.API.RPC.Entity.NewTorrent>(torrent)));
        }

        public void TorrentRemoveAsync(int[] ids, bool deleteData = false)
        {
            client.TorrentRemoveAsync(ids, deleteData);
        }
    }
}
