using Q.Domain;

namespace Q.DataAccess
{
    public class CategoryRepository : DapperBase<Category>
    {
        public CategoryRepository(string connectionString) : base(connectionString)
        {
        }
    }
}