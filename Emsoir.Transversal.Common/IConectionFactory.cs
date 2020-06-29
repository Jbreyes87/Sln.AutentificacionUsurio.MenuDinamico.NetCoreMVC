using System.Data;
namespace Emsoir.Transversal.Common
{
    public interface IConectionFactory
    {
       IDbConnection GetConection { get; }
    }
}
