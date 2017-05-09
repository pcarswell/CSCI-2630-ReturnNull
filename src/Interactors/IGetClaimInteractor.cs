﻿using System;
using EDeviceClaims.Entities;
using EDeviceClaims.Repositories;

namespace EDeviceClaims.Interactors
{
    public interface IGetClaimInteractor
    {
        ClaimEntity Execute(Guid id);
    }

    public class GetClaimInteractor : IGetClaimInteractor
    {
        private IClaimRepository Repo
        {
            get { return _repo ?? (_repo = new ClaimRepository()); }
            set { _repo = value; }
        }

        private IClaimRepository _repo;

        public GetClaimInteractor() { }

        public GetClaimInteractor(IClaimRepository claimRepo)
        {
            _repo = claimRepo;
        }

        public ClaimEntity Execute(Guid id)
        {
            return Repo.GetById(id);
        }
    }
}