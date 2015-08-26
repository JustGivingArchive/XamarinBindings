using ObjCRuntime;

[assembly: LinkWith ("KISSmetricsSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, ForceLoad = true, Frameworks = "Security")]