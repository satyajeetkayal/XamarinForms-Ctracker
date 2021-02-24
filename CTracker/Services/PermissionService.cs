using CTracker.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace CTracker.Services
{
  public  class PermissionService :IPermission
    {

        public PermissionService()
        {
        }

        public NetworkAccess CheckNetworkConnectivity()
        {
            var networkAccess = Connectivity.NetworkAccess;

            return networkAccess;
        }

    }
}
