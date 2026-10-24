using System;
using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;
using MapboxCoreMaps;
using MapboxMaps;
using MapboxCommon;

namespace MapboxMapsObjC
{
    // SWIFT_PROTOCOL("_TtP13MapboxMapObjC25TMBViewportStatusObserver_")
    // @protocol TMBViewportStatusObserver
    partial interface ITMBViewportStatusObserver { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC25TMBViewportStatusObserver_")]
    [BaseType(typeof(NSObject))]
    interface TMBViewportStatusObserver
    {
        // - (void)viewportStatusDidChangeFrom:(TMBViewportStatus * _Nonnull)fromStatus to:(TMBViewportStatus * _Nonnull)toStatus reason:(TMBViewportStatusChangeReason * _Nonnull)reason;
        [Abstract, Export("viewportStatusDidChangeFrom:to:reason:")]
        void ViewportStatusDidChangeFrom(TMBViewportStatus fromStatus, TMBViewportStatus toStatus, TMBViewportStatusChangeReason reason);
    }

    // SWIFT_PROTOCOL("_TtP13MapboxMapObjC21TMBViewportTransition_")
    // @protocol TMBViewportTransition
    partial interface ITMBViewportTransition { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC21TMBViewportTransition_")]
    [BaseType(typeof(NSObject))]
    interface TMBViewportTransition
    {
        
        // - (TMBCancelable * _Nonnull)runTo:(id <TMBViewportState> _Nonnull)toState completion:(void (^ _Nonnull)(BOOL))completion SWIFT_WARN_UNUSED_RESULT;
        [Abstract, Export("runTo:completion:")]
        TMBCancelable RunTo(ITMBViewportState toState, Action<bool> completion);
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC29TMBViewportStatusChangeReason")
    // @interface TMBViewportStatusChangeReason : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC29TMBViewportStatusChangeReason")]
    [DisableDefaultCtor]
    interface TMBViewportStatusChangeReason
    {
        // @property (nonatomic, readonly, copy) NSString * _Nonnull rawValue;
        [Export("rawValue", ArgumentSemantic.Copy)]
        string RawValue { get; }

        // /// <code>ViewportManager/status</code> changed because <code>ViewportManager/idle()</code> was invoked.
        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBViewportStatusChangeReason * _Nonnull idleRequested;)
        // + (TMBViewportStatusChangeReason * _Nonnull)idleRequested SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("idleRequested")] 
        TMBViewportStatusChangeReason IdleRequested { get; }

        // /// <code>ViewportManager/status</code> changed because <code>ViewportManager/transition(to:transition:completion:)</code> was invoked.
        // /// An event with this reason is not delivered if the <code>ViewportTransition/run(to:completion:)</code> invokes its completion
        // /// block synchronously.
        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBViewportStatusChangeReason * _Nonnull transitionStarted;)
        // + (TMBViewportStatusChangeReason * _Nonnull)transitionStarted SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("transitionStarted")] 
        TMBViewportStatusChangeReason TransitionStarted { get; }
        
        // /// <code>ViewportManager/status</code> changed because <code>ViewportManager/transition(to:transition:completion:)</code> completed successfully.
        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBViewportStatusChangeReason * _Nonnull transitionSucceeded;)
        // + (TMBViewportStatusChangeReason * _Nonnull)transitionSucceeded SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("transitionSucceeded")] 
        TMBViewportStatusChangeReason TransitionSucceeded { get; }
        
        // /// <code>ViewportManager/status</code> changed because <code>ViewportManager/transition(to:transition:completion:)</code> failed.
        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBViewportStatusChangeReason * _Nonnull transitionFailed;)
        // + (TMBViewportStatusChangeReason * _Nonnull)transitionFailed SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("transitionFailed")] 
        TMBViewportStatusChangeReason TransitionFailed { get; }
        
        // /// <code>ViewportManager/status</code> changed due to user interaction.
        // /// seealso:
        // /// <code>ViewportOptions/transitionsToIdleUponUserInteraction</code>
        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBViewportStatusChangeReason * _Nonnull userInteraction;)
        // + (TMBViewportStatusChangeReason * _Nonnull)userInteraction SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("userInteraction")] 
        TMBViewportStatusChangeReason UserInteraction { get; }
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC17TMBViewportStatus")
    // @interface TMBViewportStatus : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC17TMBViewportStatus")]
    [DisableDefaultCtor]
    interface TMBViewportStatus
    {
        // /// The <code>idle</code> status indicates that <code>ViewportManager</code> is inactive.
        // @property (nonatomic, readonly) BOOL idle;
        [Export("idle")]
        bool Idle { get; }
        // @property (nonatomic, readonly, strong) id <TMBViewportState> _Nullable state;
        [Export("state")]
        ITMBViewportState State { get; }
        // @property (nonatomic, readonly, strong) id <TMBViewportTransition> _Nullable transition;
        [Export("transition")]
        ITMBViewportTransition Transition { get; }

        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBViewportStatus * _Nonnull idleInstance;)
        // + (TMBViewportStatus * _Nonnull)idleInstance SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("idleInstance")]
        TMBViewportStatus IdleInstance { get; }

        // /// The <code>state(_:)</code> status indicates that <code>ViewportManager</code> is running the associated value <code>state</code>.
        // + (TMBViewportStatus * _Nonnull)fromState:(id <TMBViewportState> _Nonnull)state SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("fromState:")]
        TMBViewportStatus FromState(ITMBViewportState state);

        // /// The <code>transition(_:toState:)</code> status indicates that <code>ViewportManager</code> is running <code>transition</code>
        // /// and will start running <code>toState</code> upon success.
        // + (TMBViewportStatus * _Nonnull)fromTransition:(id <TMBViewportTransition> _Nonnull)transition toState:(id <TMBViewportState> _Nonnull)toState SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("fromTransition:toState:")]
        TMBViewportStatus fromTransition(ITMBViewportTransition transition, ITMBViewportState toState);
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC18TMBViewportOptions")
    // @interface TMBViewportOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBViewportOptions")]
    [DisableDefaultCtor]
    interface TMBViewportOptions
    {
        // @property (nonatomic) BOOL transitionsToIdleUponUserInteraction;
        [Export("transitionsToIdleUponUserInteraction")]
        bool TransitionsToIdleUponUserInteraction { get; set; }

        // - (nonnull instancetype)initWithTransitionsToIdleUponUserInteraction:(BOOL)transitionsToIdleUponUserInteraction OBJC_DESIGNATED_INITIALIZER;
        [Export("initWithTransitionsToIdleUponUserInteraction:")]
        NativeHandle Constructor(bool transitionsToIdleUponUserInteraction);
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC18TMBViewportManager")
    // @interface TMBViewportManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBViewportManager")]
    [DisableDefaultCtor]
    interface TMBViewportManager
    {
        // @property (nonatomic, strong) TMBViewportOptions * _Nonnull options;
        [Export("options", ArgumentSemantic.Strong)]
        TMBViewportOptions Options { get; set; }

        // @property (nonatomic, readonly, strong) TMBViewportStatus * _Nonnull status;
        [Export("status", ArgumentSemantic.Strong)]
        TMBViewportStatus Status { get; }

        // - (void)addStatusObserver:(id <TMBViewportStatusObserver> _Nonnull)observer;
        [Export("addStatusObserver:")]
        void AddStatusObserver(ITMBViewportStatusObserver observer);

        // - (void)removeStatusObserver:(id <TMBViewportStatusObserver> _Nonnull)observer;
        [Export("removeStatusObserver:")]
        void RemoveStatusObserver(ITMBViewportStatusObserver observer);

        // - (void)idle;
        [Export("idle")]
        void Idle();

        // - (void)transitionTo:(id <TMBViewportState> _Nonnull)toState transition:(id <TMBViewportTransition> _Nullable)transition completion:(void (^ _Nullable)(BOOL))completion;
        [Export("transitionTo:transition:completion:")]
        void TransitionTo(ITMBViewportState toState, [NullAllowed] ITMBViewportTransition transition, [NullAllowed] Action<bool> completion);

        // @property (nonatomic, strong) id <TMBViewportTransition> _Nonnull defaultTransition;
        [Export("defaultTransition", ArgumentSemantic.Strong)]
        ITMBViewportTransition DefaultTransition { get; set; }

        // - (TMBFollowPuckViewportState * _Nonnull)makeFollowPuckViewportStateWithOptions:(TMBFollowPuckViewportStateOptions * _Nullable)options SWIFT_WARN_UNUSED_RESULT;
        [Export("makeFollowPuckViewportStateWithOptions:")]
        TMBFollowPuckViewportState MakeFollowPuckViewportStateWithOptions([NullAllowed] TMBFollowPuckViewportStateOptions options);

        // - (TMBOverviewViewportState * _Nonnull)makeOverviewViewportStateWithOptions:(TMBOverviewViewportStateOptions * _Nonnull)options SWIFT_WARN_UNUSED_RESULT;
        [Export("makeOverviewViewportStateWithOptions:")]
        TMBOverviewViewportState MakeOverviewViewportStateWithOptions(TMBOverviewViewportStateOptions options);

        // - (TMBDefaultViewportTransition * _Nonnull)makeDefaultViewportTransitionWithOptions:(TMBDefaultViewportTransitionOptions * _Nullable)options SWIFT_WARN_UNUSED_RESULT;
        [Export("makeDefaultViewportTransitionWithOptions:")]
        TMBDefaultViewportTransition MakeDefaultViewportTransitionWithOptions(TMBDefaultViewportTransitionOptions options);

        // - (id <TMBViewportTransition> _Nonnull)makeImmediateViewportTransition SWIFT_WARN_UNUSED_RESULT;
        [Export("makeImmediateViewportTransition")]
        ITMBViewportTransition MakeImmediateViewportTransition();
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC31TMBOverviewViewportStateOptions")
    // @interface TMBOverviewViewportStateOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC31TMBOverviewViewportStateOptions")]
    [DisableDefaultCtor]
    interface TMBOverviewViewportStateOptions
    {
        // @property (nonatomic, strong) MBXGeometry * _Nonnull geometry;
        [Export("geometry", ArgumentSemantic.Strong)]
        MBXGeometry Geometry { get; set; }

        // @property (nonatomic) UIEdgeInsets geometryPadding;
        [Export("geometryPadding")]
        UIEdgeInsets GeometryPadding { get; set; }

        // /// The bearing that <code>OverviewViewportState</code> should use when calcualting its camera.
        // @property (nonatomic, strong) NSNumber * _Nullable bearing;
        [NullAllowed, Export("bearing", ArgumentSemantic.Strong)]
        NSNumber Bearing { get; set; }

        // /// The pitch that <code>OverviewViewportState</code> should use when calculating its camera.
        // @property (nonatomic, strong) NSNumber * _Nullable pitch;
        [NullAllowed, Export("pitch", ArgumentSemantic.Strong)]
        NSNumber Pitch { get; set; }

        // /// Camera padding to set as camera options.
        // @property (nonatomic, strong) NSValue * _Nullable padding;
        [NullAllowed, Export("padding", ArgumentSemantic.Strong)]
        NSValue padding { get; set; }

        // /// The maximum zoom level to allow.
        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // /// The center of the given bounds relative to the map’s center, measured in points.
        // @property (nonatomic, strong) NSValue * _Nullable offset;
        [NullAllowed, Export("offset", ArgumentSemantic.Strong)]
        NSValue Offset { get; set; }

        // /// The length of the animation performed by <code>OverviewViewportState</code> when it starts updating
        // /// the camera and any time <code>OverviewViewportState/options</code> is set. See
        // /// <code>OverviewViewportState/options</code> for details.
        // @property (nonatomic) NSTimeInterval animationDuration;
        [Export("animationDuration")]
        float AnimationDuration { get; set; }

        // - (nonnull instancetype)initWithGeometry:(MBXGeometry * _Nonnull)geometry geometryPadding:(UIEdgeInsets)geometryPadding bearing:(NSNumber * _Nullable)bearing pitch:(NSNumber * _Nullable)pitch padding:(NSValue * _Nullable)padding maxZoom:(NSNumber * _Nullable)maxZoom offset:(NSValue * _Nullable)offset animationDuration:(NSTimeInterval)animationDuration OBJC_DESIGNATED_INITIALIZER;
        [Export("initWithGeometry:geometryPadding:bearing:pitch:padding:maxZoom:offset:animationDuration:")]
        NativeHandle Constructor(MBXGeometry geometry, UIEdgeInsets geometryPadding, [NullAllowed] NSNumber bearing, [NullAllowed] NSNumber pitch, [NullAllowed] NSValue padding, [NullAllowed] NSNumber maxZoom, [NullAllowed] NSValue offset, float animationDuration);
    }
    // SWIFT_CLASS("_TtC13MapboxMapObjC24TMBOverviewViewportState")
    // @interface TMBOverviewViewportState : NSObject <TMBViewportState>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC24TMBOverviewViewportState")]
    [DisableDefaultCtor]
    interface TMBOverviewViewportState : TMBViewportState
    {
        // /// Configuration options.
        // /// When set, the viewport reframes the geometry using the new options and updates its camera with
        // /// an <code>CameraAnimationsManager/ease(to:duration:curve:completion:)</code>
        // /// animation with a linear timing curve and duration specified by the new value’s
        // /// <code>OverviewViewportStateOptions/animationDuration</code>.
        // @property (nonatomic, strong) TMBOverviewViewportStateOptions * _Nonnull options;
        [Export("options", ArgumentSemantic.Strong)]
        TMBOverviewViewportStateOptions Options { get; set; }

        // /// :nodoc:
        // /// See <code>ViewportState/observeDataSource(with:)</code>.
        // - (TMBCancelable * _Nonnull)observeDataSourceWith:(BOOL (^ _Nonnull)(TMBCameraOptions * _Nonnull))handler SWIFT_WARN_UNUSED_RESULT;
        [Export("observeDataSourceWith:")]
        TMBCancelable ObserveDataSourceWith(ObserveDataSourceWithHandler handler);

        // /// :nodoc:
        // /// See <code>ViewportState/startUpdatingCamera()</code>.
        // - (void)startUpdatingCamera;
        [Export("startUpdatingCamera")]
        void StartUpdatingCamera();

        // /// :nodoc:
        // /// See <code>ViewportState/stopUpdatingCamera()</code>.
        // - (void)stopUpdatingCamera;
        [Export("stopUpdatingCamera")]
        void StopUpdatingCamera();
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC33TMBFollowPuckViewportStateOptions")
    // @interface TMBFollowPuckViewportStateOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC33TMBFollowPuckViewportStateOptions")]
    [DisableDefaultCtor]
    interface TMBFollowPuckViewportStateOptions
    {
        // /// The value to use for <code>CameraOptions-swift.struct/padding</code> when setting the camera. If <code>nil</code>, padding
        // /// will not be modified.
        // @property (nonatomic, strong) NSValue * _Nullable padding;
        [Export("padding", ArgumentSemantic.Strong)]
        NSValue Padding { get; }

        // /// The value to use for <code>CameraOptions-swift.struct/zoom</code> when setting the camera. If <code>nil</code>, zoom will
        // /// not be modified.
        // @property (nonatomic, strong) NSNumber * _Nullable zoom;
        [Export("zoom", ArgumentSemantic.Strong)]
        NSNumber Zoom { get; }

        // /// Indicates how to obtain the value to use for <code>CameraOptions-swift.struct/bearing</code> when setting the
        // /// camera. If <code>nil</code>, bearing will not be modified.
        // @property (nonatomic, strong) TMBFollowPuckViewportStateBearing * _Nullable bearing;
        [Export("bearing", ArgumentSemantic.Strong)]
        TMBFollowPuckViewportStateBearing Bearing { get; }

        // /// The value to use for <code>CameraOptions-swift.struct/pitch</code> when setting the camera. If <code>nil</code>, pitch will
        // /// not be modified.
        // @property (nonatomic, strong) NSNumber * _Nullable pitch;
        [Export("pitch", ArgumentSemantic.Strong)]
        NSNumber Pitch { get; }

        // /// Creates options.
        // /// \param padding Camera padding.
        // ///
        // /// \param zoom Camera zoom. Default value is 16.35.
        // ///
        // /// \param bearing camera bearing, by default bearing will be taken from heading data.
        // ///
        // /// \param pitch Camera pitch. Default value is 45.
        // ///
        // - (nonnull instancetype)initWithPadding:(NSValue * _Nullable)padding zoom:(NSNumber * _Nullable)zoom bearing:(TMBFollowPuckViewportStateBearing * _Nullable)bearing pitch:(NSNumber * _Nullable)pitch OBJC_DESIGNATED_INITIALIZER;
        [Export("initWithPadding:zoom:bearing:pitch:")]
        NativeHandle Constructor([NullAllowed] NSValue padding, [NullAllowed] NSNumber zoom, [NullAllowed] TMBFollowPuckViewportStateBearing bearing, [NullAllowed] NSNumber pitch);
    }
    // SWIFT_CLASS("_TtC13MapboxMapObjC33TMBFollowPuckViewportStateBearing")
    // @interface TMBFollowPuckViewportStateBearing : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC33TMBFollowPuckViewportStateBearing")]
    [DisableDefaultCtor]
    interface TMBFollowPuckViewportStateBearing
    {
        // @property (nonatomic, readonly) CLLocationDirection bearing;
        [Export("bearing")]
        float Bearing { get; }

        // @property (nonatomic, readonly) BOOL heading;
        [Export("heading")]
        bool Heading { get; }

        // @property (nonatomic, readonly) BOOL course;
        [Export("course")]
        bool Course { get; }

        // /// <code>FollowPuckViewportState</code> sets <code>CameraOptions-swift.struct/bearing</code> to a constant value.
        // /// \param bearing the constant value that should be used to set the camera bearing.
        // ///
        // + (TMBFollowPuckViewportStateBearing * _Nonnull)FromConstant:(CLLocationDirection)bearing SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("FromConstant:")]
        TMBFollowPuckViewportStateBearing FromConstant(float bearing);

        // /// <code>FollowPuckViewportState</code> sets <code>CameraOptions-swift.struct/bearing</code> based on the current
        // /// heading.
        // /// seealso:
        // ///
        // /// <ul>
        // ///   <li>
        // ///     <code>LocationManager</code>
        // ///   </li>
        // ///   <li>
        // ///     <code>Location/heading</code>
        // ///   </li>
        // /// </ul>
        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBFollowPuckViewportStateBearing * _Nonnull heading;)
        // + (TMBFollowPuckViewportStateBearing * _Nonnull)heading SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("heading")]
        TMBFollowPuckViewportStateBearing HeadingInstance { get; }

        // /// <code>FollowPuckViewportState</code> sets <code>CameraOptions-swift.struct/bearing</code> based on the current
        // /// course.
        // /// seealso:
        // ///
        // /// <ul>
        // ///   <li>
        // ///     <code>LocationManager</code>
        // ///   </li>
        // ///   <li>
        // ///     <code>Location/course</code>
        // ///   </li>
        // /// </ul>
        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBFollowPuckViewportStateBearing * _Nonnull course;)
        // + (TMBFollowPuckViewportStateBearing * _Nonnull)course SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("course")]
        TMBFollowPuckViewportStateBearing CourseInstance { get; }
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC26TMBFollowPuckViewportState")
    // @interface TMBFollowPuckViewportState : NSObject <TMBViewportState>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC26TMBFollowPuckViewportState")]
    [DisableDefaultCtor]
    interface TMBFollowPuckViewportState : TMBViewportState
    {
        // /// Configuration options for this state.
        // @property (nonatomic, strong) TMBFollowPuckViewportStateOptions * _Nonnull options;
        [Export("options", ArgumentSemantic.Strong)]
        TMBFollowPuckViewportStateOptions Options { get; set; }

        // /// :nodoc:
        // /// See <code>ViewportState/observeDataSource(with:)</code>.
        // - (TMBCancelable * _Nonnull)observeDataSourceWith:(BOOL (^ _Nonnull)(TMBCameraOptions * _Nonnull))handler SWIFT_WARN_UNUSED_RESULT;
        [Export("observeDataSourceWith:")]
        TMBCancelable ObserveDataSourceWith(ObserveDataSourceWithHandler handler);

        // /// :nodoc:
        // /// See <code>ViewportState/startUpdatingCamera()</code>.
        // - (void)startUpdatingCamera;
        [Export("startUpdatingCamera")]
        void StartUpdatingCamera();

        // /// :nodoc:
        // /// See <code>ViewportState/stopUpdatingCamera()</code>.
        // - (void)stopUpdatingCamera;
        [Export("stopUpdatingCamera")]
        void StopUpdatingCamera();
    }

    // SWIFT_PROTOCOL("_TtP13MapboxMapObjC16TMBViewportState_")
    // @protocol TMBViewportState
    partial interface ITMBViewportState { }

    delegate bool ObserveDataSourceWithHandler(TMBCameraOptions options);


    [Model, Protocol(Name = "_TtP13MapboxMapObjC16TMBViewportState_")]
    [BaseType(typeof(NSObject))]
    interface TMBViewportState
    {
        // - (TMBCancelable * _Nonnull)observeDataSourceWith:(BOOL (^ _Nonnull)(TMBCameraOptions * _Nonnull))handler SWIFT_WARN_UNUSED_RESULT;
        [Abstract, Export("observeDataSourceWith:")]
        TMBCancelable ObserveDataSourceWith(ObserveDataSourceWithHandler handler);

        // - (void)startUpdatingCamera;
        [Abstract, Export("startUpdatingCamera")]
        void StartUpdatingCamera();

        // - (void)stopUpdatingCamera;
        [Abstract, Export("stopUpdatingCamera")]
        void StopUpdatingCamera();
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC35TMBDefaultViewportTransitionOptions")
    // @interface TMBDefaultViewportTransitionOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC35TMBDefaultViewportTransitionOptions")]
    [DisableDefaultCtor]
    interface TMBDefaultViewportTransitionOptions
    {
        // /// The maximum duration of the transition.
        // @property (nonatomic) NSTimeInterval maxDuration;
        [Export("maxDuration")]
        float MaxDuration { get; set; }

        // /// Memberwise initializer for <code>DefaultViewportTransitionOptions</code>.
        // /// \param maxDuration Defaults to 3.5.
        // ///
        // - (nonnull instancetype)initWithMaxDuration:(NSTimeInterval)maxDuration OBJC_DESIGNATED_INITIALIZER;
        [Export("initWithMaxDuration:")]
        NativeHandle Constructor(float maxDuration);
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC28TMBDefaultViewportTransition")
    // @interface TMBDefaultViewportTransition : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC28TMBDefaultViewportTransition")]
    [DisableDefaultCtor]
    interface TMBDefaultViewportTransition
    {
        // /// Configuration options.
        // /// New values will take effect the next time <code>ViewportTransition/run(to:completion:)</code>
        // /// is invoked
        // @property (nonatomic, strong) TMBDefaultViewportTransitionOptions * _Nonnull options;
        [Export("options")]
        TMBDefaultViewportTransitionOptions Options { get; set; }
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC16TMBCameraChanged")
    // @interface TMBCameraChanged : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC16TMBCameraChanged")]
    [DisableDefaultCtor]
    interface TMBCameraChanged
    {
        // /// The current state of the camera.
        // @property (nonatomic, readonly, strong) TMBCameraState * _Nonnull cameraState;
        [Export("cameraState")]
        TMBCameraState CameraState { get; }

        // /// The time when the camera was changed.
        // @property (nonatomic, readonly, copy) NSDate * _Nonnull timestamp;
        // - (nonnull instancetype)initWithCameraState:(TMBCameraState * _Nonnull)cameraState timestamp:(NSDate * _Nonnull)timestamp OBJC_DESIGNATED_INITIALIZER;
        [Export("initWithCameraState:timestamp:")]
        NativeHandle Constructor(TMBCameraState cameraState, NSDate timestamp);
    }

    // @interface BuiltInStyles : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13BuiltInStyles")]
    interface BuiltInStyles
    {
        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull standard;
        [Static]
        [Export("standard")]
        string Standard { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull streets;
        [Static]
        [Export("streets")]
        string Streets { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull outdoors;
        [Static]
        [Export("outdoors")]
        string Outdoors { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull light;
        [Static]
        [Export("light")]
        string Light { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull dark;
        [Static]
        [Export("dark")]
        string Dark { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull satellite;
        [Static]
        [Export("satellite")]
        string Satellite { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull satelliteStreets;
        [Static]
        [Export("satelliteStreets")]
        string SatelliteStreets { get; }
    }

    // @interface GeometryHelper : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14GeometryHelper")]
    [DisableDefaultCtor]
    interface GeometryHelper
    {
        // +(MBXGeometry * _Nonnull)createPoint:(NSValue * _Nonnull)location __attribute__((warn_unused_result("")));
        [Static]
        [Export("createPoint:")]
        MBXGeometry CreatePoint(NSValue location);

        // +(MBXGeometry * _Nonnull)createLine:(NSArray<NSValue *> * _Nonnull)locations __attribute__((warn_unused_result("")));
        [Static]
        [Export("createLine:")]
        MBXGeometry CreateLine(NSValue[] locations);

        // +(MBXGeometry * _Nonnull)createMultiLine:(NSArray<NSArray<NSValue *> *> * _Nonnull)locations __attribute__((warn_unused_result("")));
        [Static]
        [Export("createMultiLine:")]
        MBXGeometry CreateMultiLine(NSArray locations);

        // +(MBXGeometry * _Nonnull)createMultiPoint:(NSArray<NSValue *> * _Nonnull)locations __attribute__((warn_unused_result("")));
        [Static]
        [Export("createMultiPoint:")]
        MBXGeometry CreateMultiPoint(NSValue[] locations);

        // +(MBXGeometry * _Nonnull)createMultiPolygon:(NSArray<NSArray<NSArray<NSValue *> *> *> * _Nonnull)locations __attribute__((warn_unused_result("")));
        [Static]
        [Export("createMultiPolygon:")]
        MBXGeometry CreateMultiPolygon(NSArray locations);

        // +(MBXGeometry * _Nonnull)createPolygon:(NSArray<NSArray<NSValue *> *> * _Nonnull)locations __attribute__((warn_unused_result("")));
        [Static]
        [Export("createPolygon:")]
        MBXGeometry CreatePolygon(NSArray locations);

        // + (MBXGeometry * _Nonnull)createPolygonWithCenter:(CLLocationCoordinate2D)center radius:(CLLocationDistance)radius vertices:(NSInteger)vertices SWIFT_WARN_UNUSED_RESULT;
        [Static]
        [Export("createPolygonWithCenter:radius:vertices:")]
        MBXGeometry CreatePolygonWithCenter(CLLocationCoordinate2D center, double radius, int vertices);

        // +(MBXGeometry * _Nonnull)create:(NSArray<MBXGeometry *> * _Nonnull)items __attribute__((warn_unused_result("")));
        [Static]
        [Export("create:")]
        MBXGeometry Create(MBXGeometry[] items);
    }

    // @interface MapboxMapObjC_Swift_359
    [Category]
    [BaseType(typeof(MapInitOptions))]
    interface MapboxMapObjC_Swift_359
    {
        // -(MBMMapOptions * _Nonnull)getMapOptions __attribute__((warn_unused_result("")));
        [Export("getMapOptions")]
        MBMMapOptions GetMapOptions();

        // -(NSString * _Nullable)getStyleURI __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getStyleURI")]
        string GetStyleURI();

        // -(NSString * _Nullable)getStyleJSON __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getStyleJSON")]
        string GetStyleJSON();

        // -(TMBCameraOptions * _Nullable)getCameraOptions __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getCameraOptions")]
        TMBCameraOptions GetCameraOptions();

        // -(NSInteger)getAntialiasingSampleCount __attribute__((warn_unused_result("")));
        [Export("getAntialiasingSampleCount")]
        nint GetAntialiasingSampleCount();
    }

    // @interface MapInitOptionsFactory : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC21MapInitOptionsFactory")]
    interface MapInitOptionsFactory
    {
        // +(id)createWithMapOptions:(MBMMapOptions * _Nullable)mapOptions cameraOptions:(TMBCameraOptions * _Nullable)cameraOptions styleURI:(NSString * _Nullable)styleURI styleJSON:(NSString * _Nullable)styleJSON antialiasingSampleCount:(NSInteger)antialiasingSampleCount __attribute__((warn_unused_result("")));
        [Static]
        [Export("createWithMapOptions:cameraOptions:styleURI:styleJSON:antialiasingSampleCount:")]
        MapInitOptions CreateWithMapOptions([NullAllowed] MBMMapOptions mapOptions, [NullAllowed] TMBCameraOptions cameraOptions, [NullAllowed] string styleURI, [NullAllowed] string styleJSON, nint antialiasingSampleCount);
    }

    // @interface MapboxMapObjC_Swift_396
    [Category]
    [BaseType(typeof(MapView))]
    interface MapboxMapObjC_Swift_396
    {
        // -(TMBCameraAnimationsManager * _Nonnull)camera __attribute__((warn_unused_result("")));
        [Export("camera")]
        TMBCameraAnimationsManager Camera();
    }

    // @interface MapboxMapObjC_Swift_403
    [Category]
    [BaseType(typeof(MapView))]
    interface MapboxMapObjC_Swift_403
    {
        // -(TMBAnnotationOrchestrator * _Nonnull)annotations __attribute__((warn_unused_result("")));
        [Export("annotations")]
        TMBAnnotationOrchestrator Annotations();
    }

    // @interface MapboxMapObjC_Swift_409
    [Category]
    [BaseType(typeof(MapView))]
    interface MapboxMapObjC_Swift_409
    {
        // -(TMBMapboxMap * _Nonnull)mapboxMap __attribute__((warn_unused_result("")));
        [Export("mapboxMap")]
        TMBMapboxMap MapboxMap();
    }

    // @interface MapboxMapObjC_Swift_415
    [Category]
    [BaseType(typeof(MapView))]
    interface MapboxMapObjC_Swift_415
    {
        // -(TMBGestureManager * _Nonnull)gestures __attribute__((warn_unused_result("")));
        [Export("gestures")]
        TMBGestureManager Gestures();

        // - (TMBLocationManager * _Nonnull)location SWIFT_WARN_UNUSED_RESULT;
        [Export("location")]
        TMBLocationManager Location();
    }

    // @interface MapboxMapObjC_Swift_421
    [Category]
    [BaseType(typeof(MapView))]
    interface MapboxMapObjC_Swift_421
    {
        // -(TMBViewAnnotationManager * _Nonnull)viewAnnotations __attribute__((warn_unused_result("")));
        [Export("viewAnnotations")]
        TMBViewAnnotationManager ViewAnnotations();
    }

    // @interface MapboxMapObjC_Swift_427
    [Category]
    [BaseType(typeof(MapView))]
    interface MapboxMapObjC_Swift_427
    {
        // -(TMBOrnamentsManager * _Nonnull)ornaments __attribute__((warn_unused_result("")));
        [Export("ornaments")]
        TMBOrnamentsManager Ornaments();

        // -(TMBViewportManager * _Nonnull)viewport __attribute__((warn_unused_result("")));
        [Export("viewport")]
        TMBViewportManager Viewport();
    }

    // @interface MapboxMapObjC_Swift_434
    [Category]
    [BaseType(typeof(MapView))]
    interface MapboxMapObjC_Swift_434
    {
        // -(void)preferredFrameRateRange:(CAFrameRateRange)value;
        [Export("preferredFrameRateRange:")]
        void PreferredFrameRateRange(CAFrameRateRange value);

        // -(NSArray<NSNumber *> * _Nonnull)mapboxMapDebugOptions __attribute__((warn_unused_result("")));
        [Export("mapboxMapDebugOptions")]
        NSNumber[] MapboxMapDebugOptions();

        // -(void)mapboxMapDebugOptions:(NSArray<NSNumber *> * _Nonnull)value;
        [Export("mapboxMapDebugOptions:")]
        void MapboxMapDebugOptions(NSNumber[] value);

        // -(BOOL)getPresentsWithTransaction __attribute__((warn_unused_result("")));
        [Export("getPresentsWithTransaction")]
        bool PresentsWithTransaction();

        // -(void)setPresentsWithTransaction:(BOOL)value;
        [Export("setPresentsWithTransaction:")]
        void SetPresentsWithTransaction(bool value);

        // -(NSInteger)getPreferredFramesPerSecond __attribute__((warn_unused_result(""))) __attribute__((availability(ios, deprecated=15)));
        [Deprecated(PlatformName.iOS, 15, 0, message: "Use preferredFrameRateRange instead.")]
        [Export("getPreferredFramesPerSecond")]
        nint PreferredFramesPerSecond();

        // -(void)setPreferredFramesPerSecond:(NSInteger)value __attribute__((availability(ios, deprecated=15)));
        [Deprecated(PlatformName.iOS, 15, 0, message: "Use preferredFrameRateRange instead.")]
        [Export("setPreferredFramesPerSecond:")]
        void SetPreferredFramesPerSecond(nint value);

        // -(CAFrameRateRange)getPreferredFrameRateRange __attribute__((warn_unused_result(""))) __attribute__((availability(ios, introduced=15.0)));
        // [iOS (15, 0)]
        [Export("getPreferredFrameRateRange")]
        CAFrameRateRange PreferredFrameRateRange();

        // -(void)setPreferredFrameRateRange:(CAFrameRateRange)value __attribute__((availability(ios, introduced=15.0)));
        // [iOS (15,0)]
        [Export("setPreferredFrameRateRange:")]
        void SetPreferredFrameRateRange(CAFrameRateRange value);

        // -(TMBCameraState * _Nonnull)getCameraState __attribute__((warn_unused_result("")));
        [Export("getCameraState")]
        TMBCameraState GetCameraState();
    }

    // @interface MapViewFactory : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14MapViewFactory")]
    [DisableDefaultCtor]
    interface MapViewFactory
    {
        // +(id)createWithFrame:(CGRect)frame options:(id)options __attribute__((warn_unused_result("")));
        [Static]
        [Export("createWithFrame:options:")]
        MapView CreateWithFrame(CGRect frame, [NullAllowed] MapInitOptions options);

        // +(id)createWithFrame:(CGRect)frame mapInitOptions:(id)mapInitOptions urlOpener:(id<TMBAttributionURLOpener> _Nonnull)urlOpener __attribute__((warn_unused_result("")));
        [Static]
        [Export("createWithFrame:mapInitOptions:urlOpener:")]
        MapView CreateWithFrame(CGRect frame, [NullAllowed] MapInitOptions mapInitOptions, ITMBAttributionURLOpener urlOpener);
    }

    // @protocol NamedString
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface INamedString { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC11NamedString_")]
    [BaseType(typeof(NSObject))]
    interface NamedString
    {
        // @required -(NSString * _Nonnull)stringValue __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("stringValue")]
        string StringValue { get; }
    }

    // @interface MapboxMapObjC_Swift_478
    [Category]
    [BaseType(typeof(MBMOfflineManager))]
    interface MapboxMapObjC_Swift_478
    {
        // -(TMBCancelable * _Nonnull)loadStylePackFor:(NSString * _Nonnull)styleUriString loadOptions:(MBMStylePackLoadOptions * _Nonnull)loadOptions progress:(id)progress completion:(void (^ _Nonnull)(MBMStylePack * _Nullable, NSError * _Nullable))completion;
        [Export("loadStylePackFor:loadOptions:progress:completion:")]
        TMBCancelable LoadStylePackFor(string styleUriString, MBMStylePackLoadOptions loadOptions, Action<MBMStylePackLoadProgress> progress, Action<MBMStylePack, NSError> completion);

        // -(void)allStylePacks:(void (^ _Nonnull)(NSArray<MBMStylePack *> * _Nullable, NSError * _Nullable))completion;
        [Export("allStylePacks:")]
        void AllStylePacks(Action<NSArray<MBMStylePack>, NSError> completion);

        // -(void)stylePackFor:(NSString * _Nonnull)styleUriString completion:(void (^ _Nonnull)(MBMStylePack * _Nullable, NSError * _Nullable))completion;
        [Export("stylePackFor:completion:")]
        void StylePackFor(string styleUriString, Action<MBMStylePack, NSError> completion);

        // -(void)stylePackMetadataFor:(NSString * _Nonnull)styleUriString completion:(void (^ _Nonnull)(id _Nullable, NSError * _Nullable))completion;
        [Export("stylePackMetadataFor:completion:")]
        void StylePackMetadataFor(string styleUriString, Action<NSObject, NSError> completion);

        // -(void)removeStylePackFor:(NSString * _Nonnull)styleUriString completion:(void (^ _Nullable)(MBMStylePack * _Nullable, NSError * _Nullable))completion;
        [Export("removeStylePackFor:completion:")]
        void RemoveStylePackFor(string styleUriString, [NullAllowed] Action<MBMStylePack, NSError> completion);
    }

    // @interface TMBAmbientLight : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC15TMBAmbientLight")]
    [DisableDefaultCtor]
    interface TMBAmbientLight
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLightType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLightType Type { get; }

        // @property (nonatomic, strong) TMBValue * _Nullable color;
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        TMBValue Color { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable colorTransition;
        [NullAllowed, Export("colorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition ColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable intensity;
        [NullAllowed, Export("intensity", ArgumentSemantic.Strong)]
        TMBValue Intensity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable intensityTransition;
        [NullAllowed, Export("intensityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IntensityTransition { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC9TMBAnchor")]
    [DisableDefaultCtor]
    interface TMBAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBAnchor * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBAnchor Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBAnchor * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBAnchor Viewport { get; }
    }

    // @interface TMBAnimationOwner : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC17TMBAnimationOwner")]
    [DisableDefaultCtor]
    interface TMBAnimationOwner
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBAnimationOwner * _Nonnull gestures;
        [Static]
        [Export("gestures", ArgumentSemantic.Strong)]
        TMBAnimationOwner Gestures { get; }

        // @property (readonly, nonatomic, strong, class) TMBAnimationOwner * _Nonnull unspecified;
        [Static]
        [Export("unspecified", ArgumentSemantic.Strong)]
        TMBAnimationOwner Unspecified { get; }
    }

    // @interface TMBAnnotatedFeature : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC19TMBAnnotatedFeature")]
    [DisableDefaultCtor]
    interface TMBAnnotatedFeature
    {
        // @property (readonly, nonatomic, strong) MBXGeometry * _Nullable geometry;
        [NullAllowed, Export("geometry", ArgumentSemantic.Strong)]
        MBXGeometry Geometry { get; }

        // @property (nonatomic, strong) TMBAnnotatedFeatureLayerFeature * _Nullable layerFeature;
        [NullAllowed, Export("layerFeature", ArgumentSemantic.Strong)]
        TMBAnnotatedFeatureLayerFeature LayerFeature { get; set; }

        // +(TMBAnnotatedFeature * _Nonnull)layerFeatureWithLayerId:(NSString * _Nonnull)layerId featureId:(NSString * _Nullable)featureId __attribute__((warn_unused_result("")));
        [Static]
        [Export("layerFeatureWithLayerId:featureId:")]
        TMBAnnotatedFeature LayerFeatureWithLayerId(string layerId, [NullAllowed] string featureId);

        // +(TMBAnnotatedFeature * _Nonnull)geometry:(MBXGeometry * _Nonnull)geometry __attribute__((warn_unused_result("")));
        [Static]
        [Export("geometry:")]
        TMBAnnotatedFeature FromGeometry(MBXGeometry geometry);
    }

    // @interface TMBAnnotatedFeatureLayerFeature : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC31TMBAnnotatedFeatureLayerFeature")]
    [DisableDefaultCtor]
    interface TMBAnnotatedFeatureLayerFeature
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull layerId;
        [Export("layerId")]
        string LayerId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable featureId;
        [NullAllowed, Export("featureId")]
        string FeatureId { get; }
    }

    // @protocol TMBAnnotation
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface ITMBAnnotation { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC13TMBAnnotation_")]
    [BaseType(typeof(NSObject))]
    interface TMBAnnotation
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Abstract]
        [Export("id")]
        string Id { get; }

        // @required @property (readonly, nonatomic, strong) MBXGeometry * _Nonnull geometry;
        [Abstract]
        [Export("geometry", ArgumentSemantic.Strong)]
        MBXGeometry Geometry { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable userInfo;
        [Abstract]
        [NullAllowed, Export("userInfo", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> UserInfo { get; }
    }

    partial interface ITMBAnnotationInteractionDelegate { }

    // @protocol TMBAnnotationInteractionDelegate
    [Model, Protocol(Name = "_TtP13MapboxMapObjC32TMBAnnotationInteractionDelegate_")]
    [BaseType(typeof(NSObject))]
    interface TMBAnnotationInteractionDelegate
    {
        // @required -(void)annotationManager:(id<TMBAnnotationManager> _Nonnull)manager didDetectTappedAnnotations:(NSArray<id<TMBAnnotation>> * _Nonnull)annotations;
        [Abstract]
        [Export("annotationManager:didDetectTappedAnnotations:")]
        void DidDetectTappedAnnotations(ITMBAnnotationManager manager, NSObject[] annotations);
    }

    // @protocol TMBAnnotationManager
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface ITMBAnnotationManager : INativeObject { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC20TMBAnnotationManager_")]
    [BaseType(typeof(NSObject))]
    interface TMBAnnotationManager
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Abstract]
        [Export("id")]
        string Id { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull sourceId;
        [Abstract]
        [Export("sourceId")]
        string SourceId { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull layerId;
        [Abstract]
        [Export("layerId")]
        string LayerId { get; }

        // @required @property (copy, nonatomic) NSString * _Nullable slot;
        [Abstract]
        [NullAllowed, Export("slot")]
        string Slot { get; set; }
        
        // - (void)addAnnotations:(NSArray<TMBPointAnnotation *> * _Nonnull)annotations;
        [Export("addAnnotations:")]
        void AddAnnotations(ITMBAnnotation[] annotations);

        // - (void)addAnnotation:(TMBAnnotation * _Nonnull)annotation;
        [Export("addAnnotation:")]
        void AddAnnotation(ITMBAnnotation annotations);

        // - (void)updateAnnotations:(NSArray<TMBAnnotation *> * _Nonnull)annotations;
        [Export("updateAnnotations:")]
        void UpdateAnnotations(ITMBAnnotation[] annotations);

        // - (void)updateAnnotation:(TMBAnnotation * _Nonnull)annotation;
        [Export("updateAnnotation:")]
        void UpdateAnnotation(ITMBAnnotation annotations);

        // - (void)removeAnnotation:(TMBAnnotation * _Nonnull)annotation;
        [Export("removeAnnotation:")]
        void RemoveAnnotation(ITMBAnnotation annotation);

        // - (void)removeAnnotationById:(NSString * _Nonnull)annotationId;
        [Export("removeAnnotationById:")]
        void RemoveAnnotationById(string annotationId);

        // - (void)removeAllAnnotations;
        [Export("removeAllAnnotations")]
        void RemoveAllAnnotations();
    }

    // @interface TMBAnnotationOrchestrator : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC25TMBAnnotationOrchestrator")]
    [DisableDefaultCtor]
    interface TMBAnnotationOrchestrator
    {
        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id<TMBAnnotationManager>> * _Nonnull annotationManagersById;
        [Export("annotationManagersById", ArgumentSemantic.Copy)]
        NSDictionary<NSString, ITMBAnnotationManager> AnnotationManagersById { get; }

        // -(TMBPointAnnotationManager * _Nonnull)makePointAnnotationManagerWithId:(NSString * _Nullable)id layerPosition:(TMBLayerPosition * _Nullable)layerPosition clusterOptions:(TMBClusterOptions * _Nullable)clusterOptions __attribute__((warn_unused_result("")));
        [Export("makePointAnnotationManagerWithId:layerPosition:clusterOptions:")]
        TMBPointAnnotationManager MakePointAnnotationManagerWithId([NullAllowed] string id, [NullAllowed] TMBLayerPosition layerPosition, [NullAllowed] TMBClusterOptions clusterOptions);

        // -(TMBPolygonAnnotationManager * _Nonnull)makePolygonAnnotationManagerWithId:(NSString * _Nullable)id layerPosition:(TMBLayerPosition * _Nullable)layerPosition __attribute__((warn_unused_result("")));
        [Export("makePolygonAnnotationManagerWithId:layerPosition:")]
        TMBPolygonAnnotationManager MakePolygonAnnotationManagerWithId([NullAllowed] string id, [NullAllowed] TMBLayerPosition layerPosition);

        // -(TMBPolylineAnnotationManager * _Nonnull)makePolylineAnnotationManagerWithId:(NSString * _Nullable)id layerPosition:(TMBLayerPosition * _Nullable)layerPosition __attribute__((warn_unused_result("")));
        [Export("makePolylineAnnotationManagerWithId:layerPosition:")]
        TMBPolylineAnnotationManager MakePolylineAnnotationManagerWithId([NullAllowed] string id, [NullAllowed] TMBLayerPosition layerPosition);

        // -(TMBCircleAnnotationManager * _Nonnull)makeCircleAnnotationManagerWithId:(NSString * _Nullable)id layerPosition:(TMBLayerPosition * _Nullable)layerPosition __attribute__((warn_unused_result("")));
        [Export("makeCircleAnnotationManagerWithId:layerPosition:")]
        TMBCircleAnnotationManager MakeCircleAnnotationManagerWithId([NullAllowed] string id, [NullAllowed] TMBLayerPosition layerPosition);

        // -(void)removeAnnotationManagerWithId:(NSString * _Nonnull)id;
        [Export("removeAnnotationManagerWithId:")]
        void RemoveAnnotationManagerWithId(string id);
    }

    // @interface TMBAppleLocationProvider : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC24TMBAppleLocationProvider")]
    interface TMBAppleLocationProvider
    {
        // @property (nonatomic, strong) TMBAppleLocationProviderOptions * _Nonnull options;
        [Export("options", ArgumentSemantic.Strong)]
        TMBAppleLocationProviderOptions Options { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        TMBAppleLocationProviderDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<TMBAppleLocationProviderDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(TMBCancelable * _Nonnull)onLocationUpdateWithHandler:(void (^ _Nonnull)(NSArray<MBXLocation *> * _Nonnull))handler __attribute__((warn_unused_result("")));
        [Export("onLocationUpdateWithHandler:")]
        TMBCancelable OnLocationUpdateWithHandler(Action<NSArray<MBXLocation>> handler);

        // -(TMBCancelable * _Nonnull)onHeadingUpdateWithHandler:(void (^ _Nonnull)(TMBHeading * _Nonnull))handler __attribute__((warn_unused_result("")));
        [Export("onHeadingUpdateWithHandler:")]
        TMBCancelable OnHeadingUpdateWithHandler(Action<TMBHeading> handler);
    }

    partial interface ITMBAppleLocationProviderDelegate { }

    // @protocol TMBAppleLocationProviderDelegate
    [Model, Protocol(Name = "_TtP13MapboxMapObjC32TMBAppleLocationProviderDelegate_")]
    [BaseType(typeof(NSObject))]
    interface TMBAppleLocationProviderDelegate
    {
        // @required -(void)appleLocationProvider:(TMBAppleLocationProvider * _Nonnull)locationProvider didFailWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("appleLocationProvider:didFailWithError:")]
        void AppleLocationProvider(TMBAppleLocationProvider locationProvider, NSError error);

        // @required -(void)appleLocationProvider:(TMBAppleLocationProvider * _Nonnull)locationProvider didChangeAccuracyAuthorization:(CLAccuracyAuthorization)accuracyAuthorization;
        [Abstract]
        [Export("appleLocationProvider:didChangeAccuracyAuthorization:")]
        void AppleLocationProvider(TMBAppleLocationProvider locationProvider, CLAccuracyAuthorization accuracyAuthorization);

        // @required -(BOOL)appleLocationProviderShouldDisplayHeadingCalibration:(TMBAppleLocationProvider * _Nonnull)locationProvider __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("appleLocationProviderShouldDisplayHeadingCalibration:")]
        bool AppleLocationProviderShouldDisplayHeadingCalibration(TMBAppleLocationProvider locationProvider);
    }

    // @interface TMBAppleLocationProviderOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC31TMBAppleLocationProviderOptions")]
    [DisableDefaultCtor]
    interface TMBAppleLocationProviderOptions
    {
        // @property (nonatomic) CLLocationDistance distanceFilter;
        [Export("distanceFilter")]
        double DistanceFilter { get; set; }

        // @property (nonatomic) CLLocationAccuracy desiredAccuracy;
        [Export("desiredAccuracy")]
        double DesiredAccuracy { get; set; }

        // @property (nonatomic) CLActivityType activityType;
        [Export("activityType", ArgumentSemantic.Assign)]
        CLActivityType ActivityType { get; set; }

        // -(instancetype _Nonnull)initWithDistanceFilter:(CLLocationDistance)distanceFilter desiredAccuracy:(CLLocationAccuracy)desiredAccuracy activityType:(CLActivityType)activityType __attribute__((objc_designated_initializer));
        [Export("initWithDistanceFilter:desiredAccuracy:activityType:")]
        [DesignatedInitializer]
        NativeHandle Constructor(double distanceFilter, double desiredAccuracy, CLActivityType activityType);
    }

    // @interface TMBAtmosphere : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBAtmosphere")]
    interface TMBAtmosphere
    {
        // @property (nonatomic, strong) TMBValue * _Nullable color;
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        TMBValue Color { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable colorTransition;
        [NullAllowed, Export("colorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition ColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable highColor;
        [NullAllowed, Export("highColor", ArgumentSemantic.Strong)]
        TMBValue HighColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable highColorTransition;
        [NullAllowed, Export("highColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HighColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable horizonBlend;
        [NullAllowed, Export("horizonBlend", ArgumentSemantic.Strong)]
        TMBValue HorizonBlend { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable horizonBlendTransition;
        [NullAllowed, Export("horizonBlendTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HorizonBlendTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable range;
        [NullAllowed, Export("range", ArgumentSemantic.Strong)]
        TMBValue Range { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rangeTransition;
        [NullAllowed, Export("rangeTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RangeTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable spaceColor;
        [NullAllowed, Export("spaceColor", ArgumentSemantic.Strong)]
        TMBValue SpaceColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable spaceColorTransition;
        [NullAllowed, Export("spaceColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition SpaceColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable starIntensity;
        [NullAllowed, Export("starIntensity", ArgumentSemantic.Strong)]
        TMBValue StarIntensity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable starIntensityTransition;
        [NullAllowed, Export("starIntensityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition StarIntensityTransition { get; set; }
    }

    // @interface TMBAttributionButtonOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC27TMBAttributionButtonOptions")]
    [DisableDefaultCtor]
    interface TMBAttributionButtonOptions
    {
        // @property (nonatomic) enum TMBOrnamentPosition position;
        [Export("position", ArgumentSemantic.Assign)]
        TMBOrnamentPosition Position { get; set; }

        // @property (nonatomic) CGPoint margins;
        [Export("margins", ArgumentSemantic.Assign)]
        CGPoint Margins { get; set; }

        // -(instancetype _Nonnull)initWithPosition:(enum TMBOrnamentPosition)position margins:(CGPoint)margins __attribute__((objc_designated_initializer));
        [Export("initWithPosition:margins:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBOrnamentPosition position, CGPoint margins);
    }

    // @protocol TMBAttributionURLOpener
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface ITMBAttributionURLOpener { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC23TMBAttributionURLOpener_")]
    [BaseType(typeof(NSObject))]
    interface TMBAttributionURLOpener
    {
        // @required -(void)openAttributionURL:(NSURL * _Nonnull)url;
        [Abstract]
        [Export("openAttributionURL:")]
        void OpenAttributionURL(NSUrl url);
    }

    // @protocol TMBLayer
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface ITMBLayer { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC8TMBLayer_")]
    [BaseType(typeof(NSObject))]
    interface TMBLayer
    {
        // @required @property (copy, nonatomic) NSString * _Nonnull id;
        [Abstract]
        [Export("id")]
        string Id { get; set; }

        // @required @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Abstract]
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @required @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Abstract]
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @required @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [Abstract]
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @required @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [Abstract]
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @required @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [Abstract]
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }
    }

    // @interface TMBBackgroundLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBBackgroundLayer")]
    [DisableDefaultCtor]
    interface TMBBackgroundLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable backgroundColor;
        [NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
        TMBValue BackgroundColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable backgroundColorTransition;
        [NullAllowed, Export("backgroundColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition BackgroundColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable backgroundEmissiveStrength;
        [NullAllowed, Export("backgroundEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue BackgroundEmissiveStrength { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable backgroundEmissiveStrengthTransition;
        [NullAllowed, Export("backgroundEmissiveStrengthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition BackgroundEmissiveStrengthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable backgroundOpacity;
        [NullAllowed, Export("backgroundOpacity", ArgumentSemantic.Strong)]
        TMBValue BackgroundOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable backgroundOpacityTransition;
        [NullAllowed, Export("backgroundOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition BackgroundOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable backgroundPattern;
        [NullAllowed, Export("backgroundPattern", ArgumentSemantic.Strong)]
        TMBValue BackgroundPattern { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBBasicCameraAnimator : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBBasicCameraAnimator")]
    [DisableDefaultCtor]
    interface TMBBasicCameraAnimator
    {
        // @property (readonly, nonatomic, strong) TMBAnimationOwner * _Nonnull owner;
        [Export("owner", ArgumentSemantic.Strong)]
        TMBAnimationOwner Owner { get; }

        // @property (readonly, nonatomic, strong) TMBCameraTransition * _Nullable transition;
        [NullAllowed, Export("transition", ArgumentSemantic.Strong)]
        TMBCameraTransition Transition { get; }

        // @property (readonly, nonatomic) UIViewAnimatingState state;
        [Export("state")]
        UIViewAnimatingState State { get; }

        // @property (readonly, nonatomic) BOOL isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // @property (nonatomic) BOOL isReversed;
        [Export("isReversed")]
        bool IsReversed { get; set; }

        // @property (nonatomic) BOOL pausesOnCompletion;
        [Export("pausesOnCompletion")]
        bool PausesOnCompletion { get; set; }

        // @property (nonatomic) double fractionComplete;
        [Export("fractionComplete")]
        double FractionComplete { get; set; }

        // -(void)startAnimation;
        [Export("startAnimation")]
        void StartAnimation();

        // -(void)startAnimationAfterDelay:(NSTimeInterval)delay;
        [Export("startAnimationAfterDelay:")]
        void StartAnimationAfterDelay(double delay);

        // -(void)pauseAnimation;
        [Export("pauseAnimation")]
        void PauseAnimation();

        // -(void)stopAnimation;
        [Export("stopAnimation")]
        void StopAnimation();

        // -(void)addCompletion:(void (^ _Nonnull)(UIViewAnimatingPosition))completion;
        [Export("addCompletion:")]
        void AddCompletion(Action<UIViewAnimatingPosition> completion);

        // -(void)continueAnimationWithTimingParameters:(id<UITimingCurveProvider> _Nullable)timingParameters durationFactor:(double)durationFactor;
        [Export("continueAnimationWithTimingParameters:durationFactor:")]
        void ContinueAnimationWithTimingParameters([NullAllowed] IUITimingCurveProvider timingParameters, double durationFactor);

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();
    }

    // @interface TMBCameraAnimationsManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC26TMBCameraAnimationsManager")]
    [DisableDefaultCtor]
    interface TMBCameraAnimationsManager
    {
        // @property (readonly, copy, nonatomic) NSArray<TMBCameraAnimator *> * _Nonnull cameraAnimators;
        [Export("cameraAnimators", ArgumentSemantic.Copy)]
        TMBCameraAnimator[] CameraAnimators { get; }

        // -(void)cancelAnimations;
        [Export("cancelAnimations")]
        void CancelAnimations();

        // - (TMBCancelable * _Nonnull)flyTo:(TMBCameraOptions * _Nonnull)to duration:(NSNumber * _Nullable)duration curve:(enum UIViewAnimationCurve)curve completion:(void (^ _Nullable)(UIViewAnimatingPosition))completion;
        [Export("flyTo:duration:curve:completion:")]
        TMBCancelable FlyTo(TMBCameraOptions to, [NullAllowed] NSNumber duration, UIViewAnimationCurve curve, [NullAllowed] Action<UIViewAnimatingPosition> completion);

        // -(TMBCancelable * _Nonnull)easeTo:(TMBCameraOptions * _Nonnull)to duration:(NSTimeInterval)duration curve:(enum UIViewAnimationCurve)curve completion:(void (^ _Nullable)(UIViewAnimatingPosition))completion;
        [Export("easeTo:duration:curve:completion:")]
        TMBCancelable EaseTo(TMBCameraOptions to, double duration, UIViewAnimationCurve curve, [NullAllowed] Action<UIViewAnimatingPosition> completion);

        // -(TMBBasicCameraAnimator * _Nonnull)makeAnimatorWithDuration:(NSTimeInterval)duration timingParameters:(id<UITimingCurveProvider> _Nonnull)timingParameters animationOwner:(TMBAnimationOwner * _Nullable)animationOwner animations:(void (^ _Nonnull)(TMBCameraTransition * _Nonnull))animations __attribute__((warn_unused_result("")));
        [Export("makeAnimatorWithDuration:timingParameters:animationOwner:animations:")]
        TMBBasicCameraAnimator MakeAnimatorWithDuration(double duration, IUITimingCurveProvider timingParameters, [NullAllowed] TMBAnimationOwner animationOwner, Action<TMBCameraTransition> animations);

        // -(TMBBasicCameraAnimator * _Nonnull)makeAnimatorWithDuration:(NSTimeInterval)duration curve:(enum UIViewAnimationCurve)curve animationOwner:(TMBAnimationOwner * _Nullable)animationOwner animations:(void (^ _Nonnull)(TMBCameraTransition * _Nonnull))animations __attribute__((warn_unused_result("")));
        [Export("makeAnimatorWithDuration:curve:animationOwner:animations:")]
        TMBBasicCameraAnimator MakeAnimatorWithDuration(double duration, UIViewAnimationCurve curve, [NullAllowed] TMBAnimationOwner animationOwner, Action<TMBCameraTransition> animations);

        // -(TMBBasicCameraAnimator * _Nonnull)makeAnimatorWithDuration:(NSTimeInterval)duration controlPoint1:(CGPoint)controlPoint1 controlPoint2:(CGPoint)controlPoint2 animationOwner:(TMBAnimationOwner * _Nullable)animationOwner animations:(void (^ _Nonnull)(TMBCameraTransition * _Nonnull))animations __attribute__((warn_unused_result("")));
        [Export("makeAnimatorWithDuration:controlPoint1:controlPoint2:animationOwner:animations:")]
        TMBBasicCameraAnimator MakeAnimatorWithDuration(double duration, CGPoint controlPoint1, CGPoint controlPoint2, [NullAllowed] TMBAnimationOwner animationOwner, Action<TMBCameraTransition> animations);

        // -(TMBBasicCameraAnimator * _Nonnull)makeAnimatorWithDuration:(NSTimeInterval)duration dampingRatio:(CGFloat)dampingRatio animationOwner:(TMBAnimationOwner * _Nullable)animationOwner animations:(void (^ _Nonnull)(TMBCameraTransition * _Nonnull))animations __attribute__((warn_unused_result("")));
        [Export("makeAnimatorWithDuration:dampingRatio:animationOwner:animations:")]
        TMBBasicCameraAnimator MakeAnimatorWithDuration(double duration, nfloat dampingRatio, [NullAllowed] TMBAnimationOwner animationOwner, Action<TMBCameraTransition> animations);
    }

    // @interface TMBCancelable : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBCancelable")]
    [DisableDefaultCtor]
    interface TMBCancelable
    {
        // -(void)cancel;
        [Export("cancel")]
        void Cancel();
    }

    // @interface TMBCameraAnimator : TMBCancelable
    [BaseType(typeof(TMBCancelable), Name = "_TtC13MapboxMapObjC17TMBCameraAnimator")]
    interface TMBCameraAnimator
    {
    }

    // @interface TMBCameraBounds : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC15TMBCameraBounds")]
    [DisableDefaultCtor]
    interface TMBCameraBounds
    {
        // @property (readonly, nonatomic, strong) MBMCoordinateBounds * _Nonnull bounds;
        [Export("bounds", ArgumentSemantic.Strong)]
        MBMCoordinateBounds Bounds { get; }

        // @property (readonly, nonatomic) CGFloat maxZoom;
        [Export("maxZoom")]
        nfloat MaxZoom { get; }

        // @property (readonly, nonatomic) CGFloat minZoom;
        [Export("minZoom")]
        nfloat MinZoom { get; }

        // @property (readonly, nonatomic) CGFloat maxPitch;
        [Export("maxPitch")]
        nfloat MaxPitch { get; }

        // @property (readonly, nonatomic) CGFloat minPitch;
        [Export("minPitch")]
        nfloat MinPitch { get; }
    }

    // @interface TMBCameraBoundsOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBCameraBoundsOptions")]
    [DisableDefaultCtor]
    interface TMBCameraBoundsOptions
    {
        // @property (nonatomic, strong) MBMCoordinateBounds * _Nullable bounds;
        [NullAllowed, Export("bounds", ArgumentSemantic.Strong)]
        MBMCoordinateBounds Bounds { get; set; }

        // @property (nonatomic) CGFloat maxZoom;
        [Export("maxZoom")]
        nfloat MaxZoom { get; set; }

        // @property (nonatomic) CGFloat minZoom;
        [Export("minZoom")]
        nfloat MinZoom { get; set; }

        // @property (nonatomic) CGFloat maxPitch;
        [Export("maxPitch")]
        nfloat MaxPitch { get; set; }

        // @property (nonatomic) CGFloat minPitch;
        [Export("minPitch")]
        nfloat MinPitch { get; set; }

        // -(instancetype _Nonnull)initWithBounds:(MBMCoordinateBounds * _Nullable)bounds maxZoom:(CGFloat)maxZoom minZoom:(CGFloat)minZoom maxPitch:(CGFloat)maxPitch minPitch:(CGFloat)minPitch __attribute__((objc_designated_initializer));
        [Export("initWithBounds:maxZoom:minZoom:maxPitch:minPitch:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] MBMCoordinateBounds bounds, nfloat maxZoom, nfloat minZoom, nfloat maxPitch, nfloat minPitch);
    }

    // @interface TMBCameraOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC16TMBCameraOptions")]
    [DisableDefaultCtor]
    interface TMBCameraOptions
    {
        // @property (nonatomic) CLLocationCoordinate2D center;
        [Export("center", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Center { get; set; }

        // @property (nonatomic) UIEdgeInsets padding;
        [Export("padding", ArgumentSemantic.Assign)]
        UIEdgeInsets Padding { get; set; }

        // @property (nonatomic) CGPoint anchor;
        [Export("anchor", ArgumentSemantic.Assign)]
        CGPoint Anchor { get; set; }

        // @property (nonatomic) CGFloat zoom;
        [Export("zoom")]
        nfloat Zoom { get; set; }

        // @property (nonatomic) CLLocationDirection bearing;
        [Export("bearing")]
        double Bearing { get; set; }

        // @property (nonatomic) CGFloat pitch;
        [Export("pitch")]
        nfloat Pitch { get; set; }

        // -(instancetype _Nonnull)initWithCenter:(CLLocationCoordinate2D)center padding:(UIEdgeInsets)padding anchor:(CGPoint)anchor zoom:(CGFloat)zoom bearing:(CLLocationDirection)bearing pitch:(CGFloat)pitch __attribute__((objc_designated_initializer));
        [Export("initWithCenter:padding:anchor:zoom:bearing:pitch:")]
        [DesignatedInitializer]
        NativeHandle Constructor(CLLocationCoordinate2D center, UIEdgeInsets padding, CGPoint anchor, nfloat zoom, double bearing, nfloat pitch);

        // -(instancetype _Nonnull)initWithCameraState:(TMBCameraState * _Nonnull)cameraState anchor:(CGPoint)anchor __attribute__((objc_designated_initializer));
        [Export("initWithCameraState:anchor:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBCameraState cameraState, CGPoint anchor);
    }

    // @interface TMBCameraState : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14TMBCameraState")]
    [DisableDefaultCtor]
    interface TMBCameraState
    {
        // @property (nonatomic) CLLocationCoordinate2D center;
        [Export("center", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Center { get; set; }

        // @property (nonatomic) UIEdgeInsets padding;
        [Export("padding", ArgumentSemantic.Assign)]
        UIEdgeInsets Padding { get; set; }

        // @property (nonatomic) CGFloat zoom;
        [Export("zoom")]
        nfloat Zoom { get; set; }

        // @property (nonatomic) CLLocationDirection bearing;
        [Export("bearing")]
        double Bearing { get; set; }

        // @property (nonatomic) CGFloat pitch;
        [Export("pitch")]
        nfloat Pitch { get; set; }

        // -(instancetype _Nonnull)initWithCenter:(CLLocationCoordinate2D)center padding:(UIEdgeInsets)padding zoom:(CGFloat)zoom bearing:(CLLocationDirection)bearing pitch:(CGFloat)pitch __attribute__((objc_designated_initializer));
        [Export("initWithCenter:padding:zoom:bearing:pitch:")]
        [DesignatedInitializer]
        NativeHandle Constructor(CLLocationCoordinate2D center, UIEdgeInsets padding, nfloat zoom, double bearing, nfloat pitch);
    }

    // @interface TMBCameraTransition : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC19TMBCameraTransition")]
    [DisableDefaultCtor]
    interface TMBCameraTransition
    {
        // @property (readonly, nonatomic, strong) TMBCameraTransitionChange * _Nonnull center;
        [Export("center", ArgumentSemantic.Strong)]
        TMBCameraTransitionChange Center { get; }

        // @property (readonly, nonatomic, strong) TMBCameraTransitionChange * _Nonnull zoom;
        [Export("zoom", ArgumentSemantic.Strong)]
        TMBCameraTransitionChange Zoom { get; }

        // @property (readonly, nonatomic, strong) TMBCameraTransitionChange * _Nonnull padding;
        [Export("padding", ArgumentSemantic.Strong)]
        TMBCameraTransitionChange Padding { get; }

        // @property (readonly, nonatomic, strong) TMBCameraTransitionChange * _Nonnull anchor;
        [Export("anchor", ArgumentSemantic.Strong)]
        TMBCameraTransitionChange Anchor { get; }

        // @property (readonly, nonatomic, strong) TMBCameraTransitionChange * _Nonnull bearing;
        [Export("bearing", ArgumentSemantic.Strong)]
        TMBCameraTransitionChange Bearing { get; }

        // @property (nonatomic) BOOL shouldOptimizeBearingPath;
        [Export("shouldOptimizeBearingPath")]
        bool ShouldOptimizeBearingPath { get; set; }

        // @property (readonly, nonatomic, strong) TMBCameraTransitionChange * _Nonnull pitch;
        [Export("pitch", ArgumentSemantic.Strong)]
        TMBCameraTransitionChange Pitch { get; }
    }

    // @interface TMBCameraTransitionChange : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC25TMBCameraTransitionChange")]
    [DisableDefaultCtor]
    interface TMBCameraTransitionChange
    {
        // @property (nonatomic, strong) NSValue * _Nonnull fromValue;
        [Export("fromValue", ArgumentSemantic.Strong)]
        NSValue FromValue { get; set; }

        // @property (nonatomic, strong) NSValue * _Nullable toValue;
        [NullAllowed, Export("toValue", ArgumentSemantic.Strong)]
        NSValue ToValue { get; set; }
    }

    // @interface TMBCircleAnnotation : NSObject <TMBAnnotation>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC19TMBCircleAnnotation")]
    [DisableDefaultCtor]
    interface TMBCircleAnnotation : TMBAnnotation
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) MBXGeometry * _Nonnull geometry;
        [Export("geometry", ArgumentSemantic.Strong)]
        MBXGeometry Geometry { get; }

        // @property (nonatomic, strong) TMBPoint * _Nonnull point;
        [Export("point", ArgumentSemantic.Strong)]
        TMBPoint Point { get; set; }

        // @property (nonatomic) BOOL isSelected;
        [Export("isSelected")]
        bool IsSelected { get; set; }

        // @property (nonatomic) BOOL isDraggable;
        [Export("isDraggable")]
        bool IsDraggable { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(TMBMapContentGestureContext * _Nonnull) tapHandler;
        [NullAllowed, Export("tapHandler", ArgumentSemantic.Copy)]
        Func<TMBMapContentGestureContext, bool> TapHandler { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(TMBMapContentGestureContext * _Nonnull) longPressHandler;
        [NullAllowed, Export("longPressHandler", ArgumentSemantic.Copy)]
        Func<TMBMapContentGestureContext, bool> LongPressHandler { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable userInfo;
        [NullAllowed, Export("userInfo", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> UserInfo { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id centerCoordinate:(CLLocationCoordinate2D)centerCoordinate isSelected:(BOOL)isSelected isDraggable:(BOOL)isDraggable __attribute__((objc_designated_initializer));
        [Export("initWithId:centerCoordinate:isSelected:isDraggable:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, CLLocationCoordinate2D centerCoordinate, bool isSelected, bool isDraggable);

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id point:(TMBPoint * _Nonnull)point isSelected:(BOOL)isSelected isDraggable:(BOOL)isDraggable __attribute__((objc_designated_initializer));
        [Export("initWithId:point:isSelected:isDraggable:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, TMBPoint point, bool isSelected, bool isDraggable);

        // @property (nonatomic, strong) NSNumber * _Nullable circleSortKey;
        [NullAllowed, Export("circleSortKey", ArgumentSemantic.Strong)]
        NSNumber CircleSortKey { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable circleBlur;
        [NullAllowed, Export("circleBlur", ArgumentSemantic.Strong)]
        NSNumber CircleBlur { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable circleColor;
        [NullAllowed, Export("circleColor", ArgumentSemantic.Strong)]
        UIColor CircleColor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable circleOpacity;
        [NullAllowed, Export("circleOpacity", ArgumentSemantic.Strong)]
        NSNumber CircleOpacity { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable circleRadius;
        [NullAllowed, Export("circleRadius", ArgumentSemantic.Strong)]
        NSNumber CircleRadius { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable circleStrokeColor;
        [NullAllowed, Export("circleStrokeColor", ArgumentSemantic.Strong)]
        UIColor CircleStrokeColor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable circleStrokeOpacity;
        [NullAllowed, Export("circleStrokeOpacity", ArgumentSemantic.Strong)]
        NSNumber CircleStrokeOpacity { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable circleStrokeWidth;
        [NullAllowed, Export("circleStrokeWidth", ArgumentSemantic.Strong)]
        NSNumber CircleStrokeWidth { get; set; }
    }

    // @interface TMBCircleAnnotationManager : NSObject <TMBAnnotationManager>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC26TMBCircleAnnotationManager")]
    [DisableDefaultCtor]
    partial interface TMBCircleAnnotationManager : TMBAnnotationManager
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull sourceId;
        [Export("sourceId")]
        string SourceId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull layerId;
        [Export("layerId")]
        string LayerId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (copy, nonatomic) NSArray<TMBCircleAnnotation *> * _Nonnull annotations;
        [Export("annotations", ArgumentSemantic.Copy)]
        TMBCircleAnnotation[] Annotations { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable circleEmissiveStrength;
        [NullAllowed, Export("circleEmissiveStrength", ArgumentSemantic.Strong)]
        NSNumber CircleEmissiveStrength { get; set; }

        // @property (nonatomic, strong) TMBCirclePitchAlignment * _Nullable circlePitchAlignment;
        [NullAllowed, Export("circlePitchAlignment", ArgumentSemantic.Strong)]
        TMBCirclePitchAlignment CirclePitchAlignment { get; set; }

        // @property (nonatomic, strong) TMBCirclePitchScale * _Nullable circlePitchScale;
        [NullAllowed, Export("circlePitchScale", ArgumentSemantic.Strong)]
        TMBCirclePitchScale CirclePitchScale { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable circleTranslate;
        [NullAllowed, Export("circleTranslate", ArgumentSemantic.Copy)]
        NSNumber[] CircleTranslate { get; set; }

        // @property (nonatomic, strong) TMBCircleTranslateAnchor * _Nullable circleTranslateAnchor;
        [NullAllowed, Export("circleTranslateAnchor", ArgumentSemantic.Strong)]
        TMBCircleTranslateAnchor CircleTranslateAnchor { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable slot;
        [NullAllowed, Export("slot")]
        string Slot { get; set; }
    }

    // @interface TMBCircleLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14TMBCircleLayer")]
    [DisableDefaultCtor]
    interface TMBCircleLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBExpression * _Nullable filter;
        [NullAllowed, Export("filter", ArgumentSemantic.Strong)]
        TMBExpression Filter { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable source;
        [NullAllowed, Export("source")]
        string Source { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sourceLayer;
        [NullAllowed, Export("sourceLayer")]
        string SourceLayer { get; set; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleSortKey;
        [NullAllowed, Export("circleSortKey", ArgumentSemantic.Strong)]
        TMBValue CircleSortKey { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleBlur;
        [NullAllowed, Export("circleBlur", ArgumentSemantic.Strong)]
        TMBValue CircleBlur { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable circleBlurTransition;
        [NullAllowed, Export("circleBlurTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition CircleBlurTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleColor;
        [NullAllowed, Export("circleColor", ArgumentSemantic.Strong)]
        TMBValue CircleColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable circleColorTransition;
        [NullAllowed, Export("circleColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition CircleColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleEmissiveStrength;
        [NullAllowed, Export("circleEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue CircleEmissiveStrength { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable circleEmissiveStrengthTransition;
        [NullAllowed, Export("circleEmissiveStrengthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition CircleEmissiveStrengthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleOpacity;
        [NullAllowed, Export("circleOpacity", ArgumentSemantic.Strong)]
        TMBValue CircleOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable circleOpacityTransition;
        [NullAllowed, Export("circleOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition CircleOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circlePitchAlignment;
        [NullAllowed, Export("circlePitchAlignment", ArgumentSemantic.Strong)]
        TMBValue CirclePitchAlignment { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circlePitchScale;
        [NullAllowed, Export("circlePitchScale", ArgumentSemantic.Strong)]
        TMBValue CirclePitchScale { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleRadius;
        [NullAllowed, Export("circleRadius", ArgumentSemantic.Strong)]
        TMBValue CircleRadius { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable circleRadiusTransition;
        [NullAllowed, Export("circleRadiusTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition CircleRadiusTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleStrokeColor;
        [NullAllowed, Export("circleStrokeColor", ArgumentSemantic.Strong)]
        TMBValue CircleStrokeColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable circleStrokeColorTransition;
        [NullAllowed, Export("circleStrokeColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition CircleStrokeColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleStrokeOpacity;
        [NullAllowed, Export("circleStrokeOpacity", ArgumentSemantic.Strong)]
        TMBValue CircleStrokeOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable circleStrokeOpacityTransition;
        [NullAllowed, Export("circleStrokeOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition CircleStrokeOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleStrokeWidth;
        [NullAllowed, Export("circleStrokeWidth", ArgumentSemantic.Strong)]
        TMBValue CircleStrokeWidth { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable circleStrokeWidthTransition;
        [NullAllowed, Export("circleStrokeWidthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition CircleStrokeWidthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleTranslate;
        [NullAllowed, Export("circleTranslate", ArgumentSemantic.Strong)]
        TMBValue CircleTranslate { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable circleTranslateTransition;
        [NullAllowed, Export("circleTranslateTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition CircleTranslateTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleTranslateAnchor;
        [NullAllowed, Export("circleTranslateAnchor", ArgumentSemantic.Strong)]
        TMBValue CircleTranslateAnchor { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id source:(NSString * _Nonnull)source __attribute__((objc_designated_initializer));
        [Export("initWithId:source:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, string source);
    }

    // @interface TMBCirclePitchAlignment : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC23TMBCirclePitchAlignment")]
    [DisableDefaultCtor]
    interface TMBCirclePitchAlignment
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBCirclePitchAlignment * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBCirclePitchAlignment Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBCirclePitchAlignment * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBCirclePitchAlignment Viewport { get; }
    }

    // @interface TMBCirclePitchScale : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC19TMBCirclePitchScale")]
    [DisableDefaultCtor]
    interface TMBCirclePitchScale
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBCirclePitchScale * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBCirclePitchScale Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBCirclePitchScale * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBCirclePitchScale Viewport { get; }
    }

    // @interface TMBCircleTranslateAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC24TMBCircleTranslateAnchor")]
    [DisableDefaultCtor]
    interface TMBCircleTranslateAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBCircleTranslateAnchor * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBCircleTranslateAnchor Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBCircleTranslateAnchor * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBCircleTranslateAnchor Viewport { get; }
    }

    // @interface TMBClusterOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC17TMBClusterOptions")]
    [DisableDefaultCtor]
    interface TMBClusterOptions
    {
        // @property (nonatomic, strong) TMBValue * _Nullable circleRadius;
        [NullAllowed, Export("circleRadius", ArgumentSemantic.Strong)]
        TMBValue CircleRadius { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable circleColor;
        [NullAllowed, Export("circleColor", ArgumentSemantic.Strong)]
        TMBValue CircleColor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textColor;
        [NullAllowed, Export("textColor", ArgumentSemantic.Strong)]
        TMBValue TextColor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textSize;
        [NullAllowed, Export("textSize", ArgumentSemantic.Strong)]
        TMBValue TextSize { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textField;
        [NullAllowed, Export("textField", ArgumentSemantic.Strong)]
        TMBValue TextField { get; set; }

        // @property (nonatomic) double clusterRadius;
        [Export("clusterRadius")]
        double ClusterRadius { get; set; }

        // @property (nonatomic) double clusterMaxZoom;
        [Export("clusterMaxZoom")]
        double ClusterMaxZoom { get; set; }

        // @property (nonatomic) double clusterMinPoints;
        [Export("clusterMinPoints")]
        double ClusterMinPoints { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,TMBExpression *> * _Nullable clusterProperties;
        [NullAllowed, Export("clusterProperties", ArgumentSemantic.Copy)]
        NSDictionary<NSString, TMBExpression> ClusterProperties { get; set; }

        // -(instancetype _Nonnull)initWithCircleRadius:(TMBValue * _Nullable)circleRadius circleColor:(TMBValue * _Nullable)circleColor textColor:(TMBValue * _Nullable)textColor textSize:(TMBValue * _Nullable)textSize textField:(TMBValue * _Nullable)textField clusterRadius:(double)clusterRadius clusterMaxZoom:(double)clusterMaxZoom clusterMinPoints:(double) clusterMinPoints clusterProperties:(NSDictionary<NSString *,TMBExpression *> * _Nullable)clusterProperties __attribute__((objc_designated_initializer));
        [Export("initWithCircleRadius:circleColor:textColor:textSize:textField:clusterRadius:clusterMaxZoom:clusterMinPoints:clusterProperties:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] TMBValue circleRadius, [NullAllowed] TMBValue circleColor, [NullAllowed] TMBValue textColor, [NullAllowed] TMBValue textSize, [NullAllowed] TMBValue textField, double clusterRadius, double clusterMaxZoom, double clusterMinPoints, [NullAllowed] NSDictionary<NSString, TMBExpression> clusterProperties);
    }

    // @interface TMBCollatorOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBCollatorOptions")]
    [DisableDefaultCtor]
    interface TMBCollatorOptions
    {
        // @property (nonatomic, strong) NSNumber * _Nullable caseSensitive;
        [NullAllowed, Export("caseSensitive", ArgumentSemantic.Strong)]
        NSNumber CaseSensitive { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable diacriticSensitive;
        [NullAllowed, Export("diacriticSensitive", ArgumentSemantic.Strong)]
        NSNumber DiacriticSensitive { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable locale;
        [NullAllowed, Export("locale")]
        string Locale { get; set; }

        // -(instancetype _Nonnull)initWithCaseSensitive:(NSNumber * _Nullable)caseSensitive diacriticSensitive:(NSNumber * _Nullable)diacriticSensitive locale:(NSString * _Nullable)locale __attribute__((objc_designated_initializer));
        [Export("initWithCaseSensitive:diacriticSensitive:locale:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] NSNumber caseSensitive, [NullAllowed] NSNumber diacriticSensitive, [NullAllowed] string locale);
    }

    // @interface TMBCompassDirectionFormatter : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC28TMBCompassDirectionFormatter")]
    [DisableDefaultCtor]
    interface TMBCompassDirectionFormatter
    {
        // @property (nonatomic) enum TMBCompassDirectionFormatterStyle style;
        [Export("style", ArgumentSemantic.Assign)]
        TMBCompassDirectionFormatterStyle Style { get; set; }

        // -(NSString * _Nonnull)stringFrom:(CLLocationDirection)direction __attribute__((warn_unused_result("")));
        [Export("stringFrom:")]
        string StringFrom(double direction);
    }

    // @interface TMBCompassViewOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC21TMBCompassViewOptions")]
    [DisableDefaultCtor]
    interface TMBCompassViewOptions
    {
        // @property (nonatomic) enum TMBOrnamentPosition position;
        [Export("position", ArgumentSemantic.Assign)]
        TMBOrnamentPosition Position { get; set; }

        // @property (nonatomic) CGPoint margins;
        [Export("margins", ArgumentSemantic.Assign)]
        CGPoint Margins { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @property (nonatomic) enum TMBOrnamentVisibility visibility;
        [Export("visibility", ArgumentSemantic.Assign)]
        TMBOrnamentVisibility Visibility { get; set; }

        // -(instancetype _Nonnull)initWithPosition:(enum TMBOrnamentPosition)position margins:(CGPoint)margins image:(UIImage * _Nullable)image visibility:(enum TMBOrnamentVisibility)visibility __attribute__((objc_designated_initializer));
        [Export("initWithPosition:margins:image:visibility:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBOrnamentPosition position, CGPoint margins, [NullAllowed] UIImage image, TMBOrnamentVisibility visibility);
    }

    // @interface TMBDirectionalLight : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC19TMBDirectionalLight")]
    [DisableDefaultCtor]
    interface TMBDirectionalLight
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLightType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLightType Type { get; }

        // @property (nonatomic, strong) TMBValue * _Nullable castShadows;
        [NullAllowed, Export("castShadows", ArgumentSemantic.Strong)]
        TMBValue CastShadows { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable color;
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        TMBValue Color { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable colorTransition;
        [NullAllowed, Export("colorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition ColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable direction;
        [NullAllowed, Export("direction", ArgumentSemantic.Strong)]
        TMBValue Direction { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable directionTransition;
        [NullAllowed, Export("directionTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition DirectionTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable intensity;
        [NullAllowed, Export("intensity", ArgumentSemantic.Strong)]
        TMBValue Intensity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable intensityTransition;
        [NullAllowed, Export("intensityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IntensityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable shadowIntensity;
        [NullAllowed, Export("shadowIntensity", ArgumentSemantic.Strong)]
        TMBValue ShadowIntensity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable shadowIntensityTransition;
        [NullAllowed, Export("shadowIntensityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition ShadowIntensityTransition { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBEncoding : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC11TMBEncoding")]
    [DisableDefaultCtor]
    interface TMBEncoding
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBEncoding * _Nonnull terrarium;
        [Static]
        [Export("terrarium", ArgumentSemantic.Strong)]
        TMBEncoding Terrarium { get; }

        // @property (readonly, nonatomic, strong, class) TMBEncoding * _Nonnull mapbox;
        [Static]
        [Export("mapbox", ArgumentSemantic.Strong)]
        TMBEncoding Mapbox { get; }
    }

    // @interface TMBExpression : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBExpression")]
    [DisableDefaultCtor]
    partial interface TMBExpression : INativeObject
    {
        // @property (readonly, nonatomic, strong) TMBExpressionOperator * _Nonnull expressionOperator;
        [Export("expressionOperator", ArgumentSemantic.Strong)]
        TMBExpressionOperator ExpressionOperator { get; }

        // @property (readonly, copy, nonatomic) NSArray * _Nonnull arguments;
        [Export("arguments", ArgumentSemantic.Copy)]
        NSObject[] Arguments { get; }

        // +(TMBExpression * _Nonnull)createWithOperator:(TMBExpressionOperator * _Nonnull)operator_ __attribute__((warn_unused_result("")));
        [Static]
        [Export("createWithOperator:")]
        TMBExpression CreateWithOperator(TMBExpressionOperator operator_);

        // +(TMBExpression * _Nonnull)createWithOperator:(TMBExpressionOperator * _Nonnull)operator_ arguments:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("createWithOperator:arguments:")]
        TMBExpression CreateWithOperator(TMBExpressionOperator operator_, NSObject[] arguments);

        // +(TMBExpression * _Nonnull)args:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("args:")]
        TMBExpression Args(NSObject[] arguments);
    }

    // @interface MapboxMapObjC_Swift_1730 (TMBExpression)
    partial interface TMBExpression
    {
        // +(TMBExpression * _Nonnull)subtract __attribute__((warn_unused_result("")));
        [Static]
        [Export("subtract")]
        TMBExpression Subtract();

        // +(TMBExpression * _Nonnull)subtract:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("subtract:")]
        TMBExpression Subtract(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)not __attribute__((warn_unused_result("")));
        [Static]
        [Export("not")]
        TMBExpression Not();

        // +(TMBExpression * _Nonnull)not:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("not:")]
        TMBExpression Not(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)neq __attribute__((warn_unused_result("")));
        [Static]
        [Export("neq")]
        TMBExpression Neq();

        // +(TMBExpression * _Nonnull)neq:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("neq:")]
        TMBExpression Neq(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)product __attribute__((warn_unused_result("")));
        [Static]
        [Export("product")]
        TMBExpression Product();

        // +(TMBExpression * _Nonnull)product:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("product:")]
        TMBExpression Product(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)division __attribute__((warn_unused_result("")));
        [Static]
        [Export("division")]
        TMBExpression Division();

        // +(TMBExpression * _Nonnull)division:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("division:")]
        TMBExpression Division(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)mod __attribute__((warn_unused_result("")));
        [Static]
        [Export("mod")]
        TMBExpression Mod();

        // +(TMBExpression * _Nonnull)mod:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("mod:")]
        TMBExpression Mod(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)pow __attribute__((warn_unused_result("")));
        [Static]
        [Export("pow")]
        TMBExpression Pow();

        // +(TMBExpression * _Nonnull)pow:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("pow:")]
        TMBExpression Pow(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)sum __attribute__((warn_unused_result("")));
        [Static]
        [Export("sum")]
        TMBExpression Sum();

        // +(TMBExpression * _Nonnull)sum:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("sum:")]
        TMBExpression Sum(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)lt __attribute__((warn_unused_result("")));
        [Static]
        [Export("lt")]
        TMBExpression Lt();

        // +(TMBExpression * _Nonnull)lt:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("lt:")]
        TMBExpression Lt(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)lte __attribute__((warn_unused_result("")));
        [Static]
        [Export("lte")]
        TMBExpression Lte();

        // +(TMBExpression * _Nonnull)lte:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("lte:")]
        TMBExpression Lte(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)eq __attribute__((warn_unused_result("")));
        [Static]
        [Export("eq")]
        TMBExpression Eq();

        // +(TMBExpression * _Nonnull)eq:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("eq:")]
        TMBExpression Eq(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)gt __attribute__((warn_unused_result("")));
        [Static]
        [Export("gt")]
        TMBExpression Gt();

        // +(TMBExpression * _Nonnull)gt:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("gt:")]
        TMBExpression Gt(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)gte __attribute__((warn_unused_result("")));
        [Static]
        [Export("gte")]
        TMBExpression Gte();

        // +(TMBExpression * _Nonnull)gte:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("gte:")]
        TMBExpression Gte(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)abs __attribute__((warn_unused_result("")));
        [Static]
        [Export("abs")]
        TMBExpression Abs();

        // +(TMBExpression * _Nonnull)abs:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("abs:")]
        TMBExpression Abs(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)accumulated __attribute__((warn_unused_result("")));
        [Static]
        [Export("accumulated")]
        TMBExpression Accumulated();

        // +(TMBExpression * _Nonnull)accumulated:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("accumulated:")]
        TMBExpression Accumulated(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)acos __attribute__((warn_unused_result("")));
        [Static]
        [Export("acos")]
        TMBExpression Acos();

        // +(TMBExpression * _Nonnull)acos:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("acos:")]
        TMBExpression Acos(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)all __attribute__((warn_unused_result("")));
        [Static]
        [Export("all")]
        TMBExpression All();

        // +(TMBExpression * _Nonnull)all:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("all:")]
        TMBExpression All(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)any __attribute__((warn_unused_result("")));
        [Static]
        [Export("any")]
        TMBExpression Any();

        // +(TMBExpression * _Nonnull)any:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("any:")]
        TMBExpression Any(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)array __attribute__((warn_unused_result("")));
        [Static]
        [Export("array")]
        TMBExpression Array();

        // +(TMBExpression * _Nonnull)array:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("array:")]
        TMBExpression Array(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)asin __attribute__((warn_unused_result("")));
        [Static]
        [Export("asin")]
        TMBExpression Asin();

        // +(TMBExpression * _Nonnull)asin:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("asin:")]
        TMBExpression Asin(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)at __attribute__((warn_unused_result("")));
        [Static]
        [Export("at")]
        TMBExpression At();

        // +(TMBExpression * _Nonnull)at:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("at:")]
        TMBExpression At(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)atan __attribute__((warn_unused_result("")));
        [Static]
        [Export("atan")]
        TMBExpression Atan();

        // +(TMBExpression * _Nonnull)atan:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("atan:")]
        TMBExpression Atan(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)boolean __attribute__((warn_unused_result("")));
        [Static]
        [Export("boolean")]
        TMBExpression Boolean();

        // +(TMBExpression * _Nonnull)boolean:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("boolean:")]
        TMBExpression Boolean(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)switchCase __attribute__((warn_unused_result("")));
        [Static]
        [Export("switchCase")]
        TMBExpression SwitchCase();

        // +(TMBExpression * _Nonnull)switchCase:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("switchCase:")]
        TMBExpression SwitchCase(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)ceil __attribute__((warn_unused_result("")));
        [Static]
        [Export("ceil")]
        TMBExpression Ceil();

        // +(TMBExpression * _Nonnull)ceil:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("ceil:")]
        TMBExpression Ceil(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)coalesce __attribute__((warn_unused_result("")));
        [Static]
        [Export("coalesce")]
        TMBExpression Coalesce();

        // +(TMBExpression * _Nonnull)coalesce:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("coalesce:")]
        TMBExpression Coalesce(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)collator __attribute__((warn_unused_result("")));
        [Static]
        [Export("collator")]
        TMBExpression Collator();

        // +(TMBExpression * _Nonnull)collator:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("collator:")]
        TMBExpression Collator(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)concat __attribute__((warn_unused_result("")));
        [Static]
        [Export("concat")]
        TMBExpression Concat();

        // +(TMBExpression * _Nonnull)concat:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("concat:")]
        TMBExpression Concat(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)cos __attribute__((warn_unused_result("")));
        [Static]
        [Export("cos")]
        TMBExpression Cos();

        // +(TMBExpression * _Nonnull)cos:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("cos:")]
        TMBExpression Cos(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)distance __attribute__((warn_unused_result("")));
        [Static]
        [Export("distance")]
        TMBExpression Distance();

        // +(TMBExpression * _Nonnull)distance:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("distance:")]
        TMBExpression Distance(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)distanceFromCenter __attribute__((warn_unused_result("")));
        [Static]
        [Export("distanceFromCenter")]
        TMBExpression DistanceFromCenter();

        // +(TMBExpression * _Nonnull)distanceFromCenter:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("distanceFromCenter:")]
        TMBExpression DistanceFromCenter(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)downcase __attribute__((warn_unused_result("")));
        [Static]
        [Export("downcase")]
        TMBExpression Downcase();

        // +(TMBExpression * _Nonnull)downcase:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("downcase:")]
        TMBExpression Downcase(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)e __attribute__((warn_unused_result("")));
        [Static]
        [Export("e")]
        TMBExpression E();

        // +(TMBExpression * _Nonnull)e:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("e:")]
        TMBExpression E(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)featureState __attribute__((warn_unused_result("")));
        [Static]
        [Export("featureState")]
        TMBExpression FeatureState();

        // +(TMBExpression * _Nonnull)featureState:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("featureState:")]
        TMBExpression FeatureState(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)floor __attribute__((warn_unused_result("")));
        [Static]
        [Export("floor")]
        TMBExpression Floor();

        // +(TMBExpression * _Nonnull)floor:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("floor:")]
        TMBExpression Floor(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)format __attribute__((warn_unused_result("")));
        [Static]
        [Export("format")]
        TMBExpression Format();

        // +(TMBExpression * _Nonnull)format:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("format:")]
        TMBExpression Format(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)geometryType __attribute__((warn_unused_result("")));
        [Static]
        [Export("geometryType")]
        TMBExpression GeometryType();

        // +(TMBExpression * _Nonnull)geometryType:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("geometryType:")]
        TMBExpression GeometryType(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)get __attribute__((warn_unused_result("")));
        [Static]
        [Export("get")]
        TMBExpression Get();

        // +(TMBExpression * _Nonnull)get:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("get:")]
        TMBExpression Get(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)has __attribute__((warn_unused_result("")));
        [Static]
        [Export("has")]
        TMBExpression Has();

        // +(TMBExpression * _Nonnull)has:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("has:")]
        TMBExpression Has(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)heatmapDensity __attribute__((warn_unused_result("")));
        [Static]
        [Export("heatmapDensity")]
        TMBExpression HeatmapDensity();

        // +(TMBExpression * _Nonnull)heatmapDensity:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("heatmapDensity:")]
        TMBExpression HeatmapDensity(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)id __attribute__((warn_unused_result("")));
        [Static]
        [Export("id")]
        TMBExpression Id();

        // +(TMBExpression * _Nonnull)id:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("id:")]
        TMBExpression Id(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)image __attribute__((warn_unused_result("")));
        [Static]
        [Export("image")]
        TMBExpression Image();

        // +(TMBExpression * _Nonnull)image:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("image:")]
        TMBExpression Image(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)inExpression __attribute__((warn_unused_result("")));
        [Static]
        [Export("inExpression")]
        TMBExpression InExpression();

        // +(TMBExpression * _Nonnull)inExpression:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("inExpression:")]
        TMBExpression InExpression(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)indexOf __attribute__((warn_unused_result("")));
        [Static]
        [Export("indexOf")]
        TMBExpression IndexOf();

        // +(TMBExpression * _Nonnull)indexOf:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("indexOf:")]
        TMBExpression IndexOf(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)interpolate __attribute__((warn_unused_result("")));
        [Static]
        [Export("interpolate")]
        TMBExpression Interpolate();

        // +(TMBExpression * _Nonnull)interpolate:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("interpolate:")]
        TMBExpression Interpolate(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)isSupportedScript __attribute__((warn_unused_result("")));
        [Static]
        [Export("isSupportedScript")]
        TMBExpression IsSupportedScript();

        // +(TMBExpression * _Nonnull)isSupportedScript:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("isSupportedScript:")]
        TMBExpression IsSupportedScript(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)length __attribute__((warn_unused_result("")));
        [Static]
        [Export("length")]
        TMBExpression Length();

        // +(TMBExpression * _Nonnull)length:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("length:")]
        TMBExpression Length(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)letExpression __attribute__((warn_unused_result("")));
        [Static]
        [Export("letExpression")]
        TMBExpression LetExpression();

        // +(TMBExpression * _Nonnull)letExpression:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("letExpression:")]
        TMBExpression LetExpression(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)lineProgress __attribute__((warn_unused_result("")));
        [Static]
        [Export("lineProgress")]
        TMBExpression LineProgress();

        // +(TMBExpression * _Nonnull)lineProgress:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("lineProgress:")]
        TMBExpression LineProgress(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)literal __attribute__((warn_unused_result("")));
        [Static]
        [Export("literal")]
        TMBExpression Literal();

        // +(TMBExpression * _Nonnull)literal:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("literal:")]
        TMBExpression Literal(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)ln __attribute__((warn_unused_result("")));
        [Static]
        [Export("ln")]
        TMBExpression Ln();

        // +(TMBExpression * _Nonnull)ln:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("ln:")]
        TMBExpression Ln(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)ln2 __attribute__((warn_unused_result("")));
        [Static]
        [Export("ln2")]
        TMBExpression Ln2();

        // +(TMBExpression * _Nonnull)ln2:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("ln2:")]
        TMBExpression Ln2(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)log10 __attribute__((warn_unused_result("")));
        [Static]
        [Export("log10")]
        TMBExpression Log10();

        // +(TMBExpression * _Nonnull)log10:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("log10:")]
        TMBExpression Log10(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)log2 __attribute__((warn_unused_result("")));
        [Static]
        [Export("log2")]
        TMBExpression Log2();

        // +(TMBExpression * _Nonnull)log2:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("log2:")]
        TMBExpression Log2(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)match __attribute__((warn_unused_result("")));
        [Static]
        [Export("match")]
        TMBExpression Match();

        // +(TMBExpression * _Nonnull)match:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("match:")]
        TMBExpression Match(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)max __attribute__((warn_unused_result("")));
        [Static]
        [Export("max")]
        TMBExpression Max();

        // +(TMBExpression * _Nonnull)max:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("max:")]
        TMBExpression Max(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)min __attribute__((warn_unused_result("")));
        [Static]
        [Export("min")]
        TMBExpression Min();

        // +(TMBExpression * _Nonnull)min:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("min:")]
        TMBExpression Min(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)number __attribute__((warn_unused_result("")));
        [Static]
        [Export("number")]
        TMBExpression Number();

        // +(TMBExpression * _Nonnull)number:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("number:")]
        TMBExpression Number(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)numberFormat __attribute__((warn_unused_result("")));
        [Static]
        [Export("numberFormat")]
        TMBExpression NumberFormat();

        // +(TMBExpression * _Nonnull)numberFormat:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("numberFormat:")]
        TMBExpression NumberFormat(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)objectExpression __attribute__((warn_unused_result("")));
        [Static]
        [Export("objectExpression")]
        TMBExpression ObjectExpression();

        // +(TMBExpression * _Nonnull)objectExpression:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("objectExpression:")]
        TMBExpression ObjectExpression(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)pi __attribute__((warn_unused_result("")));
        [Static]
        [Export("pi")]
        TMBExpression Pi();

        // +(TMBExpression * _Nonnull)pi:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("pi:")]
        TMBExpression Pi(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)pitch __attribute__((warn_unused_result("")));
        [Static]
        [Export("pitch")]
        TMBExpression Pitch();

        // +(TMBExpression * _Nonnull)pitch:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("pitch:")]
        TMBExpression Pitch(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)properties __attribute__((warn_unused_result("")));
        [Static]
        [Export("properties")]
        TMBExpression Properties();

        // +(TMBExpression * _Nonnull)properties:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("properties:")]
        TMBExpression Properties(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)resolvedLocale __attribute__((warn_unused_result("")));
        [Static]
        [Export("resolvedLocale")]
        TMBExpression ResolvedLocale();

        // +(TMBExpression * _Nonnull)resolvedLocale:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("resolvedLocale:")]
        TMBExpression ResolvedLocale(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)rgb __attribute__((warn_unused_result("")));
        [Static]
        [Export("rgb")]
        TMBExpression Rgb();

        // +(TMBExpression * _Nonnull)rgb:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("rgb:")]
        TMBExpression Rgb(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)rgba __attribute__((warn_unused_result("")));
        [Static]
        [Export("rgba")]
        TMBExpression Rgba();

        // +(TMBExpression * _Nonnull)rgba:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("rgba:")]
        TMBExpression Rgba(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)round __attribute__((warn_unused_result("")));
        [Static]
        [Export("round")]
        TMBExpression Round();

        // +(TMBExpression * _Nonnull)round:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("round:")]
        TMBExpression Round(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)sin __attribute__((warn_unused_result("")));
        [Static]
        [Export("sin")]
        TMBExpression Sin();

        // +(TMBExpression * _Nonnull)sin:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("sin:")]
        TMBExpression Sin(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)skyRadialProgress __attribute__((warn_unused_result("")));
        [Static]
        [Export("skyRadialProgress")]
        TMBExpression SkyRadialProgress();

        // +(TMBExpression * _Nonnull)skyRadialProgress:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("skyRadialProgress:")]
        TMBExpression SkyRadialProgress(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)slice __attribute__((warn_unused_result("")));
        [Static]
        [Export("slice")]
        TMBExpression Slice();

        // +(TMBExpression * _Nonnull)slice:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("slice:")]
        TMBExpression Slice(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)sqrt __attribute__((warn_unused_result("")));
        [Static]
        [Export("sqrt")]
        TMBExpression Sqrt();

        // +(TMBExpression * _Nonnull)sqrt:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("sqrt:")]
        TMBExpression Sqrt(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)step __attribute__((warn_unused_result("")));
        [Static]
        [Export("step")]
        TMBExpression Step();

        // +(TMBExpression * _Nonnull)step:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("step:")]
        TMBExpression Step(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)string __attribute__((warn_unused_result("")));
        [Static]
        [Export("string")]
        TMBExpression String();

        // +(TMBExpression * _Nonnull)string:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("string:")]
        TMBExpression String(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)tan __attribute__((warn_unused_result("")));
        [Static]
        [Export("tan")]
        TMBExpression Tan();

        // +(TMBExpression * _Nonnull)tan:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("tan:")]
        TMBExpression Tan(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)toBoolean __attribute__((warn_unused_result("")));
        [Static]
        [Export("toBoolean")]
        TMBExpression ToBoolean();

        // +(TMBExpression * _Nonnull)toBoolean:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("toBoolean:")]
        TMBExpression ToBoolean(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)toColor __attribute__((warn_unused_result("")));
        [Static]
        [Export("toColor")]
        TMBExpression ToColor();

        // +(TMBExpression * _Nonnull)toColor:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("toColor:")]
        TMBExpression ToColor(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)toNumber __attribute__((warn_unused_result("")));
        [Static]
        [Export("toNumber")]
        TMBExpression ToNumber();

        // +(TMBExpression * _Nonnull)toNumber:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("toNumber:")]
        TMBExpression ToNumber(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)toRgba __attribute__((warn_unused_result("")));
        [Static]
        [Export("toRgba")]
        TMBExpression ToRgba();

        // +(TMBExpression * _Nonnull)toRgba:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("toRgba:")]
        TMBExpression ToRgba(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)toString __attribute__((warn_unused_result("")));
        [Static]
        [Export("toString")]
        TMBExpression ToString();

        // +(TMBExpression * _Nonnull)toString:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("toString:")]
        TMBExpression ToString(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)typeofExpression __attribute__((warn_unused_result("")));
        [Static]
        [Export("typeofExpression")]
        TMBExpression TypeofExpression();

        // +(TMBExpression * _Nonnull)typeofExpression:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("typeofExpression:")]
        TMBExpression TypeofExpression(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)upcase __attribute__((warn_unused_result("")));
        [Static]
        [Export("upcase")]
        TMBExpression Upcase();

        // +(TMBExpression * _Nonnull)upcase:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("upcase:")]
        TMBExpression Upcase(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)varExpression __attribute__((warn_unused_result("")));
        [Static]
        [Export("varExpression")]
        TMBExpression VarExpression();

        // +(TMBExpression * _Nonnull)varExpression:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("varExpression:")]
        TMBExpression VarExpression(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)within __attribute__((warn_unused_result("")));
        [Static]
        [Export("within")]
        TMBExpression Within();

        // +(TMBExpression * _Nonnull)within:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("within:")]
        TMBExpression Within(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)zoom __attribute__((warn_unused_result("")));
        [Static]
        [Export("zoom")]
        TMBExpression Zoom();

        // +(TMBExpression * _Nonnull)zoom:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("zoom:")]
        TMBExpression Zoom(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)linear __attribute__((warn_unused_result("")));
        [Static]
        [Export("linear")]
        TMBExpression Linear();

        // +(TMBExpression * _Nonnull)linear:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("linear:")]
        TMBExpression Linear(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)exponential __attribute__((warn_unused_result("")));
        [Static]
        [Export("exponential")]
        TMBExpression Exponential();

        // +(TMBExpression * _Nonnull)exponential:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("exponential:")]
        TMBExpression Exponential(NSObject[] arguments);

        // +(TMBExpression * _Nonnull)cubicBezier __attribute__((warn_unused_result("")));
        [Static]
        [Export("cubicBezier")]
        TMBExpression CubicBezier();

        // +(TMBExpression * _Nonnull)cubicBezier:(NSArray * _Nonnull)arguments __attribute__((warn_unused_result("")));
        [Static]
        [Export("cubicBezier:")]
        TMBExpression CubicBezier(NSObject[] arguments);
    }

    // @interface TMBExpressionOperator : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC21TMBExpressionOperator")]
    [DisableDefaultCtor]
    interface TMBExpressionOperator
    {
        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull subtract;
        [Static]
        [Export("subtract", ArgumentSemantic.Strong)]
        TMBExpressionOperator Subtract { get; }

        // @property (readonly, getter = not, nonatomic, strong, class) TMBExpressionOperator * _Nonnull not_;
        [Static]
        [Export("not_", ArgumentSemantic.Strong)]
        TMBExpressionOperator Not_ { [Bind("not")] get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull neq;
        [Static]
        [Export("neq", ArgumentSemantic.Strong)]
        TMBExpressionOperator Neq { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull product;
        [Static]
        [Export("product", ArgumentSemantic.Strong)]
        TMBExpressionOperator Product { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull division;
        [Static]
        [Export("division", ArgumentSemantic.Strong)]
        TMBExpressionOperator Division { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull mod;
        [Static]
        [Export("mod", ArgumentSemantic.Strong)]
        TMBExpressionOperator Mod { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull pow;
        [Static]
        [Export("pow", ArgumentSemantic.Strong)]
        TMBExpressionOperator Pow { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull sum;
        [Static]
        [Export("sum", ArgumentSemantic.Strong)]
        TMBExpressionOperator Sum { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull lt;
        [Static]
        [Export("lt", ArgumentSemantic.Strong)]
        TMBExpressionOperator Lt { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull lte;
        [Static]
        [Export("lte", ArgumentSemantic.Strong)]
        TMBExpressionOperator Lte { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull eq;
        [Static]
        [Export("eq", ArgumentSemantic.Strong)]
        TMBExpressionOperator Eq { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull gt;
        [Static]
        [Export("gt", ArgumentSemantic.Strong)]
        TMBExpressionOperator Gt { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull gte;
        [Static]
        [Export("gte", ArgumentSemantic.Strong)]
        TMBExpressionOperator Gte { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull abs;
        [Static]
        [Export("abs", ArgumentSemantic.Strong)]
        TMBExpressionOperator Abs { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull accumulated;
        [Static]
        [Export("accumulated", ArgumentSemantic.Strong)]
        TMBExpressionOperator Accumulated { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull acos;
        [Static]
        [Export("acos", ArgumentSemantic.Strong)]
        TMBExpressionOperator Acos { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull all;
        [Static]
        [Export("all", ArgumentSemantic.Strong)]
        TMBExpressionOperator All { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull any;
        [Static]
        [Export("any", ArgumentSemantic.Strong)]
        TMBExpressionOperator Any { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull array;
        [Static]
        [Export("array", ArgumentSemantic.Strong)]
        TMBExpressionOperator Array { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull asin;
        [Static]
        [Export("asin", ArgumentSemantic.Strong)]
        TMBExpressionOperator Asin { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull at;
        [Static]
        [Export("at", ArgumentSemantic.Strong)]
        TMBExpressionOperator At { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull atan;
        [Static]
        [Export("atan", ArgumentSemantic.Strong)]
        TMBExpressionOperator Atan { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull boolean;
        [Static]
        [Export("boolean", ArgumentSemantic.Strong)]
        TMBExpressionOperator Boolean { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull switchCase;
        [Static]
        [Export("switchCase", ArgumentSemantic.Strong)]
        TMBExpressionOperator SwitchCase { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull ceil;
        [Static]
        [Export("ceil", ArgumentSemantic.Strong)]
        TMBExpressionOperator Ceil { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull coalesce;
        [Static]
        [Export("coalesce", ArgumentSemantic.Strong)]
        TMBExpressionOperator Coalesce { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull collator;
        [Static]
        [Export("collator", ArgumentSemantic.Strong)]
        TMBExpressionOperator Collator { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull concat;
        [Static]
        [Export("concat", ArgumentSemantic.Strong)]
        TMBExpressionOperator Concat { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull config;
        [Static]
        [Export("config", ArgumentSemantic.Strong)]
        TMBExpressionOperator Config { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull cos;
        [Static]
        [Export("cos", ArgumentSemantic.Strong)]
        TMBExpressionOperator Cos { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull distance;
        [Static]
        [Export("distance", ArgumentSemantic.Strong)]
        TMBExpressionOperator Distance { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull distanceFromCenter;
        [Static]
        [Export("distanceFromCenter", ArgumentSemantic.Strong)]
        TMBExpressionOperator DistanceFromCenter { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull downcase;
        [Static]
        [Export("downcase", ArgumentSemantic.Strong)]
        TMBExpressionOperator Downcase { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull e;
        [Static]
        [Export("e", ArgumentSemantic.Strong)]
        TMBExpressionOperator E { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull featureState;
        [Static]
        [Export("featureState", ArgumentSemantic.Strong)]
        TMBExpressionOperator FeatureState { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull floor;
        [Static]
        [Export("floor", ArgumentSemantic.Strong)]
        TMBExpressionOperator Floor { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull format;
        [Static]
        [Export("format", ArgumentSemantic.Strong)]
        TMBExpressionOperator Format { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull geometryType;
        [Static]
        [Export("geometryType", ArgumentSemantic.Strong)]
        TMBExpressionOperator GeometryType { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull get;
        [Static]
        [Export("get", ArgumentSemantic.Strong)]
        TMBExpressionOperator Get { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull has;
        [Static]
        [Export("has", ArgumentSemantic.Strong)]
        TMBExpressionOperator Has { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull heatmapDensity;
        [Static]
        [Export("heatmapDensity", ArgumentSemantic.Strong)]
        TMBExpressionOperator HeatmapDensity { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull hsl;
        [Static]
        [Export("hsl", ArgumentSemantic.Strong)]
        TMBExpressionOperator Hsl { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull hsla;
        [Static]
        [Export("hsla", ArgumentSemantic.Strong)]
        TMBExpressionOperator Hsla { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull id;
        [Static]
        [Export("id", ArgumentSemantic.Strong)]
        TMBExpressionOperator Id { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull image;
        [Static]
        [Export("image", ArgumentSemantic.Strong)]
        TMBExpressionOperator Image { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull inExpression;
        [Static]
        [Export("inExpression", ArgumentSemantic.Strong)]
        TMBExpressionOperator InExpression { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull indexOf;
        [Static]
        [Export("indexOf", ArgumentSemantic.Strong)]
        TMBExpressionOperator IndexOf { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull interpolate;
        [Static]
        [Export("interpolate", ArgumentSemantic.Strong)]
        TMBExpressionOperator Interpolate { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull isSupportedScript;
        [Static]
        [Export("isSupportedScript", ArgumentSemantic.Strong)]
        TMBExpressionOperator IsSupportedScript { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull length;
        [Static]
        [Export("length", ArgumentSemantic.Strong)]
        TMBExpressionOperator Length { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull letExpression;
        [Static]
        [Export("letExpression", ArgumentSemantic.Strong)]
        TMBExpressionOperator LetExpression { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull lineProgress;
        [Static]
        [Export("lineProgress", ArgumentSemantic.Strong)]
        TMBExpressionOperator LineProgress { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull literal;
        [Static]
        [Export("literal", ArgumentSemantic.Strong)]
        TMBExpressionOperator Literal { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull ln;
        [Static]
        [Export("ln", ArgumentSemantic.Strong)]
        TMBExpressionOperator Ln { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull ln2;
        [Static]
        [Export("ln2", ArgumentSemantic.Strong)]
        TMBExpressionOperator Ln2 { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull log10;
        [Static]
        [Export("log10", ArgumentSemantic.Strong)]
        TMBExpressionOperator Log10 { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull log2;
        [Static]
        [Export("log2", ArgumentSemantic.Strong)]
        TMBExpressionOperator Log2 { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull match;
        [Static]
        [Export("match", ArgumentSemantic.Strong)]
        TMBExpressionOperator Match { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull max;
        [Static]
        [Export("max", ArgumentSemantic.Strong)]
        TMBExpressionOperator Max { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull measureLight;
        [Static]
        [Export("measureLight", ArgumentSemantic.Strong)]
        TMBExpressionOperator MeasureLight { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull min;
        [Static]
        [Export("min", ArgumentSemantic.Strong)]
        TMBExpressionOperator Min { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull number;
        [Static]
        [Export("number", ArgumentSemantic.Strong)]
        TMBExpressionOperator Number { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull numberFormat;
        [Static]
        [Export("numberFormat", ArgumentSemantic.Strong)]
        TMBExpressionOperator NumberFormat { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull objectExpression;
        [Static]
        [Export("objectExpression", ArgumentSemantic.Strong)]
        TMBExpressionOperator ObjectExpression { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull pi;
        [Static]
        [Export("pi", ArgumentSemantic.Strong)]
        TMBExpressionOperator Pi { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull pitch;
        [Static]
        [Export("pitch", ArgumentSemantic.Strong)]
        TMBExpressionOperator Pitch { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull properties;
        [Static]
        [Export("properties", ArgumentSemantic.Strong)]
        TMBExpressionOperator Properties { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull random;
        [Static]
        [Export("random", ArgumentSemantic.Strong)]
        TMBExpressionOperator Random { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull rasterValue;
        [Static]
        [Export("rasterValue", ArgumentSemantic.Strong)]
        TMBExpressionOperator RasterValue { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull resolvedLocale;
        [Static]
        [Export("resolvedLocale", ArgumentSemantic.Strong)]
        TMBExpressionOperator ResolvedLocale { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull rgb;
        [Static]
        [Export("rgb", ArgumentSemantic.Strong)]
        TMBExpressionOperator Rgb { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull rgba;
        [Static]
        [Export("rgba", ArgumentSemantic.Strong)]
        TMBExpressionOperator Rgba { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull round;
        [Static]
        [Export("round", ArgumentSemantic.Strong)]
        TMBExpressionOperator Round { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull sin;
        [Static]
        [Export("sin", ArgumentSemantic.Strong)]
        TMBExpressionOperator Sin { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull skyRadialProgress;
        [Static]
        [Export("skyRadialProgress", ArgumentSemantic.Strong)]
        TMBExpressionOperator SkyRadialProgress { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull slice;
        [Static]
        [Export("slice", ArgumentSemantic.Strong)]
        TMBExpressionOperator Slice { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull sqrt;
        [Static]
        [Export("sqrt", ArgumentSemantic.Strong)]
        TMBExpressionOperator Sqrt { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull step;
        [Static]
        [Export("step", ArgumentSemantic.Strong)]
        TMBExpressionOperator Step { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull string;
        [Static]
        [Export("string", ArgumentSemantic.Strong)]
        TMBExpressionOperator String { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull tan;
        [Static]
        [Export("tan", ArgumentSemantic.Strong)]
        TMBExpressionOperator Tan { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull toBoolean;
        [Static]
        [Export("toBoolean", ArgumentSemantic.Strong)]
        TMBExpressionOperator ToBoolean { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull toColor;
        [Static]
        [Export("toColor", ArgumentSemantic.Strong)]
        TMBExpressionOperator ToColor { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull toNumber;
        [Static]
        [Export("toNumber", ArgumentSemantic.Strong)]
        TMBExpressionOperator ToNumber { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull toRgba;
        [Static]
        [Export("toRgba", ArgumentSemantic.Strong)]
        TMBExpressionOperator ToRgba { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull toString;
        [Static]
        [Export("toString", ArgumentSemantic.Strong)]
        TMBExpressionOperator ToString { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull typeofExpression;
        [Static]
        [Export("typeofExpression", ArgumentSemantic.Strong)]
        TMBExpressionOperator TypeofExpression { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull upcase;
        [Static]
        [Export("upcase", ArgumentSemantic.Strong)]
        TMBExpressionOperator Upcase { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull varExpression;
        [Static]
        [Export("varExpression", ArgumentSemantic.Strong)]
        TMBExpressionOperator VarExpression { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull within;
        [Static]
        [Export("within", ArgumentSemantic.Strong)]
        TMBExpressionOperator Within { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull zoom;
        [Static]
        [Export("zoom", ArgumentSemantic.Strong)]
        TMBExpressionOperator Zoom { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull linear;
        [Static]
        [Export("linear", ArgumentSemantic.Strong)]
        TMBExpressionOperator Linear { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull exponential;
        [Static]
        [Export("exponential", ArgumentSemantic.Strong)]
        TMBExpressionOperator Exponential { get; }

        // @property (readonly, nonatomic, strong, class) TMBExpressionOperator * _Nonnull cubicBezier;
        [Static]
        [Export("cubicBezier", ArgumentSemantic.Strong)]
        TMBExpressionOperator CubicBezier { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);
    }

    // @interface TMBExpressionOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC20TMBExpressionOptions")]
    [DisableDefaultCtor]
    interface TMBExpressionOptions
    {
        // @property (readonly, nonatomic) enum TMBExpressionOptionsType type;
        [Export("type")]
        TMBExpressionOptionsType Type { get; }

        // @property (readonly, nonatomic) id _Nonnull options;
        [Export("options")]
        NSObject Options { get; }

        // +(TMBExpressionOptions * _Nonnull)format:(TMBFormatOptions * _Nonnull)options __attribute__((warn_unused_result("")));
        [Static]
        [Export("format:")]
        TMBExpressionOptions Format(TMBFormatOptions options);

        // +(TMBExpressionOptions * _Nonnull)numberFormat:(TMBNumberFormatOptions * _Nonnull)options __attribute__((warn_unused_result("")));
        [Static]
        [Export("numberFormat:")]
        TMBExpressionOptions NumberFormat(TMBNumberFormatOptions options);

        // +(TMBExpressionOptions * _Nonnull)collator:(TMBCollatorOptions * _Nonnull)options __attribute__((warn_unused_result("")));
        [Static]
        [Export("collator:")]
        TMBExpressionOptions Collator(TMBCollatorOptions options);
    }

    // @interface TMBFillExtrusionLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC21TMBFillExtrusionLayer")]
    [DisableDefaultCtor]
    interface TMBFillExtrusionLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBExpression * _Nullable filter;
        [NullAllowed, Export("filter", ArgumentSemantic.Strong)]
        TMBExpression Filter { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable source;
        [NullAllowed, Export("source")]
        string Source { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sourceLayer;
        [NullAllowed, Export("sourceLayer")]
        string SourceLayer { get; set; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionAmbientOcclusionIntensity;
        [NullAllowed, Export("fillExtrusionAmbientOcclusionIntensity", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionAmbientOcclusionIntensity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillExtrusionAmbientOcclusionIntensityTransition;
        [NullAllowed, Export("fillExtrusionAmbientOcclusionIntensityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillExtrusionAmbientOcclusionIntensityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionAmbientOcclusionRadius;
        [NullAllowed, Export("fillExtrusionAmbientOcclusionRadius", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionAmbientOcclusionRadius { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillExtrusionAmbientOcclusionRadiusTransition;
        [NullAllowed, Export("fillExtrusionAmbientOcclusionRadiusTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillExtrusionAmbientOcclusionRadiusTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionBase;
        [NullAllowed, Export("fillExtrusionBase", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionBase { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillExtrusionBaseTransition;
        [NullAllowed, Export("fillExtrusionBaseTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillExtrusionBaseTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionColor;
        [NullAllowed, Export("fillExtrusionColor", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillExtrusionColorTransition;
        [NullAllowed, Export("fillExtrusionColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillExtrusionColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionCutoffFadeRange;
        [NullAllowed, Export("fillExtrusionCutoffFadeRange", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionCutoffFadeRange { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionEmissiveStrength;
        [NullAllowed, Export("fillExtrusionEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionEmissiveStrength { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillExtrusionEmissiveStrengthTransition;
        [NullAllowed, Export("fillExtrusionEmissiveStrengthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillExtrusionEmissiveStrengthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionHeight;
        [NullAllowed, Export("fillExtrusionHeight", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionHeight { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillExtrusionHeightTransition;
        [NullAllowed, Export("fillExtrusionHeightTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillExtrusionHeightTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionOpacity;
        [NullAllowed, Export("fillExtrusionOpacity", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillExtrusionOpacityTransition;
        [NullAllowed, Export("fillExtrusionOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillExtrusionOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionPattern;
        [NullAllowed, Export("fillExtrusionPattern", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionPattern { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionTranslate;
        [NullAllowed, Export("fillExtrusionTranslate", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionTranslate { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillExtrusionTranslateTransition;
        [NullAllowed, Export("fillExtrusionTranslateTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillExtrusionTranslateTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionTranslateAnchor;
        [NullAllowed, Export("fillExtrusionTranslateAnchor", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionTranslateAnchor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillExtrusionVerticalGradient;
        [NullAllowed, Export("fillExtrusionVerticalGradient", ArgumentSemantic.Strong)]
        TMBValue FillExtrusionVerticalGradient { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id source:(NSString * _Nonnull)source __attribute__((objc_designated_initializer));
        [Export("initWithId:source:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, string source);
    }

    // @interface TMBFillExtrusionTranslateAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC31TMBFillExtrusionTranslateAnchor")]
    [DisableDefaultCtor]
    interface TMBFillExtrusionTranslateAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBFillExtrusionTranslateAnchor * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBFillExtrusionTranslateAnchor Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBFillExtrusionTranslateAnchor * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBFillExtrusionTranslateAnchor Viewport { get; }
    }

    // @interface TMBFillLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC12TMBFillLayer")]
    [DisableDefaultCtor]
    interface TMBFillLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBExpression * _Nullable filter;
        [NullAllowed, Export("filter", ArgumentSemantic.Strong)]
        TMBExpression Filter { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable source;
        [NullAllowed, Export("source")]
        string Source { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sourceLayer;
        [NullAllowed, Export("sourceLayer")]
        string SourceLayer { get; set; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillSortKey;
        [NullAllowed, Export("fillSortKey", ArgumentSemantic.Strong)]
        TMBValue FillSortKey { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillAntialias;
        [NullAllowed, Export("fillAntialias", ArgumentSemantic.Strong)]
        TMBValue FillAntialias { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillColor;
        [NullAllowed, Export("fillColor", ArgumentSemantic.Strong)]
        TMBValue FillColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillColorTransition;
        [NullAllowed, Export("fillColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillEmissiveStrength;
        [NullAllowed, Export("fillEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue FillEmissiveStrength { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillEmissiveStrengthTransition;
        [NullAllowed, Export("fillEmissiveStrengthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillEmissiveStrengthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillOpacity;
        [NullAllowed, Export("fillOpacity", ArgumentSemantic.Strong)]
        TMBValue FillOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillOpacityTransition;
        [NullAllowed, Export("fillOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillOutlineColor;
        [NullAllowed, Export("fillOutlineColor", ArgumentSemantic.Strong)]
        TMBValue FillOutlineColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillOutlineColorTransition;
        [NullAllowed, Export("fillOutlineColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillOutlineColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillPattern;
        [NullAllowed, Export("fillPattern", ArgumentSemantic.Strong)]
        TMBValue FillPattern { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillTranslate;
        [NullAllowed, Export("fillTranslate", ArgumentSemantic.Strong)]
        TMBValue FillTranslate { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable fillTranslateTransition;
        [NullAllowed, Export("fillTranslateTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition FillTranslateTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable fillTranslateAnchor;
        [NullAllowed, Export("fillTranslateAnchor", ArgumentSemantic.Strong)]
        TMBValue FillTranslateAnchor { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id source:(NSString * _Nonnull)source __attribute__((objc_designated_initializer));
        [Export("initWithId:source:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, string source);
    }

    // @interface TMBFillTranslateAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBFillTranslateAnchor")]
    [DisableDefaultCtor]
    interface TMBFillTranslateAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBFillTranslateAnchor * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBFillTranslateAnchor Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBFillTranslateAnchor * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBFillTranslateAnchor Viewport { get; }
    }

    // @interface TMBFlatLight : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC12TMBFlatLight")]
    [DisableDefaultCtor]
    interface TMBFlatLight
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLightType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLightType Type { get; }

        // @property (nonatomic, strong) TMBValue * _Nullable anchor;
        [NullAllowed, Export("anchor", ArgumentSemantic.Strong)]
        TMBValue Anchor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable color;
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        TMBValue Color { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable colorTransition;
        [NullAllowed, Export("colorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition ColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable intensity;
        [NullAllowed, Export("intensity", ArgumentSemantic.Strong)]
        TMBValue Intensity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable intensityTransition;
        [NullAllowed, Export("intensityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IntensityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable position;
        [NullAllowed, Export("position", ArgumentSemantic.Strong)]
        TMBValue Position { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable positionTransition;
        [NullAllowed, Export("positionTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition PositionTransition { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBFlyToCameraAnimator : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBFlyToCameraAnimator")]
    [DisableDefaultCtor]
    interface TMBFlyToCameraAnimator
    {
        // @property (readonly, nonatomic, strong) TMBAnimationOwner * _Nonnull owner;
        [Export("owner", ArgumentSemantic.Strong)]
        TMBAnimationOwner Owner { get; }

        // @property (readonly, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        double Duration { get; }

        // @property (readonly, nonatomic) UIViewAnimatingState state;
        [Export("state")]
        UIViewAnimatingState State { get; }

        // -(void)stopAnimation;
        [Export("stopAnimation")]
        void StopAnimation();

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();
    }

    // @interface TMBFormatOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC16TMBFormatOptions")]
    [DisableDefaultCtor]
    interface TMBFormatOptions
    {
        // @property (nonatomic, strong) TMBValue * _Nullable fontScale;
        [NullAllowed, Export("fontScale", ArgumentSemantic.Strong)]
        TMBValue FontScale { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textFont;
        [NullAllowed, Export("textFont", ArgumentSemantic.Strong)]
        TMBValue TextFont { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textColor;
        [NullAllowed, Export("textColor", ArgumentSemantic.Strong)]
        TMBValue TextColor { get; set; }
    }

    // @protocol TMBSource
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface ITMBSource { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC9TMBSource_")]
    [BaseType(typeof(NSObject))]
    interface TMBSource
    {
        // @required @property (readonly, nonatomic, strong) TMBSourceType * _Nonnull type;
        [Abstract]
        [Export("type", ArgumentSemantic.Strong)]
        TMBSourceType Type { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Abstract]
        [Export("id")]
        string Id { get; }
    }

    // @interface TMBGeoJSONSource : NSObject <TMBSource>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC16TMBGeoJSONSource")]
    [DisableDefaultCtor]
    interface TMBGeoJSONSource : TMBSource
    {
        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);

        // @property (readonly, nonatomic, strong) TMBSourceType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBSourceType Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (nonatomic, strong) TMBGeoJSONSourceData * _Nullable data;
        [NullAllowed, Export("data", ArgumentSemantic.Strong)]
        TMBGeoJSONSourceData Data { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxzoom;
        [NullAllowed, Export("maxzoom", ArgumentSemantic.Strong)]
        NSNumber Maxzoom { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable attribution;
        [NullAllowed, Export("attribution")]
        string Attribution { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable buffer;
        [NullAllowed, Export("buffer", ArgumentSemantic.Strong)]
        NSNumber Buffer { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable tolerance;
        [NullAllowed, Export("tolerance", ArgumentSemantic.Strong)]
        NSNumber Tolerance { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable cluster;
        [NullAllowed, Export("cluster", ArgumentSemantic.Strong)]
        NSNumber Cluster { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable clusterRadius;
        [NullAllowed, Export("clusterRadius", ArgumentSemantic.Strong)]
        NSNumber ClusterRadius { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable clusterMaxZoom;
        [NullAllowed, Export("clusterMaxZoom", ArgumentSemantic.Strong)]
        NSNumber ClusterMaxZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable clusterMinPoints;
        [NullAllowed, Export("clusterMinPoints", ArgumentSemantic.Strong)]
        NSNumber ClusterMinPoints { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,TMBExpression *> * _Nullable clusterProperties;
        [NullAllowed, Export("clusterProperties", ArgumentSemantic.Copy)]
        NSDictionary<NSString, TMBExpression> ClusterProperties { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineMetrics;
        [NullAllowed, Export("lineMetrics", ArgumentSemantic.Strong)]
        NSNumber LineMetrics { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable generateId;
        [NullAllowed, Export("generateId", ArgumentSemantic.Strong)]
        NSNumber GenerateId { get; set; }

        // @property (nonatomic, strong) TMBPromoteId * _Nullable promoteId;
        [NullAllowed, Export("promoteId", ArgumentSemantic.Strong)]
        TMBPromoteId PromoteId { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable prefetchZoomDelta;
        [NullAllowed, Export("prefetchZoomDelta", ArgumentSemantic.Strong)]
        NSNumber PrefetchZoomDelta { get; set; }

        // @property (nonatomic, strong) TMBTileCacheBudgetSize * _Nullable tileCacheBudget;
        [NullAllowed, Export("tileCacheBudget", ArgumentSemantic.Strong)]
        TMBTileCacheBudgetSize TileCacheBudget { get; set; }
    }

    // @interface TMBGeoJSONSourceData : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC20TMBGeoJSONSourceData")]
    [DisableDefaultCtor]
    interface TMBGeoJSONSourceData
    {
        // @property (readonly, nonatomic) enum TMBGeoJSONSourceType type;
        [Export("type")]
        TMBGeoJSONSourceType Type { get; }

        // + (TMBGeoJSONSourceData * _Nonnull)url:(NSURL * _Nonnull)url SWIFT_WARN_UNUSED_RESULT;
        [Static]
        [Export("url:")]
        TMBGeoJSONSourceData FromUrl(NSUrl url);

        //+ (TMBGeoJSONSourceData * _Nonnull)string:(NSString * _Nonnull)string SWIFT_WARN_UNUSED_RESULT;
        [Static]
        [Export("string:")]
        TMBGeoJSONSourceData FromString(string @string);

        // + (TMBGeoJSONSourceData * _Nonnull)feature:(MBXFeature * _Nonnull)feature SWIFT_WARN_UNUSED_RESULT;
        [Static]
        [Export("feature:")]
        TMBGeoJSONSourceData FromFeature(MBXFeature feature);

        // + (TMBGeoJSONSourceData * _Nonnull)featureCollection:(NSArray<MBXFeature *> * _Nonnull)features SWIFT_WARN_UNUSED_RESULT;
        [Static]
        [Export("featureCollection:")]
        TMBGeoJSONSourceData FromFeatureCollection(MBXFeature[] features);

        // + (TMBGeoJSONSourceData * _Nonnull)geometry:(MBXGeometry * _Nonnull)geometry SWIFT_WARN_UNUSED_RESULT;
        [Static]
        [Export("geometry:")]
        TMBGeoJSONSourceData FromGeometry(MBXGeometry geometry);
    }

    // @interface TMBGestureManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC17TMBGestureManager")]
    [DisableDefaultCtor]
    interface TMBGestureManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        TMBGestureManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<TMBGestureManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, strong) TMBGestureOptions * _Nonnull gestureOptions;
        [Export("gestureOptions", ArgumentSemantic.Strong)]
        TMBGestureOptions GestureOptions { get; set; }

        // @property (readonly, nonatomic, strong) UIGestureRecognizer * _Nonnull panGestureRecognizer;
        [Export("panGestureRecognizer", ArgumentSemantic.Strong)]
        UIGestureRecognizer PanGestureRecognizer { get; }

        // @property (readonly, nonatomic, strong) UIGestureRecognizer * _Nonnull pinchGestureRecognizer;
        [Export("pinchGestureRecognizer", ArgumentSemantic.Strong)]
        UIGestureRecognizer PinchGestureRecognizer { get; }

        // @property (readonly, nonatomic, strong) UIGestureRecognizer * _Nonnull rotateGestureRecognizer;
        [Export("rotateGestureRecognizer", ArgumentSemantic.Strong)]
        UIGestureRecognizer RotateGestureRecognizer { get; }

        // @property (readonly, nonatomic, strong) UIGestureRecognizer * _Nonnull pitchGestureRecognizer;
        [Export("pitchGestureRecognizer", ArgumentSemantic.Strong)]
        UIGestureRecognizer PitchGestureRecognizer { get; }

        // @property (readonly, nonatomic, strong) UIGestureRecognizer * _Nonnull doubleTapToZoomInGestureRecognizer;
        [Export("doubleTapToZoomInGestureRecognizer", ArgumentSemantic.Strong)]
        UIGestureRecognizer DoubleTapToZoomInGestureRecognizer { get; }

        // @property (readonly, nonatomic, strong) UIGestureRecognizer * _Nonnull doubleTouchToZoomOutGestureRecognizer;
        [Export("doubleTouchToZoomOutGestureRecognizer", ArgumentSemantic.Strong)]
        UIGestureRecognizer DoubleTouchToZoomOutGestureRecognizer { get; }

        // @property (readonly, nonatomic, strong) UIGestureRecognizer * _Nonnull quickZoomGestureRecognizer;
        [Export("quickZoomGestureRecognizer", ArgumentSemantic.Strong)]
        UIGestureRecognizer QuickZoomGestureRecognizer { get; }

        // @property (readonly, nonatomic, strong) UIGestureRecognizer * _Nonnull singleTapGestureRecognizer;
        [Export("singleTapGestureRecognizer", ArgumentSemantic.Strong)]
        UIGestureRecognizer SingleTapGestureRecognizer { get; }
    }

    partial interface ITMBGestureManagerDelegate { }

    // @protocol TMBGestureManagerDelegate
    [Model, Protocol(Name = "_TtP13MapboxMapObjC25TMBGestureManagerDelegate_")]
    [BaseType(typeof(NSObject))]
    interface TMBGestureManagerDelegate
    {
        // @required -(void)gestureManagerWithDidBegin:(enum TMBGestureType)gestureType;
        [Abstract]
        [Export("gestureManagerWithDidBegin:")]
        void GestureManagerWithDidBegin(TMBGestureType gestureType);

        // @required -(void)gestureManagerWithDidEnd:(enum TMBGestureType)gestureType willAnimate:(BOOL)willAnimate;
        [Abstract]
        [Export("gestureManagerWithDidEnd:willAnimate:")]
        void GestureManagerWithDidEnd(TMBGestureType gestureType, bool willAnimate);

        // @required -(void)gestureManagerWithDidEndAnimatingFor:(enum TMBGestureType)gestureType;
        [Abstract]
        [Export("gestureManagerWithDidEndAnimatingFor:")]
        void GestureManagerWithDidEndAnimatingFor(TMBGestureType gestureType);
    }

    // @interface TMBGestureOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC17TMBGestureOptions")]
    [DisableDefaultCtor]
    interface TMBGestureOptions
    {
        // @property (nonatomic) BOOL panEnabled;
        [Export("panEnabled")]
        bool PanEnabled { get; set; }

        // @property (nonatomic) BOOL pinchEnabled;
        [Export("pinchEnabled")]
        bool PinchEnabled { get; set; }

        // @property (nonatomic) BOOL rotateEnabled;
        [Export("rotateEnabled")]
        bool RotateEnabled { get; set; }

        // @property (nonatomic) BOOL simultaneousRotateAndPinchZoomEnabled;
        [Export("simultaneousRotateAndPinchZoomEnabled")]
        bool SimultaneousRotateAndPinchZoomEnabled { get; set; }

        // @property (nonatomic) BOOL pinchZoomEnabled;
        [Export("pinchZoomEnabled")]
        bool PinchZoomEnabled { get; set; }

        // @property (nonatomic) BOOL pinchPanEnabled;
        [Export("pinchPanEnabled")]
        bool PinchPanEnabled { get; set; }

        // @property (nonatomic) BOOL pitchEnabled;
        [Export("pitchEnabled")]
        bool PitchEnabled { get; set; }

        // @property (nonatomic) BOOL doubleTapToZoomInEnabled;
        [Export("doubleTapToZoomInEnabled")]
        bool DoubleTapToZoomInEnabled { get; set; }

        // @property (nonatomic) BOOL doubleTouchToZoomOutEnabled;
        [Export("doubleTouchToZoomOutEnabled")]
        bool DoubleTouchToZoomOutEnabled { get; set; }

        // @property (nonatomic) BOOL quickZoomEnabled;
        [Export("quickZoomEnabled")]
        bool QuickZoomEnabled { get; set; }

        // @property (nonatomic) enum TMBPanMode panMode;
        [Export("panMode", ArgumentSemantic.Assign)]
        TMBPanMode PanMode { get; set; }

        // @property (nonatomic) CGFloat panDecelerationFactor;
        [Export("panDecelerationFactor")]
        nfloat PanDecelerationFactor { get; set; }

        // @property (nonatomic) CGPoint focalPoint;
        [NullAllowed, Export("focalPoint", ArgumentSemantic.Strong)]
        NSValue FocalPoint { get; set; }

        // -(instancetype _Nonnull)initWithPanEnabled:(BOOL)panEnabled pinchEnabled:(BOOL)pinchEnabled rotateEnabled:(BOOL)rotateEnabled simultaneousRotateAndPinchZoomEnabled:(BOOL)simultaneousRotateAndPinchZoomEnabled pinchZoomEnabled:(BOOL)pinchZoomEnabled pinchPanEnabled:(BOOL)pinchPanEnabled pitchEnabled:(BOOL)pitchEnabled doubleTapToZoomInEnabled:(BOOL)doubleTapToZoomInEnabled doubleTouchToZoomOutEnabled:(BOOL)doubleTouchToZoomOutEnabled quickZoomEnabled:(BOOL)quickZoomEnabled panMode:(enum TMBPanMode)panMode panDecelerationFactor:(CGFloat)panDecelerationFactor focalPoint:(CGPoint)focalPoint __attribute__((objc_designated_initializer));
        [Export("initWithPanEnabled:pinchEnabled:rotateEnabled:simultaneousRotateAndPinchZoomEnabled:pinchZoomEnabled:pinchPanEnabled:pitchEnabled:doubleTapToZoomInEnabled:doubleTouchToZoomOutEnabled:quickZoomEnabled:panMode:panDecelerationFactor:focalPoint:")]
        [DesignatedInitializer]
        NativeHandle Constructor(bool panEnabled, bool pinchEnabled, bool rotateEnabled, bool simultaneousRotateAndPinchZoomEnabled, bool pinchZoomEnabled, bool pinchPanEnabled, bool pitchEnabled, bool doubleTapToZoomInEnabled, bool doubleTouchToZoomOutEnabled, bool quickZoomEnabled, TMBPanMode panMode, nfloat panDecelerationFactor, [NullAllowed] NSValue focalPoint);
    }

    // @interface TMBHeading : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC10TMBHeading")]
    [DisableDefaultCtor]
    interface TMBHeading
    {
        // @property (nonatomic) CLLocationDirection direction;
        [Export("direction")]
        double Direction { get; set; }

        // @property (nonatomic) CLLocationDirection accuracy;
        [Export("accuracy")]
        double Accuracy { get; set; }

        // @property (copy, nonatomic) NSDate * _Nonnull timestamp;
        [Export("timestamp", ArgumentSemantic.Copy)]
        NSDate Timestamp { get; set; }

        // -(instancetype _Nonnull)initWithDirection:(CLLocationDirection)direction accuracy:(CLLocationDirection)accuracy timestamp:(NSDate * _Nonnull)timestamp __attribute__((objc_designated_initializer));
        [Export("initWithDirection:accuracy:timestamp:")]
        [DesignatedInitializer]
        NativeHandle Constructor(double direction, double accuracy, NSDate timestamp);

        // -(instancetype _Nonnull)initFrom:(CLHeading * _Nonnull)clHeading;
        [Export("initFrom:")]
        NativeHandle Constructor(CLHeading clHeading);
    }

    // @protocol TMBHeadingObserver
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface ITMBHeadingObserver { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC18TMBHeadingObserver_")]
    [BaseType(typeof(NSObject))]
    interface TMBHeadingObserver
    {
        // @required -(void)onHeadingUpdate:(TMBHeading * _Nonnull)heading;
        [Abstract]
        [Export("onHeadingUpdate:")]
        void OnHeadingUpdate(TMBHeading heading);
    }

    // @protocol TMBHeadingProvider
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface ITMBHeadingProvider { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC18TMBHeadingProvider_")]
    [BaseType(typeof(NSObject))]
    interface TMBHeadingProvider
    {
        // @required @property (readonly, nonatomic, strong) TMBHeading * _Nullable latestHeading;
        [Abstract]
        [NullAllowed, Export("latestHeading", ArgumentSemantic.Strong)]
        TMBHeading LatestHeading { get; }

        // @required -(void)addWithHeadingObserver:(id<TMBHeadingObserver> _Nonnull)headingObserver;
        [Abstract]
        [Export("addWithHeadingObserver:")]
        void AddWithHeadingObserver(ITMBHeadingObserver headingObserver);

        // @required -(void)removeWithHeadingObserver:(id<TMBHeadingObserver> _Nonnull)headingObserver;
        [Abstract]
        [Export("removeWithHeadingObserver:")]
        void RemoveWithHeadingObserver(ITMBHeadingObserver headingObserver);
    }

    // @interface TMBHeatmapLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC15TMBHeatmapLayer")]
    [DisableDefaultCtor]
    interface TMBHeatmapLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBExpression * _Nullable filter;
        [NullAllowed, Export("filter", ArgumentSemantic.Strong)]
        TMBExpression Filter { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable source;
        [NullAllowed, Export("source")]
        string Source { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sourceLayer;
        [NullAllowed, Export("sourceLayer")]
        string SourceLayer { get; set; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable heatmapColor;
        [NullAllowed, Export("heatmapColor", ArgumentSemantic.Strong)]
        TMBValue HeatmapColor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable heatmapIntensity;
        [NullAllowed, Export("heatmapIntensity", ArgumentSemantic.Strong)]
        TMBValue HeatmapIntensity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable heatmapIntensityTransition;
        [NullAllowed, Export("heatmapIntensityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HeatmapIntensityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable heatmapOpacity;
        [NullAllowed, Export("heatmapOpacity", ArgumentSemantic.Strong)]
        TMBValue HeatmapOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable heatmapOpacityTransition;
        [NullAllowed, Export("heatmapOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HeatmapOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable heatmapRadius;
        [NullAllowed, Export("heatmapRadius", ArgumentSemantic.Strong)]
        TMBValue HeatmapRadius { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable heatmapRadiusTransition;
        [NullAllowed, Export("heatmapRadiusTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HeatmapRadiusTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable heatmapWeight;
        [NullAllowed, Export("heatmapWeight", ArgumentSemantic.Strong)]
        TMBValue HeatmapWeight { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id source:(NSString * _Nonnull)source __attribute__((objc_designated_initializer));
        [Export("initWithId:source:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, string source);
    }

    // @interface TMBHillshadeIlluminationAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC30TMBHillshadeIlluminationAnchor")]
    [DisableDefaultCtor]
    interface TMBHillshadeIlluminationAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBHillshadeIlluminationAnchor * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBHillshadeIlluminationAnchor Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBHillshadeIlluminationAnchor * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBHillshadeIlluminationAnchor Viewport { get; }
    }

    // @interface TMBHillshadeLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC17TMBHillshadeLayer")]
    [DisableDefaultCtor]
    interface TMBHillshadeLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBExpression * _Nullable filter;
        [NullAllowed, Export("filter", ArgumentSemantic.Strong)]
        TMBExpression Filter { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable source;
        [NullAllowed, Export("source")]
        string Source { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sourceLayer;
        [NullAllowed, Export("sourceLayer")]
        string SourceLayer { get; set; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable hillshadeAccentColor;
        [NullAllowed, Export("hillshadeAccentColor", ArgumentSemantic.Strong)]
        TMBValue HillshadeAccentColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable hillshadeAccentColorTransition;
        [NullAllowed, Export("hillshadeAccentColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HillshadeAccentColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable hillshadeExaggeration;
        [NullAllowed, Export("hillshadeExaggeration", ArgumentSemantic.Strong)]
        TMBValue HillshadeExaggeration { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable hillshadeExaggerationTransition;
        [NullAllowed, Export("hillshadeExaggerationTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HillshadeExaggerationTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable hillshadeHighlightColor;
        [NullAllowed, Export("hillshadeHighlightColor", ArgumentSemantic.Strong)]
        TMBValue HillshadeHighlightColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable hillshadeHighlightColorTransition;
        [NullAllowed, Export("hillshadeHighlightColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HillshadeHighlightColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable hillshadeEmissiveStrength;
        [NullAllowed, Export("hillshadeEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue HillshadeEmissiveStrength { get; set; }
        
        // @property (nonatomic, strong) TMBStyleTransition * _Nullable hillshadeEmissiveStrengthTransition;
        [NullAllowed, Export("hillshadeEmissiveStrengthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HillshadeEmissiveStrengthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable hillshadeIlluminationAnchor;
        [NullAllowed, Export("hillshadeIlluminationAnchor", ArgumentSemantic.Strong)]
        TMBValue HillshadeIlluminationAnchor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable hillshadeIlluminationDirection;
        [NullAllowed, Export("hillshadeIlluminationDirection", ArgumentSemantic.Strong)]
        TMBValue HillshadeIlluminationDirection { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable hillshadeShadowColor;
        [NullAllowed, Export("hillshadeShadowColor", ArgumentSemantic.Strong)]
        TMBValue HillshadeShadowColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable hillshadeShadowColorTransition;
        [NullAllowed, Export("hillshadeShadowColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition HillshadeShadowColorTransition { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id source:(NSString * _Nonnull)source __attribute__((objc_designated_initializer));
        [Export("initWithId:source:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, string source);
    }

    // @interface TMBIconAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBIconAnchor")]
    [DisableDefaultCtor]
    interface TMBIconAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBIconAnchor * _Nonnull center;
        [Static]
        [Export("center", ArgumentSemantic.Strong)]
        TMBIconAnchor Center { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconAnchor * _Nonnull left;
        [Static]
        [Export("left", ArgumentSemantic.Strong)]
        TMBIconAnchor Left { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconAnchor * _Nonnull right;
        [Static]
        [Export("right", ArgumentSemantic.Strong)]
        TMBIconAnchor Right { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconAnchor * _Nonnull top;
        [Static]
        [Export("top", ArgumentSemantic.Strong)]
        TMBIconAnchor Top { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconAnchor * _Nonnull bottom;
        [Static]
        [Export("bottom", ArgumentSemantic.Strong)]
        TMBIconAnchor Bottom { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconAnchor * _Nonnull topLeft;
        [Static]
        [Export("topLeft", ArgumentSemantic.Strong)]
        TMBIconAnchor TopLeft { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconAnchor * _Nonnull topRight;
        [Static]
        [Export("topRight", ArgumentSemantic.Strong)]
        TMBIconAnchor TopRight { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconAnchor * _Nonnull bottomLeft;
        [Static]
        [Export("bottomLeft", ArgumentSemantic.Strong)]
        TMBIconAnchor BottomLeft { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconAnchor * _Nonnull bottomRight;
        [Static]
        [Export("bottomRight", ArgumentSemantic.Strong)]
        TMBIconAnchor BottomRight { get; }
    }

    // @interface TMBIconPitchAlignment : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC21TMBIconPitchAlignment")]
    [DisableDefaultCtor]
    interface TMBIconPitchAlignment
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBIconPitchAlignment * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBIconPitchAlignment Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconPitchAlignment * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBIconPitchAlignment Viewport { get; }

        // @property (readonly, getter = auto, nonatomic, strong, class) TMBIconPitchAlignment * _Nonnull auto_;
        [Static]
        [Export("auto_", ArgumentSemantic.Strong)]
        TMBIconPitchAlignment Auto_ { [Bind("auto")] get; }
    }

    // @interface TMBIconRotationAlignment : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC24TMBIconRotationAlignment")]
    [DisableDefaultCtor]
    interface TMBIconRotationAlignment
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBIconRotationAlignment * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBIconRotationAlignment Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconRotationAlignment * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBIconRotationAlignment Viewport { get; }

        // @property (readonly, getter = auto, nonatomic, strong, class) TMBIconRotationAlignment * _Nonnull auto_;
        [Static]
        [Export("auto_", ArgumentSemantic.Strong)]
        TMBIconRotationAlignment Auto_ { [Bind("auto")] get; }
    }

    // @interface TMBIconTextFit : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14TMBIconTextFit")]
    [DisableDefaultCtor]
    interface TMBIconTextFit
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBIconTextFit * _Nonnull none;
        [Static]
        [Export("none", ArgumentSemantic.Strong)]
        TMBIconTextFit None { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconTextFit * _Nonnull width;
        [Static]
        [Export("width", ArgumentSemantic.Strong)]
        TMBIconTextFit Width { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconTextFit * _Nonnull height;
        [Static]
        [Export("height", ArgumentSemantic.Strong)]
        TMBIconTextFit Height { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconTextFit * _Nonnull both;
        [Static]
        [Export("both", ArgumentSemantic.Strong)]
        TMBIconTextFit Both { get; }
    }

    // @interface TMBIconTranslateAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBIconTranslateAnchor")]
    [DisableDefaultCtor]
    interface TMBIconTranslateAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBIconTranslateAnchor * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBIconTranslateAnchor Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBIconTranslateAnchor * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBIconTranslateAnchor Viewport { get; }
    }

    // @interface TMBImageSource : NSObject <TMBSource>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14TMBImageSource")]
    [DisableDefaultCtor]
    interface TMBImageSource : TMBSource
    {
        // @property (readonly, nonatomic, strong) TMBSourceType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBSourceType Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (copy, nonatomic) NSString * _Nullable url;
        [NullAllowed, Export("url")]
        string Url { get; set; }

        // @property (copy, nonatomic) NSArray<NSArray<NSNumber *> *> * _Nullable coordinates;
        [NullAllowed, Export("coordinates", ArgumentSemantic.Copy)]
        NSArray<NSNumber>[] Coordinates { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable prefetchZoomDelta;
        [NullAllowed, Export("prefetchZoomDelta", ArgumentSemantic.Strong)]
        NSNumber PrefetchZoomDelta { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBLayerInfo : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC12TMBLayerInfo")]
    [DisableDefaultCtor]
    interface TMBLayerInfo
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id type:(TMBLayerType * _Nonnull)type __attribute__((objc_designated_initializer));
        [Export("initWithId:type:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, TMBLayerType type);
    }

    // @interface TMBLayerPosition : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC16TMBLayerPosition")]
    [DisableDefaultCtor]
    interface TMBLayerPosition
    {
        // @property (readonly, nonatomic, strong) id _Nonnull arg;
        [Export("arg", ArgumentSemantic.Strong)]
        NSObject Arg { get; }

        // @property (readonly, nonatomic) enum TMBLayerPositionType type;
        [Export("type")]
        TMBLayerPositionType Type { get; }

        // -(instancetype _Nonnull)init:(enum TMBLayerPositionType)type arg:(id _Nonnull)arg __attribute__((objc_designated_initializer));
        [Export("init:arg:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBLayerPositionType type, NSObject arg);

        // +(TMBLayerPosition * _Nonnull)atIndex:(NSInteger)index __attribute__((warn_unused_result("")));
        [Static]
        [Export("atIndex:")]
        TMBLayerPosition AtIndex(nint index);

        // +(TMBLayerPosition * _Nonnull)belowLayerId:(NSString * _Nonnull)layerId __attribute__((warn_unused_result("")));
        [Static]
        [Export("belowLayerId:")]
        TMBLayerPosition BelowLayerId(string layerId);

        // +(TMBLayerPosition * _Nonnull)aboveLayerId:(NSString * _Nonnull)layerId __attribute__((warn_unused_result("")));
        [Static]
        [Export("aboveLayerId:")]
        TMBLayerPosition AboveLayerId(string layerId);

        // +(TMBLayerPosition * _Nonnull)default __attribute__((warn_unused_result("")));
        [Static]
        [Export("default")]
        TMBLayerPosition GetDefault();
    }

    // @interface TMBLayerType : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC12TMBLayerType")]
    [DisableDefaultCtor]
    interface TMBLayerType
    {
        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull fill;
        [Static]
        [Export("fill", ArgumentSemantic.Strong)]
        TMBLayerType Fill { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull line;
        [Static]
        [Export("line", ArgumentSemantic.Strong)]
        TMBLayerType Line { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull symbol;
        [Static]
        [Export("symbol", ArgumentSemantic.Strong)]
        TMBLayerType Symbol { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull circle;
        [Static]
        [Export("circle", ArgumentSemantic.Strong)]
        TMBLayerType Circle { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull heatmap;
        [Static]
        [Export("heatmap", ArgumentSemantic.Strong)]
        TMBLayerType Heatmap { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull clip;
        [Static]
        [Export("clip", ArgumentSemantic.Strong)]
        TMBLayerType Clip { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull fillExtrusion;
        [Static]
        [Export("fillExtrusion", ArgumentSemantic.Strong)]
        TMBLayerType FillExtrusion { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull raster;
        [Static]
        [Export("raster", ArgumentSemantic.Strong)]
        TMBLayerType Raster { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull rasterParticle;
        [Static]
        [Export("rasterParticle", ArgumentSemantic.Strong)]
        TMBLayerType RasterParticle { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull hillshade;
        [Static]
        [Export("hillshade", ArgumentSemantic.Strong)]
        TMBLayerType Hillshade { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull background;
        [Static]
        [Export("background", ArgumentSemantic.Strong)]
        TMBLayerType Background { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull locationIndicator;
        [Static]
        [Export("locationIndicator", ArgumentSemantic.Strong)]
        TMBLayerType LocationIndicator { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull sky;
        [Static]
        [Export("sky", ArgumentSemantic.Strong)]
        TMBLayerType Sky { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull slot;
        [Static]
        [Export("slot", ArgumentSemantic.Strong)]
        TMBLayerType Slot { get; }

        // @property (readonly, nonatomic, strong, class) TMBLayerType * _Nonnull model;
        [Static]
        [Export("model", ArgumentSemantic.Strong)]
        TMBLayerType Model { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);
    }

    // @interface TMBLightInfo : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC12TMBLightInfo")]
    [DisableDefaultCtor]
    interface TMBLightInfo
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (nonatomic, strong) TMBLightType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLightType Type { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id type:(TMBLightType * _Nonnull)type __attribute__((objc_designated_initializer));
        [Export("initWithId:type:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, TMBLightType type);
    }

    // @interface TMBLightType : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC12TMBLightType")]
    [DisableDefaultCtor]
    interface TMBLightType
    {
        // @property (readonly, nonatomic, strong, class) TMBLightType * _Nonnull flat;
        [Static]
        [Export("flat", ArgumentSemantic.Strong)]
        TMBLightType Flat { get; }

        // @property (readonly, nonatomic, strong, class) TMBLightType * _Nonnull ambient;
        [Static]
        [Export("ambient", ArgumentSemantic.Strong)]
        TMBLightType Ambient { get; }

        // @property (readonly, nonatomic, strong, class) TMBLightType * _Nonnull directional;
        [Static]
        [Export("directional", ArgumentSemantic.Strong)]
        TMBLightType Directional { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);
    }

    // @interface TMBLineCap : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC10TMBLineCap")]
    [DisableDefaultCtor]
    interface TMBLineCap
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBLineCap * _Nonnull butt;
        [Static]
        [Export("butt", ArgumentSemantic.Strong)]
        TMBLineCap Butt { get; }

        // @property (readonly, nonatomic, strong, class) TMBLineCap * _Nonnull round;
        [Static]
        [Export("round", ArgumentSemantic.Strong)]
        TMBLineCap Round { get; }

        // @property (readonly, nonatomic, strong, class) TMBLineCap * _Nonnull square;
        [Static]
        [Export("square", ArgumentSemantic.Strong)]
        TMBLineCap Square { get; }
    }

    // @interface TMBLineJoin : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC11TMBLineJoin")]
    [DisableDefaultCtor]
    interface TMBLineJoin
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBLineJoin * _Nonnull bevel;
        [Static]
        [Export("bevel", ArgumentSemantic.Strong)]
        TMBLineJoin Bevel { get; }

        // @property (readonly, nonatomic, strong, class) TMBLineJoin * _Nonnull round;
        [Static]
        [Export("round", ArgumentSemantic.Strong)]
        TMBLineJoin Round { get; }

        // @property (readonly, nonatomic, strong, class) TMBLineJoin * _Nonnull miter;
        [Static]
        [Export("miter", ArgumentSemantic.Strong)]
        TMBLineJoin Miter { get; }
    }

    // @interface TMBLineLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC12TMBLineLayer")]
    [DisableDefaultCtor]
    interface TMBLineLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBExpression * _Nullable filter;
        [NullAllowed, Export("filter", ArgumentSemantic.Strong)]
        TMBExpression Filter { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable source;
        [NullAllowed, Export("source")]
        string Source { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sourceLayer;
        [NullAllowed, Export("sourceLayer")]
        string SourceLayer { get; set; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineCap;
        [NullAllowed, Export("lineCap", ArgumentSemantic.Strong)]
        TMBValue LineCap { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineJoin;
        [NullAllowed, Export("lineJoin", ArgumentSemantic.Strong)]
        TMBValue LineJoin { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineMiterLimit;
        [NullAllowed, Export("lineMiterLimit", ArgumentSemantic.Strong)]
        TMBValue LineMiterLimit { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineRoundLimit;
        [NullAllowed, Export("lineRoundLimit", ArgumentSemantic.Strong)]
        TMBValue LineRoundLimit { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineSortKey;
        [NullAllowed, Export("lineSortKey", ArgumentSemantic.Strong)]
        TMBValue LineSortKey { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineBlur;
        [NullAllowed, Export("lineBlur", ArgumentSemantic.Strong)]
        TMBValue LineBlur { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineBlurTransition;
        [NullAllowed, Export("lineBlurTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineBlurTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineBorderColor;
        [NullAllowed, Export("lineBorderColor", ArgumentSemantic.Strong)]
        TMBValue LineBorderColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineBorderColorTransition;
        [NullAllowed, Export("lineBorderColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineBorderColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineBorderWidth;
        [NullAllowed, Export("lineBorderWidth", ArgumentSemantic.Strong)]
        TMBValue LineBorderWidth { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineBorderWidthTransition;
        [NullAllowed, Export("lineBorderWidthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineBorderWidthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineColor;
        [NullAllowed, Export("lineColor", ArgumentSemantic.Strong)]
        TMBValue LineColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineColorTransition;
        [NullAllowed, Export("lineColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineDasharray;
        [NullAllowed, Export("lineDasharray", ArgumentSemantic.Strong)]
        TMBValue LineDasharray { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineDepthOcclusionFactor;
        [NullAllowed, Export("lineDepthOcclusionFactor", ArgumentSemantic.Strong)]
        TMBValue LineDepthOcclusionFactor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineDepthOcclusionFactorTransition;
        [NullAllowed, Export("lineDepthOcclusionFactorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineDepthOcclusionFactorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineEmissiveStrength;
        [NullAllowed, Export("lineEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue LineEmissiveStrength { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineEmissiveStrengthTransition;
        [NullAllowed, Export("lineEmissiveStrengthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineEmissiveStrengthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineGapWidth;
        [NullAllowed, Export("lineGapWidth", ArgumentSemantic.Strong)]
        TMBValue LineGapWidth { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineGapWidthTransition;
        [NullAllowed, Export("lineGapWidthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineGapWidthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineGradient;
        [NullAllowed, Export("lineGradient", ArgumentSemantic.Strong)]
        TMBValue LineGradient { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineOffset;
        [NullAllowed, Export("lineOffset", ArgumentSemantic.Strong)]
        TMBValue LineOffset { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineOffsetTransition;
        [NullAllowed, Export("lineOffsetTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineOffsetTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineOpacity;
        [NullAllowed, Export("lineOpacity", ArgumentSemantic.Strong)]
        TMBValue LineOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineOpacityTransition;
        [NullAllowed, Export("lineOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable linePattern;
        [NullAllowed, Export("linePattern", ArgumentSemantic.Strong)]
        TMBValue LinePattern { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineTranslate;
        [NullAllowed, Export("lineTranslate", ArgumentSemantic.Strong)]
        TMBValue LineTranslate { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineTranslateTransition;
        [NullAllowed, Export("lineTranslateTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineTranslateTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineTranslateAnchor;
        [NullAllowed, Export("lineTranslateAnchor", ArgumentSemantic.Strong)]
        TMBValue LineTranslateAnchor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineTrimOffset;
        [NullAllowed, Export("lineTrimOffset", ArgumentSemantic.Strong)]
        TMBValue LineTrimOffset { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable lineWidth;
        [NullAllowed, Export("lineWidth", ArgumentSemantic.Strong)]
        TMBValue LineWidth { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable lineWidthTransition;
        [NullAllowed, Export("lineWidthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LineWidthTransition { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id source:(NSString * _Nonnull)source __attribute__((objc_designated_initializer));
        [Export("initWithId:source:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, string source);
    }

    // @interface TMBLineString : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBLineString")]
    [DisableDefaultCtor]
    interface TMBLineString
    {
        // @property (readonly, copy, nonatomic) NSArray<NSValue *> * _Nonnull coordinates;
        [Export("coordinates", ArgumentSemantic.Copy)]
        NSValue[] Coordinates { get; }
    }

    // @interface TMBLineTranslateAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBLineTranslateAnchor")]
    [DisableDefaultCtor]
    interface TMBLineTranslateAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBLineTranslateAnchor * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBLineTranslateAnchor Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBLineTranslateAnchor * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBLineTranslateAnchor Viewport { get; }
    }

    // @interface TMBLocationIndicatorLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC25TMBLocationIndicatorLayer")]
    [DisableDefaultCtor]
    interface TMBLocationIndicatorLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable bearingImage;
        [NullAllowed, Export("bearingImage", ArgumentSemantic.Strong)]
        TMBValue BearingImage { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable shadowImage;
        [NullAllowed, Export("shadowImage", ArgumentSemantic.Strong)]
        TMBValue ShadowImage { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable topImage;
        [NullAllowed, Export("topImage", ArgumentSemantic.Strong)]
        TMBValue TopImage { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable accuracyRadius;
        [NullAllowed, Export("accuracyRadius", ArgumentSemantic.Strong)]
        TMBValue AccuracyRadius { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable accuracyRadiusTransition;
        [NullAllowed, Export("accuracyRadiusTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition AccuracyRadiusTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable accuracyRadiusBorderColor;
        [NullAllowed, Export("accuracyRadiusBorderColor", ArgumentSemantic.Strong)]
        TMBValue AccuracyRadiusBorderColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable accuracyRadiusBorderColorTransition;
        [NullAllowed, Export("accuracyRadiusBorderColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition AccuracyRadiusBorderColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable accuracyRadiusColor;
        [NullAllowed, Export("accuracyRadiusColor", ArgumentSemantic.Strong)]
        TMBValue AccuracyRadiusColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable accuracyRadiusColorTransition;
        [NullAllowed, Export("accuracyRadiusColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition AccuracyRadiusColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable bearing;
        [NullAllowed, Export("bearing", ArgumentSemantic.Strong)]
        TMBValue Bearing { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable bearingTransition;
        [NullAllowed, Export("bearingTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition BearingTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable bearingImageSize;
        [NullAllowed, Export("bearingImageSize", ArgumentSemantic.Strong)]
        TMBValue BearingImageSize { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable bearingImageSizeTransition;
        [NullAllowed, Export("bearingImageSizeTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition BearingImageSizeTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable emphasisCircleColor;
        [NullAllowed, Export("emphasisCircleColor", ArgumentSemantic.Strong)]
        TMBValue EmphasisCircleColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable emphasisCircleColorTransition;
        [NullAllowed, Export("emphasisCircleColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition EmphasisCircleColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable emphasisCircleRadius;
        [NullAllowed, Export("emphasisCircleRadius", ArgumentSemantic.Strong)]
        TMBValue EmphasisCircleRadius { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable emphasisCircleRadiusTransition;
        [NullAllowed, Export("emphasisCircleRadiusTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition EmphasisCircleRadiusTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable imagePitchDisplacement;
        [NullAllowed, Export("imagePitchDisplacement", ArgumentSemantic.Strong)]
        TMBValue ImagePitchDisplacement { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable location;
        [NullAllowed, Export("location", ArgumentSemantic.Strong)]
        TMBValue Location { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable locationTransition;
        [NullAllowed, Export("locationTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LocationTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable locationIndicatorOpacity;
        [NullAllowed, Export("locationIndicatorOpacity", ArgumentSemantic.Strong)]
        TMBValue LocationIndicatorOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable locationIndicatorOpacityTransition;
        [NullAllowed, Export("locationIndicatorOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition LocationIndicatorOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable perspectiveCompensation;
        [NullAllowed, Export("perspectiveCompensation", ArgumentSemantic.Strong)]
        TMBValue PerspectiveCompensation { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable shadowImageSize;
        [NullAllowed, Export("shadowImageSize", ArgumentSemantic.Strong)]
        TMBValue ShadowImageSize { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable shadowImageSizeTransition;
        [NullAllowed, Export("shadowImageSizeTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition ShadowImageSizeTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable topImageSize;
        [NullAllowed, Export("topImageSize", ArgumentSemantic.Strong)]
        TMBValue TopImageSize { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable topImageSizeTransition;
        [NullAllowed, Export("topImageSizeTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition TopImageSizeTransition { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBLocationManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBLocationManager")]
    [DisableDefaultCtor]
    interface TMBLocationManager
    {
        //  @property (nonatomic, strong) TMBLocationOptions * _Nonnull options;
        [Export("options", ArgumentSemantic.Strong)]
        TMBLocationOptions Options { get; set; }

        // -(TMBCancelable * _Nonnull)onLocationChangeWithHandler:(void (^ _Nonnull)(NSArray<MBXLocation *> * _Nonnull))handler __attribute__((warn_unused_result("")));
        [Export("onLocationChangeWithHandler:")]
        TMBCancelable OnLocationChangeWithHandler(Action<NSArray<MBXLocation>> handler);

        // -(TMBCancelable * _Nonnull)onHeadingChangeWithHandler:(void (^ _Nonnull)(TMBHeading * _Nonnull))handler __attribute__((warn_unused_result("")));
        [Export("onHeadingChangeWithHandler:")]
        TMBCancelable OnHeadingChangeWithHandler(Action<TMBHeading> handler);

        // -(TMBCancelable * _Nonnull)onPuckRenderWithHandler:(void (^ _Nonnull)(TMBPuckRenderingData * _Nonnull))handler __attribute__((warn_unused_result("")));
        [Export("onPuckRenderWithHandler:")]
        TMBCancelable OnPuckRenderWithHandler(Action<TMBPuckRenderingData> handler);

        // -(void)overrideWithLocationHandler:(void (^ _Nonnull)(NSArray<MBXLocation *> * _Nonnull))locationHandler headingHandler:(void (^ _Nullable)(TMBHeading * _Nonnull))headingHandler;
        [Export("overrideWithLocationHandler:headingHandler:")]
        void OverrideWithLocationHandler(Action<NSArray<MBXLocation>> locationHandler, [NullAllowed] Action<TMBHeading> headingHandler);

        // -(void)overrideWithLocationProvider:(id<MBXLocationProvider> _Nonnull)locationProvider headingProvider:(id<TMBHeadingProvider> _Nullable)headingProvider;
        [Export("overrideWithLocationProvider:headingProvider:")]
        void OverrideWithLocationProvider(IMBXLocationProvider locationProvider, [NullAllowed] ITMBHeadingProvider headingProvider);

        // -(void)overrideWithProvider:(id<MBXLocationProvider,TMBHeadingProvider> _Nonnull)provider;
        [Export("overrideWithProvider:")]
        void OverrideWithProvider(NSObject provider);

        // @property (readonly, nonatomic, strong) MBXLocation * _Nullable latestLocation;
        [NullAllowed, Export("latestLocation", ArgumentSemantic.Strong)]
        MBXLocation LatestLocation { get; }

        // + (CLLocationDirection)directionFrom:(CLLocationCoordinate2D)from to:(CLLocationCoordinate2D)coordinate SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("directionFrom:to:")]
        double DirectionFrom(CLLocationCoordinate2D from, CLLocationCoordinate2D to);
        
        // + (CLLocationCoordinate2D)coordinateFrom:(CLLocationCoordinate2D)from at:(CLLocationDistance)distance facing:(CLLocationDirection)direction SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("coordinateFrom:at:facing:")]
        CLLocationCoordinate2D CoordinateFrom(CLLocationCoordinate2D from, double distance, double direction);
        
        // + (CLLocationDistance)distanceFrom:(CLLocationCoordinate2D)from to:(CLLocationCoordinate2D)coordinate SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("distanceFrom:to:")]
        double DistanceFrom(CLLocationCoordinate2D from, CLLocationCoordinate2D to);
    }

    // @interface TMBLocationOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBLocationOptions")]
    [DisableDefaultCtor]
    interface TMBLocationOptions
    {
        // @property (nonatomic, strong) id<TMBPuckTypeConfiguration> _Nullable puckType;
        [NullAllowed, Export("puckType", ArgumentSemantic.Strong)]
        ITMBPuckTypeConfiguration PuckType { get; set; }

        // @property (nonatomic) enum TMBPuckBearing puckBearing;
        [Export("puckBearing", ArgumentSemantic.Assign)]
        TMBPuckBearing PuckBearing { get; set; }

        // @property (nonatomic) BOOL puckBearingEnabled;
        [Export("puckBearingEnabled")]
        bool PuckBearingEnabled { get; set; }

        // -(instancetype _Nonnull)initWithPuckType:(id<TMBPuckTypeConfiguration> _Nullable)puckType puckBearing:(enum TMBPuckBearing)puckBearing puckBearingEnabled:(BOOL)puckBearingEnabled __attribute__((objc_designated_initializer));
        [Export("initWithPuckType:puckBearing:puckBearingEnabled:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] ITMBPuckTypeConfiguration puckType, TMBPuckBearing puckBearing, bool puckBearingEnabled);
    }

    // @interface TMBLogoViewOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBLogoViewOptions")]
    [DisableDefaultCtor]
    interface TMBLogoViewOptions
    {
        // @property (nonatomic) enum TMBOrnamentPosition position;
        [Export("position", ArgumentSemantic.Assign)]
        TMBOrnamentPosition Position { get; set; }

        // @property (nonatomic) CGPoint margins;
        [Export("margins", ArgumentSemantic.Assign)]
        CGPoint Margins { get; set; }

        // -(instancetype _Nonnull)initWithPosition:(enum TMBOrnamentPosition)position margins:(CGPoint)margins __attribute__((objc_designated_initializer));
        [Export("initWithPosition:margins:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBOrnamentPosition position, CGPoint margins);
    }

    // @interface TMBMapContentGestureContext : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC27TMBMapContentGestureContext")]
    [DisableDefaultCtor]
    interface TMBMapContentGestureContext
    {
        // @property (readonly, nonatomic) CGPoint point;
        [Export("point")]
        CGPoint Point { get; }

        // @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
        [Export("coordinate")]
        CLLocationCoordinate2D Coordinate { get; }
    }

    // @interface TMBMapViewDebugOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBMapViewDebugOptions")]
    [DisableDefaultCtor]
    interface TMBMapViewDebugOptions
    {
        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull tileBorders;
        [Static]
        [Export("tileBorders", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions TileBorders { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull parseStatus;
        [Static]
        [Export("parseStatus", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions ParseStatus { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull timestamps;
        [Static]
        [Export("timestamps", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions Timestamps { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull collision;
        [Static]
        [Export("collision", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions Collision { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull overdraw;
        [Static]
        [Export("overdraw", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions Overdraw { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull stencilClip;
        [Static]
        [Export("stencilClip", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions StencilClip { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull depthBuffer;
        [Static]
        [Export("depthBuffer", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions DepthBuffer { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull modelBounds;
        [Static]
        [Export("modelBounds", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions ModelBounds { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull light;
        [Static]
        [Export("light", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions Light { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull camera;
        [Static]
        [Export("camera", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions Camera { get; }

        // @property (readonly, nonatomic, strong, class) TMBMapViewDebugOptions * _Nonnull padding;
        [Static]
        [Export("padding", ArgumentSemantic.Strong)]
        TMBMapViewDebugOptions Padding { get; }

        // @property (readonly, nonatomic) NSInteger rawValue;
        [Export("rawValue")]
        nint RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSInteger)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(nint rawValue);
    }

    // @interface TMBStyleManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC15TMBStyleManager")]
    [DisableDefaultCtor]
    interface TMBStyleManager
    {
        // -(void)addLayer:(id<TMBLayer> _Nonnull)layer layerPosition:(TMBLayerPosition * _Nullable)layerPosition completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addLayer:layerPosition:completion:")]
        void AddLayer(ITMBLayer layer, [NullAllowed] TMBLayerPosition layerPosition, [NullAllowed] Action<NSError> completion);

        // -(void)addPersistentLayer:(id<TMBLayer> _Nonnull)layer layerPosition:(TMBLayerPosition * _Nullable)layerPosition completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addPersistentLayer:layerPosition:completion:")]
        void AddPersistentLayer(ITMBLayer layer, [NullAllowed] TMBLayerPosition layerPosition, [NullAllowed] Action<NSError> completion);

        // -(void)moveLayerWithId:(NSString * _Nonnull)id to:(TMBLayerPosition * _Nonnull)position completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("moveLayerWithId:to:completion:")]
        void MoveLayerWithId(string id, TMBLayerPosition position, [NullAllowed] Action<NSError> completion);

        // -(void)layerWithId:(NSString * _Nonnull)id completion:(void (^ _Nullable)(id<TMBLayer> _Nullable, NSError * _Nullable))completion;
        [Export("layerWithId:completion:")]
        void LayerWithId(string id, [NullAllowed] Action<ITMBLayer, NSError> completion);

        // -(void)addSource:(id<TMBSource> _Nonnull)source dataId:(NSString * _Nullable)dataId completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addSource:dataId:completion:")]
        void AddSource(ITMBSource source, [NullAllowed] string dataId, [NullAllowed] Action<NSError> completion);

        // -(void)sourceWithId:(NSString * _Nonnull)id completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("sourceWithId:completion:")]
        void SourceWithId(string id, [NullAllowed] Action<NSError> completion);

        // -(void)updateGeoJSONSourceWithId:(NSString * _Nonnull)id data:(TMBGeoJSONSourceData * _Nonnull)data dataId:(NSString * _Nullable)dataId;
        [Export("updateGeoJSONSourceWithId:data:dataId:")]
        void UpdateGeoJSONSourceWithId(string id, TMBGeoJSONSourceData data, [NullAllowed] string dataId);

        // -(void)updateGeoJSONSourceWithId:(NSString * _Nonnull)id geoJSON:(NSString * _Nonnull)geoJSON dataId:(NSString * _Nullable)dataId completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("updateGeoJSONSourceWithId:geoJSON:dataId:completion:")]
        void UpdateGeoJSONSourceWithId(string id, string geoJSON, [NullAllowed] string dataId, [NullAllowed] Action<NSError> completion);

        // -(void)addGeoJSONSourceFeaturesForSourceId:(NSString * _Nonnull)sourceId features:(NSArray<MBXFeature *> * _Nonnull)features dataId:(NSString * _Nullable)dataId;
        [Export("addGeoJSONSourceFeaturesForSourceId:features:dataId:")]
        void AddGeoJSONSourceFeaturesForSourceId(string sourceId, MBXFeature[] features, [NullAllowed] string dataId);

        // -(void)updateGeoJSONSourceFeaturesForSourceId:(NSString * _Nonnull)sourceId features:(NSArray<MBXFeature *> * _Nonnull)features dataId:(NSString * _Nullable)dataId;
        [Export("updateGeoJSONSourceFeaturesForSourceId:features:dataId:")]
        void UpdateGeoJSONSourceFeaturesForSourceId(string sourceId, MBXFeature[] features, [NullAllowed] string dataId);

        // -(void)removeGeoJSONSourceFeaturesForSourceId:(NSString * _Nonnull)sourceId featureIds:(NSArray<NSString *> * _Nonnull)featureIds dataId:(NSString * _Nullable)dataId;
        [Export("removeGeoJSONSourceFeaturesForSourceId:featureIds:dataId:")]
        void RemoveGeoJSONSourceFeaturesForSourceId(string sourceId, string[] featureIds, [NullAllowed] string dataId);

        // @property (readonly, nonatomic) BOOL isStyleLoaded;
        [Export("isStyleLoaded")]
        bool IsStyleLoaded { get; }

        // @property (nonatomic, strong) TMBStyleURI * _Nullable styleURI;
        [NullAllowed, Export("styleURI", ArgumentSemantic.Strong)]
        TMBStyleURI StyleURI { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull styleJSON;
        [Export("styleJSON")]
        string StyleJSON { get; set; }

        // @property (readonly, nonatomic, strong) TMBCameraOptions * _Nonnull styleDefaultCamera;
        [Export("styleDefaultCamera", ArgumentSemantic.Strong)]
        TMBCameraOptions StyleDefaultCamera { get; }

        // @property (nonatomic, strong) MBMTransitionOptions * _Nonnull styleTransition;
        [Export("styleTransition", ArgumentSemantic.Strong)]
        MBMTransitionOptions StyleTransition { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<MBMStyleObjectInfo *> * _Nonnull styleImports;
        [Export("styleImports", ArgumentSemantic.Copy)]
        MBMStyleObjectInfo[] StyleImports { get; }

        // -(void)removeStyleImportFor:(NSString * _Nonnull)importId completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("removeStyleImportFor:completion:")]
        void RemoveStyleImportFor(string importId, [NullAllowed] Action<NSError> completion);

        // -(void)getStyleImportSchemaFor:(NSString * _Nonnull)importId completion:(void (^ _Nullable)(id _Nullable, NSError * _Nullable))completion;
        [Export("getStyleImportSchemaFor:completion:")]
        void GetStyleImportSchemaFor(string importId, [NullAllowed] Action<NSObject, NSError> completion);

        // -(void)getStyleImportConfigPropertiesFor:(NSString * _Nonnull)importId completion:(void (^ _Nullable)(NSDictionary<NSString *,TMBStylePropertyValue *> * _Nullable, NSError * _Nullable))completion;
        [Export("getStyleImportConfigPropertiesFor:completion:")]
        void GetStyleImportConfigPropertiesFor(string importId, [NullAllowed] Action<NSDictionary<NSString, TMBStylePropertyValue>, NSError> completion);

        // -(void)getStyleImportConfigPropertyFor:(NSString * _Nonnull)importId config:(NSString * _Nonnull)config completion:(void (^ _Nullable)(TMBStylePropertyValue * _Nullable, NSError * _Nullable))completion;
        [Export("getStyleImportConfigPropertyFor:config:completion:")]
        void GetStyleImportConfigPropertyFor(string importId, string config, [NullAllowed] Action<TMBStylePropertyValue, NSError> completion);

        // -(void)setStyleImportConfigPropertiesFor:(NSString * _Nonnull)importId configs:(NSDictionary<NSString *,id> * _Nonnull)configs completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setStyleImportConfigPropertiesFor:configs:completion:")]
        void SetStyleImportConfigPropertiesFor(string importId, NSDictionary<NSString, NSObject> configs, [NullAllowed] Action<NSError> completion);

        // -(void)setStyleImportConfigPropertyFor:(NSString * _Nonnull)importId config:(NSString * _Nonnull)config value:(id _Nonnull)value completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setStyleImportConfigPropertyFor:config:value:completion:")]
        void SetStyleImportConfigPropertyFor(string importId, string config, NSObject value, [NullAllowed] Action<NSError> completion);

        // -(void)addLayerWith:(NSDictionary<NSString *,id> * _Nonnull)properties layerPosition:(TMBLayerPosition * _Nullable)layerPosition completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addLayerWith:layerPosition:completion:")]
        void AddLayerWith(NSDictionary<NSString, NSObject> properties, [NullAllowed] TMBLayerPosition layerPosition, [NullAllowed] Action<NSError> completion);

        // -(void)addPersistentLayerWith:(NSDictionary<NSString *,id> * _Nonnull)properties layerPosition:(TMBLayerPosition * _Nullable)layerPosition completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addPersistentLayerWith:layerPosition:completion:")]
        void AddPersistentLayerWith(NSDictionary<NSString, NSObject> properties, [NullAllowed] TMBLayerPosition layerPosition, [NullAllowed] Action<NSError> completion);

        // -(void)isPersistentLayerWithId:(NSString * _Nonnull)id completion:(void (^ _Nullable)(BOOL, NSError * _Nullable))completion;
        [Export("isPersistentLayerWithId:completion:")]
        void IsPersistentLayerWithId(string id, [NullAllowed] Action<bool, NSError> completion);

        // -(void)addPersistentCustomLayerWithId:(NSString * _Nonnull)id layerHost:(id<MBMCustomLayerHost> _Nonnull)layerHost layerPosition:(TMBLayerPosition * _Nullable)layerPosition completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addPersistentCustomLayerWithId:layerHost:layerPosition:completion:")]
        void AddPersistentCustomLayerWithId(string id, MBMCustomLayerHost layerHost, [NullAllowed] TMBLayerPosition layerPosition, [NullAllowed] Action<NSError> completion);

        // -(void)addCustomLayerWithId:(NSString * _Nonnull)id layerHost:(id<MBMCustomLayerHost> _Nonnull)layerHost layerPosition:(TMBLayerPosition * _Nullable)layerPosition completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addCustomLayerWithId:layerHost:layerPosition:completion:")]
        void AddCustomLayerWithId(string id, IMBMCustomLayerHost layerHost, [NullAllowed] TMBLayerPosition layerPosition, [NullAllowed] Action<NSError> completion);

        // -(void)removeLayerWithId:(NSString * _Nonnull)id completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("removeLayerWithId:completion:")]
        void RemoveLayerWithId(string id, [NullAllowed] Action<NSError> completion);

        // -(BOOL)layerExistsWithId:(NSString * _Nonnull)id __attribute__((warn_unused_result("")));
        [Export("layerExistsWithId:")]
        bool LayerExistsWithId(string id);

        // @property (readonly, copy, nonatomic) NSArray<TMBLayerInfo *> * _Nonnull allLayerIdentifiers;
        [Export("allLayerIdentifiers", ArgumentSemantic.Copy)]
        TMBLayerInfo[] AllLayerIdentifiers { get; }

        // -(id _Nonnull)layerPropertyValueFor:(NSString * _Nonnull)layerId property:(NSString * _Nonnull)property __attribute__((warn_unused_result("")));
        [Export("layerPropertyValueFor:property:")]
        NSObject LayerPropertyValueFor(string layerId, string property);

        // -(TMBStylePropertyValue * _Nonnull)layerPropertyFor:(NSString * _Nonnull)layerId property:(NSString * _Nonnull)property __attribute__((warn_unused_result("")));
        [Export("layerPropertyFor:property:")]
        TMBStylePropertyValue LayerPropertyFor(string layerId, string property);

        // -(void)setLayerPropertyFor:(NSString * _Nonnull)layerId property:(NSString * _Nonnull)property value:(id _Nonnull)value completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setLayerPropertyFor:property:value:completion:")]
        void SetLayerPropertyFor(string layerId, string property, NSObject value, [NullAllowed] Action<NSError> completion);

        // -(TMBStylePropertyValue * _Nonnull)layerPropertyDefaultValueFor:(TMBLayerType * _Nonnull)layerType property:(NSString * _Nonnull)property __attribute__((warn_unused_result("")));
        [Export("layerPropertyDefaultValueFor:property:")]
        TMBStylePropertyValue LayerPropertyDefaultValueFor(TMBLayerType layerType, string property);

        // -(void)layerPropertiesFor:(NSString * _Nonnull)layerId completion:(void (^ _Nullable)(NSDictionary<NSString *,id> * _Nullable, NSError * _Nullable))completion;
        [Export("layerPropertiesFor:completion:")]
        void LayerPropertiesFor(string layerId, [NullAllowed] Action<NSDictionary<NSString, NSObject>, NSError> completion);

        // -(void)setLayerPropertiesFor:(NSString * _Nonnull)layerId properties:(NSDictionary<NSString *,id> * _Nonnull)properties completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setLayerPropertiesFor:properties:completion:")]
        void SetLayerPropertiesFor(string layerId, NSDictionary<NSString, NSObject> properties, [NullAllowed] Action<NSError> completion);

        // -(void)addSourceWithId:(NSString * _Nonnull)id properties:(NSDictionary<NSString *,id> * _Nonnull)properties completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addSourceWithId:properties:completion:")]
        void AddSourceWithId(string id, NSDictionary<NSString, NSObject> properties, [NullAllowed] Action<NSError> completion);

        // -(void)removeSourceWithId:(NSString * _Nonnull)id completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("removeSourceWithId:completion:")]
        void RemoveSourceWithId(string id, [NullAllowed] Action<NSError> completion);

        // -(BOOL)sourceExistsWithId:(NSString * _Nonnull)id __attribute__((warn_unused_result("")));
        [Export("sourceExistsWithId:")]
        bool SourceExistsWithId(string id);

        // @property (readonly, copy, nonatomic) NSArray<TMBSourceInfo *> * _Nonnull allSourceIdentifiers;
        [Export("allSourceIdentifiers", ArgumentSemantic.Copy)]
        TMBSourceInfo[] AllSourceIdentifiers { get; }

        // -(TMBStylePropertyValue * _Nonnull)sourcePropertyFor:(NSString * _Nonnull)sourceId property:(NSString * _Nonnull)property __attribute__((warn_unused_result("")));
        [Export("sourcePropertyFor:property:")]
        TMBStylePropertyValue SourcePropertyFor(string sourceId, string property);

        // -(void)setSourcePropertyFor:(NSString * _Nonnull)sourceId property:(NSString * _Nonnull)property value:(id _Nonnull)value completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setSourcePropertyFor:property:value:completion:")]
        void SetSourcePropertyFor(string sourceId, string property, NSObject value, [NullAllowed] Action<NSError> completion);

        // -(void)sourcePropertiesFor:(NSString * _Nonnull)sourceId completion:(void (^ _Nullable)(NSDictionary<NSString *,id> * _Nullable, NSError * _Nullable))completion;
        [Export("sourcePropertiesFor:completion:")]
        void SourcePropertiesFor(string sourceId, [NullAllowed] Action<NSDictionary<NSString, NSObject>, NSError> completion);

        // -(void)setSourcePropertiesFor:(NSString * _Nonnull)sourceId properties:(NSDictionary<NSString *,id> * _Nonnull)properties completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setSourcePropertiesFor:properties:completion:")]
        void SetSourcePropertiesFor(string sourceId, NSDictionary<NSString, NSObject> properties, [NullAllowed] Action<NSError> completion);

        // -(TMBStylePropertyValue * _Nonnull)sourcePropertyDefaultValueFor:(NSString * _Nonnull)sourceType property:(NSString * _Nonnull)property __attribute__((warn_unused_result("")));
        [Export("sourcePropertyDefaultValueFor:property:")]
        TMBStylePropertyValue SourcePropertyDefaultValueFor(string sourceType, string property);

        // -(void)updateImageSourceWithId:(NSString * _Nonnull)id image:(UIImage * _Nonnull)image completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("updateImageSourceWithId:image:completion:")]
        void UpdateImageSourceWithId(string id, UIImage image, [NullAllowed] Action<NSError> completion);

        // -(void)addImage:(UIImage * _Nonnull)image id:(NSString * _Nonnull)id sdf:(BOOL)sdf stretchX:(NSArray<MBMImageStretches *> * _Nonnull)stretchX stretchY:(NSArray<MBMImageStretches *> * _Nonnull)stretchY content:(MBMImageContent * _Nullable)content completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addImage:id:sdf:stretchX:stretchY:content:completion:")]
        void AddImage(UIImage image, string id, bool sdf, MBMImageStretches[] stretchX, MBMImageStretches[] stretchY, [NullAllowed] MBMImageContent content, [NullAllowed] Action<NSError> completion);

        // -(void)addImage:(UIImage * _Nonnull)image id:(NSString * _Nonnull)id sdf:(BOOL)sdf contentInsets:(UIEdgeInsets)contentInsets completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addImage:id:sdf:contentInsets:completion:")]
        void AddImage(UIImage image, string id, bool sdf, UIEdgeInsets contentInsets, [NullAllowed] Action<NSError> completion);

        // -(void)removeImageWithId:(NSString * _Nonnull)id completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("removeImageWithId:completion:")]
        void RemoveImageWithId(string id, [NullAllowed] Action<NSError> completion);

        // -(BOOL)imageExistsWithId:(NSString * _Nonnull)id __attribute__((warn_unused_result("")));
        [Export("imageExistsWithId:")]
        bool ImageExistsWithId(string id);

        // -(UIImage * _Nullable)imageWithId:(NSString * _Nonnull)id __attribute__((warn_unused_result("")));
        [Export("imageWithId:")]
        [return: NullAllowed]
        UIImage ImageWithId(string id);

        // @property (readonly, copy, nonatomic) NSArray<TMBLightInfo *> * _Nonnull allLightIdentifiers;
        [Export("allLightIdentifiers", ArgumentSemantic.Copy)]
        TMBLightInfo[] AllLightIdentifiers { get; }

        // -(id _Nonnull)lightPropertyFor:(NSString * _Nonnull)lightId property:(NSString * _Nonnull)property __attribute__((warn_unused_result("")));
        [Export("lightPropertyFor:property:")]
        NSObject LightPropertyFor(string lightId, string property);

        // -(void)setLights:(TMBFlatLight * _Nonnull)flatLight completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setLights:completion:")]
        void SetLights(TMBFlatLight flatLight, [NullAllowed] Action<NSError> completion);

        // -(void)setLightsWithAmbient:(TMBAmbientLight * _Nonnull)ambientLight directional:(TMBDirectionalLight * _Nonnull)directionalLight completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setLightsWithAmbient:directional:completion:")]
        void SetLightsWithAmbient(TMBAmbientLight ambientLight, TMBDirectionalLight directionalLight, [NullAllowed] Action<NSError> completion);

        // -(void)setLightPropertyFor:(NSString * _Nonnull)lightId property:(NSString * _Nonnull)property value:(id _Nonnull)value completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setLightPropertyFor:property:value:completion:")]
        void SetLightPropertyFor(string lightId, string property, NSObject value, [NullAllowed] Action<NSError> completion);

        // -(void)setTerrain:(TMBTerrain * _Nonnull)terrain completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setTerrain:completion:")]
        void SetTerrain(TMBTerrain terrain, [NullAllowed] Action<NSError> completion);

        // -(void)removeTerrain;
        [Export("removeTerrain")]
        void RemoveTerrain();

        // -(void)setTerrainWithProperties:(NSDictionary<NSString *,id> * _Nonnull)properties completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setTerrainWithProperties:completion:")]
        void SetTerrainWithProperties(NSDictionary<NSString, NSObject> properties, [NullAllowed] Action<NSError> completion);

        // -(void)setTerrainProperty:(NSString * _Nonnull)property value:(id _Nonnull)value completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setTerrainProperty:value:completion:")]
        void SetTerrainProperty(string property, NSObject value, [NullAllowed] Action<NSError> completion);

        // -(id _Nonnull)terrainPropertyValue:(NSString * _Nonnull)property __attribute__((warn_unused_result("")));
        [Export("terrainPropertyValue:")]
        NSObject TerrainPropertyValue(string property);

        // -(TMBStylePropertyValue * _Nonnull)terrainProperty:(NSString * _Nonnull)property __attribute__((warn_unused_result("")));
        [Export("terrainProperty:")]
        TMBStylePropertyValue TerrainProperty(string property);

        // -(void)setAtmosphere:(TMBAtmosphere * _Nonnull)atmosphere completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setAtmosphere:completion:")]
        void SetAtmosphere(TMBAtmosphere atmosphere, [NullAllowed] Action<NSError> completion);

        // -(void)removeAtmosphereWithCompletion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("removeAtmosphereWithCompletion:")]
        void RemoveAtmosphereWithCompletion([NullAllowed] Action<NSError> completion);

        // -(void)setAtmosphereWithProperties:(NSDictionary<NSString *,id> * _Nonnull)properties completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setAtmosphereWithProperties:completion:")]
        void SetAtmosphereWithProperties(NSDictionary<NSString, NSObject> properties, [NullAllowed] Action<NSError> completion);

        // -(void)setAtmosphereProperty:(NSString * _Nonnull)property value:(id _Nonnull)value completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setAtmosphereProperty:value:completion:")]
        void SetAtmosphereProperty(string property, NSObject value, [NullAllowed] Action<NSError> completion);

        // -(TMBStylePropertyValue * _Nonnull)atmosphereProperty:(NSString * _Nonnull)property __attribute__((warn_unused_result("")));
        [Export("atmosphereProperty:")]
        TMBStylePropertyValue AtmosphereProperty(string property);

        // -(void)addCustomGeometrySourceWithId:(NSString * _Nonnull)id options:(MBMCustomGeometrySourceOptions * _Nonnull)options completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("addCustomGeometrySourceWithId:options:completion:")]
        void AddCustomGeometrySourceWithId(string id, MBMCustomGeometrySourceOptions options, [NullAllowed] Action<NSError> completion);

        // -(void)setCustomGeometrySourceTileDataForSourceId:(NSString * _Nonnull)sourceId tileId:(MBMCanonicalTileID * _Nonnull)tileId features:(NSArray<MBXFeature *> * _Nonnull)features completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setCustomGeometrySourceTileDataForSourceId:tileId:features:completion:")]
        void SetCustomGeometrySourceTileDataForSourceId(string sourceId, MBMCanonicalTileID tileId, MBXFeature[] features, [NullAllowed] Action<NSError> completion);

        // -(void)invalidateCustomGeometrySourceTileForSourceId:(NSString * _Nonnull)sourceId tileId:(MBMCanonicalTileID * _Nonnull)tileId completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("invalidateCustomGeometrySourceTileForSourceId:tileId:completion:")]
        void InvalidateCustomGeometrySourceTileForSourceId(string sourceId, MBMCanonicalTileID tileId, [NullAllowed] Action<NSError> completion);

        // -(void)invalidateCustomGeometrySourceRegionForSourceId:(NSString * _Nonnull)sourceId bounds:(MBMCoordinateBounds * _Nonnull)bounds completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("invalidateCustomGeometrySourceRegionForSourceId:bounds:completion:")]
        void InvalidateCustomGeometrySourceRegionForSourceId(string sourceId, MBMCoordinateBounds bounds, [NullAllowed] Action<NSError> completion);
    }

    // @interface TMBMapboxMap : TMBStyleManager
    [BaseType(typeof(TMBStyleManager), Name = "_TtC13MapboxMapObjC12TMBMapboxMap")]
    interface TMBMapboxMap
    {
        // -(void)triggerRepaint;
        [Export("triggerRepaint")]
        void TriggerRepaint();

        // -(void)loadStyleWithUri:(NSString * _Nonnull)uri transition:(MBMTransitionOptions * _Nullable)transition completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("loadStyleWithUri:transition:completion:")]
        void LoadStyleWithUri(string uri, [NullAllowed] MBMTransitionOptions transition, [NullAllowed] Action<NSError> completion);

        // -(void)loadStyleWithJson:(NSString * _Nonnull)json transition:(MBMTransitionOptions * _Nullable)transition completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("loadStyleWithJson:transition:completion:")]
        void LoadStyleWithJson(string json, [NullAllowed] MBMTransitionOptions transition, [NullAllowed] Action<NSError> completion);

        // @property (nonatomic) uint8_t prefetchZoomDelta;
        [Export("prefetchZoomDelta")]
        byte PrefetchZoomDelta { get; set; }

        // -(void)setTileCacheBudget:(MBMTileCacheBudget * _Nullable)tileCacheBudget;
        [Export("setTileCacheBudget:")]
        void SetTileCacheBudget([NullAllowed] MBMTileCacheBudget tileCacheBudget);

        // @property (nonatomic) BOOL shouldRenderWorldCopies;
        [Export("shouldRenderWorldCopies")]
        bool ShouldRenderWorldCopies { get; set; }

        // -(NSNumber * _Nullable)elevationAt:(CLLocationCoordinate2D)coordinate __attribute__((warn_unused_result("")));
        [Export("elevationAt:")]
        [return: NullAllowed]
        NSNumber ElevationAt(CLLocationCoordinate2D coordinate);

        // -(MBMCoordinateBounds * _Nonnull)coordinateBoundsFor:(CGRect)rect __attribute__((warn_unused_result("")));
        [Export("coordinateBoundsFor:")]
        MBMCoordinateBounds CoordinateBoundsFor(CGRect rect);

        // -(CGRect)rectFor:(MBMCoordinateBounds * _Nonnull)coordinateBounds __attribute__((warn_unused_result("")));
        [Export("rectFor:")]
        CGRect RectFor(MBMCoordinateBounds coordinateBounds);

        // @property (readonly, nonatomic, strong) MBMMapOptions * _Nonnull options;
        [Export("options", ArgumentSemantic.Strong)]
        MBMMapOptions Options { get; }

        // -(TMBCameraOptions * _Nonnull)cameraFor:(NSArray<NSValue *> * _Nonnull)coordinates camera:(TMBCameraOptions * _Nonnull)camera rect:(CGRect)rect __attribute__((warn_unused_result("")));
        [Export("cameraFor:camera:rect:")]
        TMBCameraOptions CameraFor(NSValue[] coordinates, TMBCameraOptions camera, CGRect rect);

        // - (void)cameraFor:(NSArray<NSValue *> * _Nonnull)coordinates camera:(TMBCameraOptions * _Nonnull)camera coordinatesPadding:(NSValue * _Nullable)coordinatesPadding maxZoom:(NSNumber * _Nullable)maxZoom offset:(NSValue * _Nullable)offset completion:(SWIFT_NOESCAPE void (^ _Nonnull)(TMBCameraOptions * _Nullable, NSError * _Nullable))completion;
        [Export("cameraFor:camera:coordinatesPadding:maxZoom:offset:completion:")]
        void CameraFor(NSValue[] coordinates, TMBCameraOptions camera, [NullAllowed] NSValue coordinatesPadding, [NullAllowed] NSNumber maxZoom, [NullAllowed] NSValue offset, Action<TMBCameraOptions?, NSError?> completion);

        // -(MBMCoordinateBounds * _Nonnull)coordinateBoundsForCameraBounds:(TMBCameraOptions * _Nonnull)camera __attribute__((warn_unused_result("")));
        [Export("coordinateBoundsForCameraBounds:")]
        MBMCoordinateBounds CoordinateBoundsForCameraBounds(TMBCameraOptions camera);

        // -(MBMCoordinateBounds * _Nonnull)coordinateBoundsUnwrappedFor:(TMBCameraOptions * _Nonnull)camera __attribute__((warn_unused_result("")));
        [Export("coordinateBoundsUnwrappedFor:")]
        MBMCoordinateBounds CoordinateBoundsUnwrappedFor(TMBCameraOptions camera);

        // -(MBMCoordinateBoundsZoom * _Nonnull)coordinateBoundsZoomFor:(TMBCameraOptions * _Nonnull)camera __attribute__((warn_unused_result("")));
        [Export("coordinateBoundsZoomFor:")]
        MBMCoordinateBoundsZoom CoordinateBoundsZoomFor(TMBCameraOptions camera);

        // -(MBMCoordinateBoundsZoom * _Nonnull)coordinateBoundsZoomUnwrappedFor:(TMBCameraOptions * _Nonnull)camera __attribute__((warn_unused_result("")));
        [Export("coordinateBoundsZoomUnwrappedFor:")]
        MBMCoordinateBoundsZoom CoordinateBoundsZoomUnwrappedFor(TMBCameraOptions camera);

        // -(CLLocationCoordinate2D)coordinateFor:(CGPoint)point __attribute__((warn_unused_result("")));
        [Export("coordinateFor:")]
        CLLocationCoordinate2D CoordinateFor(CGPoint point);

        // -(CGPoint)pointFor:(CLLocationCoordinate2D)coordinate __attribute__((warn_unused_result("")));
        [Export("pointFor:")]
        CGPoint PointFor(CLLocationCoordinate2D coordinate);

        // -(NSArray<NSValue *> * _Nonnull)pointsFor:(NSArray<NSValue *> * _Nonnull)coordinates __attribute__((warn_unused_result("")));
        [Export("pointsFor:")]
        NSValue[] PointsFor(NSValue[] coordinates);

        // -(NSArray<NSValue *> * _Nonnull)coordinatesFor:(NSArray<NSValue *> * _Nonnull)points __attribute__((warn_unused_result("")));
        [Export("coordinatesFor:")]
        NSValue[] CoordinatesFor(NSValue[] points);

        // -(void)setCameraTo:(TMBCameraOptions * _Nonnull)cameraOptions;
        [Export("setCameraTo:")]
        void SetCameraTo(TMBCameraOptions cameraOptions);

        // @property (readonly, nonatomic, strong) TMBCameraState * _Nonnull cameraState;
        [Export("cameraState", ArgumentSemantic.Strong)]
        TMBCameraState CameraState { get; }

        // @property (nonatomic, strong) MBMFreeCameraOptions * _Nonnull freeCameraOptions;
        [Export("freeCameraOptions", ArgumentSemantic.Strong)]
        MBMFreeCameraOptions FreeCameraOptions { get; set; }

        // @property (readonly, nonatomic, strong) TMBCameraBounds * _Nonnull cameraBounds;
        [Export("cameraBounds", ArgumentSemantic.Strong)]
        TMBCameraBounds CameraBounds { get; }

        // -(void)setCameraBoundsWith:(TMBCameraBoundsOptions * _Nonnull)options completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setCameraBoundsWith:completion:")]
        void SetCameraBoundsWith(TMBCameraBoundsOptions options, [NullAllowed] Action<NSError> completion);

        // -(TMBCameraOptions * _Nonnull)dragCameraOptionsFrom:(CGPoint)from to:(CGPoint)to __attribute__((warn_unused_result("")));
        [Export("dragCameraOptionsFrom:to:")]
        TMBCameraOptions DragCameraOptionsFrom(CGPoint from, CGPoint to);

        // -(void)beginAnimation;
        [Export("beginAnimation")]
        void BeginAnimation();

        // -(void)endAnimation;
        [Export("endAnimation")]
        void EndAnimation();

        // -(void)beginGesture;
        [Export("beginGesture")]
        void BeginGesture();

        // -(void)endGesture;
        [Export("endGesture")]
        void EndGesture();
    }

    // @interface MapboxMapObjC_Swift_4724 (TMBMapboxMap)
    [Category]
    [BaseType(typeof(TMBMapboxMap))]
    interface TMBMapboxMap_MapboxMapObjC_Swift_4724
    {
        // +(void)clearDataWithCompletion:(void (^ _Nonnull)(NSError * _Nullable))completion;
        [Static]
        [Export("clearDataWithCompletion:")]
        void ClearDataWithCompletion(Action<NSError> completion);
    }

    // @interface MapboxMapObjC_Swift_4738 (TMBMapboxMap)
    [Category]
    [BaseType(typeof(TMBMapboxMap))]
    interface TMBMapboxMap_MapboxMapObjC_Swift_4738
    {
        // -(TMBCancelable * _Nonnull)setFeatureStateWithSourceId:(NSString * _Nonnull)sourceId sourceLayerId:(NSString * _Nullable)sourceLayerId featureId:(NSString * _Nonnull)featureId state:(NSDictionary<NSString *,id> * _Nonnull)state callback:(void (^ _Nonnull)(NSError * _Nullable))callback;
        [Export("setFeatureStateWithSourceId:sourceLayerId:featureId:state:callback:")]
        TMBCancelable SetFeatureStateWithSourceId(string sourceId, [NullAllowed] string sourceLayerId, string featureId, NSDictionary<NSString, NSObject> state, Action<NSError> callback);

        // -(TMBCancelable * _Nonnull)getFeatureStateWithSourceId:(NSString * _Nonnull)sourceId sourceLayerId:(NSString * _Nullable)sourceLayerId featureId:(NSString * _Nonnull)featureId callback:(void (^ _Nonnull)(NSDictionary<NSString *,id> * _Nullable, NSError * _Nullable))callback;
        [Export("getFeatureStateWithSourceId:sourceLayerId:featureId:callback:")]
        TMBCancelable GetFeatureStateWithSourceId(string sourceId, [NullAllowed] string sourceLayerId, string featureId, Action<NSDictionary<NSString, NSObject>, NSError> callback);

        // -(TMBCancelable * _Nonnull)removeFeatureStateWithSourceId:(NSString * _Nonnull)sourceId sourceLayerId:(NSString * _Nullable)sourceLayerId featureId:(NSString * _Nonnull)featureId stateKey:(NSString * _Nullable)stateKey callback:(void (^ _Nonnull)(NSError * _Nullable))callback;
        [Export("removeFeatureStateWithSourceId:sourceLayerId:featureId:stateKey:callback:")]
        TMBCancelable RemoveFeatureStateWithSourceId(string sourceId, [NullAllowed] string sourceLayerId, string featureId, [NullAllowed] string stateKey, Action<NSError> callback);

        // -(TMBCancelable * _Nonnull)resetFeatureStatesWithSourceId:(NSString * _Nonnull)sourceId sourceLayerId:(NSString * _Nullable)sourceLayerId callback:(void (^ _Nonnull)(NSError * _Nullable))callback;
        [Export("resetFeatureStatesWithSourceId:sourceLayerId:callback:")]
        TMBCancelable ResetFeatureStatesWithSourceId(string sourceId, [NullAllowed] string sourceLayerId, Action<NSError> callback);
    }

    // @interface MapboxMapObjC_Swift_4807 (TMBMapboxMap)
    [Category]
    [BaseType(typeof(TMBMapboxMap))]
    interface TMBMapboxMap_MapboxMapObjC_Swift_4807
    {
        // -(TMBCancelable * _Nonnull)queryRenderedFeaturesWithShape:(NSArray<NSValue *> * _Nonnull)shape options:(MBMRenderedQueryOptions * _Nullable)options completion:(void (^ _Nullable)(NSArray<MBMQueriedRenderedFeature *> * _Nullable, NSError * _Nullable))completion;
        [Export("queryRenderedFeaturesWithShape:options:completion:")]
        TMBCancelable QueryRenderedFeaturesWithShape(NSValue[] shape, [NullAllowed] MBMRenderedQueryOptions options, [NullAllowed] Action<NSArray<MBMQueriedRenderedFeature>, NSError> completion);

        // -(TMBCancelable * _Nonnull)queryRenderedFeaturesWithRect:(CGRect)rect options:(MBMRenderedQueryOptions * _Nullable)options completion:(void (^ _Nullable)(NSArray<MBMQueriedRenderedFeature *> * _Nullable, NSError * _Nullable))completion;
        [Export("queryRenderedFeaturesWithRect:options:completion:")]
        TMBCancelable QueryRenderedFeaturesWithRect(CGRect rect, [NullAllowed] MBMRenderedQueryOptions options, [NullAllowed] Action<NSArray<MBMQueriedRenderedFeature>, NSError> completion);

        // -(TMBCancelable * _Nonnull)queryRenderedFeaturesWithPoint:(CGPoint)point options:(MBMRenderedQueryOptions * _Nullable)options completion:(void (^ _Nullable)(NSArray<MBMQueriedRenderedFeature *> * _Nullable, NSError * _Nullable))completion;
        [Export("queryRenderedFeaturesWithPoint:options:completion:")]
        TMBCancelable QueryRenderedFeaturesWithPoint(CGPoint point, [NullAllowed] MBMRenderedQueryOptions options, [NullAllowed] Action<NSArray<MBMQueriedRenderedFeature>, NSError> completion);

        // -(void)querySourceFeaturesFor:(NSString * _Nonnull)sourceId options:(MBMSourceQueryOptions * _Nonnull)options completion:(void (^ _Nullable)(NSArray<MBMQueriedSourceFeature *> * _Nullable, NSError * _Nullable))completion;
        [Export("querySourceFeaturesFor:options:completion:")]
        void QuerySourceFeaturesFor(string sourceId, MBMSourceQueryOptions options, [NullAllowed] Action<NSArray<MBMQueriedSourceFeature>, NSError> completion);

        // -(void)getGeoJsonClusterLeavesForSourceId:(NSString * _Nonnull)sourceId feature:(MBXFeature * _Nonnull)feature limit:(uint64_t)limit offset:(uint64_t)offset completion:(void (^ _Nonnull)(MBMFeatureExtensionValue * _Nullable, NSError * _Nullable))completion;
        [Export("getGeoJsonClusterLeavesForSourceId:feature:limit:offset:completion:")]
        void GetGeoJsonClusterLeavesForSourceId(string sourceId, MBXFeature feature, ulong limit, ulong offset, Action<MBMFeatureExtensionValue, NSError> completion);

        // -(void)getGeoJsonClusterChildrenForSourceId:(NSString * _Nonnull)sourceId feature:(MBXFeature * _Nonnull)feature completion:(void (^ _Nonnull)(MBMFeatureExtensionValue * _Nullable, NSError * _Nullable))completion;
        [Export("getGeoJsonClusterChildrenForSourceId:feature:completion:")]
        void GetGeoJsonClusterChildrenForSourceId(string sourceId, MBXFeature feature, Action<MBMFeatureExtensionValue, NSError> completion);

        // -(void)getGeoJsonClusterExpansionZoomForSourceId:(NSString * _Nonnull)sourceId feature:(MBXFeature * _Nonnull)feature completion:(void (^ _Nonnull)(MBMFeatureExtensionValue * _Nullable, NSError * _Nullable))completion;
        [Export("getGeoJsonClusterExpansionZoomForSourceId:feature:completion:")]
        void GetGeoJsonClusterExpansionZoomForSourceId(string sourceId, MBXFeature feature, Action<MBMFeatureExtensionValue, NSError> completion);
    }

    // @interface MapboxMapObjC_Swift_4859 (TMBMapboxMap)
    [Category]
    [BaseType(typeof(TMBMapboxMap))]
    interface TMBMapboxMap_MapboxMapObjC_Swift_4859
    {
        // -(TMBCancelable * _Nonnull)onMapLoaded:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onMapLoaded:")]
        TMBCancelable OnMapLoaded(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onMapLoadingError:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onMapLoadingError:")]
        TMBCancelable OnMapLoadingError(Action<MBMMapLoadingError> handler);

        // -(TMBCancelable * _Nonnull)onStyleLoaded:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onStyleLoaded:")]
        TMBCancelable OnStyleLoaded(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onStyleDataLoaded:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onStyleDataLoaded:")]
        TMBCancelable OnStyleDataLoaded(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onCameraChanged:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onCameraChanged:")]
        TMBCancelable OnCameraChanged(Action<TMBCameraChanged> handler);

        // -(TMBCancelable * _Nonnull)onMapIdle:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onMapIdle:")]
        TMBCancelable OnMapIdle(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onSourceAdded:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onSourceAdded:")]
        TMBCancelable OnSourceAdded(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onSourceRemoved:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onSourceRemoved:")]
        TMBCancelable OnSourceRemoved(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onSourceDataLoaded:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onSourceDataLoaded:")]
        TMBCancelable OnSourceDataLoaded(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onStyleImageMissing:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onStyleImageMissing:")]
        TMBCancelable OnStyleImageMissing(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onStyleImageRemoveUnused:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onStyleImageRemoveUnused:")]
        TMBCancelable OnStyleImageRemoveUnused(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onRenderFrameStarted:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onRenderFrameStarted:")]
        TMBCancelable OnRenderFrameStarted(Action<NSObject> handler);

        // -(TMBCancelable * _Nonnull)onRenderFrameFinished:(void (^ _Nonnull)(id _Nonnull))handler;
        [Export("onRenderFrameFinished:")]
        TMBCancelable OnRenderFrameFinished(Action<NSObject> handler);
    }

    // @interface TMBModel : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC8TMBModel")]
    [DisableDefaultCtor]
    interface TMBModel
    {
        // @property (copy, nonatomic) NSURL * _Nullable uri;
        [NullAllowed, Export("uri", ArgumentSemantic.Copy)]
        NSUrl Uri { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable position;
        [NullAllowed, Export("position", ArgumentSemantic.Copy)]
        NSNumber[] Position { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable orientation;
        [NullAllowed, Export("orientation", ArgumentSemantic.Copy)]
        NSNumber[] Orientation { get; set; }

        // -(instancetype _Nonnull)initWithUri:(NSURL * _Nullable)uri position:(NSArray<NSNumber *> * _Nullable)position orientation:(NSArray<NSNumber *> * _Nullable)orientation __attribute__((objc_designated_initializer));
        [Export("initWithUri:position:orientation:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] NSUrl uri, [NullAllowed] NSNumber[] position, [NullAllowed] NSNumber[] orientation);
    }

    // @interface TMBModelScaleMode : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC17TMBModelScaleMode")]
    [DisableDefaultCtor]
    interface TMBModelScaleMode
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBModelScaleMode * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBModelScaleMode Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBModelScaleMode * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBModelScaleMode Viewport { get; }
    }

    // @interface TMBModelType : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC12TMBModelType")]
    [DisableDefaultCtor]
    interface TMBModelType
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBModelType * _Nonnull common3d;
        [Static]
        [Export("common3d", ArgumentSemantic.Strong)]
        TMBModelType Common3d { get; }

        // @property (readonly, nonatomic, strong, class) TMBModelType * _Nonnull locationIndicator;
        [Static]
        [Export("locationIndicator", ArgumentSemantic.Strong)]
        TMBModelType LocationIndicator { get; }
    }

    // @interface TMBNumberFormatOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBNumberFormatOptions")]
    [DisableDefaultCtor]
    interface TMBNumberFormatOptions
    {
    }

    // @interface TMBOrnamentOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBOrnamentOptions")]
    [DisableDefaultCtor]
    interface TMBOrnamentOptions
    {
        // @property (nonatomic, strong) TMBScaleBarViewOptions * _Nonnull scaleBar;
        [Export("scaleBar", ArgumentSemantic.Strong)]
        TMBScaleBarViewOptions ScaleBar { get; set; }

        // @property (nonatomic, strong) TMBCompassViewOptions * _Nonnull compass;
        [Export("compass", ArgumentSemantic.Strong)]
        TMBCompassViewOptions Compass { get; set; }

        // @property (nonatomic, strong) TMBLogoViewOptions * _Nonnull logo;
        [Export("logo", ArgumentSemantic.Strong)]
        TMBLogoViewOptions Logo { get; set; }

        // @property (nonatomic, strong) TMBAttributionButtonOptions * _Nonnull attributionButton;
        [Export("attributionButton", ArgumentSemantic.Strong)]
        TMBAttributionButtonOptions AttributionButton { get; set; }

        // -(instancetype _Nonnull)initWithScaleBar:(TMBScaleBarViewOptions * _Nonnull)scaleBar compass:(TMBCompassViewOptions * _Nonnull)compass logo:(TMBLogoViewOptions * _Nonnull)logo attributionButton:(TMBAttributionButtonOptions * _Nonnull)attributionButton __attribute__((objc_designated_initializer));
        [Export("initWithScaleBar:compass:logo:attributionButton:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBScaleBarViewOptions scaleBar, TMBCompassViewOptions compass, TMBLogoViewOptions logo, TMBAttributionButtonOptions attributionButton);
    }

    // @interface TMBOrnamentsManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC19TMBOrnamentsManager")]
    [DisableDefaultCtor]
    interface TMBOrnamentsManager
    {
        // @property (nonatomic, strong) TMBOrnamentOptions * _Nonnull options;
        [Export("options", ArgumentSemantic.Strong)]
        TMBOrnamentOptions Options { get; set; }

        // @property (readonly, nonatomic, strong) UIView * _Nonnull logoView;
        [Export("logoView", ArgumentSemantic.Strong)]
        UIView LogoView { get; }

        // @property (readonly, nonatomic, strong) UIView * _Nonnull scaleBarView;
        [Export("scaleBarView", ArgumentSemantic.Strong)]
        UIView ScaleBarView { get; }

        // @property (readonly, nonatomic, strong) UIView * _Nonnull compassView;
        [Export("compassView", ArgumentSemantic.Strong)]
        UIView CompassView { get; }

        // @property (readonly, nonatomic, strong) UIView * _Nonnull attributionButton;
        [Export("attributionButton", ArgumentSemantic.Strong)]
        UIView AttributionButton { get; }
    }

    // @interface TMBPoint : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC8TMBPoint")]
    [DisableDefaultCtor]
    interface TMBPoint
    {
        // @property (readonly, nonatomic) CLLocationCoordinate2D coordinates;
        [Export("coordinates")]
        CLLocationCoordinate2D Coordinates { get; }

        // -(instancetype _Nonnull)init:(CLLocationCoordinate2D)coordinates __attribute__((objc_designated_initializer));
        [Export("init:")]
        [DesignatedInitializer]
        NativeHandle Constructor(CLLocationCoordinate2D coordinates);
    }

    // @interface TMBPointAnnotation : NSObject <TMBAnnotation>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBPointAnnotation")]
    [DisableDefaultCtor]
    interface TMBPointAnnotation : TMBAnnotation
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) MBXGeometry * _Nonnull geometry;
        [Export("geometry", ArgumentSemantic.Strong)]
        MBXGeometry Geometry { get; }

        // @property (nonatomic, strong) TMBPoint * _Nonnull point;
        [Export("point", ArgumentSemantic.Strong)]
        TMBPoint Point { get; set; }

        // @property (nonatomic) BOOL isSelected;
        [Export("isSelected")]
        bool IsSelected { get; set; }

        // @property (nonatomic) BOOL isDraggable;
        [Export("isDraggable")]
        bool IsDraggable { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(TMBMapContentGestureContext * _Nonnull) tapHandler;
        [NullAllowed, Export("tapHandler", ArgumentSemantic.Copy)]
        Func<TMBMapContentGestureContext, bool> TapHandler { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(TMBMapContentGestureContext * _Nonnull) longPressHandler;
        [NullAllowed, Export("longPressHandler", ArgumentSemantic.Copy)]
        Func<TMBMapContentGestureContext, bool> LongPressHandler { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable userInfo;
        [NullAllowed, Export("userInfo", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> UserInfo { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id point:(TMBPoint * _Nonnull)point isSelected:(BOOL)isSelected isDraggable:(BOOL)isDraggable __attribute__((objc_designated_initializer));
        [Export("initWithId:point:isSelected:isDraggable:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, TMBPoint point, bool isSelected, bool isDraggable);

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id coordinate:(CLLocationCoordinate2D)coordinate isSelected:(BOOL)isSelected isDraggable:(BOOL)isDraggable __attribute__((objc_designated_initializer));
        [Export("initWithId:coordinate:isSelected:isDraggable:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, CLLocationCoordinate2D coordinate, bool isSelected, bool isDraggable);

        // @property (nonatomic, strong) TMBIconAnchor * _Nullable iconAnchor;
        [NullAllowed, Export("iconAnchor", ArgumentSemantic.Strong)]
        TMBIconAnchor IconAnchor { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable iconImage;
        [NullAllowed, Export("iconImage")]
        string IconImage { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable iconOffset;
        [NullAllowed, Export("iconOffset", ArgumentSemantic.Copy)]
        NSNumber[] IconOffset { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconRotate;
        [NullAllowed, Export("iconRotate", ArgumentSemantic.Strong)]
        NSNumber IconRotate { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconSize;
        [NullAllowed, Export("iconSize", ArgumentSemantic.Strong)]
        NSNumber IconSize { get; set; }

        // @property (nonatomic, strong) TMBIconTextFit * _Nullable iconTextFit;
        [NullAllowed, Export("iconTextFit", ArgumentSemantic.Strong)]
        TMBIconTextFit IconTextFit { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable iconTextFitPadding;
        [NullAllowed, Export("iconTextFitPadding", ArgumentSemantic.Copy)]
        NSNumber[] IconTextFitPadding { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable symbolSortKey;
        [NullAllowed, Export("symbolSortKey", ArgumentSemantic.Strong)]
        NSNumber SymbolSortKey { get; set; }

        // @property (nonatomic, strong) TMBTextAnchor * _Nullable textAnchor;
        [NullAllowed, Export("textAnchor", ArgumentSemantic.Strong)]
        TMBTextAnchor TextAnchor { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable textField;
        [NullAllowed, Export("textField")]
        string TextField { get; set; }

        // @property (nonatomic, strong) TMBTextJustify * _Nullable textJustify;
        [NullAllowed, Export("textJustify", ArgumentSemantic.Strong)]
        TMBTextJustify TextJustify { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textLetterSpacing;
        [NullAllowed, Export("textLetterSpacing", ArgumentSemantic.Strong)]
        NSNumber TextLetterSpacing { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textLineHeight;
        [NullAllowed, Export("textLineHeight", ArgumentSemantic.Strong)]
        NSNumber TextLineHeight { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textMaxWidth;
        [NullAllowed, Export("textMaxWidth", ArgumentSemantic.Strong)]
        NSNumber TextMaxWidth { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable textOffset;
        [NullAllowed, Export("textOffset", ArgumentSemantic.Copy)]
        NSNumber[] TextOffset { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textRadialOffset;
        [NullAllowed, Export("textRadialOffset", ArgumentSemantic.Strong)]
        NSNumber TextRadialOffset { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textRotate;
        [NullAllowed, Export("textRotate", ArgumentSemantic.Strong)]
        NSNumber TextRotate { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textSize;
        [NullAllowed, Export("textSize", ArgumentSemantic.Strong)]
        NSNumber TextSize { get; set; }

        // @property (nonatomic, strong) TMBTextTransform * _Nullable textTransform;
        [NullAllowed, Export("textTransform", ArgumentSemantic.Strong)]
        TMBTextTransform TextTransform { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable iconColor;
        [NullAllowed, Export("iconColor", ArgumentSemantic.Strong)]
        UIColor IconColor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconEmissiveStrength;
        [NullAllowed, Export("iconEmissiveStrength", ArgumentSemantic.Strong)]
        NSNumber IconEmissiveStrength { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconHaloBlur;
        [NullAllowed, Export("iconHaloBlur", ArgumentSemantic.Strong)]
        NSNumber IconHaloBlur { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable iconHaloColor;
        [NullAllowed, Export("iconHaloColor", ArgumentSemantic.Strong)]
        UIColor IconHaloColor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconHaloWidth;
        [NullAllowed, Export("iconHaloWidth", ArgumentSemantic.Strong)]
        NSNumber IconHaloWidth { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconImageCrossFade;
        [NullAllowed, Export("iconImageCrossFade", ArgumentSemantic.Strong)]
        NSNumber IconImageCrossFade { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconOpacity;
        [NullAllowed, Export("iconOpacity", ArgumentSemantic.Strong)]
        NSNumber IconOpacity { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable textColor;
        [NullAllowed, Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textEmissiveStrength;
        [NullAllowed, Export("textEmissiveStrength", ArgumentSemantic.Strong)]
        NSNumber TextEmissiveStrength { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textHaloBlur;
        [NullAllowed, Export("textHaloBlur", ArgumentSemantic.Strong)]
        NSNumber TextHaloBlur { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable textHaloColor;
        [NullAllowed, Export("textHaloColor", ArgumentSemantic.Strong)]
        UIColor TextHaloColor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textHaloWidth;
        [NullAllowed, Export("textHaloWidth", ArgumentSemantic.Strong)]
        NSNumber TextHaloWidth { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textOpacity;
        [NullAllowed, Export("textOpacity", ArgumentSemantic.Strong)]
        NSNumber TextOpacity { get; set; }

        // @property (nonatomic, strong) TMBPointAnnotationImage * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        TMBPointAnnotationImage Image { get; set; }
    }

    // @interface TMBPointAnnotationImage : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC23TMBPointAnnotationImage")]
    [DisableDefaultCtor]
    interface TMBPointAnnotationImage
    {
        // @property (nonatomic, strong) UIImage * _Nonnull image;
        [Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; set; }

        // -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image name:(NSString * _Nonnull)name __attribute__((objc_designated_initializer));
        [Export("initWithImage:name:")]
        [DesignatedInitializer]
        NativeHandle Constructor(UIImage image, string name);
    }

    // @interface TMBPointAnnotationManager : NSObject <TMBAnnotationManager>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC25TMBPointAnnotationManager")]
    [DisableDefaultCtor]
    partial interface TMBPointAnnotationManager : TMBAnnotationManager
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull sourceId;
        [Export("sourceId")]
        string SourceId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull layerId;
        [Export("layerId")]
        string LayerId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (copy, nonatomic) NSArray<TMBPointAnnotation *> * _Nonnull annotations;
        [Export("annotations", ArgumentSemantic.Copy)]
        TMBPointAnnotation[] Annotations { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconAllowOverlap;
        [NullAllowed, Export("iconAllowOverlap", ArgumentSemantic.Strong)]
        NSNumber IconAllowOverlap { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconIgnorePlacement;
        [NullAllowed, Export("iconIgnorePlacement", ArgumentSemantic.Strong)]
        NSNumber IconIgnorePlacement { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconKeepUpright;
        [NullAllowed, Export("iconKeepUpright", ArgumentSemantic.Strong)]
        NSNumber IconKeepUpright { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconOptional;
        [NullAllowed, Export("iconOptional", ArgumentSemantic.Strong)]
        NSNumber IconOptional { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable iconPadding;
        [NullAllowed, Export("iconPadding", ArgumentSemantic.Strong)]
        NSNumber IconPadding { get; set; }

        // @property (nonatomic, strong) TMBIconPitchAlignment * _Nullable iconPitchAlignment;
        [NullAllowed, Export("iconPitchAlignment", ArgumentSemantic.Strong)]
        TMBIconPitchAlignment IconPitchAlignment { get; set; }

        // @property (nonatomic, strong) TMBIconRotationAlignment * _Nullable iconRotationAlignment;
        [NullAllowed, Export("iconRotationAlignment", ArgumentSemantic.Strong)]
        TMBIconRotationAlignment IconRotationAlignment { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable symbolAvoidEdges;
        [NullAllowed, Export("symbolAvoidEdges", ArgumentSemantic.Strong)]
        NSNumber SymbolAvoidEdges { get; set; }

        // @property (nonatomic, strong) TMBSymbolPlacement * _Nullable symbolPlacement;
        [NullAllowed, Export("symbolPlacement", ArgumentSemantic.Strong)]
        TMBSymbolPlacement SymbolPlacement { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable symbolSpacing;
        [NullAllowed, Export("symbolSpacing", ArgumentSemantic.Strong)]
        NSNumber SymbolSpacing { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable symbolZElevate;
        [NullAllowed, Export("symbolZElevate", ArgumentSemantic.Strong)]
        NSNumber SymbolZElevate { get; set; }

        // @property (nonatomic, strong) TMBSymbolZOrder * _Nullable symbolZOrder;
        [NullAllowed, Export("symbolZOrder", ArgumentSemantic.Strong)]
        TMBSymbolZOrder SymbolZOrder { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textAllowOverlap;
        [NullAllowed, Export("textAllowOverlap", ArgumentSemantic.Strong)]
        NSNumber TextAllowOverlap { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable textFont;
        [NullAllowed, Export("textFont", ArgumentSemantic.Copy)]
        string[] TextFont { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textIgnorePlacement;
        [NullAllowed, Export("textIgnorePlacement", ArgumentSemantic.Strong)]
        NSNumber TextIgnorePlacement { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textKeepUpright;
        [NullAllowed, Export("textKeepUpright", ArgumentSemantic.Strong)]
        NSNumber TextKeepUpright { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textMaxAngle;
        [NullAllowed, Export("textMaxAngle", ArgumentSemantic.Strong)]
        NSNumber TextMaxAngle { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textOptional;
        [NullAllowed, Export("textOptional", ArgumentSemantic.Strong)]
        NSNumber TextOptional { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable textPadding;
        [NullAllowed, Export("textPadding", ArgumentSemantic.Strong)]
        NSNumber TextPadding { get; set; }

        // @property (nonatomic, strong) TMBTextPitchAlignment * _Nullable textPitchAlignment;
        [NullAllowed, Export("textPitchAlignment", ArgumentSemantic.Strong)]
        TMBTextPitchAlignment TextPitchAlignment { get; set; }

        // @property (nonatomic, strong) TMBTextRotationAlignment * _Nullable textRotationAlignment;
        [NullAllowed, Export("textRotationAlignment", ArgumentSemantic.Strong)]
        TMBTextRotationAlignment TextRotationAlignment { get; set; }

        // @property (copy, nonatomic) NSArray<TMBTextAnchor *> * _Nullable textVariableAnchor;
        [NullAllowed, Export("textVariableAnchor", ArgumentSemantic.Copy)]
        TMBTextAnchor[] TextVariableAnchor { get; set; }

        // @property (copy, nonatomic) NSArray<TMBTextWritingMode *> * _Nullable textWritingMode;
        [NullAllowed, Export("textWritingMode", ArgumentSemantic.Copy)]
        TMBTextWritingMode[] TextWritingMode { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable iconTranslate;
        [NullAllowed, Export("iconTranslate", ArgumentSemantic.Copy)]
        NSNumber[] IconTranslate { get; set; }

        // @property (nonatomic, strong) TMBIconTranslateAnchor * _Nullable iconTranslateAnchor;
        [NullAllowed, Export("iconTranslateAnchor", ArgumentSemantic.Strong)]
        TMBIconTranslateAnchor IconTranslateAnchor { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable textTranslate;
        [NullAllowed, Export("textTranslate", ArgumentSemantic.Copy)]
        NSNumber[] TextTranslate { get; set; }

        // @property (nonatomic, strong) TMBTextTranslateAnchor * _Nullable textTranslateAnchor;
        [NullAllowed, Export("textTranslateAnchor", ArgumentSemantic.Strong)]
        TMBTextTranslateAnchor TextTranslateAnchor { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable slot;
        [NullAllowed, Export("slot")]
        string Slot { get; set; }
    }

    // @interface TMBPolygon : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC10TMBPolygon")]
    [DisableDefaultCtor]
    interface TMBPolygon
    {
        // @property (readonly, copy, nonatomic) NSArray<NSArray<NSValue *> *> * _Nonnull coordinates;
        [Export("coordinates", ArgumentSemantic.Copy)]
        NSArray Coordinates { get; }

        // -(instancetype _Nonnull)init:(NSArray<NSArray<NSValue *> *> * _Nonnull)coordinates __attribute__((objc_designated_initializer));
        [Export("init:")]
        [DesignatedInitializer]
        NativeHandle Constructor(NSArray coordinates);

        // -(instancetype _Nonnull)initWithOuterRing:(TMBPolygonRing * _Nonnull)outerRing innerRings:(NSArray<TMBPolygonRing *> * _Nonnull)innerRings __attribute__((objc_designated_initializer));
        [Export("initWithOuterRing:innerRings:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBPolygonRing outerRing, TMBPolygonRing[] innerRings);

        // -(instancetype _Nonnull)initWithCenter:(CLLocationCoordinate2D)center radius:(CLLocationDistance)radius vertices:(NSInteger)vertices __attribute__((objc_designated_initializer));
        [Export("initWithCenter:radius:vertices:")]
        [DesignatedInitializer]
        NativeHandle Constructor(CLLocationCoordinate2D center, double radius, nint vertices);
    }

    // @interface TMBPolygonAnnotation : NSObject <TMBAnnotation>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC20TMBPolygonAnnotation")]
    [DisableDefaultCtor]
    interface TMBPolygonAnnotation : TMBAnnotation
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) MBXGeometry * _Nonnull geometry;
        [Export("geometry", ArgumentSemantic.Strong)]
        MBXGeometry Geometry { get; }

        // @property (nonatomic, strong) TMBPolygon * _Nonnull polygon;
        [Export("polygon", ArgumentSemantic.Strong)]
        TMBPolygon Polygon { get; set; }

        // @property (nonatomic) BOOL isSelected;
        [Export("isSelected")]
        bool IsSelected { get; set; }

        // @property (nonatomic) BOOL isDraggable;
        [Export("isDraggable")]
        bool IsDraggable { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(TMBMapContentGestureContext * _Nonnull) tapHandler;
        [NullAllowed, Export("tapHandler", ArgumentSemantic.Copy)]
        Func<TMBMapContentGestureContext, bool> TapHandler { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(TMBMapContentGestureContext * _Nonnull) longPressHandler;
        [NullAllowed, Export("longPressHandler", ArgumentSemantic.Copy)]
        Func<TMBMapContentGestureContext, bool> LongPressHandler { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable userInfo;
        [NullAllowed, Export("userInfo", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> UserInfo { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id polygon:(TMBPolygon * _Nonnull)polygon isSelected:(BOOL)isSelected isDraggable:(BOOL)isDraggable __attribute__((objc_designated_initializer));
        [Export("initWithId:polygon:isSelected:isDraggable:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, TMBPolygon polygon, bool isSelected, bool isDraggable);

        // @property (nonatomic, strong) NSNumber * _Nullable fillSortKey;
        [NullAllowed, Export("fillSortKey", ArgumentSemantic.Strong)]
        NSNumber FillSortKey { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable fillColor;
        [NullAllowed, Export("fillColor", ArgumentSemantic.Strong)]
        UIColor FillColor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable fillOpacity;
        [NullAllowed, Export("fillOpacity", ArgumentSemantic.Strong)]
        NSNumber FillOpacity { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable fillOutlineColor;
        [NullAllowed, Export("fillOutlineColor", ArgumentSemantic.Strong)]
        UIColor FillOutlineColor { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable fillPattern;
        [NullAllowed, Export("fillPattern")]
        string FillPattern { get; set; }
    }

    // @interface TMBPolygonAnnotationManager : NSObject <TMBAnnotationManager>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC27TMBPolygonAnnotationManager")]
    [DisableDefaultCtor]
    partial interface TMBPolygonAnnotationManager : TMBAnnotationManager
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull sourceId;
        [Export("sourceId")]
        string SourceId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull layerId;
        [Export("layerId")]
        string LayerId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (copy, nonatomic) NSArray<TMBPolygonAnnotation *> * _Nonnull annotations;
        [Export("annotations", ArgumentSemantic.Copy)]
        TMBPolygonAnnotation[] Annotations { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable fillAntialias;
        [NullAllowed, Export("fillAntialias", ArgumentSemantic.Strong)]
        NSNumber FillAntialias { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable fillEmissiveStrength;
        [NullAllowed, Export("fillEmissiveStrength", ArgumentSemantic.Strong)]
        NSNumber FillEmissiveStrength { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable fillTranslate;
        [NullAllowed, Export("fillTranslate", ArgumentSemantic.Copy)]
        NSNumber[] FillTranslate { get; set; }

        // @property (nonatomic, strong) TMBFillTranslateAnchor * _Nullable fillTranslateAnchor;
        [NullAllowed, Export("fillTranslateAnchor", ArgumentSemantic.Strong)]
        TMBFillTranslateAnchor FillTranslateAnchor { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable slot;
        [NullAllowed, Export("slot")]
        string Slot { get; set; }
    }

    // @interface TMBPolygonRing : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14TMBPolygonRing")]
    [DisableDefaultCtor]
    interface TMBPolygonRing
    {
        // @property (copy, nonatomic) NSArray<NSValue *> * _Nonnull coordinates;
        [Export("coordinates", ArgumentSemantic.Copy)]
        NSValue[] Coordinates { get; set; }

        // -(instancetype _Nonnull)initWithCoordinates:(NSArray<NSValue *> * _Nonnull)coordinates __attribute__((objc_designated_initializer));
        [Export("initWithCoordinates:")]
        [DesignatedInitializer]
        NativeHandle Constructor(NSValue[] coordinates);
    }

    // @interface TMBPolylineAnnotation : NSObject <TMBAnnotation>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC21TMBPolylineAnnotation")]
    [DisableDefaultCtor]
    interface TMBPolylineAnnotation : TMBAnnotation
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) MBXGeometry * _Nonnull geometry;
        [Export("geometry", ArgumentSemantic.Strong)]
        MBXGeometry Geometry { get; }

        // @property (nonatomic, strong) TMBLineString * _Nonnull lineString;
        [Export("lineString", ArgumentSemantic.Strong)]
        TMBLineString LineString { get; set; }

        // @property (nonatomic) BOOL isSelected;
        [Export("isSelected")]
        bool IsSelected { get; set; }

        // @property (nonatomic) BOOL isDraggable;
        [Export("isDraggable")]
        bool IsDraggable { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(TMBMapContentGestureContext * _Nonnull) tapHandler;
        [NullAllowed, Export("tapHandler", ArgumentSemantic.Copy)]
        Func<TMBMapContentGestureContext, bool> TapHandler { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(TMBMapContentGestureContext * _Nonnull) longPressHandler;
        [NullAllowed, Export("longPressHandler", ArgumentSemantic.Copy)]
        Func<TMBMapContentGestureContext, bool> LongPressHandler { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable userInfo;
        [NullAllowed, Export("userInfo", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> UserInfo { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id lineString:(TMBLineString * _Nonnull)lineString isSelected:(BOOL)isSelected isDraggable:(BOOL)isDraggable __attribute__((objc_designated_initializer));
        [Export("initWithId:lineString:isSelected:isDraggable:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, TMBLineString lineString, bool isSelected, bool isDraggable);

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id lineCoordinates:(NSArray<NSValue *> * _Nonnull)lineCoordinates isSelected:(BOOL)isSelected isDraggable:(BOOL)isDraggable __attribute__((objc_designated_initializer));
        [Export("initWithId:lineCoordinates:isSelected:isDraggable:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, NSValue[] lineCoordinates, bool isSelected, bool isDraggable);

        // @property (nonatomic, strong) TMBLineJoin * _Nullable lineJoin;
        [NullAllowed, Export("lineJoin", ArgumentSemantic.Strong)]
        TMBLineJoin LineJoin { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineSortKey;
        [NullAllowed, Export("lineSortKey", ArgumentSemantic.Strong)]
        NSNumber LineSortKey { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineBlur;
        [NullAllowed, Export("lineBlur", ArgumentSemantic.Strong)]
        NSNumber LineBlur { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable lineBorderColor;
        [NullAllowed, Export("lineBorderColor", ArgumentSemantic.Strong)]
        UIColor LineBorderColor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineBorderWidth;
        [NullAllowed, Export("lineBorderWidth", ArgumentSemantic.Strong)]
        NSNumber LineBorderWidth { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable lineColor;
        [NullAllowed, Export("lineColor", ArgumentSemantic.Strong)]
        UIColor LineColor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineGapWidth;
        [NullAllowed, Export("lineGapWidth", ArgumentSemantic.Strong)]
        NSNumber LineGapWidth { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineOffset;
        [NullAllowed, Export("lineOffset", ArgumentSemantic.Strong)]
        NSNumber LineOffset { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineOpacity;
        [NullAllowed, Export("lineOpacity", ArgumentSemantic.Strong)]
        NSNumber LineOpacity { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable linePattern;
        [NullAllowed, Export("linePattern")]
        string LinePattern { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineWidth;
        [NullAllowed, Export("lineWidth", ArgumentSemantic.Strong)]
        NSNumber LineWidth { get; set; }
    }

    // @interface TMBPolylineAnnotationManager : NSObject <TMBAnnotationManager>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC28TMBPolylineAnnotationManager")]
    [DisableDefaultCtor]
    partial interface TMBPolylineAnnotationManager : TMBAnnotationManager
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull sourceId;
        [Export("sourceId")]
        string SourceId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull layerId;
        [Export("layerId")]
        string LayerId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (copy, nonatomic) NSArray<TMBPolylineAnnotation *> * _Nonnull annotations;
        [Export("annotations", ArgumentSemantic.Copy)]
        TMBPolylineAnnotation[] Annotations { get; set; }

        // @property (nonatomic, strong) TMBLineCap * _Nullable lineCap;
        [NullAllowed, Export("lineCap", ArgumentSemantic.Strong)]
        TMBLineCap LineCap { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineMiterLimit;
        [NullAllowed, Export("lineMiterLimit", ArgumentSemantic.Strong)]
        NSNumber LineMiterLimit { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineRoundLimit;
        [NullAllowed, Export("lineRoundLimit", ArgumentSemantic.Strong)]
        NSNumber LineRoundLimit { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable lineDasharray;
        [NullAllowed, Export("lineDasharray", ArgumentSemantic.Copy)]
        NSNumber[] LineDasharray { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineDepthOcclusionFactor;
        [NullAllowed, Export("lineDepthOcclusionFactor", ArgumentSemantic.Strong)]
        NSNumber LineDepthOcclusionFactor { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable lineEmissiveStrength;
        [NullAllowed, Export("lineEmissiveStrength", ArgumentSemantic.Strong)]
        NSNumber LineEmissiveStrength { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable lineTranslate;
        [NullAllowed, Export("lineTranslate", ArgumentSemantic.Copy)]
        NSNumber[] LineTranslate { get; set; }

        // @property (nonatomic, strong) TMBLineTranslateAnchor * _Nullable lineTranslateAnchor;
        [NullAllowed, Export("lineTranslateAnchor", ArgumentSemantic.Strong)]
        TMBLineTranslateAnchor LineTranslateAnchor { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable lineTrimOffset;
        [NullAllowed, Export("lineTrimOffset", ArgumentSemantic.Copy)]
        NSNumber[] LineTrimOffset { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable slot;
        [NullAllowed, Export("slot")]
        string Slot { get; set; }
    }

    // @interface TMBProjection : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBProjection")]
    interface TMBProjection
    {
        // @property (readonly, nonatomic, class) CLLocationDegrees latitudeMax;
        [Static]
        [Export("latitudeMax")]
        double LatitudeMax { get; }

        // @property (readonly, nonatomic, class) CLLocationDegrees latitudeMin;
        [Static]
        [Export("latitudeMin")]
        double LatitudeMin { get; }

        // +(double)metersPerPointFor:(CLLocationDegrees)latitude zoom:(CGFloat)zoom __attribute__((warn_unused_result("")));
        [Static]
        [Export("metersPerPointFor:zoom:")]
        double MetersPerPointFor(double latitude, nfloat zoom);

        // +(MBMProjectedMeters * _Nonnull)projectedMetersFor:(CLLocationCoordinate2D)coordinate __attribute__((warn_unused_result("")));
        [Static]
        [Export("projectedMetersFor:")]
        MBMProjectedMeters ProjectedMetersFor(CLLocationCoordinate2D coordinate);

        // +(CLLocationCoordinate2D)coordinateFor:(MBMProjectedMeters * _Nonnull)projectedMeters __attribute__((warn_unused_result("")));
        [Static]
        [Export("coordinateFor:")]
        CLLocationCoordinate2D CoordinateFor(MBMProjectedMeters projectedMeters);

        // +(MBMMercatorCoordinate * _Nonnull)project:(CLLocationCoordinate2D)coordinate zoomScale:(CGFloat)zoomScale __attribute__((warn_unused_result("")));
        [Static]
        [Export("project:zoomScale:")]
        MBMMercatorCoordinate Project(CLLocationCoordinate2D coordinate, nfloat zoomScale);

        // +(CLLocationCoordinate2D)unproject:(MBMMercatorCoordinate * _Nonnull)mercatorCoordinate zoomScale:(CGFloat)zoomScale __attribute__((warn_unused_result("")));
        [Static]
        [Export("unproject:zoomScale:")]
        CLLocationCoordinate2D Unproject(MBMMercatorCoordinate mercatorCoordinate, nfloat zoomScale);
    }

    // @interface TMBPromoteId : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC12TMBPromoteId")]
    [DisableDefaultCtor]
    interface TMBPromoteId
    {
        // @property (readonly, nonatomic) enum TMBPromoteIdType type;
        [Export("type")]
        TMBPromoteIdType Type { get; }

        // +(TMBPromoteId * _Nonnull)string:(NSString * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("string:")]
        TMBPromoteId String(string value);

        // +(TMBPromoteId * _Nonnull)object:(NSDictionary<NSString *,NSString *> * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("object:")]
        TMBPromoteId Object(NSDictionary<NSString, NSString> value);
    }

    // @protocol TMBPuckTypeConfiguration
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface ITMBPuckTypeConfiguration { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC24TMBPuckTypeConfiguration_")]
    [BaseType(typeof(NSObject))]
    interface TMBPuckTypeConfiguration
    {
    }

    // @interface TMBPuck2DConfiguration : NSObject <TMBPuckTypeConfiguration>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBPuck2DConfiguration")]
    [DisableDefaultCtor]
    interface TMBPuck2DConfiguration : TMBPuckTypeConfiguration
    {
        // @property (nonatomic) double opacity;
        [Export("opacity")]
        double Opacity { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable topImage;
        [NullAllowed, Export("topImage", ArgumentSemantic.Strong)]
        UIImage TopImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable bearingImage;
        [NullAllowed, Export("bearingImage", ArgumentSemantic.Strong)]
        UIImage BearingImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable shadowImage;
        [NullAllowed, Export("shadowImage", ArgumentSemantic.Strong)]
        UIImage ShadowImage { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable scale;
        [NullAllowed, Export("scale", ArgumentSemantic.Strong)]
        TMBValue Scale { get; set; }

        // @property (nonatomic, strong) TMBPuck2DConfigurationPulsing * _Nullable pulsing;
        [NullAllowed, Export("pulsing", ArgumentSemantic.Strong)]
        TMBPuck2DConfigurationPulsing Pulsing { get; set; }

        // @property (nonatomic) BOOL showsAccuracyRing;
        [Export("showsAccuracyRing")]
        bool ShowsAccuracyRing { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull accuracyRingColor;
        [Export("accuracyRingColor", ArgumentSemantic.Strong)]
        UIColor AccuracyRingColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull accuracyRingBorderColor;
        [Export("accuracyRingBorderColor", ArgumentSemantic.Strong)]
        UIColor AccuracyRingBorderColor { get; set; }

        // -(instancetype _Nonnull)initWithTopImage:(UIImage * _Nullable)topImage bearingImage:(UIImage * _Nullable)bearingImage shadowImage:(UIImage * _Nullable)shadowImage scale:(TMBValue * _Nullable)scale pulsing:(TMBPuck2DConfigurationPulsing * _Nullable)pulsing showsAccuracyRing:(BOOL)showsAccuracyRing opacity:(double)opacity __attribute__((objc_designated_initializer));
        [Export("initWithTopImage:bearingImage:shadowImage:scale:pulsing:showsAccuracyRing:opacity:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] UIImage topImage, [NullAllowed] UIImage bearingImage, [NullAllowed] UIImage shadowImage, [NullAllowed] TMBValue scale, [NullAllowed] TMBPuck2DConfigurationPulsing pulsing, bool showsAccuracyRing, double opacity);

        // -(instancetype _Nonnull)initWithTopImage:(UIImage * _Nullable)topImage bearingImage:(UIImage * _Nullable)bearingImage shadowImage:(UIImage * _Nullable)shadowImage scale:(TMBValue * _Nullable)scale showsAccuracyRing:(BOOL)showsAccuracyRing accuracyRingColor:(UIColor * _Nonnull)accuracyRingColor accuracyRingBorderColor:(UIColor * _Nonnull)accuracyRingBorderColor opacity:(double)opacity __attribute__((objc_designated_initializer));
        [Export("initWithTopImage:bearingImage:shadowImage:scale:showsAccuracyRing:accuracyRingColor:accuracyRingBorderColor:opacity:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] UIImage topImage, [NullAllowed] UIImage bearingImage, [NullAllowed] UIImage shadowImage, [NullAllowed] TMBValue scale, bool showsAccuracyRing, UIColor accuracyRingColor, UIColor accuracyRingBorderColor, double opacity);

        // + (TMBPuck2DConfiguration * _Nonnull)makeDefaultWithShowBearing:(BOOL)showBearing SWIFT_WARN_UNUSED_RESULT;
        [Export("makeDefaultWithShowBearing:"), Static]
        TMBPuck2DConfiguration MakeDefaultWithShowBearing(bool showBearing);
    }

    // @interface TMBPuck2DConfigurationPulsing : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC29TMBPuck2DConfigurationPulsing")]
    [DisableDefaultCtor]
    interface TMBPuck2DConfigurationPulsing
    {
        // + (TMBPuck2DConfigurationPulsing * _Nonnull)default SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("default")]
        TMBPuck2DConfigurationPulsing Default();

        // /// Flag determining whether the pulsing circle animation. <code>true</code> by default.
        // @property (nonatomic) BOOL isEnabled;
        [Export("isEnabled")]
        bool IsEnabled { get; set; }

        // /// The color of the pulsing circle.
        // @property (nonatomic, strong) UIColor * _Nonnull color;
        [Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // /// The radius of the pulsing circle.
        // @property (nonatomic, strong) TMBPuck2DConfigurationPulsingRadius * _Nonnull radius;
        [Export("radius", ArgumentSemantic.Strong)]
        TMBPuck2DConfigurationPulsingRadius Radius { get; set; }

        // -(instancetype _Nonnull)initWithColor:(UIColor * _Nonnull)color radius:(TMBPuck2DConfigurationPulsingRadius * _Nonnull)radius __attribute__((objc_designated_initializer));
        [Export("initWithColor:radius:")]
        [DesignatedInitializer]
        NativeHandle Constructor(UIColor color, TMBPuck2DConfigurationPulsingRadius radius);
    }

    // @interface TMBPuck2DConfigurationPulsingRadius : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC35TMBPuck2DConfigurationPulsingRadius")]
    [DisableDefaultCtor]
    interface TMBPuck2DConfigurationPulsingRadius
    {
        // @property (readonly, nonatomic, strong) NSNumber * _Nullable constant;
        [NullAllowed, Export("constant", ArgumentSemantic.Strong)]
        NSNumber Constant { get; }

        // + (TMBPuck2DConfigurationPulsingRadius * _Nonnull)accuracy SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("accuracy")]
        TMBPuck2DConfigurationPulsingRadius Accuracy { get; }

        // + (TMBPuck2DConfigurationPulsingRadius * _Nonnull)fromConstant:(double)constant SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("fromConstant:")]
        TMBPuck2DConfigurationPulsingRadius FromConstant(double constant);
    }

    // @interface TMBPuck3DConfiguration : NSObject <TMBPuckTypeConfiguration>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBPuck3DConfiguration")]
    [DisableDefaultCtor]
    interface TMBPuck3DConfiguration : TMBPuckTypeConfiguration
    {
        // @property (nonatomic, strong) TMBModel * _Nonnull model;
        [Export("model", ArgumentSemantic.Strong)]
        TMBModel Model { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable modelScale;
        [NullAllowed, Export("modelScale", ArgumentSemantic.Strong)]
        TMBValue ModelScale { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable modelRotation;
        [NullAllowed, Export("modelRotation", ArgumentSemantic.Strong)]
        TMBValue ModelRotation { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable modelOpacity;
        [NullAllowed, Export("modelOpacity", ArgumentSemantic.Strong)]
        TMBValue ModelOpacity { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable modelEmissiveStrength;
        [NullAllowed, Export("modelEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue ModelEmissiveStrength { get; set; }

        // -(instancetype _Nonnull)initWithModel:(TMBModel * _Nonnull)model modelScale:(TMBValue * _Nullable)modelScale modelRotation:(TMBValue * _Nullable)modelRotation modelOpacity:(TMBValue * _Nullable)modelOpacity __attribute__((objc_designated_initializer));
        [Export("initWithModel:modelScale:modelRotation:modelOpacity:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBModel model, [NullAllowed] TMBValue modelScale, [NullAllowed] TMBValue modelRotation, [NullAllowed] TMBValue modelOpacity);
    }

    // @interface TMBPuckRenderingData : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC20TMBPuckRenderingData")]
    [DisableDefaultCtor]
    interface TMBPuckRenderingData
    {
        // @property (nonatomic, strong) MBXLocation * _Nonnull location;
        [Export("location", ArgumentSemantic.Strong)]
        MBXLocation Location { get; set; }

        // @property (nonatomic, strong) TMBHeading * _Nullable heading;
        [NullAllowed, Export("heading", ArgumentSemantic.Strong)]
        TMBHeading Heading { get; set; }

        // -(instancetype _Nonnull)initWithLocation:(MBXLocation * _Nonnull)location heading:(TMBHeading * _Nullable)heading __attribute__((objc_designated_initializer));
        [Export("initWithLocation:heading:")]
        [DesignatedInitializer]
        NativeHandle Constructor(MBXLocation location, [NullAllowed] TMBHeading heading);
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC22TMBTileCacheBudgetSize")
    // @interface TMBTileCacheBudgetSize : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBTileCacheBudgetSize")]
    [DisableDefaultCtor]
    interface TMBTileCacheBudgetSize 
    {
        // + (TMBTileCacheBudgetSize * _Nonnull)inTiles:(NSInteger)tiles SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("inTiles:")]
        TMBTileCacheBudgetSize InTiles(int tiles);

        // + (TMBTileCacheBudgetSize * _Nonnull)inMegabytes:(NSInteger)megabytes SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("inMegabytes:")]
        TMBTileCacheBudgetSize InMegabytes(int megabytes);

        // @property (nonatomic, readonly, strong) NSNumber * _Nullable tiles;
        [NullAllowed, Export("tiles", ArgumentSemantic.Strong)]
        NSNumber Tiles { get; }

        // @property (nonatomic, readonly, strong) NSNumber * _Nullable megabytes;
        [NullAllowed, Export("megabytes", ArgumentSemantic.Strong)]
        NSNumber Megabytes { get; }

        // /// The TileCacheBudget formatted for core
        // @property (nonatomic, readonly, strong) MBMTileCacheBudget * _Nonnull coreTileCacheBudget;
        [Export("coreTileCacheBudget", ArgumentSemantic.Strong)]
        MBMTileCacheBudget CoreTileCacheBudget { get; }
    }

    // @interface TMBRasterDemSource : NSObject <TMBSource>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBRasterDemSource")]
    [DisableDefaultCtor]
    interface TMBRasterDemSource : TMBSource
    {
        // @property (readonly, nonatomic, strong) TMBSourceType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBSourceType Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (copy, nonatomic) NSString * _Nullable url;
        [NullAllowed, Export("url")]
        string Url { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable tiles;
        [NullAllowed, Export("tiles", ArgumentSemantic.Copy)]
        string[] Tiles { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable bounds;
        [NullAllowed, Export("bounds", ArgumentSemantic.Copy)]
        NSNumber[] Bounds { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minzoom;
        [NullAllowed, Export("minzoom", ArgumentSemantic.Strong)]
        NSNumber Minzoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxzoom;
        [NullAllowed, Export("maxzoom", ArgumentSemantic.Strong)]
        NSNumber Maxzoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable tileSize;
        [NullAllowed, Export("tileSize", ArgumentSemantic.Strong)]
        NSNumber TileSize { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable attribution;
        [NullAllowed, Export("attribution")]
        string Attribution { get; set; }

        // @property (nonatomic, strong) TMBEncoding * _Nullable encoding;
        [NullAllowed, Export("encoding", ArgumentSemantic.Strong)]
        TMBEncoding Encoding { get; set; }

        // @property (getter = volatile, nonatomic, setter = setVolatile:, strong) NSNumber * _Nullable volatile_;
        [NullAllowed, Export("volatile_", ArgumentSemantic.Strong)]
        NSNumber Volatile_ { [Bind("volatile")] get; [Bind("setVolatile:")] set; }

        // @property (nonatomic, strong) NSNumber * _Nullable prefetchZoomDelta;
        [NullAllowed, Export("prefetchZoomDelta", ArgumentSemantic.Strong)]
        NSNumber PrefetchZoomDelta { get; set; }

        // @property (nonatomic, strong) TMBTileCacheBudgetSize * _Nullable tileCacheBudget;
        [NullAllowed, Export("tileCacheBudget", ArgumentSemantic.Strong)]
        TMBTileCacheBudgetSize TileCacheBudget { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minimumTileUpdateInterval;
        [NullAllowed, Export("minimumTileUpdateInterval", ArgumentSemantic.Strong)]
        NSNumber MinimumTileUpdateInterval { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxOverscaleFactorForParentTiles;
        [NullAllowed, Export("maxOverscaleFactorForParentTiles", ArgumentSemantic.Strong)]
        NSNumber MaxOverscaleFactorForParentTiles { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable tileRequestsDelay;
        [NullAllowed, Export("tileRequestsDelay", ArgumentSemantic.Strong)]
        NSNumber TileRequestsDelay { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable tileNetworkRequestsDelay;
        [NullAllowed, Export("tileNetworkRequestsDelay", ArgumentSemantic.Strong)]
        NSNumber TileNetworkRequestsDelay { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBRasterLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14TMBRasterLayer")]
    [DisableDefaultCtor]
    interface TMBRasterLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBExpression * _Nullable filter;
        [NullAllowed, Export("filter", ArgumentSemantic.Strong)]
        TMBExpression Filter { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable source;
        [NullAllowed, Export("source")]
        string Source { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sourceLayer;
        [NullAllowed, Export("sourceLayer")]
        string SourceLayer { get; set; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterBrightnessMax;
        [NullAllowed, Export("rasterBrightnessMax", ArgumentSemantic.Strong)]
        TMBValue RasterBrightnessMax { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rasterBrightnessMaxTransition;
        [NullAllowed, Export("rasterBrightnessMaxTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RasterBrightnessMaxTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterBrightnessMin;
        [NullAllowed, Export("rasterBrightnessMin", ArgumentSemantic.Strong)]
        TMBValue RasterBrightnessMin { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rasterBrightnessMinTransition;
        [NullAllowed, Export("rasterBrightnessMinTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RasterBrightnessMinTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterColor;
        [NullAllowed, Export("rasterColor", ArgumentSemantic.Strong)]
        TMBValue RasterColor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterColorMix;
        [NullAllowed, Export("rasterColorMix", ArgumentSemantic.Strong)]
        TMBValue RasterColorMix { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rasterColorMixTransition;
        [NullAllowed, Export("rasterColorMixTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RasterColorMixTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterColorRange;
        [NullAllowed, Export("rasterColorRange", ArgumentSemantic.Strong)]
        TMBValue RasterColorRange { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rasterColorRangeTransition;
        [NullAllowed, Export("rasterColorRangeTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RasterColorRangeTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterContrast;
        [NullAllowed, Export("rasterContrast", ArgumentSemantic.Strong)]
        TMBValue RasterContrast { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rasterContrastTransition;
        [NullAllowed, Export("rasterContrastTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RasterContrastTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterEmissiveStrength;
        [NullAllowed, Export("rasterEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue RasterEmissiveStrength { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rasterEmissiveStrengthTransition;
        [NullAllowed, Export("rasterEmissiveStrengthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RasterEmissiveStrengthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterFadeDuration;
        [NullAllowed, Export("rasterFadeDuration", ArgumentSemantic.Strong)]
        TMBValue RasterFadeDuration { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterHueRotate;
        [NullAllowed, Export("rasterHueRotate", ArgumentSemantic.Strong)]
        TMBValue RasterHueRotate { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rasterHueRotateTransition;
        [NullAllowed, Export("rasterHueRotateTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RasterHueRotateTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterOpacity;
        [NullAllowed, Export("rasterOpacity", ArgumentSemantic.Strong)]
        TMBValue RasterOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rasterOpacityTransition;
        [NullAllowed, Export("rasterOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RasterOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterResampling;
        [NullAllowed, Export("rasterResampling", ArgumentSemantic.Strong)]
        TMBValue RasterResampling { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable rasterSaturation;
        [NullAllowed, Export("rasterSaturation", ArgumentSemantic.Strong)]
        TMBValue RasterSaturation { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable rasterSaturationTransition;
        [NullAllowed, Export("rasterSaturationTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition RasterSaturationTransition { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id source:(NSString * _Nonnull)source __attribute__((objc_designated_initializer));
        [Export("initWithId:source:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, string source);
    }

    // @interface TMBRasterResampling : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC19TMBRasterResampling")]
    [DisableDefaultCtor]
    interface TMBRasterResampling
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBRasterResampling * _Nonnull linear;
        [Static]
        [Export("linear", ArgumentSemantic.Strong)]
        TMBRasterResampling Linear { get; }

        // @property (readonly, nonatomic, strong, class) TMBRasterResampling * _Nonnull nearest;
        [Static]
        [Export("nearest", ArgumentSemantic.Strong)]
        TMBRasterResampling Nearest { get; }
    }

    // @interface TMBRasterSource : NSObject <TMBSource>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC15TMBRasterSource")]
    [DisableDefaultCtor]
    interface TMBRasterSource : TMBSource
    {
        // @property (readonly, nonatomic, strong) TMBSourceType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBSourceType Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (copy, nonatomic) NSString * _Nullable url;
        [NullAllowed, Export("url")]
        string Url { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable tiles;
        [NullAllowed, Export("tiles", ArgumentSemantic.Copy)]
        string[] Tiles { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable bounds;
        [NullAllowed, Export("bounds", ArgumentSemantic.Copy)]
        NSNumber[] Bounds { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minzoom;
        [NullAllowed, Export("minzoom", ArgumentSemantic.Strong)]
        NSNumber Minzoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxzoom;
        [NullAllowed, Export("maxzoom", ArgumentSemantic.Strong)]
        NSNumber Maxzoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable tileSize;
        [NullAllowed, Export("tileSize", ArgumentSemantic.Strong)]
        NSNumber TileSize { get; set; }

        // @property (nonatomic, strong) TMBScheme * _Nullable scheme;
        [NullAllowed, Export("scheme", ArgumentSemantic.Strong)]
        TMBScheme Scheme { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable attribution;
        [NullAllowed, Export("attribution")]
        string Attribution { get; set; }

        // @property (getter = volatile, nonatomic, setter = setVolatile:, strong) NSNumber * _Nullable volatile_;
        [NullAllowed, Export("volatile_", ArgumentSemantic.Strong)]
        NSNumber Volatile_ { [Bind("volatile")] get; [Bind("setVolatile:")] set; }

        // @property (nonatomic, strong) NSNumber * _Nullable prefetchZoomDelta;
        [NullAllowed, Export("prefetchZoomDelta", ArgumentSemantic.Strong)]
        NSNumber PrefetchZoomDelta { get; set; }

        // @property (nonatomic, strong) TMBTileCacheBudgetSize * _Nullable tileCacheBudget;
        [NullAllowed, Export("tileCacheBudget", ArgumentSemantic.Strong)]
        TMBTileCacheBudgetSize TileCacheBudget { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minimumTileUpdateInterval;
        [NullAllowed, Export("minimumTileUpdateInterval", ArgumentSemantic.Strong)]
        NSNumber MinimumTileUpdateInterval { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxOverscaleFactorForParentTiles;
        [NullAllowed, Export("maxOverscaleFactorForParentTiles", ArgumentSemantic.Strong)]
        NSNumber MaxOverscaleFactorForParentTiles { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable tileRequestsDelay;
        [NullAllowed, Export("tileRequestsDelay", ArgumentSemantic.Strong)]
        NSNumber TileRequestsDelay { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable tileNetworkRequestsDelay;
        [NullAllowed, Export("tileNetworkRequestsDelay", ArgumentSemantic.Strong)]
        NSNumber TileNetworkRequestsDelay { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBResolvedImage : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC16TMBResolvedImage")]
    [DisableDefaultCtor]
    interface TMBResolvedImage
    {
    }

    // @interface MapboxMapObjC_Swift_5921 (TMBResolvedImage)
    [Category]
    [BaseType(typeof(TMBResolvedImage))]
    interface TMBResolvedImage_MapboxMapObjC_Swift_5921
    {
        // +(TMBResolvedImage * _Nonnull)fromName:(NSString * _Nonnull)name __attribute__((warn_unused_result("")));
        [Static]
        [Export("fromName:")]
        TMBResolvedImage FromName(string name);

        // +(TMBResolvedImage * _Nonnull)fromName:(NSString * _Nonnull)name available:(BOOL)available __attribute__((warn_unused_result("")));
        [Static]
        [Export("fromName:available:")]
        TMBResolvedImage FromName(string name, bool available);
    }

    // @interface TMBScaleBarViewOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBScaleBarViewOptions")]
    [DisableDefaultCtor]
    interface TMBScaleBarViewOptions
    {
        // @property (nonatomic) enum TMBOrnamentPosition position;
        [Export("position", ArgumentSemantic.Assign)]
        TMBOrnamentPosition Position { get; set; }

        // @property (nonatomic) CGPoint margins;
        [Export("margins", ArgumentSemantic.Assign)]
        CGPoint Margins { get; set; }

        // @property (nonatomic) enum TMBOrnamentVisibility visibility;
        [Export("visibility", ArgumentSemantic.Assign)]
        TMBOrnamentVisibility Visibility { get; set; }

        // @property (nonatomic) BOOL useMetricUnits;
        [Export("useMetricUnits")]
        bool UseMetricUnits { get; set; }

        // -(instancetype _Nonnull)initWithPosition:(enum TMBOrnamentPosition)position margins:(CGPoint)margins visibility:(enum TMBOrnamentVisibility)visibility useMetricUnits:(BOOL)useMetricUnits __attribute__((objc_designated_initializer));
        [Export("initWithPosition:margins:visibility:useMetricUnits:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBOrnamentPosition position, CGPoint margins, TMBOrnamentVisibility visibility, bool useMetricUnits);
    }

    // @interface TMBScheme : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC9TMBScheme")]
    [DisableDefaultCtor]
    interface TMBScheme
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBScheme * _Nonnull xyz;
        [Static]
        [Export("xyz", ArgumentSemantic.Strong)]
        TMBScheme Xyz { get; }

        // @property (readonly, nonatomic, strong, class) TMBScheme * _Nonnull tms;
        [Static]
        [Export("tms", ArgumentSemantic.Strong)]
        TMBScheme Tms { get; }
    }

    // @interface TMBSkyLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC11TMBSkyLayer")]
    [DisableDefaultCtor]
    interface TMBSkyLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable skyAtmosphereColor;
        [NullAllowed, Export("skyAtmosphereColor", ArgumentSemantic.Strong)]
        TMBValue SkyAtmosphereColor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable skyAtmosphereHaloColor;
        [NullAllowed, Export("skyAtmosphereHaloColor", ArgumentSemantic.Strong)]
        TMBValue SkyAtmosphereHaloColor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable skyAtmosphereSun;
        [NullAllowed, Export("skyAtmosphereSun", ArgumentSemantic.Strong)]
        TMBValue SkyAtmosphereSun { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable skyAtmosphereSunIntensity;
        [NullAllowed, Export("skyAtmosphereSunIntensity", ArgumentSemantic.Strong)]
        TMBValue SkyAtmosphereSunIntensity { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable skyGradient;
        [NullAllowed, Export("skyGradient", ArgumentSemantic.Strong)]
        TMBValue SkyGradient { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable skyGradientCenter;
        [NullAllowed, Export("skyGradientCenter", ArgumentSemantic.Strong)]
        TMBValue SkyGradientCenter { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable skyGradientRadius;
        [NullAllowed, Export("skyGradientRadius", ArgumentSemantic.Strong)]
        TMBValue SkyGradientRadius { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable skyOpacity;
        [NullAllowed, Export("skyOpacity", ArgumentSemantic.Strong)]
        TMBValue SkyOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable skyOpacityTransition;
        [NullAllowed, Export("skyOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition SkyOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable skyType;
        [NullAllowed, Export("skyType", ArgumentSemantic.Strong)]
        TMBValue SkyType { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBSkyType : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC10TMBSkyType")]
    [DisableDefaultCtor]
    interface TMBSkyType
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBSkyType * _Nonnull gradient;
        [Static]
        [Export("gradient", ArgumentSemantic.Strong)]
        TMBSkyType Gradient { get; }

        // @property (readonly, nonatomic, strong, class) TMBSkyType * _Nonnull atmosphere;
        [Static]
        [Export("atmosphere", ArgumentSemantic.Strong)]
        TMBSkyType Atmosphere { get; }
    }

    // @interface TMBSlot : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC7TMBSlot")]
    [DisableDefaultCtor]
    interface TMBSlot
    {
        // @property (readonly, nonatomic, strong, class) TMBSlot * _Nonnull top;
        [Static]
        [Export("top", ArgumentSemantic.Strong)]
        TMBSlot Top { get; }

        // @property (readonly, nonatomic, strong, class) TMBSlot * _Nonnull middle;
        [Static]
        [Export("middle", ArgumentSemantic.Strong)]
        TMBSlot Middle { get; }

        // @property (readonly, nonatomic, strong, class) TMBSlot * _Nonnull bottom;
        [Static]
        [Export("bottom", ArgumentSemantic.Strong)]
        TMBSlot Bottom { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);
    }

    // @interface TMBSourceInfo : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBSourceInfo")]
    [DisableDefaultCtor]
    interface TMBSourceInfo
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (nonatomic, strong) TMBSourceType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBSourceType Type { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id type:(TMBSourceType * _Nonnull)type __attribute__((objc_designated_initializer));
        [Export("initWithId:type:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, TMBSourceType type);
    }

    // @interface TMBSourceType : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBSourceType")]
    [DisableDefaultCtor]
    interface TMBSourceType
    {
        // @property (readonly, nonatomic, strong, class) TMBSourceType * _Nonnull vector;
        [Static]
        [Export("vector", ArgumentSemantic.Strong)]
        TMBSourceType Vector { get; }

        // @property (readonly, nonatomic, strong, class) TMBSourceType * _Nonnull raster;
        [Static]
        [Export("raster", ArgumentSemantic.Strong)]
        TMBSourceType Raster { get; }

        // @property (readonly, nonatomic, strong, class) TMBSourceType * _Nonnull rasterDem;
        [Static]
        [Export("rasterDem", ArgumentSemantic.Strong)]
        TMBSourceType RasterDem { get; }

        // @property (readonly, nonatomic, strong, class) TMBSourceType * _Nonnull geoJson;
        [Static]
        [Export("geoJson", ArgumentSemantic.Strong)]
        TMBSourceType GeoJson { get; }

        // @property (readonly, nonatomic, strong, class) TMBSourceType * _Nonnull image;
        [Static]
        [Export("image", ArgumentSemantic.Strong)]
        TMBSourceType Image { get; }

        // @property (readonly, nonatomic, strong, class) TMBSourceType * _Nonnull model;
        [Static]
        [Export("model", ArgumentSemantic.Strong)]
        TMBSourceType Model { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);
    }

    // @interface MapboxMapObjC_Swift_6112 (TMBStyleManager)
    [Category]
    [BaseType(typeof(TMBStyleManager))]
    interface TMBStyleManager_MapboxMapObjC_Swift_6112
    {
        // -(void)setProjection:(TMBStyleProjection * _Nonnull)projection completion:(void (^ _Nullable)(NSError * _Nullable))completion;
        [Export("setProjection:completion:")]
        void SetProjection(TMBStyleProjection projection, [NullAllowed] Action<NSError> completion);

        // -(TMBStyleProjection * _Nullable)projection __attribute__((warn_unused_result("")));
        [NullAllowed, Export("projection")]
        TMBStyleProjection Projection();
    }

    // @interface TMBStyleProjection : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBStyleProjection")]
    [DisableDefaultCtor]
    interface TMBStyleProjection
    {
        // @property (nonatomic, strong) TMBStyleProjectionName * _Nonnull name;
        [Export("name", ArgumentSemantic.Strong)]
        TMBStyleProjectionName Name { get; set; }

        // -(instancetype _Nonnull)initWithName:(TMBStyleProjectionName * _Nonnull)name __attribute__((objc_designated_initializer));
        [Export("initWithName:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBStyleProjectionName name);
    }

    // @interface TMBStyleProjectionName : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBStyleProjectionName")]
    [DisableDefaultCtor]
    interface TMBStyleProjectionName
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBStyleProjectionName * _Nonnull mercator;
        [Static]
        [Export("mercator", ArgumentSemantic.Strong)]
        TMBStyleProjectionName Mercator { get; }

        // @property (readonly, nonatomic, strong, class) TMBStyleProjectionName * _Nonnull globe;
        [Static]
        [Export("globe", ArgumentSemantic.Strong)]
        TMBStyleProjectionName Globe { get; }
    }

    // @interface TMBStylePropertyValue : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC21TMBStylePropertyValue")]
    [DisableDefaultCtor]
    interface TMBStylePropertyValue : INativeObject
    {
        // @property (readonly, nonatomic) id _Nullable value;
        [NullAllowed, Export("value")]
        NSObject Value { get; }

        // @property (readonly, nonatomic) enum TMBStylePropertyValueKind kind;
        [Export("kind")]
        TMBStylePropertyValueKind Kind { get; }
    }

    // @interface TMBStyleTransition : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBStyleTransition")]
    [DisableDefaultCtor]
    interface TMBStyleTransition
    {
        // @property (nonatomic) NSTimeInterval duration;
        [Export("duration")]
        double Duration { get; set; }

        // @property (nonatomic) NSTimeInterval delay;
        [Export("delay")]
        double Delay { get; set; }

        // -(instancetype _Nonnull)initWithDuration:(NSTimeInterval)duration delay:(NSTimeInterval)delay __attribute__((objc_designated_initializer));
        [Export("initWithDuration:delay:")]
        [DesignatedInitializer]
        NativeHandle Constructor(double duration, double delay);
    }

    // @interface TMBStyleURI : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC11TMBStyleURI")]
    [DisableDefaultCtor]
    interface TMBStyleURI
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBStyleURI * _Nonnull streets;
        [Static]
        [Export("streets", ArgumentSemantic.Strong)]
        TMBStyleURI Streets { get; }

        // @property (readonly, nonatomic, strong, class) TMBStyleURI * _Nonnull outdoors;
        [Static]
        [Export("outdoors", ArgumentSemantic.Strong)]
        TMBStyleURI Outdoors { get; }

        // @property (readonly, nonatomic, strong, class) TMBStyleURI * _Nonnull light;
        [Static]
        [Export("light", ArgumentSemantic.Strong)]
        TMBStyleURI Light { get; }

        // @property (readonly, nonatomic, strong, class) TMBStyleURI * _Nonnull dark;
        [Static]
        [Export("dark", ArgumentSemantic.Strong)]
        TMBStyleURI Dark { get; }

        // @property (readonly, nonatomic, strong, class) TMBStyleURI * _Nonnull satellite;
        [Static]
        [Export("satellite", ArgumentSemantic.Strong)]
        TMBStyleURI Satellite { get; }

        // @property (readonly, nonatomic, strong, class) TMBStyleURI * _Nonnull satelliteStreets;
        [Static]
        [Export("satelliteStreets", ArgumentSemantic.Strong)]
        TMBStyleURI SatelliteStreets { get; }

        // @property (readonly, nonatomic, strong, class) TMBStyleURI * _Nonnull standard;
        [Static]
        [Export("standard", ArgumentSemantic.Strong)]
        TMBStyleURI Standard { get; }
    }

    // @interface TMBSymbolLayer : NSObject <TMBLayer>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14TMBSymbolLayer")]
    [DisableDefaultCtor]
    interface TMBSymbolLayer : TMBLayer
    {
        // @property (copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; set; }

        // @property (readonly, nonatomic, strong) TMBLayerType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBLayerType Type { get; }

        // @property (nonatomic, strong) TMBExpression * _Nullable filter;
        [NullAllowed, Export("filter", ArgumentSemantic.Strong)]
        TMBExpression Filter { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable source;
        [NullAllowed, Export("source")]
        string Source { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable sourceLayer;
        [NullAllowed, Export("sourceLayer")]
        string SourceLayer { get; set; }

        // @property (nonatomic, strong) TMBSlot * _Nullable slot;
        [NullAllowed, Export("slot", ArgumentSemantic.Strong)]
        TMBSlot Slot { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minZoom;
        [NullAllowed, Export("minZoom", ArgumentSemantic.Strong)]
        NSNumber MinZoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxZoom;
        [NullAllowed, Export("maxZoom", ArgumentSemantic.Strong)]
        NSNumber MaxZoom { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nonnull visibility;
        [Export("visibility", ArgumentSemantic.Strong)]
        TMBValue Visibility { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconAllowOverlap;
        [NullAllowed, Export("iconAllowOverlap", ArgumentSemantic.Strong)]
        TMBValue IconAllowOverlap { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconAnchor;
        [NullAllowed, Export("iconAnchor", ArgumentSemantic.Strong)]
        TMBValue IconAnchor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconIgnorePlacement;
        [NullAllowed, Export("iconIgnorePlacement", ArgumentSemantic.Strong)]
        TMBValue IconIgnorePlacement { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconImage;
        [NullAllowed, Export("iconImage", ArgumentSemantic.Strong)]
        TMBValue IconImage { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconKeepUpright;
        [NullAllowed, Export("iconKeepUpright", ArgumentSemantic.Strong)]
        TMBValue IconKeepUpright { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconOffset;
        [NullAllowed, Export("iconOffset", ArgumentSemantic.Strong)]
        TMBValue IconOffset { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconOptional;
        [NullAllowed, Export("iconOptional", ArgumentSemantic.Strong)]
        TMBValue IconOptional { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconPadding;
        [NullAllowed, Export("iconPadding", ArgumentSemantic.Strong)]
        TMBValue IconPadding { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconPitchAlignment;
        [NullAllowed, Export("iconPitchAlignment", ArgumentSemantic.Strong)]
        TMBValue IconPitchAlignment { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconRotate;
        [NullAllowed, Export("iconRotate", ArgumentSemantic.Strong)]
        TMBValue IconRotate { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconRotationAlignment;
        [NullAllowed, Export("iconRotationAlignment", ArgumentSemantic.Strong)]
        TMBValue IconRotationAlignment { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconSize;
        [NullAllowed, Export("iconSize", ArgumentSemantic.Strong)]
        TMBValue IconSize { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconTextFit;
        [NullAllowed, Export("iconTextFit", ArgumentSemantic.Strong)]
        TMBValue IconTextFit { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconTextFitPadding;
        [NullAllowed, Export("iconTextFitPadding", ArgumentSemantic.Strong)]
        TMBValue IconTextFitPadding { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable symbolAvoidEdges;
        [NullAllowed, Export("symbolAvoidEdges", ArgumentSemantic.Strong)]
        TMBValue SymbolAvoidEdges { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable symbolPlacement;
        [NullAllowed, Export("symbolPlacement", ArgumentSemantic.Strong)]
        TMBValue SymbolPlacement { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable symbolSortKey;
        [NullAllowed, Export("symbolSortKey", ArgumentSemantic.Strong)]
        TMBValue SymbolSortKey { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable symbolSpacing;
        [NullAllowed, Export("symbolSpacing", ArgumentSemantic.Strong)]
        TMBValue SymbolSpacing { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable symbolZElevate;
        [NullAllowed, Export("symbolZElevate", ArgumentSemantic.Strong)]
        TMBValue SymbolZElevate { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable symbolZOrder;
        [NullAllowed, Export("symbolZOrder", ArgumentSemantic.Strong)]
        TMBValue SymbolZOrder { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textAllowOverlap;
        [NullAllowed, Export("textAllowOverlap", ArgumentSemantic.Strong)]
        TMBValue TextAllowOverlap { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textAnchor;
        [NullAllowed, Export("textAnchor", ArgumentSemantic.Strong)]
        TMBValue TextAnchor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textField;
        [NullAllowed, Export("textField", ArgumentSemantic.Strong)]
        TMBValue TextField { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textFont;
        [NullAllowed, Export("textFont", ArgumentSemantic.Strong)]
        TMBValue TextFont { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textIgnorePlacement;
        [NullAllowed, Export("textIgnorePlacement", ArgumentSemantic.Strong)]
        TMBValue TextIgnorePlacement { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textJustify;
        [NullAllowed, Export("textJustify", ArgumentSemantic.Strong)]
        TMBValue TextJustify { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textKeepUpright;
        [NullAllowed, Export("textKeepUpright", ArgumentSemantic.Strong)]
        TMBValue TextKeepUpright { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textLetterSpacing;
        [NullAllowed, Export("textLetterSpacing", ArgumentSemantic.Strong)]
        TMBValue TextLetterSpacing { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textLineHeight;
        [NullAllowed, Export("textLineHeight", ArgumentSemantic.Strong)]
        TMBValue TextLineHeight { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textMaxAngle;
        [NullAllowed, Export("textMaxAngle", ArgumentSemantic.Strong)]
        TMBValue TextMaxAngle { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textMaxWidth;
        [NullAllowed, Export("textMaxWidth", ArgumentSemantic.Strong)]
        TMBValue TextMaxWidth { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textOffset;
        [NullAllowed, Export("textOffset", ArgumentSemantic.Strong)]
        TMBValue TextOffset { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textOptional;
        [NullAllowed, Export("textOptional", ArgumentSemantic.Strong)]
        TMBValue TextOptional { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textPadding;
        [NullAllowed, Export("textPadding", ArgumentSemantic.Strong)]
        TMBValue TextPadding { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textPitchAlignment;
        [NullAllowed, Export("textPitchAlignment", ArgumentSemantic.Strong)]
        TMBValue TextPitchAlignment { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textRadialOffset;
        [NullAllowed, Export("textRadialOffset", ArgumentSemantic.Strong)]
        TMBValue TextRadialOffset { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textRotate;
        [NullAllowed, Export("textRotate", ArgumentSemantic.Strong)]
        TMBValue TextRotate { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textRotationAlignment;
        [NullAllowed, Export("textRotationAlignment", ArgumentSemantic.Strong)]
        TMBValue TextRotationAlignment { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textSize;
        [NullAllowed, Export("textSize", ArgumentSemantic.Strong)]
        TMBValue TextSize { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textTransform;
        [NullAllowed, Export("textTransform", ArgumentSemantic.Strong)]
        TMBValue TextTransform { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textVariableAnchor;
        [NullAllowed, Export("textVariableAnchor", ArgumentSemantic.Strong)]
        TMBValue TextVariableAnchor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textWritingMode;
        [NullAllowed, Export("textWritingMode", ArgumentSemantic.Strong)]
        TMBValue TextWritingMode { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconColor;
        [NullAllowed, Export("iconColor", ArgumentSemantic.Strong)]
        TMBValue IconColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable iconColorTransition;
        [NullAllowed, Export("iconColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IconColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconColorSaturation;
        [NullAllowed, Export("iconColorSaturation", ArgumentSemantic.Strong)]
        TMBValue IconColorSaturation { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable iconColorSaturationTransition;
        [NullAllowed, Export("iconColorSaturationTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IconColorSaturationTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconEmissiveStrength;
        [NullAllowed, Export("iconEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue IconEmissiveStrength { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable iconEmissiveStrengthTransition;
        [NullAllowed, Export("iconEmissiveStrengthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IconEmissiveStrengthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconHaloBlur;
        [NullAllowed, Export("iconHaloBlur", ArgumentSemantic.Strong)]
        TMBValue IconHaloBlur { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable iconHaloBlurTransition;
        [NullAllowed, Export("iconHaloBlurTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IconHaloBlurTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconHaloColor;
        [NullAllowed, Export("iconHaloColor", ArgumentSemantic.Strong)]
        TMBValue IconHaloColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable iconHaloColorTransition;
        [NullAllowed, Export("iconHaloColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IconHaloColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconHaloWidth;
        [NullAllowed, Export("iconHaloWidth", ArgumentSemantic.Strong)]
        TMBValue IconHaloWidth { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable iconHaloWidthTransition;
        [NullAllowed, Export("iconHaloWidthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IconHaloWidthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconImageCrossFade;
        [NullAllowed, Export("iconImageCrossFade", ArgumentSemantic.Strong)]
        TMBValue IconImageCrossFade { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable iconImageCrossFadeTransition;
        [NullAllowed, Export("iconImageCrossFadeTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IconImageCrossFadeTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconOpacity;
        [NullAllowed, Export("iconOpacity", ArgumentSemantic.Strong)]
        TMBValue IconOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable iconOpacityTransition;
        [NullAllowed, Export("iconOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IconOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconTranslate;
        [NullAllowed, Export("iconTranslate", ArgumentSemantic.Strong)]
        TMBValue IconTranslate { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable iconTranslateTransition;
        [NullAllowed, Export("iconTranslateTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition IconTranslateTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable iconTranslateAnchor;
        [NullAllowed, Export("iconTranslateAnchor", ArgumentSemantic.Strong)]
        TMBValue IconTranslateAnchor { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textColor;
        [NullAllowed, Export("textColor", ArgumentSemantic.Strong)]
        TMBValue TextColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable textColorTransition;
        [NullAllowed, Export("textColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition TextColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textEmissiveStrength;
        [NullAllowed, Export("textEmissiveStrength", ArgumentSemantic.Strong)]
        TMBValue TextEmissiveStrength { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable textEmissiveStrengthTransition;
        [NullAllowed, Export("textEmissiveStrengthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition TextEmissiveStrengthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textHaloBlur;
        [NullAllowed, Export("textHaloBlur", ArgumentSemantic.Strong)]
        TMBValue TextHaloBlur { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable textHaloBlurTransition;
        [NullAllowed, Export("textHaloBlurTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition TextHaloBlurTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textHaloColor;
        [NullAllowed, Export("textHaloColor", ArgumentSemantic.Strong)]
        TMBValue TextHaloColor { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable textHaloColorTransition;
        [NullAllowed, Export("textHaloColorTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition TextHaloColorTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textHaloWidth;
        [NullAllowed, Export("textHaloWidth", ArgumentSemantic.Strong)]
        TMBValue TextHaloWidth { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable textHaloWidthTransition;
        [NullAllowed, Export("textHaloWidthTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition TextHaloWidthTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textOpacity;
        [NullAllowed, Export("textOpacity", ArgumentSemantic.Strong)]
        TMBValue TextOpacity { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable textOpacityTransition;
        [NullAllowed, Export("textOpacityTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition TextOpacityTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textTranslate;
        [NullAllowed, Export("textTranslate", ArgumentSemantic.Strong)]
        TMBValue TextTranslate { get; set; }

        // @property (nonatomic, strong) TMBStyleTransition * _Nullable textTranslateTransition;
        [NullAllowed, Export("textTranslateTransition", ArgumentSemantic.Strong)]
        TMBStyleTransition TextTranslateTransition { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable textTranslateAnchor;
        [NullAllowed, Export("textTranslateAnchor", ArgumentSemantic.Strong)]
        TMBValue TextTranslateAnchor { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id source:(NSString * _Nonnull)source __attribute__((objc_designated_initializer));
        [Export("initWithId:source:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id, string source);
    }

    // @interface TMBSymbolPlacement : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBSymbolPlacement")]
    [DisableDefaultCtor]
    interface TMBSymbolPlacement
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBSymbolPlacement * _Nonnull point;
        [Static]
        [Export("point", ArgumentSemantic.Strong)]
        TMBSymbolPlacement Point { get; }

        // @property (readonly, nonatomic, strong, class) TMBSymbolPlacement * _Nonnull line;
        [Static]
        [Export("line", ArgumentSemantic.Strong)]
        TMBSymbolPlacement Line { get; }

        // @property (readonly, nonatomic, strong, class) TMBSymbolPlacement * _Nonnull lineCenter;
        [Static]
        [Export("lineCenter", ArgumentSemantic.Strong)]
        TMBSymbolPlacement LineCenter { get; }
    }

    // @interface TMBSymbolZOrder : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC15TMBSymbolZOrder")]
    [DisableDefaultCtor]
    interface TMBSymbolZOrder
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, getter = auto, nonatomic, strong, class) TMBSymbolZOrder * _Nonnull auto_;
        [Static]
        [Export("auto_", ArgumentSemantic.Strong)]
        TMBSymbolZOrder Auto_ { [Bind("auto")] get; }

        // @property (readonly, nonatomic, strong, class) TMBSymbolZOrder * _Nonnull viewportY;
        [Static]
        [Export("viewportY", ArgumentSemantic.Strong)]
        TMBSymbolZOrder ViewportY { get; }

        // @property (readonly, nonatomic, strong, class) TMBSymbolZOrder * _Nonnull source;
        [Static]
        [Export("source", ArgumentSemantic.Strong)]
        TMBSymbolZOrder Source { get; }
    }

    // @interface TMBTerrain : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC10TMBTerrain")]
    [DisableDefaultCtor]
    interface TMBTerrain
    {
        // -(instancetype _Nonnull)initWithSourceId:(NSString * _Nonnull)sourceId __attribute__((objc_designated_initializer));
        [Export("initWithSourceId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string sourceId);

        // @property (copy, nonatomic) NSString * _Nonnull source;
        [Export("source")]
        string Source { get; set; }

        // @property (nonatomic, strong) TMBValue * _Nullable exaggeration;
        [NullAllowed, Export("exaggeration", ArgumentSemantic.Strong)]
        TMBValue Exaggeration { get; set; }
    }

    // @interface TMBTextAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBTextAnchor")]
    [DisableDefaultCtor]
    interface TMBTextAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBTextAnchor * _Nonnull center;
        [Static]
        [Export("center", ArgumentSemantic.Strong)]
        TMBTextAnchor Center { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextAnchor * _Nonnull left;
        [Static]
        [Export("left", ArgumentSemantic.Strong)]
        TMBTextAnchor Left { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextAnchor * _Nonnull right;
        [Static]
        [Export("right", ArgumentSemantic.Strong)]
        TMBTextAnchor Right { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextAnchor * _Nonnull top;
        [Static]
        [Export("top", ArgumentSemantic.Strong)]
        TMBTextAnchor Top { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextAnchor * _Nonnull bottom;
        [Static]
        [Export("bottom", ArgumentSemantic.Strong)]
        TMBTextAnchor Bottom { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextAnchor * _Nonnull topLeft;
        [Static]
        [Export("topLeft", ArgumentSemantic.Strong)]
        TMBTextAnchor TopLeft { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextAnchor * _Nonnull topRight;
        [Static]
        [Export("topRight", ArgumentSemantic.Strong)]
        TMBTextAnchor TopRight { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextAnchor * _Nonnull bottomLeft;
        [Static]
        [Export("bottomLeft", ArgumentSemantic.Strong)]
        TMBTextAnchor BottomLeft { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextAnchor * _Nonnull bottomRight;
        [Static]
        [Export("bottomRight", ArgumentSemantic.Strong)]
        TMBTextAnchor BottomRight { get; }
    }

    // @interface TMBTextJustify : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC14TMBTextJustify")]
    [DisableDefaultCtor]
    interface TMBTextJustify
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, getter = auto, nonatomic, strong, class) TMBTextJustify * _Nonnull auto_;
        [Static]
        [Export("auto_", ArgumentSemantic.Strong)]
        TMBTextJustify Auto_ { [Bind("auto")] get; }

        // @property (readonly, nonatomic, strong, class) TMBTextJustify * _Nonnull left;
        [Static]
        [Export("left", ArgumentSemantic.Strong)]
        TMBTextJustify Left { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextJustify * _Nonnull center;
        [Static]
        [Export("center", ArgumentSemantic.Strong)]
        TMBTextJustify Center { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextJustify * _Nonnull right;
        [Static]
        [Export("right", ArgumentSemantic.Strong)]
        TMBTextJustify Right { get; }
    }

    // @interface TMBTextPitchAlignment : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC21TMBTextPitchAlignment")]
    [DisableDefaultCtor]
    interface TMBTextPitchAlignment
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBTextPitchAlignment * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBTextPitchAlignment Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextPitchAlignment * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBTextPitchAlignment Viewport { get; }

        // @property (readonly, getter = auto, nonatomic, strong, class) TMBTextPitchAlignment * _Nonnull auto_;
        [Static]
        [Export("auto_", ArgumentSemantic.Strong)]
        TMBTextPitchAlignment Auto_ { [Bind("auto")] get; }
    }

    // @interface TMBTextRotationAlignment : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC24TMBTextRotationAlignment")]
    [DisableDefaultCtor]
    interface TMBTextRotationAlignment
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBTextRotationAlignment * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBTextRotationAlignment Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextRotationAlignment * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBTextRotationAlignment Viewport { get; }

        // @property (readonly, getter = auto, nonatomic, strong, class) TMBTextRotationAlignment * _Nonnull auto_;
        [Static]
        [Export("auto_", ArgumentSemantic.Strong)]
        TMBTextRotationAlignment Auto_ { [Bind("auto")] get; }
    }

    // @interface TMBTextTransform : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC16TMBTextTransform")]
    [DisableDefaultCtor]
    interface TMBTextTransform
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBTextTransform * _Nonnull none;
        [Static]
        [Export("none", ArgumentSemantic.Strong)]
        TMBTextTransform None { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextTransform * _Nonnull uppercase;
        [Static]
        [Export("uppercase", ArgumentSemantic.Strong)]
        TMBTextTransform Uppercase { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextTransform * _Nonnull lowercase;
        [Static]
        [Export("lowercase", ArgumentSemantic.Strong)]
        TMBTextTransform Lowercase { get; }
    }

    // @interface TMBTextTranslateAnchor : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC22TMBTextTranslateAnchor")]
    [DisableDefaultCtor]
    interface TMBTextTranslateAnchor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBTextTranslateAnchor * _Nonnull map;
        [Static]
        [Export("map", ArgumentSemantic.Strong)]
        TMBTextTranslateAnchor Map { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextTranslateAnchor * _Nonnull viewport;
        [Static]
        [Export("viewport", ArgumentSemantic.Strong)]
        TMBTextTranslateAnchor Viewport { get; }
    }

    // @interface TMBTextWritingMode : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC18TMBTextWritingMode")]
    [DisableDefaultCtor]
    interface TMBTextWritingMode
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        NativeHandle Constructor(string rawValue);

        // @property (readonly, nonatomic, strong, class) TMBTextWritingMode * _Nonnull horizontal;
        [Static]
        [Export("horizontal", ArgumentSemantic.Strong)]
        TMBTextWritingMode Horizontal { get; }

        // @property (readonly, nonatomic, strong, class) TMBTextWritingMode * _Nonnull vertical;
        [Static]
        [Export("vertical", ArgumentSemantic.Strong)]
        TMBTextWritingMode Vertical { get; }
    }

    // @protocol TMBTileStoreObserver
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    partial interface ITMBTileStoreObserver { }

    [Model, Protocol(Name = "_TtP13MapboxMapObjC20TMBTileStoreObserver_")]
    [BaseType(typeof(NSObject))]
    interface TMBTileStoreObserver
    {
        // @required -(void)onRegionLoadProgressForId:(NSString * _Nonnull)id progress:(MBXTileRegionLoadProgress * _Nonnull)progress;
        [Abstract]
        [Export("onRegionLoadProgressForId:progress:")]
        void OnRegionLoadProgressForId(string id, MBXTileRegionLoadProgress progress);

        // @required -(void)onRegionLoadFinishedForId:(NSString * _Nonnull)id region:(MBXTileRegion * _Nullable)region error:(NSError * _Nullable)error;
        [Abstract]
        [Export("onRegionLoadFinishedForId:region:error:")]
        void OnRegionLoadFinishedForId(string id, [NullAllowed] MBXTileRegion region, [NullAllowed] NSError error);

        // @required -(void)onRegionRemovedForId:(NSString * _Nonnull)id;
        [Abstract]
        [Export("onRegionRemovedForId:")]
        void OnRegionRemovedForId(string id);

        // @required -(void)onRegionGeometryChangedForId:(NSString * _Nonnull)id geometry:(MBXGeometry * _Nullable)geometry;
        [Abstract]
        [Export("onRegionGeometryChangedForId:geometry:")]
        void OnRegionGeometryChangedForId(string id, [NullAllowed] MBXGeometry geometry);

        // @required -(void)onRegionMetadataChangedForId:(NSString * _Nonnull)id value:(id _Nonnull)value;
        [Abstract]
        [Export("onRegionMetadataChangedForId:value:")]
        void OnRegionMetadataChangedForId(string id, NSObject value);
    }

    // @interface TMBValue : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC8TMBValue")]
    [DisableDefaultCtor]
    partial interface TMBValue
    {
        // @property (readonly, nonatomic) id _Nullable constant;
        [NullAllowed, Export("constant")]
        NSObject Constant { get; }

        // @property (readonly, nonatomic, strong) TMBExpression * _Nullable expression;
        [NullAllowed, Export("expression", ArgumentSemantic.Strong)]
        TMBExpression Expression { get; }

        // -(instancetype _Nonnull)initWithConstant:(id _Nullable)constant __attribute__((objc_designated_initializer));
        [Export("initWithConstant:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] NSObject constant);

        // -(instancetype _Nonnull)initWithExpression:(TMBExpression * _Nonnull)expression __attribute__((objc_designated_initializer));
        [Export("initWithExpression:")]
        [DesignatedInitializer]
        NativeHandle Constructor(TMBExpression expression);

        // +(TMBValue * _Nonnull)constant:(NSObject * _Nonnull)constant __attribute__((warn_unused_result("")));
        [Static]
        [Export("constant:")]
        TMBValue FromConstant(NSObject constant);

        // +(TMBValue * _Nonnull)intValue:(NSInteger)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("intValue:")]
        TMBValue IntValue(nint value);

        // +(TMBValue * _Nonnull)doubleValue:(double)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("doubleValue:")]
        TMBValue DoubleValue(double value);

        // +(TMBValue * _Nonnull)expression:(TMBExpression * _Nonnull)expression __attribute__((warn_unused_result("")));
        [Static]
        [Export("expression:")]
        TMBValue FromExpression(TMBExpression expression);
    }

    // @interface MapboxMapObjC_Swift_6635 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)symbolPlacement:(TMBSymbolPlacement * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("symbolPlacement:")]
        TMBValue SymbolPlacement(TMBSymbolPlacement value);
    }

    // @interface MapboxMapObjC_Swift_6640 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)modelScaleMode:(TMBModelScaleMode * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("modelScaleMode:")]
        TMBValue ModelScaleMode(TMBModelScaleMode value);
    }

    // @interface MapboxMapObjC_Swift_6645 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)skyType:(TMBSkyType * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("skyType:")]
        TMBValue SkyType(TMBSkyType value);
    }

    // @interface MapboxMapObjC_Swift_6650 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)modelType:(TMBModelType * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("modelType:")]
        TMBValue ModelType(TMBModelType value);
    }

    // @interface MapboxMapObjC_Swift_6656 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)visibility:(enum TMBVisibility)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("visibility:")]
        TMBValue Visibility(TMBVisibility value);
    }

    // @interface MapboxMapObjC_Swift_6661 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)lightType:(TMBLightType * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("lightType:")]
        TMBValue LightType(TMBLightType value);
    }

    // @interface MapboxMapObjC_Swift_6666 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)encoding:(TMBEncoding * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("encoding:")]
        TMBValue Encoding(TMBEncoding value);
    }

    // @interface MapboxMapObjC_Swift_6671 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)iconPitchAlignment:(TMBIconPitchAlignment * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("iconPitchAlignment:")]
        TMBValue IconPitchAlignment(TMBIconPitchAlignment value);
    }

    // @interface MapboxMapObjC_Swift_6676 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)textPitchAlignment:(TMBTextPitchAlignment * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("textPitchAlignment:")]
        TMBValue TextPitchAlignment(TMBTextPitchAlignment value);
    }

    // @interface MapboxMapObjC_Swift_6681 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)sourceType:(TMBSourceType * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("sourceType:")]
        TMBValue SourceType(TMBSourceType value);
    }

    // @interface MapboxMapObjC_Swift_6686 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)styleURI:(TMBStyleURI * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("styleURI:")]
        TMBValue StyleURI(TMBStyleURI value);
    }

    // @interface MapboxMapObjC_Swift_6691 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)textWritingMode:(TMBTextWritingMode * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("textWritingMode:")]
        TMBValue TextWritingMode(TMBTextWritingMode value);
    }

    // @interface MapboxMapObjC_Swift_6696 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)textAnchor:(TMBTextAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("textAnchor:")]
        TMBValue TextAnchor(TMBTextAnchor value);
    }

    // @interface MapboxMapObjC_Swift_6701 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)textRotationAlignment:(TMBTextRotationAlignment * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("textRotationAlignment:")]
        TMBValue TextRotationAlignment(TMBTextRotationAlignment value);
    }

    // @interface MapboxMapObjC_Swift_6706 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)iconTextFit:(TMBIconTextFit * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("iconTextFit:")]
        TMBValue IconTextFit(TMBIconTextFit value);
    }

    // @interface MapboxMapObjC_Swift_6711 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)textTransform:(TMBTextTransform * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("textTransform:")]
        TMBValue TextTransform(TMBTextTransform value);
    }

    // @interface MapboxMapObjC_Swift_6716 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)iconAnchor:(TMBIconAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("iconAnchor:")]
        TMBValue IconAnchor(TMBIconAnchor value);
    }

    // @interface MapboxMapObjC_Swift_6721 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)fillTranslateAnchor:(TMBFillTranslateAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("fillTranslateAnchor:")]
        TMBValue FillTranslateAnchor(TMBFillTranslateAnchor value);
    }

    // @interface MapboxMapObjC_Swift_6726 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)styleProjectionName:(TMBStyleProjectionName * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("styleProjectionName:")]
        TMBValue StyleProjectionName(TMBStyleProjectionName value);
    }

    // @interface MapboxMapObjC_Swift_6731 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)lineTranslateAnchor:(TMBLineTranslateAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("lineTranslateAnchor:")]
        TMBValue LineTranslateAnchor(TMBLineTranslateAnchor value);
    }

    // @interface MapboxMapObjC_Swift_6736 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)iconRotationAlignment:(TMBIconRotationAlignment * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("iconRotationAlignment:")]
        TMBValue IconRotationAlignment(TMBIconRotationAlignment value);
    }

    // @interface MapboxMapObjC_Swift_6741 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)iconTranslateAnchor:(TMBIconTranslateAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("iconTranslateAnchor:")]
        TMBValue IconTranslateAnchor(TMBIconTranslateAnchor value);
    }

    // @interface MapboxMapObjC_Swift_6746 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)layerType:(TMBLayerType * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("layerType:")]
        TMBValue LayerType(TMBLayerType value);
    }

    // @interface MapboxMapObjC_Swift_6751 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)textTranslateAnchor:(TMBTextTranslateAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("textTranslateAnchor:")]
        TMBValue TextTranslateAnchor(TMBTextTranslateAnchor value);
    }

    // @interface MapboxMapObjC_Swift_6756 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)lineJoin:(TMBLineJoin * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("lineJoin:")]
        TMBValue LineJoin(TMBLineJoin value);
    }

    // @interface MapboxMapObjC_Swift_6761 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)circlePitchAlignment:(TMBCirclePitchAlignment * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("circlePitchAlignment:")]
        TMBValue CirclePitchAlignment(TMBCirclePitchAlignment value);
    }

    // @interface MapboxMapObjC_Swift_6766 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)circlePitchScale:(TMBCirclePitchScale * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("circlePitchScale:")]
        TMBValue CirclePitchScale(TMBCirclePitchScale value);
    }

    // @interface MapboxMapObjC_Swift_6771 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)expressionOperator:(TMBExpressionOperator * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("expressionOperator:")]
        TMBValue ExpressionOperator(TMBExpressionOperator value);
    }

    // @interface MapboxMapObjC_Swift_6776 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)circleTranslateAnchor:(TMBCircleTranslateAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("circleTranslateAnchor:")]
        TMBValue CircleTranslateAnchor(TMBCircleTranslateAnchor value);
    }

    // @interface MapboxMapObjC_Swift_6781 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)symbolZOrder:(TMBSymbolZOrder * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("symbolZOrder:")]
        TMBValue SymbolZOrder(TMBSymbolZOrder value);
    }

    // @interface MapboxMapObjC_Swift_6786 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)lineCap:(TMBLineCap * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("lineCap:")]
        TMBValue LineCap(TMBLineCap value);
    }

    // @interface MapboxMapObjC_Swift_6791 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)fillExtrusionTranslateAnchor:(TMBFillExtrusionTranslateAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("fillExtrusionTranslateAnchor:")]
        TMBValue FillExtrusionTranslateAnchor(TMBFillExtrusionTranslateAnchor value);
    }

    // @interface MapboxMapObjC_Swift_6796 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)textJustify:(TMBTextJustify * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("textJustify:")]
        TMBValue TextJustify(TMBTextJustify value);
    }

    // @interface MapboxMapObjC_Swift_6801 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)rasterResampling:(TMBRasterResampling * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("rasterResampling:")]
        TMBValue RasterResampling(TMBRasterResampling value);
    }

    // @interface MapboxMapObjC_Swift_6806 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)scheme:(TMBScheme * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("scheme:")]
        TMBValue Scheme(TMBScheme value);
    }

    // @interface MapboxMapObjC_Swift_6811 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)hillshadeIlluminationAnchor:(TMBHillshadeIlluminationAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("hillshadeIlluminationAnchor:")]
        TMBValue HillshadeIlluminationAnchor(TMBHillshadeIlluminationAnchor value);
    }

    // @interface MapboxMapObjC_Swift_6817 (TMBValue)
    partial interface TMBValue
    {
        // +(TMBValue * _Nonnull)anchor:(TMBAnchor * _Nonnull)value __attribute__((warn_unused_result("")));
        [Static]
        [Export("anchor:")]
        TMBValue Anchor(TMBAnchor value);
    }

    // @interface TMBVectorSource : NSObject <TMBSource>
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC15TMBVectorSource")]
    [DisableDefaultCtor]
    interface TMBVectorSource : TMBSource
    {
        // @property (readonly, nonatomic, strong) TMBSourceType * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        TMBSourceType Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (copy, nonatomic) NSString * _Nullable url;
        [NullAllowed, Export("url")]
        string Url { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nullable tiles;
        [NullAllowed, Export("tiles", ArgumentSemantic.Copy)]
        string[] Tiles { get; set; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable bounds;
        [NullAllowed, Export("bounds", ArgumentSemantic.Copy)]
        NSNumber[] Bounds { get; set; }

        // @property (nonatomic, strong) TMBScheme * _Nullable scheme;
        [NullAllowed, Export("scheme", ArgumentSemantic.Strong)]
        TMBScheme Scheme { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minzoom;
        [NullAllowed, Export("minzoom", ArgumentSemantic.Strong)]
        NSNumber Minzoom { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxzoom;
        [NullAllowed, Export("maxzoom", ArgumentSemantic.Strong)]
        NSNumber Maxzoom { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable attribution;
        [NullAllowed, Export("attribution")]
        string Attribution { get; set; }

        // @property (nonatomic, strong) TMBPromoteId * _Nullable promoteId;
        [NullAllowed, Export("promoteId", ArgumentSemantic.Strong)]
        TMBPromoteId PromoteId { get; set; }

        // @property (getter = volatile, nonatomic, setter = setVolatile:, strong) NSNumber * _Nullable volatile_;
        [NullAllowed, Export("volatile_", ArgumentSemantic.Strong)]
        NSNumber Volatile_ { [Bind("volatile")] get; [Bind("setVolatile:")] set; }

        // @property (nonatomic, strong) NSNumber * _Nullable prefetchZoomDelta;
        [NullAllowed, Export("prefetchZoomDelta", ArgumentSemantic.Strong)]
        NSNumber PrefetchZoomDelta { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable minimumTileUpdateInterval;
        [NullAllowed, Export("minimumTileUpdateInterval", ArgumentSemantic.Strong)]
        NSNumber MinimumTileUpdateInterval { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable maxOverscaleFactorForParentTiles;
        [NullAllowed, Export("maxOverscaleFactorForParentTiles", ArgumentSemantic.Strong)]
        NSNumber MaxOverscaleFactorForParentTiles { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable tileRequestsDelay;
        [NullAllowed, Export("tileRequestsDelay", ArgumentSemantic.Strong)]
        NSNumber TileRequestsDelay { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable tileNetworkRequestsDelay;
        [NullAllowed, Export("tileNetworkRequestsDelay", ArgumentSemantic.Strong)]
        NSNumber TileNetworkRequestsDelay { get; set; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id __attribute__((objc_designated_initializer));
        [Export("initWithId:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string id);
    }

    // @interface TMBViewAnnotation : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC17TMBViewAnnotation")]
    [DisableDefaultCtor]
    interface TMBViewAnnotation
    {
        // @property (readonly, nonatomic, strong) UIView * _Nonnull view;
        [Export("view", ArgumentSemantic.Strong)]
        UIView View { get; }

        // @property (nonatomic, strong) TMBAnnotatedFeature * _Nonnull annotatedFeature;
        [Export("annotatedFeature", ArgumentSemantic.Strong)]
        TMBAnnotatedFeature AnnotatedFeature { get; set; }

        // @property (nonatomic) BOOL allowOverlap;
        [Export("allowOverlap")]
        bool AllowOverlap { get; set; }

        // @property (nonatomic) BOOL allowOverlapWithPuck;
        [Export("allowOverlapWithPuck")]
        bool AllowOverlapWithPuck { get; set; }

        // @property (nonatomic) BOOL ignoreCameraPadding;
        [Export("ignoreCameraPadding")]
        bool IgnoreCameraPadding { get; set; }

        // @property (nonatomic) BOOL visible;
        [Export("visible")]
        bool Visible { get; set; }

        // @property (nonatomic) BOOL selected;
        [Export("selected")]
        bool Selected { get; set; }

        // @property (copy, nonatomic) NSArray<MBMViewAnnotationAnchorConfig *> * _Nonnull variableAnchors;
        [Export("variableAnchors", ArgumentSemantic.Copy)]
        MBMViewAnnotationAnchorConfig[] VariableAnchors { get; set; }

        // @property (readonly, copy, nonatomic) void (^ _Nullable)(BOOL) onVisibilityChanged;
        [NullAllowed, Export("onVisibilityChanged", ArgumentSemantic.Copy)]
        Action<bool> OnVisibilityChanged { get; }

        // @property (readonly, copy, nonatomic) void (^ _Nullable)(MBMViewAnnotationAnchorConfig * _Nonnull) onAnchorChanged;
        [NullAllowed, Export("onAnchorChanged", ArgumentSemantic.Copy)]
        Action<MBMViewAnnotationAnchorConfig> OnAnchorChanged { get; }

        // @property (readonly, copy, nonatomic) void (^ _Nullable)(CLLocationCoordinate2D) onAnchorCoordinateChanged;
        [NullAllowed, Export("onAnchorCoordinateChanged", ArgumentSemantic.Copy)]
        Action<CLLocationCoordinate2D> OnAnchorCoordinateChanged { get; }

        // @property (readonly, copy, nonatomic) void (^ _Nullable)(CGRect) onFrameChanged;
        [NullAllowed, Export("onFrameChanged", ArgumentSemantic.Copy)]
        Action<CGRect> OnFrameChanged { get; }

        // @property (readonly, nonatomic, strong) MBMViewAnnotationAnchorConfig * _Nullable anchorConfig;
        [NullAllowed, Export("anchorConfig", ArgumentSemantic.Strong)]
        MBMViewAnnotationAnchorConfig AnchorConfig { get; }

        // @property (readonly, nonatomic, strong) NSValue * _Nullable anchorCoordinate;
        [NullAllowed, Export("anchorCoordinate", ArgumentSemantic.Strong)]
        NSValue AnchorCoordinate { get; }

        // +(TMBViewAnnotation * _Nonnull)fromAnnotatedFeature:(TMBAnnotatedFeature * _Nonnull)annotatedFeature view:(UIView * _Nonnull)view __attribute__((warn_unused_result("")));
        [Static]
        [Export("fromAnnotatedFeature:view:")]
        TMBViewAnnotation FromAnnotatedFeature(TMBAnnotatedFeature annotatedFeature, UIView view);

        // +(TMBViewAnnotation * _Nonnull)fromCoordinate:(CLLocationCoordinate2D)coordinate view:(UIView * _Nonnull)view __attribute__((warn_unused_result("")));
        [Static]
        [Export("fromCoordinate:view:")]
        TMBViewAnnotation FromCoordinate(CLLocationCoordinate2D coordinate, UIView view);

        // +(TMBViewAnnotation * _Nonnull)fromLayerId:(NSString * _Nonnull)layerId featureId:(NSString * _Nullable)featureId view:(UIView * _Nonnull)view __attribute__((warn_unused_result("")));
        [Static]
        [Export("fromLayerId:featureId:view:")]
        TMBViewAnnotation FromLayerId(string layerId, [NullAllowed] string featureId, UIView view);

        // -(void)remove;
        [Export("remove")]
        void Remove();

        // -(void)setNeedsUpdateSize;
        [Export("setNeedsUpdateSize")]
        void SetNeedsUpdateSize();
    }

    // @interface TMBViewAnnotationManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC24TMBViewAnnotationManager")]
    [DisableDefaultCtor]
    interface TMBViewAnnotationManager
    {
        // -(void)addWithAnnotation:(TMBViewAnnotation * _Nonnull)annotation;
        [Export("addWithAnnotation:")]
        void AddWithAnnotation(TMBViewAnnotation annotation);

        // -(void)removeAllViewAnnotations;
        [Export("removeAllViewAnnotations")]
        void RemoveAllViewAnnotations();

        // -(TMBCameraOptions * _Nullable)cameraForAnnotations:(NSArray<TMBViewAnnotation *> * _Nonnull)annotations padding:(UIEdgeInsets)padding bearing:(NSNumber * _Nullable)bearing pitch:(NSNumber * _Nullable)pitch __attribute__((warn_unused_result("")));
        [Export("cameraForAnnotations:padding:bearing:pitch:")]
        [return: NullAllowed]
        TMBCameraOptions CameraForAnnotations(TMBViewAnnotation[] annotations, UIEdgeInsets padding, [NullAllowed] NSNumber bearing, [NullAllowed] NSNumber pitch);
    }

    // @interface TMBViewAnnotationOptions : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC24TMBViewAnnotationOptions")]
    [DisableDefaultCtor]
    interface TMBViewAnnotationOptions
    {
        // @property (nonatomic, strong) TMBAnnotatedFeature * _Nullable annotatedFeature;
        [NullAllowed, Export("annotatedFeature", ArgumentSemantic.Strong)]
        TMBAnnotatedFeature AnnotatedFeature { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable width;
        [NullAllowed, Export("width", ArgumentSemantic.Strong)]
        NSNumber Width { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable height;
        [NullAllowed, Export("height", ArgumentSemantic.Strong)]
        NSNumber Height { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable allowOverlap;
        [NullAllowed, Export("allowOverlap", ArgumentSemantic.Strong)]
        NSNumber AllowOverlap { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable allowOverlapWithPuck;
        [NullAllowed, Export("allowOverlapWithPuck", ArgumentSemantic.Strong)]
        NSNumber AllowOverlapWithPuck { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable visible;
        [NullAllowed, Export("visible", ArgumentSemantic.Strong)]
        NSNumber Visible { get; set; }

        // @property (copy, nonatomic) NSArray<MBMViewAnnotationAnchorConfig *> * _Nullable variableAnchors;
        [NullAllowed, Export("variableAnchors", ArgumentSemantic.Copy)]
        MBMViewAnnotationAnchorConfig[] VariableAnchors { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable selected;
        [NullAllowed, Export("selected", ArgumentSemantic.Strong)]
        NSNumber Selected { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable ignoreCameraPadding;
        [NullAllowed, Export("ignoreCameraPadding", ArgumentSemantic.Strong)]
        NSNumber IgnoreCameraPadding { get; set; }

        // -(instancetype _Nonnull)initWithAnnotatedFeature:(TMBAnnotatedFeature * _Nullable)annotatedFeature width:(NSNumber * _Nullable)width height:(NSNumber * _Nullable)height allowOverlap:(NSNumber * _Nullable)allowOverlap allowOverlapWithPuck:(NSNumber * _Nullable)allowOverlapWithPuck visible:(NSNumber * _Nullable)visible selected:(NSNumber * _Nullable)selected variableAnchors:(NSArray<MBMViewAnnotationAnchorConfig *> * _Nullable)variableAnchors ignoreCameraPadding:(NSNumber * _Nullable)ignoreCameraPadding __attribute__((objc_designated_initializer));
        [Export("initWithAnnotatedFeature:width:height:allowOverlap:allowOverlapWithPuck:visible:selected:variableAnchors:ignoreCameraPadding:")]
        [DesignatedInitializer]
        NativeHandle Constructor([NullAllowed] TMBAnnotatedFeature annotatedFeature, [NullAllowed] NSNumber width, [NullAllowed] NSNumber height, [NullAllowed] NSNumber allowOverlap, [NullAllowed] NSNumber allowOverlapWithPuck, [NullAllowed] NSNumber visible, [NullAllowed] NSNumber selected, [NullAllowed] MBMViewAnnotationAnchorConfig[] variableAnchors, [NullAllowed] NSNumber ignoreCameraPadding);
    }

    // @interface MapboxMapObjC_Swift_7109
    [Category]
    [BaseType(typeof(MBXTileStore))]
    interface MapboxMapObjC_Swift_7109
    {
        // -(TMBCancelable * _Nonnull)loadTileRegionForId:(NSString * _Nonnull)id loadOptions:(MBXTileRegionLoadOptions * _Nonnull)loadOptions progress:(id)progress completion:(void (^ _Nonnull)(MBXTileRegion * _Nullable, NSError * _Nullable))completion;
        [Export("loadTileRegionForId:loadOptions:progress:completion:")]
        TMBCancelable LoadTileRegionForId(string id, MBXTileRegionLoadOptions loadOptions, Action<MBXTileRegionLoadProgress> progress, Action<MBXTileRegion, NSError> completion);

        // -(void)tileRegionContainsDescriptorsForId:(NSString * _Nonnull)id descriptors:(NSArray<MBXTilesetDescriptor *> * _Nonnull)descriptors completion:(void (^ _Nonnull)(BOOL, NSError * _Nullable))completion;
        [Export("tileRegionContainsDescriptorsForId:descriptors:completion:")]
        void TileRegionContainsDescriptorsForId(string id, MBXTilesetDescriptor[] descriptors, Action<bool, NSError> completion);

        // -(void)allTileRegions:(void (^ _Nonnull)(NSArray<MBXTileRegion *> * _Nullable, NSError * _Nullable))completion;
        [Export("allTileRegions:")]
        void AllTileRegions(Action<MBXTileRegion[], NSError> completion);

        // -(void)tileRegionForId:(NSString * _Nonnull)id completion:(void (^ _Nonnull)(MBXTileRegion * _Nullable, NSError * _Nullable))completion;
        [Export("tileRegionForId:completion:")]
        void TileRegionForId(string id, Action<MBXTileRegion, NSError> completion);

        // -(void)tileRegionGeometryForId:(NSString * _Nonnull)id completion:(void (^ _Nonnull)(MBXGeometry * _Nullable, NSError * _Nullable))completion;
        [Export("tileRegionGeometryForId:completion:")]
        void TileRegionGeometryForId(string id, Action<MBXGeometry, NSError> completion);

        // -(void)tileRegionMetadataForId:(NSString * _Nonnull)id completion:(void (^ _Nonnull)(id _Nullable, NSError * _Nullable))completion;
        [Export("tileRegionMetadataForId:completion:")]
        void TileRegionMetadataForId(string id, Action<NSObject, NSError> completion);

        // -(TMBCancelable * _Nonnull)subscribe:(id<TMBTileStoreObserver> _Nonnull)observer __attribute__((warn_unused_result("")));
        [Export("subscribe:")]
        TMBCancelable Subscribe(TMBTileStoreObserver observer);

        // -(void)removeRegionForId:(NSString * _Nonnull)id completion:(void (^ _Nonnull)(MBXTileRegion * _Nullable, NSError * _Nullable))completion;
        [Export("removeRegionForId:completion:")]
        void RemoveRegionForId(string id, Action<MBXTileRegion, NSError> completion);
    }

    // @interface TileStoreFactory : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC16TileStoreFactory")]
    [DisableDefaultCtor]
    interface TileStoreFactory
    {
        // +(id)getDefault __attribute__((warn_unused_result("")));
        [Static]
        [Export("getDefault")]
        MBXTileStore GetDefault();

        // +(id)sharedFor:(NSURL * _Nonnull)filePathURL __attribute__((warn_unused_result("")));
        [Static]
        [Export("sharedFor:")]
        MBXTileStore SharedFor(NSUrl filePathURL);
    }

    // SWIFT_CLASS("_TtC13MapboxMapObjC13TMBVisibility")
    // @interface TMBVisibility : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC13MapboxMapObjC13TMBVisibility")]
    interface TMBVisibility
    {
        // @property (nonatomic, readonly, copy) NSString * _Nonnull rawValue;
        [Export("rawValue")]
        string RawValue { get; }

        // - (nonnull instancetype)initWithRawValue:(NSString * _Nonnull)rawValue;
        [Export("initWithRawValue:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string rawValue);

        // /// The layer is shown.
        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBVisibility * _Nonnull visible;)
        // + (TMBVisibility * _Nonnull)visible SWIFT_WARN_UNUSED_RESULT;
        [Static]
        [Export("visible", ArgumentSemantic.Strong)]
        TMBVisibility Visible { get; }

        // /// The layer is hidden.
        // SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly, strong) TMBVisibility * _Nonnull none;)
        // + (TMBVisibility * _Nonnull)none SWIFT_WARN_UNUSED_RESULT;
        [Static]
        [Export("none", ArgumentSemantic.Strong)]
        TMBVisibility None { get; }
    }
}
