using DataAccess.Model;
using Newtonsoft.Json;

namespace DataAccess.Repositories
{
    public class SongModelRepository
    {
        public List<SongDataModel> GetSongs(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                var line = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<SongDataModel>>(line);
            }
        }
    }
}
