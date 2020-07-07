using System.Data;
using System.Data.SqlClient;

namespace Emsoir.Transversal.Common
{
    public interface IConectionFactory
    {
        SqlConnection GetConection { get; }
    }
}
