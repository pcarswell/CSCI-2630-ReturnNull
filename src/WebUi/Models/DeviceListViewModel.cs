using System.Collections.Generic;
using EDeviceClaims.Domain.Models;

namespace EDeviceClaims.WebUi.Models
{
  public class DeviceListViewModel : List<DeviceViewModel>
  {
    public DeviceListViewModel(IEnumerable<PolicyDomainModel> domainModel)
    {
      foreach (var device in domainModel)
      {
        Add(new DeviceViewModel(device));
      }
    }
  }
}