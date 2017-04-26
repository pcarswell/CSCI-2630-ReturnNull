using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
    public class DeviceViewModel
    {
        public DeviceViewModel(PolicyDomainModel device)
        {
            PolicyId = device.Id;
            PolicyNumber = device.Number;
            SerialNumber = device.SerialNumber;
            Name = device.DeviceName;

            //MostCurrentClaim = (device.Claims.Any()) ? new ClaimViewModel(device.Claims.First()) : null; //This doesn't work for some reason?!?
        }

        public ClaimViewModel MostCurrentClaim { get; set; }
        
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string PolicyNumber { get; set; }

        public Guid PolicyId { get; set; }

        public bool ShowViewClaimButton()
        {
           return MostCurrentClaim != null;
        }
    }
}