using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace CTracker.Interface
{
    public interface IPermission
    {

        NetworkAccess CheckNetworkConnectivity();

    }
}
