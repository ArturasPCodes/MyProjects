using DataAccess.Entities;
using DataAccess.Filters;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MusicApp.Windows
{
    /// <summary>
    /// Interaction logic for TopStatsWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private SelectedFilter selectedFilter = SelectedFilter.None;
        private string filteredName = string.Empty;
        private List<SongDataEntity> songEntities;

        public SearchWindow()
        {
            InitializeComponent();
            var filterDb = new DbFilters();
            songEntities = filterDb.GetSongs();
        }

        private void nSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            nDgGridIntro.Visibility = Visibility.Hidden;
            nDgGrid.Visibility = Visibility.Visible;
            ReadInputs();
            ExecuteSearch(songEntities);
            nNameTxtBox.Focus();
        }

        private void ExecuteSearch(List<SongDataEntity> list)
        {
            try
            {
                var songList = new List<SongDataEntity>();

                if (filteredName != string.Empty)
                {
                    var filterDb = new DbFilters();
                    songList = filterDb.GetSongsByName(songEntities, filteredName);

                    if (songList.Count == 0)
                    {
                        throw new Exception("Such artist could not be found");
                    }
                }
                else
                {
                    songList = songEntities;
                }

                var filter = new SongDataFilters();

                switch (selectedFilter)
                {
                    case SelectedFilter.Tracks:
                        var tracks = filter.SumTracksByMinutes(songList);
                        ShowResultByTracks(tracks);
                        break;
                    case SelectedFilter.Albums:
                        var albums = filter.SumAlbumsByMinutes(songList);
                        ShowResultByAlbums(albums);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Note");
            }
        }

        private void ShowResultByTracks(List<TracksViewModel> filteredEntityList)
        {
            nToplbl.Content = "Top songs of " + filteredName;

            nDGTop.ItemsSource = filteredEntityList;

            nDGTop.Columns[0].Width = DataGridLength.Auto;

            nDGTop.Columns[1].Header = "Track Name";

            nDGTop.Columns[2].Header = "Hours Played";
            nDGTop.Columns[2].Width = DataGridLength.Auto;

            nDGTop.Columns[3].Header = "Minutes Played";
            nDGTop.Columns[3].Width = DataGridLength.Auto;

            nDGTop.Columns[4].Header = "Album Name";
        }

        private void ShowResultByAlbums(List<AlbumsViewModel> filteredEntityList)
        {
            nToplbl.Content = "Top albums of " + filteredName;

            nDGTop.ItemsSource = filteredEntityList;

            nDGTop.Columns[0].Width = DataGridLength.Auto;

            nDGTop.Columns[1].Header = "Album name";

            nDGTop.Columns[2].Header = "Hours Played";
            nDGTop.Columns[2].Width = DataGridLength.Auto;

            nDGTop.Columns[3].Header = "Minutes Played";
            nDGTop.Columns[3].Width = DataGridLength.Auto;

            nDGTop.Columns[4].Header = "Favourite song of the album";
        }

        private void nFilterComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsSearchEnabled();
        }

        private void nFilterComBox_DropDownClosed(object sender, EventArgs e)
        {
            IsSearchEnabled();
        }

        /// <summary>
        /// Checks if search button can be pressed
        /// </summary>
        private void IsSearchEnabled()
        {
            ReadInputs();

            if (selectedFilter == SelectedFilter.None)
            {
                nSearchBtn.IsEnabled = false;
                return;
            }

            nSearchBtn.IsEnabled = true;
        }

        private void ReadInputs()
        {
            switch (nFilterComBox.Text)
            {
                case "Tracks":
                    selectedFilter = SelectedFilter.Tracks;
                    break;
                case "Albums":
                    selectedFilter = SelectedFilter.Albums;
                    break;
                default:
                    selectedFilter = SelectedFilter.None;
                    break;
            }

            filteredName = nNameTxtBox.Text;
        }
    }
}
