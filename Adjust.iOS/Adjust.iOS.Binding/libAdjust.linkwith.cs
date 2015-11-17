using System;
using ObjCRuntime;

[assembly: LinkWith ("libAdjust.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, SmartLink = false, ForceLoad = true, Frameworks = "AdSupport iAd")]
