using System;
using System.Linq;
using System.Linq.Expressions;
using EDeviceClaims.Domain.Models;
using System.Data.Entity.Core.Objects;

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
            HasExistingClaim = device.Claims.Any();

            MostCurrentClaim = (device.Claims.Any()) ? new ClaimViewModel(device.Claims.First()) : null;
        }

        
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string PolicyNumber { get; set; }

        public Guid PolicyId { get; set; }

        // may need to change based on what happens with DeviceDomainModel
        public ClaimDomainModel MostCurrentClaim { get; set; }
        // may need to change based on what happens with DeviceDomainModel
        public bool HasExistingClaim { get; set; }
    }
}