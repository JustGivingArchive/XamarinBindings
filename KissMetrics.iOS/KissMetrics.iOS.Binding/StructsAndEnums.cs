using System;
using ObjCRuntime;

namespace KissMetrics.iOS.Binding
{
  [Native]
  public enum KMARecordCondition : long
  {
    Always,
    OncePerInstall,
    OncePerIdentity
  }
}

