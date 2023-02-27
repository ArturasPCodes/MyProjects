using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class SongEntityRepository
    {
        protected SongDbContext _songDbContext;

        public SongEntityRepository()
        {
            var songDbContextFactory = new SongDbContextFactory();
            _songDbContext = songDbContextFactory.CreateDbContext(Array.Empty<string>());
        }

        /// <summary>
        /// Create a SongDataEntity in the data base
        /// </summary>
        /// <param name="songDataEntity"></param>
        /// <returns></returns>
        public void CreateDataRecord(SongDataEntity songDataEntity)
        {
            _songDbContext.Add(songDataEntity);
        }

        public void SaveChangesInDb()
        {
            _songDbContext.SaveChanges();
        }

        public void DeleteDbData()
        {
            _songDbContext.SongsData.RemoveRange(_songDbContext.SongsData);
            _songDbContext.SaveChanges();
        }
    }
}
