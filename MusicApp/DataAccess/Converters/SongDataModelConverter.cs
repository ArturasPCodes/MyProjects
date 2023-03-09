using DataAccess.Entities;
using DataAccess.Model;
using Microsoft.IdentityModel.Tokens;

namespace DataAccess.Converters
{
    public class SongDataModelConverter
    {
        public List<SongDataEntity> ConvertToEntity(List<SongDataModel> songsModel)
        {
            List<SongDataEntity> songEntities = new List<SongDataEntity>();

            
            foreach(var song in songsModel)
            {
                if (song.ArtistName == null || song.ArtistName == string.Empty)
                {
                    continue;
                }

                SongDataEntity songEntity = new SongDataEntity();
                songEntity.ArtistName = song.ArtistName;
                songEntity.TrackName = song.TrackName;
                songEntity.AlbumName = song.AlbumName;
                songEntity.Uri = song.Uri;
                songEntity.CountryStreamFrom = song.CountryStreamFrom;
                songEntity.MilisecondsPlayed = song.MilisecondsPlayed;
                songEntity.ReasonSongStarted = song.ReasonSongStarted;
                songEntity.ReasonSongEnded = song.ReasonSongEnded;
                songEntity.TimeSongWasPlayed = song.TimeSongWasPlayed;
                
                songEntities.Add(songEntity);
            }

            return songEntities;
        }
    }
}
