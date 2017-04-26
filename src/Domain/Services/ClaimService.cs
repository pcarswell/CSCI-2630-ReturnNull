using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;

namespace EDeviceClaims.Domain.Services
{

    public interface IClaimService
    {
        ClaimDomainModel StartClaim(Guid policyId); //This is just Id in the video...
        ClaimDomainModel ViewClaim(Guid policyId); //This too
        ClaimDomainModel GetById(Guid id);
    }

    public class ClaimService : IClaimService
    {
        private IGetPolicyInteractor _getPolicyInteractor;

        private IGetPolicyInteractor GetPolicyInteractor
        {
            get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
            set { _getPolicyInteractor = value; }
        }

        private IGetClaimInteractor _getClaimInteractor;

        private IGetClaimInteractor GetClaimInteractor
        {
            get { return _getClaimInteractor ?? (_getClaimInteractor = new GetClaimInteractor()); } //Video 4b 18:00, named wrong
            set { _getClaimInteractor = value; }
        }

        public ClaimDomainModel StartClaim(Guid policyId)
        {
            var policy = GetPolicyInteractor.GetById(policyId);

            if (policy == null) throw new ArgumentException("There is no policy for that ID.");

            // Check for existing claim
            var existingClaim = GetClaimInteractor.GetClaimById(policyId);

            // TODO:Create new claim

            // currently returns empty model regardless
            // will eventually need to either return existing or new claim
            return new ClaimDomainModel(policyId);
        }

        public ClaimDomainModel ViewClaim(Guid policyId)
        {
            var policy = GetPolicyInteractor.GetById(policyId);

            if (policy == null) throw new ArgumentException("There is no policy for that ID.");

            var existingClaim = GetClaimInteractor.GetClaimById(policyId);

            // returns new claim model regardless
            // will eventually need to return existing claim data or error handle
            return new ClaimDomainModel(policyId);
        }

        public ClaimDomainModel GetById(Guid id)
        {
            var claim = GetClaimInteractor.Execute(id);
            if(claim == null) throw new ArgumentException("Claim does not exist");

            return new ClaimDomainModel(claim);
        }
    }
}
