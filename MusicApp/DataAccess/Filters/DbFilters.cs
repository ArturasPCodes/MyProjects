using DataAccess.Entities;
using DataAccess.Model;
using System.Linq.Expressions;

namespace DataAccess.Filters
{
    public class DbFilters
    {
        protected SongDbContext _songDbContext;

        public DbFilters()
        {
            var songDbContextFactory = new SongDbContextFactory();
            _songDbContext = songDbContextFactory.CreateDbContext(Array.Empty<string>());
        }

        public List<SongDataEntity> GetSongs()
        {
            return _songDbContext.SongsData.ToList();;
        }

        /// <summary>
        /// Returns all the records in the database filtered by artist name
        /// </summary>
        /// <returns></returns>
        public List<SongDataEntity> GetSongsByName(List<SongDataEntity> list, string artistName)
        {
            return list.Where(row => row.ArtistName == artistName).ToList();
        } 

        public int CountRecords()
        {
            return _songDbContext
                .SongsData
                .Count();
        }

        public int CustomCount<T>(Expression<Func<SongDataEntity, T>> condition)
        {
            return _songDbContext
                .SongsData
                .Select(condition)
                .Distinct()
                .Count();
        }

        public double CountTotalHours()
        {
            var ms = _songDbContext
                .SongsData
                .Sum(x => x.MilisecondsPlayed);

            return Math.Round(ConvertToHours(ms), 2);
        }

        public string GetMostStreamedName(Func<SongDataEntity, string> condition)
        {
            var topOne = GetMostStreamed(condition);
            return topOne.Name;
        }

        public double GetMostStreamedHours(Func<SongDataEntity, string> condition)
        {
            var topOne = GetMostStreamed(condition);
            return topOne.HoursPlayed;
        }

        private TopSongModel GetMostStreamed(Func<SongDataEntity, string> condition)
        {
            var songs = _songDbContext
                .SongsData
                .ToList()
                .GroupBy(condition)
                .Select(
                    song => new TopSongModel
                    {
                        Name = song.Key,
                        HoursPlayed = Math.Round(song.Sum(x => ConvertToHours(x.MilisecondsPlayed)), 2)
                    }
                )
                .OrderByDescending(x => x.HoursPlayed)
                .Take(1);

            return new TopSongModel
            {
                Name = songs.First().Name,
                HoursPlayed = songs.First().HoursPlayed
            };
        }

        private double ConvertToHours(double ms)
        {
            return (ms / 3600000);
        }
    }
}
