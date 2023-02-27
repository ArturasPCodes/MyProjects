using DataAccess.Filters;
using System.Windows;

namespace MusicApp.Windows
{
    /// <summary>
    /// Interaction logic for FunFactsWindow.xaml
    /// </summary>
    public partial class TopStatsWindow : Window
    {
        public TopStatsWindow()
        {
            InitializeComponent();
            ListFacts();
        }

        private void ListFacts()
        {
            var filter = new DbFilters();
            nRecordsInDbLbl.Content = filter.CountRecords();

            if (nRecordsInDbLbl.Content.ToString() == "0")
            {
                return;
            }

            nTotalArtistsLbl.Content = filter.CustomCount(x => x.ArtistName);
            nTotalSongsLbl.Content = filter.CustomCount(x => x.TrackName);
            nTotalAlbumsLbl.Content = filter.CustomCount(x => x.AlbumName);

            nTotalHoursLbl.Content = filter.CountTotalHours();

            nTopArtistLbl.Content = filter.GetMostStreamedName(x => x.ArtistName);
            nTopArtistHoursLbl.Content = filter.GetMostStreamedHours(x => x.ArtistName);

            nTopSongLbl.Content = filter.GetMostStreamedName(x => x.TrackName);
            nTopSongHoursLbl.Content = filter.GetMostStreamedHours(x => x.TrackName);

            nTopAlbumLbl.Content = filter.GetMostStreamedName(x => x.AlbumName);
            nTopAlbumHoursLbl.Content = filter.GetMostStreamedHours(x => x.AlbumName);
        }
    }
}
