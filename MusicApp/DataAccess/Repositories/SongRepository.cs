using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class SongRepository
    {
        protected SongDbContext _songDbContext;

        public SongRepository()
        {
            var songDbContextFactory = new SongDbContextFactory();
            _songDbContext = songDbContextFactory.CreateDbContext(Array.Empty<string>());
        }

        /// <summary>
        /// Write songdata to the database
        /// </summary>
        /// <param name="songDataEntity"></param>
        /// <returns></returns>
        public void CreateMultiplieRecords(List<SongDataEntity> songDataEntities)
        {
            foreach (var songData in songDataEntities)
            {
                _songDbContext.Add(songData);
            }

            _songDbContext.SaveChanges();
        }

        public void DeleteDbData()
        {
            _songDbContext.SongsData.RemoveRange(_songDbContext.SongsData);
            _songDbContext.SaveChanges();
        }
    }
}
