using System;
using ObjCRuntime;

namespace ExactTarget.iOS
{
    [Native]
    public enum LocationUpdateAppState : long
    {
        Background,
        Foreground
    }

    [Native]
    public enum GenericUpdateSendMethod : long
    {
        Get,
        Post,
        Put,
        Delete
    }

    [Native]
    public enum ETRegionRequestType : ulong
    {
        Unknown,
        Geofence,
        Proximity
    }

    [Native]
    public enum MobilePushGeofenceType : ulong
    {
        None = 0,
        Circle,
        Polygon,
        Proximity
    }

    public enum PushOriginationState : uint
    {
        Background = 0,
        Foreground
    }

    [Native]
    public enum MobilePushMessageType : ulong
    {
        Unknown,
        Basic,
        Enhanced,
        FenceEntry,
        FenceExit,
        Proximity
    }

    [Native]
    public enum MobilePushContentType : ulong
    {
        None = 0,
        AlertMessage = 1 << 0,
        Page = 1 << 1
    }

    [Native]
    public enum MPMessageSource : long
    {
        Database,
        Remote
    }

    [Native]
    public enum MobilePushMessageFrequencyUnit : ulong
    {
        None,
        Year,
        Month,
        Week,
        Day,
        Hour
    }

    [Native]
    public enum NSURLConnResponse : long
    {
        ReceiveData,
        FinishLoading,
        FailWithError,
        ReceiveResponse
    }

}

