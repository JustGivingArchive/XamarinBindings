using System;
using ObjCRuntime;

[assembly: LinkWith ("libetpushsdk-3.4.2.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator, SmartLink = true, ForceLoad = false, Frameworks = "CoreLocation", LinkerFlags = "-lz -lsqlite3", IsCxx = true)]
