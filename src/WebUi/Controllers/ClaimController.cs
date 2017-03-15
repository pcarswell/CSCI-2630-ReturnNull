using System;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;
using EDeviceClaims.WebUi.Models;

namespace EDeviceClaims.WebUi.Controllers
{
    [Authorize]
    public class ClaimController : AppController
    {
        private IClaimService _claimService = new ClaimService();
        
        public ActionResult Open(Guid policyId)
        {
            var claimModel = _claimService.StartClaim(policyId);
            var viewModel = new ClaimViewModel(claimModel);

            return View("Open", viewModel);
        }

        public ActionResult Details(Guid policyId)
        {

            var claimModel = _claimService.ViewClaim(policyId);
            var viewModel = new ClaimViewModel(claimModel);

            return View("Details", viewModel);
        }
    }
}