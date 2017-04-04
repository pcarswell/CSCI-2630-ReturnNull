using System;
using System.Web.Mvc;
using EDeviceClaims.Domain.Services;

namespace EDeviceClaims.WebUi.Controllers
{
    public class ClaimController : AppController
    {
        private IClaimService _claimsevice = new ClaimService();
        
        public ActionResult StartClaim(Guid id)
        {
            var ClaimDomainModel = _claimsevice.StartClaim(id);
            var model = new ClaimViewModel(ClaimDomainModel);
            return View(model);
        }

        public ActionResult ViewClaim(Guid id)
        {
            return null;
        }
    }
}