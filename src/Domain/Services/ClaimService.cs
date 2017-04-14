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
        ClaimDomainModel StartClaim(Guid policyId);
        ClaimDomainModel ViewClaim(Guid policyId);
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

        public IGetClaimInteractor GetClaimInteractor
        {
            get { return _getClaimInteractor ?? (_getClaimInteractor = new GetClaimInteractor()); }
            set { _getClaimInteractor = value; }
        }

        public ICreateClaimInteractor CreateClaimInteractor
        {
            get { return _createClaimInteractor ?? (_createClaimInteractor = new CreateClaimInteractor()); }
            set { _createClaimInteractor = value; }
            
        }
        private ICreateClaimInteractor _createClaimInteractor;


        public ClaimDomainModel StartClaim(Guid policyId)
        {
            var policy = GetPolicyInteractor.GetById(policyId);

            if (policy == null) throw new ArgumentException("There is no policy for that ID.");

            // Check for existing claim
            var existingClaim = CreateClaimInteractor.Execute(policyId);

            // TODO:Create new claim

            // currently returns empty model regardless
            // will eventually need to either return existing or new claim
            return new ClaimDomainModel(existingClaim);
        }

        public ClaimDomainModel ViewClaim(Guid policyId)
        {
            var claim = GetClaimInteractor.Execute(policyId);
            if(claim==null) throw new ArgumentException("This Cliam does not exist.");
            return new ClaimDomainModel(claim);
        }
    }
}
