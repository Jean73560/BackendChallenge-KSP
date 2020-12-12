using System.Data;

namespace JPSD.ChallengeKSP.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
