using DataAccess.Entities;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Filters
{
    public class SongDataFilters
    {
        public List<TracksViewModel> SumTracksByMinutes(List<SongDataEntity> songDataEntityList)
        {
            var tracksSummedByMs = songDataEntityList.GroupBy(data => data.TrackName)
                .Select(
                    songEntity => new TracksViewModel
                    {
                        TrackName = songEntity.Key,
                        HoursPlayed = Math.Round(songEntity.Sum(s => ConvertToHours(s.MilisecondsPlayed)),2),
                        MinutesPlayed = Math.Round(songEntity.Sum(s => ConvertToMinutes(s.MilisecondsPlayed)),2),
                        AlbumName = songEntity.First().AlbumName
                    }
                )
                .OrderByDescending(x => x.HoursPlayed)
                .Take(10)
                .ToList();

            return AssignIdToTracks(tracksSummedByMs);
        }

        public List<AlbumsViewModel> SumAlbumsByMinutes(List<SongDataEntity> songDataEntityList)
        {
            var albumsSummedByMs = songDataEntityList.GroupBy(data => data.AlbumName)
                .Select(
                    songEntity => new AlbumsViewModel
                    {
                        AlbumName = songEntity.Key,
                        HoursPlayed = Math.Round(songEntity.Sum(s => ConvertToHours(s.MilisecondsPlayed)), 2),
                        MinutesPlayed = Math.Round(songEntity.Sum(s => ConvertToMinutes(s.MilisecondsPlayed)), 2),
                        FavoriteSong = GetFavouriteSong(songEntity)
                    }
                )
                .OrderByDescending(x => x.HoursPlayed)
                .Take(5)
                .ToList();

            return AssignIdToAlbum(albumsSummedByMs);
        }       

        private string GetFavouriteSong(IGrouping<string, SongDataEntity> songEntity)
        {
            return songEntity
                .OrderByDescending(song => song.MilisecondsPlayed)
                .Take(1)
                .FirstOrDefault()
                .TrackName;
        }

        private List<TracksViewModel> AssignIdToTracks(List<TracksViewModel> list)
        {
            foreach (var item in list)
            {
                item.Id = list.IndexOf(item) + 1;
            }

            return list;
        }

        private List<AlbumsViewModel> AssignIdToAlbum(List<AlbumsViewModel> list)
        {
            foreach (var item in list)
            {
                item.Id = list.IndexOf(item) + 1;
            }

            return list;
        }

        private double ConvertToMinutes(double ms)
        {
            return (ms / 60000);
        }

        private double ConvertToHours(double ms)
        {
            return (ms / 3600000);
        }
    }
}
