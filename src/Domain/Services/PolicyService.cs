using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EDeviceClaims.Domain.Models;
using EDeviceClaims.Interactors;


namespace EDeviceClaims.Domain.Services
{
    public interface IPolicyService
    {
        IEnumerable<PolicyDomainModel> GetByUserId(string userId);
        PolicyDomainModel GetById(Guid policyId);
        void AssociateExistingDevices(string userId);
    }

    public class PolicyService : IPolicyService
    {
        private IGetPolicyInteractor _getPolicyInteractor;

        private IGetPolicyInteractor GetPolicyInteractor
        {
            get { return _getPolicyInteractor ?? (_getPolicyInteractor = new GetPolicyInteractor()); }
            set { _getPolicyInteractor = value; }
        }

        private IGetUserInteractor _getUserInteractor;

        private IGetUserInteractor GetUserInteractor
        {
            get { return _getUserInteractor ?? (_getUserInteractor = new GetUserInteractor()); }
            set { _getUserInteractor = value; }
        }


        public IEnumerable<PolicyDomainModel> GetByUserId(string userId)
        {
            var policyEntities = GetPolicyInteractor.GetByUserId(userId);

            return policyEntities.Select(policyEntity => new PolicyDomainModel(policyEntity)).ToList();
        }

        public PolicyDomainModel GetById(Guid policyId)
        {
            var entity = GetPolicyInteractor.GetById(policyId);

            if (entity == null) return null;
            
            return new PolicyDomainModel(entity);

        }

        public void AssociateExistingDevices(string userId)
        {
            //get user
            var user = GetUserInteractor.GetById(userId);
            if (user==null)
                throw new Exception();
            //get device for email add
            var devices = GetPolicyInteractor.GetByCustomerEmailAdress(user.Email);

            //update device with userid
            foreach (var device in devices)
            {
                device.UserId = user.Id;
            }
            GetPolicyInteractor.Repo.EfUnitOfWork.Context.SaveChanges();
        }
    }

   
}
