namespace DataAccess.Repositories
{
    public class FileLogRepository
    {
        public void WriteToCsv(string fileName, string path, bool isNew)
        {
            using (StreamWriter writer = new StreamWriter(path, isNew))
            {
                writer.WriteLine(fileName);
            }
        }
    }
}
