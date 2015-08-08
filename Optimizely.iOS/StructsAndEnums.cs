using System;
using ObjCRuntime;

namespace OptimizelyiOS
{
    [Native]
    public enum OptimizelyExperimentDataState : ulong
    {
        Disabled,
        Running,
        Deactivated
    }

}

