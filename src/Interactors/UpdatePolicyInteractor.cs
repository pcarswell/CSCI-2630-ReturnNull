using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

// Work in progress, not connected to anything

namespace EDeviceClaims.Interactors
{
    public interface IUpdatePolicyInteractor
    {
        void UpdatePolicy(Policy policy);
    }

    public class UpdatePolicyInteractor : IUpdatePolicyInteractor
    {
        private IPolicyRepository Repo
        {
            get { return _repo ?? (_repo = new PolicyRepository()); }
            set { _repo = value; }
        }

        private IPolicyRepository _repo;
        
        private IGetPolicyInteractor GetPolicyInteractor
        {
            get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
            set { _getPolicyInteractor = value; }
        }

        private IGetPolicyInteractor _getPolicyInteractor;

        public UpdatePolicyInteractor() { }

        public UpdatePolicyInteractor(IGetPolicyInteractor getPolicyInteractor)
        {
            _getPolicyInteractor = getPolicyInteractor;
        }

        public void UpdatePolicy(Policy policy)
        {
            GetPolicyInteractor.GetById(policy.Id);
            
            Repo.SavePolicyChanges();
        }
        
    }
}
