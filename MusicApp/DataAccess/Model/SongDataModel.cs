using Newtonsoft.Json;

namespace DataAccess.Model
{
    public class SongDataModel
    {
        [JsonProperty("ts")]
        public DateTime TimeSongWasPlayed { get; set; }

        [JsonProperty("ms_played")]
        public double MilisecondsPlayed { get; set; }

        [JsonProperty("conn_country")]
        public string CountryStreamFrom { get; set; }

        [JsonProperty("master_metadata_track_name")]
        public string? TrackName { get; set; }

        [JsonProperty("master_metadata_album_artist_name")]
        public string? ArtistName { get; set; }

        [JsonProperty("master_metadata_album_album_name")]
        public string? AlbumName { get; set; }

        [JsonProperty("spotify_track_uri")]
        public string? Uri { get; set; }

        [JsonProperty("reason_start")]
        public string ReasonSongStarted { get; set; }

        [JsonProperty("reason_end")]
        public string ReasonSongEnded { get; set; }
    }
}
