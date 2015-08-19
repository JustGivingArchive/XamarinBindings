using System;
using ObjCRuntime;

[assembly: LinkWith("ZendeskSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.Arm64, SmartLink = true,
    ForceLoad = false, Frameworks = "MobileCoreServices")]
