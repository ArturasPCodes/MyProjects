using DataAccess.Converters;
using DataAccess.Entities;
using DataAccess.Model;
using DataAccess.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MusicApp.Windows
{
    /// <summary>
    /// Interaction logic for DataAccessWindow.xaml
    /// </summary>
    public partial class DataAccessWindow : Window
    {
        public DataAccessWindow()
        {
            InitializeComponent();
        }

        private void nInsertNewDataBtn_Click(object sender, RoutedEventArgs e)
        {
            var fileInformation = GetFileName();

            InsertData(fileInformation);
        }

        private void nDeleteDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GetConfirmationOfDeletion() == "OK")
            {
                DeleteDbData();
                nDataAccessMessageLbl.Content = "Database has been cleared";
            }
        }

        private FileInformation GetFileName()
        {
            //Create OpenFileDialog
            OpenFileDialog dlg = new OpenFileDialog();

            //Set filter for file extension and default file extension
            dlg.DefaultExt = ".json";
            dlg.Filter = "json files (*.json)|*.json";

            //Open the window to look for the file
            bool? result = dlg.ShowDialog();

            //Get the file info and store it in a object of strings
            var fileInformation = new FileInformation();

            if (result == true)
            {
                fileInformation.Path = dlg.FileName;
                fileInformation.Name = Path.GetFileName(fileInformation.Path);
            }

            return fileInformation;
        }

        private void InsertData(FileInformation fileData)
        {
            if (fileData.Path is null)
            {
                return;
            }

            try
            {
                var songDataEntities = GetDataForDb(fileData.Path);

                WriteDataToDb(songDataEntities);

                WriteToLog(fileData.Name);

                nDataAccessMessageLbl.Content = fileData.Name + " was inserted into the Database";
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error occured");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Error occured");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unknown error occured, contact administrator", "Error occured");
            }
        }

        private List<SongDataEntity> GetDataForDb(string path)
        {
            try
            {
                var songModelRepository = new SongModelRepository();
                var songsData = songModelRepository.GetSongs(path);

                var songDataModelConverter = new SongDataModelConverter();

                return songDataModelConverter.ConvertToEntity(songsData);
            }
            catch
            {
                throw new FormatException("Failed to read the data into the model, check the file formating");
            }
        }

        /// <summary>
        /// Inserts the data to database
        /// </summary>
        /// <param name="songDataEntities"></param>
        private void WriteDataToDb(List<SongDataEntity> songDataEntities)
        {
            var songEntityRepository = new SongEntityRepository();

            foreach (var songData in songDataEntities)
            {
                songEntityRepository.CreateDataRecord(songData);
            }

            songEntityRepository.SaveChangesInDb();
        }

        /// <summary>
        /// Logs which files have been written to database
        /// </summary>
        /// <param name="message">File name</param>
        /// <exception cref="IOException"></exception>
        private void WriteToLog(string message)
        {
            try
            {
                var logRepository = new FileLogRepository();
                logRepository.WriteToCsv(message, "log.csv", true);
            }
            catch
            {
                throw new IOException("Log file is open, please close it");
            }
        }

        private string GetConfirmationOfDeletion()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear the database?!",
                "Please confirm your action",
                MessageBoxButton.OKCancel);

            return result.ToString();
        }

        private void DeleteDbData()
        {
            var songEntityRepository = new SongEntityRepository();
            songEntityRepository.DeleteDbData();

            //Clear the log
            var logRepository = new FileLogRepository();
            logRepository.WriteToCsv("Files written to DB", "log.csv", false);
        }   
    }
}
