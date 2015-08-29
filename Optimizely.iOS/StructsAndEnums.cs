using ObjCRuntime;

namespace OptimizelyiOS
{
  // typedef NS_ENUM (NSUInteger, OptimizelyExperimentDataState)
  [Native]
  public enum OptimizelyExperimentDataState : ulong
  {
    /** Experiment is not running on the Optimizely dashboard. Try starting the experiment on https://www.optimizely.com */
    Disabled,
    /** Experiment is running */
    Running,
    /** Experiment has been deactivated
     * This can happen if
     * (a) not all of its assets are downloaded by the time our block time runs out, or
     * (b) another experiment has already been activated that makes a conflicting change
     * (c) targeting criteria for this experiment has not been met
     */
    Deactivated
  }
}