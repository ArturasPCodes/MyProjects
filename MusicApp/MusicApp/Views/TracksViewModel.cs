namespace DataAccess.Model
{
    public class TracksViewModel
    {
        public int Id { get; set; }
        public string? TrackName { get; set; }
        public double HoursPlayed { get; set; }
        public double MinutesPlayed { get; set; }
        public string? AlbumName { get; set; }
    }
}