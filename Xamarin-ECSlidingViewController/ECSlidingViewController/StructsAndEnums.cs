using System;

namespace ECSlidingViewControllerBinding
{

  public enum ECSlidingViewControllerOperation {
    None,
    AnchorLeft,
    AnchorRight,
    ResetFromLeft,
    ResetFromRight
  }


  public enum ECSlidingViewControllerTopViewPosition {
    AnchoredLeft,
    AnchoredRight,
    Centered
  }

  public enum ECSlidingViewControllerAnchoredGesture {
    None = 0,
    Panning = 1 << 0,
    Tapping = 1 << 1,
    Custom = 1 << 2,
    Disabled = 1 << 3
  }
}

