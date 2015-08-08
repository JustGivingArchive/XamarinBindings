using System;
using ObjCRuntime;

namespace OptimizelyiOSSDK
{
    [Native]
    public enum OptimizelyExperimentDataState : ulong
    {
        Disabled,
        Running,
        Deactivated
    }

}

