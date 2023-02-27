namespace DataAccess.Model
{
    public class AlbumsViewModel
    {
        public int Id { get; set; }
        public string? AlbumName { get; set; }
        public double HoursPlayed { get; set; }
        public double MinutesPlayed { get; set; }
        public string? FavoriteSong { get; set; }
    }
}
