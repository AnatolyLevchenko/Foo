using Q.Domain;

namespace Q.DataAccess
{
    public class VideoRepository:DapperBase<Video>
    {
        public VideoRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
