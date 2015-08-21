using System;
using ObjCRuntime;

[assembly: LinkWith ("Optimizely.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64 | LinkTarget.ArmV7s | LinkTarget.ArmV6 | LinkTarget.Thumb, 
    SmartLink = true, ForceLoad = true, 
    Frameworks = "AudioToolbox CFNetwork MobileCoreServices Security SystemConfiguration",
    LinkerFlags = "-licucore -lsqlite3")]
