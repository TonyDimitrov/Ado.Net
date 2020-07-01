using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ado.Net.Web.Data
{
    public interface IDbAccessor
    {
        Task<SqlConnection> Open();
    }
}
