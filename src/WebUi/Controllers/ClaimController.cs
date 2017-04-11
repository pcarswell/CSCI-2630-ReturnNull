﻿using System;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Controllers
{
    [Authorize]
    public class ClaimController : AppController
    {
        private IClaimService _claimService = new ClaimService();
        
        public ActionResult StartClaim(Guid id)
        {
            var ClaimDomainModel = _claimService.StartClaim(id);
            var model = new ClaimViewModel(ClaimDomainModel);
            return View(model);
        }

        public ActionResult ViewClaim(Guid id)
        {
            return null;
        }
    }
}