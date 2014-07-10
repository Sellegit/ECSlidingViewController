using System.Drawing;
using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

using MonoTouch.Foundation;

namespace ECSlidingViewControllerBinding {

  public delegate void ECSlidingViewAnimationComplete ();

  [BaseType (typeof (NSObject))]
  public partial interface ECPercentDrivenInteractiveTransition  {

    [Export ("animationController", ArgumentSemantic.Retain)]
    UIViewControllerAnimatedTransitioning AnimationController { get; set; }

    [Export ("percentComplete")]
    float PercentComplete { get; }

    [Export ("updateInteractiveTransition:")]
    void UpdateInteractiveTransition (float percentComplete);

    [Export ("cancelInteractiveTransition")]
    void CancelInteractiveTransition ();

    [Export ("finishInteractiveTransition")]
    void FinishInteractiveTransition ();
  }

  [BaseType (typeof (NSObject))]
  public partial interface ECSlidingAnimationController {

    [Export ("defaultTransitionDuration")]
    double DefaultTransitionDuration { get; set; }
  }

  [Model, BaseType (typeof (NSObject))]
  public partial interface ECSlidingViewControllerLayout {

    [Export ("slidingViewController:frameForViewController:topViewPosition:")]
    RectangleF SlidingViewController (ECSlidingViewController slidingViewController, UIViewController viewController, ECSlidingViewControllerTopViewPosition topViewPosition);
  }

  [Model, BaseType (typeof (NSObject)), Protocol]
  public partial interface ECSlidingViewControllerDelegate {

    [Export ("slidingViewController:animationControllerForOperation:topViewController:")]
    UIViewControllerAnimatedTransitioning AnimationControllerForOperation (ECSlidingViewController slidingViewController, ECSlidingViewControllerOperation operation, UIViewController topViewController);

    [Export ("slidingViewController:interactionControllerForAnimationController:")]
    UIViewControllerInteractiveTransitioning InteractionControllerForAnimationController (ECSlidingViewController slidingViewController, UIViewControllerAnimatedTransitioning animationController);

    [Export ("slidingViewController:layoutControllerForTopViewPosition:")]
    ECSlidingViewControllerLayout LayoutControllerForTopViewPosition (ECSlidingViewController slidingViewController, ECSlidingViewControllerTopViewPosition topViewPosition);
  }

  [BaseType (typeof (NSObject))]
  public partial interface ECSlidingInteractiveTransition {

    [Export ("initWithSlidingViewController:")]
    IntPtr Constructor (ECSlidingViewController slidingViewController);

    [Export ("updateTopViewHorizontalCenterWithRecognizer:")]
    void UpdateTopViewHorizontalCenterWithRecognizer (UIPanGestureRecognizer recognizer);
  }

  [BaseType (typeof (UIStoryboardSegue))]
  public partial interface ECSlidingSegue {

    [Export ("skipSettingTopViewController")]
    bool SkipSettingTopViewController { get; set; }
  }


  [BaseType (typeof (UIViewController))]
  public partial interface ECSlidingViewController { //: UIViewControllerContextTransitioning, UIViewControllerTransitionCoordinator, UIViewControllerTransitionCoordinatorContext {

    [Static, Export ("slidingWithTopViewController:")]
    ECSlidingViewController SlidingWithTopViewController (UIViewController topViewController);

    [Export ("initWithTopViewController:")]
    IntPtr Constructor (UIViewController topViewController);

    [Export ("topViewController", ArgumentSemantic.Retain)]
    UIViewController TopViewController { get; set; }

    [Export ("underLeftViewController", ArgumentSemantic.Retain)]
    UIViewController UnderLeftViewController { get; set; }

    [Export ("underRightViewController", ArgumentSemantic.Retain)]
    UIViewController UnderRightViewController { get; set; }

    [Export ("anchorLeftPeekAmount")]
    float AnchorLeftPeekAmount { get; set; }

    [Export ("anchorLeftRevealAmount")]
    float AnchorLeftRevealAmount { get; set; }

    [Export ("anchorRightPeekAmount")]
    float AnchorRightPeekAmount { get; set; }

    [Export ("anchorRightRevealAmount")]
    float AnchorRightRevealAmount { get; set; }

    [Export ("anchorTopViewToRightAnimated:")]
    void AnchorTopViewToRightAnimated (bool animated);

    [Export ("anchorTopViewToRightAnimated:onComplete:")]
    void AnchorTopViewToRightAnimated (bool animated, [NullAllowed] ECSlidingViewAnimationComplete complete);

    [Export ("anchorTopViewToLeftAnimated:")]
    void AnchorTopViewToLeftAnimated (bool animated);

    [Export ("anchorTopViewToLeftAnimated:onComplete:")]
    void AnchorTopViewToLeftAnimated (bool animated, [NullAllowed] ECSlidingViewAnimationComplete complete);

    [Export ("resetTopViewAnimated:")]
    void ResetTopViewAnimated (bool animated);

    [Export ("resetTopViewAnimated:onComplete:")]
    void ResetTopViewAnimated (bool animated, [NullAllowed] ECSlidingViewAnimationComplete complete);

    [Export ("topViewControllerStoryboardId", ArgumentSemantic.Retain)]
    string TopViewControllerStoryboardId { get; set; }

    [Export ("underLeftViewControllerStoryboardId", ArgumentSemantic.Retain)]
    string UnderLeftViewControllerStoryboardId { get; set; }

    [Export ("underRightViewControllerStoryboardId", ArgumentSemantic.Retain)]
    string UnderRightViewControllerStoryboardId { get; set; }

    [Export ("delegate", ArgumentSemantic.Assign)]
    ECSlidingViewControllerDelegate Delegate { get; set; }

    [Export ("topViewAnchoredGesture")]
    ECSlidingViewControllerAnchoredGesture TopViewAnchoredGesture { get; set; }

    [Export ("currentTopViewPosition")]
    ECSlidingViewControllerTopViewPosition CurrentTopViewPosition { get; }

    [Export ("panGesture", ArgumentSemantic.Retain)]
    UIPanGestureRecognizer PanGesture { get; }

    [Export ("resetTapGesture", ArgumentSemantic.Retain)]
    UITapGestureRecognizer ResetTapGesture { get; }

    [Export ("customAnchoredGestures", ArgumentSemantic.Retain)]
    NSObject [] CustomAnchoredGestures { get; set; }

    [Export ("defaultTransitionDuration")]
    double DefaultTransitionDuration { get; set; }
  }

  [Category, BaseType (typeof (UIViewController))]
  public partial interface ECSlidingViewController_UIViewController {

    [Export ("slidingViewController")]
    ECSlidingViewController SlidingViewController ();//{ get; }
  }
}