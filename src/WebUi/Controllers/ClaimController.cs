using System;
using System.Web.Mvc;
using EDeviceClaims.Domain.Models;
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
            var domainModel = _claimService.StartClaim(id);
            var model = new ClaimViewModel(domainModel);
            return View(model);
        }

        public ActionResult ViewClaim(Guid id)
        {
            try
            {
                ClaimDomainModel claimModel = _claimService.GetById(id);
                ClaimViewModel viewModel = new ClaimViewModel(claimModel);

                return View(viewModel);
            }
            catch (ArgumentException e)
            {
                return null;
            }
        }
    }
}