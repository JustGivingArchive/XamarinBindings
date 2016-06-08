using System;
using ObjCRuntime;

[assembly: LinkWith("libMixpanel.a",
    LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
	SmartLink = true, ForceLoad = true,
	Frameworks = "UIKit Foundation SystemConfiguration CoreTelephony Accelerate CoreGraphics QuartzCore",
    LinkerFlags="-ObjC -licucore")]