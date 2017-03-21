using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Core;
using EDeviceClaims.Entities;

namespace EDeviceClaims.Repositories
{
    public interface IClaimRepository : IEfRepository<ClaimEntity, Guid>
    {
        ClaimEntity GetByPolicyId(Guid policyId);
    }

    public class ClaimRepository : EfRepository<ClaimEntity, Guid>, IClaimRepository
    {
        public ClaimEntity GetByPolicyId(Guid policyId)
        {

            try // to find the first claim entry
            {
                return ObjectSet.FirstOrDefault(c => c.PolicyId == policyId);
            }
            catch (NullReferenceException)
            {
                //return a new claim if there aren't any
                return new ClaimEntity();
            }
            
        }
    }
}
