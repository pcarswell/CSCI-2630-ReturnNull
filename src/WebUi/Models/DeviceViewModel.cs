using System;
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
            MostCurrentClaim = (device.PendingClaim.Any()) ? new ClaimViewModel(device.PendingClaim.First()) : null;
        }

        public ClaimViewModel MostCurrentClaim { get; set; }

        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string PolicyNumber { get; set; }

        public Guid PolicyId { get; set; }

        public bool HasExistingClaim()
        {
            return MostCurrentClaim != null;
        }
    }
}