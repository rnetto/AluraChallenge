using AluraFlix.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraFlix.Service
{
    public interface IVideoService
    {
        Task<List<Video>> GetAll();
        Task<Video> GetId(int id);
        Task<Video> Update(int id, Video videoUpdate);
        Task<Video> Insert(Video video);
        Task<int?> Delete(int id);
    }
}