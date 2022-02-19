using backend.Models;

namespace backend.Repositories
{
    public interface IMongoCatCollection
    {
        Task InsertMongoCat(MongoCat mcat);//TASk for asyn
        Task UpdateMongoCat(MongoCat mcat);
        Task DeleteMongoCat(string id);
        Task<MongoCat> GetMongoCat(string id);   
        Task<List<MongoCat>> GetAllMongoCats();
    }
}
