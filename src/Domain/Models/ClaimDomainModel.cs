using System;

namespace EDeviceClaims.Domain.Models
{
    public class ClaimDomainModel
    {
        public Guid Id { get; set; }

        public ClaimDomainModel(Guid id)
        {
            Id = id;
        }
    }
}