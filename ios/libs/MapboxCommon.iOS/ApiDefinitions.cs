using System;
using CoreLocation;
using Foundation;
using MapboxCommon;
using ObjCRuntime;
// using ObjectiveC;

namespace MapboxCommon
{
    // @interface MBXCacheClearingError : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXCacheClearingError
	{
        // // This class provides custom init which should be called
        // - (nonnull instancetype)init NS_UNAVAILABLE;

        // // This class provides custom init which should be called
        // + (nonnull instancetype)new NS_UNAVAILABLE;

        // - (nonnull instancetype)initWithType:(MBXCacheClearingErrorType)type
        //                             message:(nonnull NSString *)message;
        [Export ("initWithType:message:")]
		NativeHandle Constructor (MBXCacheClearingErrorType type, string message);

        // /** The reason for the response error. */
        // @property (nonatomic, readonly) MBXCacheClearingErrorType type;
        [Export ("type", ArgumentSemantic.Assign)]
		MBXCacheClearingErrorType Type { get; }
    }

    // /** An error message */
    // @property (nonatomic, readonly, nonnull, copy) NSString *message;
	// @interface MBXCoordinate2D : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXCoordinate2D
	{
		// @property (readonly, assign, nonatomic) CLLocationCoordinate2D value;
		[Export ("value", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Value { get; }

		// -(instancetype _Nonnull)initWithValue:(CLLocationCoordinate2D)value;
		[Export ("initWithValue:")]
		NativeHandle Constructor (CLLocationCoordinate2D value);
	}

    // cmd: nm -m 'artifacts/MapboxCommon.xcframework/ios-arm64/MapboxCommon.framework/MapboxCommon' \
    //  | grep '_OBJC_CLASS_$_MBXExceptionHandler'
    // result: 000000000035cb58 (__DATA,__objc_data) non-external _OBJC_CLASS_$_MBXExceptionHandler
	// // @interface MBXExceptionHandler : NSObject
	// [BaseType (typeof(NSObject))]
	// interface MBXExceptionHandler
	// {
	// 	// +(void)tryWithCallback:(void (^ _Nonnull)(void))callback error:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
	// 	[Static]
	// 	[Export ("tryWithCallback:error:")]
	// 	void TryWithCallback (Action callback, [NullAllowed] out NSError error);
	// }

	// @interface MBXFeature : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXFeature
	{
		// @property (readonly, retain) NSObject * _Nonnull identifier;
		[Export ("identifier", ArgumentSemantic.Retain)]
		NSObject Identifier { get; }

		// @property (readonly, retain) MBXGeometry * _Nonnull geometry;
		[Export ("geometry", ArgumentSemantic.Retain)]
		MBXGeometry Geometry { get; }

		// @property (readonly, retain) NSDictionary<NSString *,NSObject *> * _Nonnull properties;
		[Export ("properties", ArgumentSemantic.Retain)]
		NSDictionary<NSString, NSObject> Properties { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSObject * _Nonnull)identifier geometry:(MBXGeometry * _Nonnull)geometry properties:(NSDictionary<NSString *,NSObject *> * _Nonnull)properties;
		[Export ("initWithIdentifier:geometry:properties:")]
		NativeHandle Constructor (NSObject identifier, MBXGeometry geometry, NSDictionary<NSString, NSObject> properties);
	}

	// @interface MBXGeometry : NSObject
	[BaseType (typeof(NSObject))]
	interface MBXGeometry
	{
		// @property (readonly, assign) MBXGeometryType geometryType;
		[Export ("geometryType", ArgumentSemantic.Assign)]
		MBXGeometryType GeometryType { get; }

		// @property (readonly, assign) void * _Nonnull geometry;
		[Export ("geometry", ArgumentSemantic.Assign)]
		unsafe NSObject Geometry { get; }

		// -(instancetype _Nonnull)initWithPoint:(NSValue * _Nonnull)location;
		[Export ("initWithPoint:")]
		NativeHandle Constructor (NSValue location);

		// -(instancetype _Nonnull)initWithLine:(NSArray<NSValue *> * _Nonnull)locations;
		[Export ("initWithLine:")]
		NativeHandle Constructor (NSValue[] locations);

		// initWithPolygon:, initWithMultiPoint:, initWithMultiLine:, initWithMultiPolygon: and
		// initWithGeometryCollection: are instance initializers whose C# signatures collide; they are
		// exposed as static From* factories (alloc + init) in MBXGeometry.cs.

		// -(NSValue * _Nullable)extractLocations;
		[NullAllowed, Export ("extractLocations")]
		NSValue ExtractLocations();

		// -(NSArray<NSValue *> * _Nullable)extractLocationsArray;
		[NullAllowed, Export ("extractLocationsArray")]
		NSValue[] ExtractLocationsArray();

		// -(NSArray<NSArray<NSValue *> *> * _Nullable)extractLocations2DArray;
		[NullAllowed, Export ("extractLocations2DArray")]
		NSArray ExtractLocations2DArray();

		// -(NSArray<NSArray<NSArray<NSValue *> *> *> * _Nullable)extractLocations3DArray;
		[NullAllowed, Export ("extractLocations3DArray")]
		NSArray ExtractLocations3DArray();

		// -(NSArray<MBXGeometry *> * _Nullable)extractGeometriesArray;
		[NullAllowed, Export ("extractGeometriesArray")]
		MBXGeometry[] ExtractGeometriesArray();
	}

	// @interface MBXLocation : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXLocation
	{
		// -(instancetype _Nonnull)initWithLatitude:(double)latitude longitude:(double)longitude timestamp:(uint64_t)timestamp monotonicTimestamp:(NSNumber * _Nullable)monotonicTimestamp altitude:(NSNumber * _Nullable)altitude horizontalAccuracy:(NSNumber * _Nullable)horizontalAccuracy verticalAccuracy:(NSNumber * _Nullable)verticalAccuracy speed:(NSNumber * _Nullable)speed speedAccuracy:(NSNumber * _Nullable)speedAccuracy bearing:(NSNumber * _Nullable)bearing bearingAccuracy:(NSNumber * _Nullable)bearingAccuracy floor:(NSNumber * _Nullable)floor source:(NSString * _Nullable)source extra:(id _Nullable)extra __attribute__((swift_private));
		[Export ("initWithLatitude:longitude:timestamp:monotonicTimestamp:altitude:horizontalAccuracy:verticalAccuracy:speed:speedAccuracy:bearing:bearingAccuracy:floor:source:extra:")]
		NativeHandle Constructor (double latitude, double longitude, ulong timestamp, [NullAllowed] NSNumber monotonicTimestamp, [NullAllowed] NSNumber altitude, [NullAllowed] NSNumber horizontalAccuracy, [NullAllowed] NSNumber verticalAccuracy, [NullAllowed] NSNumber speed, [NullAllowed] NSNumber speedAccuracy, [NullAllowed] NSNumber bearing, [NullAllowed] NSNumber bearingAccuracy, [NullAllowed] NSNumber floor, [NullAllowed] string source, [NullAllowed] NSObject extra);

		// @property (readonly, nonatomic) double latitude __attribute__((swift_private));
		[Export ("latitude")]
		double Latitude { get; }

		// @property (readonly, nonatomic) double longitude __attribute__((swift_private));
		[Export ("longitude")]
		double Longitude { get; }

		// @property (readonly, nonatomic) uint64_t timestamp __attribute__((swift_private));
		[Export ("timestamp")]
		ulong Timestamp { get; }

		// @property (readwrite, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * monotonicTimestamp __attribute__((swift_private));
		[Export ("monotonicTimestamp", ArgumentSemantic.Assign)]
		NSNumber MonotonicTimestamp { get; set; }

		// @property (readwrite, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * altitude __attribute__((swift_private));
		[Export ("altitude", ArgumentSemantic.Assign)]
		NSNumber Altitude { get; set; }

		// @property (readwrite, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * horizontalAccuracy __attribute__((swift_private));
		[Export ("horizontalAccuracy", ArgumentSemantic.Assign)]
		NSNumber HorizontalAccuracy { get; set; }

		// @property (readwrite, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * verticalAccuracy __attribute__((swift_private));
		[Export ("verticalAccuracy", ArgumentSemantic.Assign)]
		NSNumber VerticalAccuracy { get; set; }

		// @property (readwrite, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * speed __attribute__((swift_private));
		[Export ("speed", ArgumentSemantic.Assign)]
		NSNumber Speed { get; set; }

		// @property (readwrite, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * speedAccuracy __attribute__((swift_private));
		[Export ("speedAccuracy", ArgumentSemantic.Assign)]
		NSNumber SpeedAccuracy { get; set; }

		// @property (readwrite, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * bearing __attribute__((swift_private));
		[Export ("bearing", ArgumentSemantic.Assign)]
		NSNumber Bearing { get; set; }

		// @property (readwrite, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * bearingAccuracy __attribute__((swift_private));
		[Export ("bearingAccuracy", ArgumentSemantic.Assign)]
		NSNumber BearingAccuracy { get; set; }

		// @property (readwrite, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * floor __attribute__((swift_private));
		[Export ("floor", ArgumentSemantic.Assign)]
		NSNumber Floor { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable source;
		[NullAllowed, Export ("source")]
		string Source { get; set; }

		// @property (readonly, copy, nonatomic) id _Nullable extra;
		[NullAllowed, Export ("extra", ArgumentSemantic.Copy)]
		NSObject Extra { get; }

		// -(BOOL)isEqualToLocation:(MBXLocation * _Nonnull)other;
		[Export ("isEqualToLocation:")]
		bool IsEqualToLocation (MBXLocation other);
	}

	// @interface Additions (MBXLocation)
	[Category]
	[BaseType (typeof(MBXLocation))]
	interface MBXLocation_Additions
	{
		// -(instancetype _Nonnull)initWithCLLocation:(CLLocation * _Nonnull)location;
		[Export ("initWithCLLocation:")]
		MBXLocation FromLocation (CLLocation location);

		// -(instancetype _Nonnull)initWithCLLocation:(CLLocation * _Nonnull)location extra:(id _Nullable)extra;
		[Export ("initWithCLLocation:extra:")]
		MBXLocation FromLocation (CLLocation location, [NullAllowed] NSObject extra);
	}

	// @interface MBXTilesetDescriptor : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXTilesetDescriptor
	{
	}

	// @protocol MBXCancelable
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBXCancelable { }

    [Model, Protocol]
	[BaseType(typeof(NSObject))]
	interface MBXCancelable
	{
		// @required -(void)cancel;
		[Abstract]
		[Export ("cancel")]
		void Cancel ();
	}

	// @interface MBXHttpRequest : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXHttpRequest
	{
		// -(instancetype _Nonnull)initWithUrl:(NSString * _Nonnull)url headers:(NSDictionary<NSString *,NSString *> * _Nonnull)headers sdkInformation:(MBXSdkInformation * _Nonnull)sdkInformation body:(NSData * _Nullable)body;
		[Export ("initWithUrl:headers:sdkInformation:body:")]
		NativeHandle Constructor (string url, NSDictionary<NSString, NSString> headers, MBXSdkInformation sdkInformation, [NullAllowed] NSData body);

		// -(instancetype _Nonnull)initWithMethod:(MBXHttpMethod)method url:(NSString * _Nonnull)url headers:(NSDictionary<NSString *,NSString *> * _Nonnull)headers timeout:(uint64_t)timeout networkRestriction:(MBXNetworkRestriction)networkRestriction sdkInformation:(MBXSdkInformation * _Nonnull)sdkInformation body:(NSData * _Nullable)body flags:(uint32_t)flags;
		[Export ("initWithMethod:url:headers:timeout:networkRestriction:sdkInformation:body:flags:")]
		NativeHandle Constructor (MBXHttpMethod method, string url, NSDictionary<NSString, NSString> headers, ulong timeout, MBXNetworkRestriction networkRestriction, MBXSdkInformation sdkInformation, [NullAllowed] NSData body, uint flags);

		// @property (readwrite, nonatomic) MBXHttpMethod method;
		[Export ("method", ArgumentSemantic.Assign)]
		MBXHttpMethod Method { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; }

		// @property (readwrite, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull headers;
		[Export ("headers", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Headers { get; set; }

		// @property (readonly, nonatomic) uint64_t timeout;
		[Export ("timeout")]
		ulong Timeout { get; }

		// @property (readonly, nonatomic) MBXNetworkRestriction networkRestriction;
		[Export ("networkRestriction")]
		MBXNetworkRestriction NetworkRestriction { get; }

		// @property (readonly, nonatomic) MBXSdkInformation * _Nonnull sdkInformation;
		[Export ("sdkInformation")]
		MBXSdkInformation SdkInformation { get; }

		// @property (readonly, nonatomic) NSData * _Nullable body;
		[NullAllowed, Export ("body")]
		NSData Body { get; }

		// @property (readonly, nonatomic) uint32_t flags;
		[Export ("flags")]
		uint Flags { get; }
	}

	// @interface MBXHttpRequestError : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXHttpRequestError
	{
		// -(instancetype _Nonnull)initWithType:(MBXHttpRequestErrorType)type message:(NSString * _Nonnull)message;
		[Export ("initWithType:message:")]
		NativeHandle Constructor (MBXHttpRequestErrorType type, string message);

		// @property (readonly, nonatomic) MBXHttpRequestErrorType type;
		[Export ("type")]
		MBXHttpRequestErrorType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }
	}

	// @interface MBXHttpResponseData : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXHttpResponseData
	{
		// -(instancetype _Nonnull)initWithHeaders:(NSDictionary<NSString *,NSString *> * _Nonnull)headers code:(int32_t)code data:(NSData * _Nonnull)data;
		[Export ("initWithHeaders:code:data:")]
		NativeHandle Constructor (NSDictionary<NSString, NSString> headers, int code, NSData data);

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull headers;
		[Export ("headers", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Headers { get; }

		// @property (readonly, nonatomic) int32_t code;
		[Export ("code")]
		int Code { get; }

		// @property (readonly, nonatomic) NSData * _Nonnull data;
		[Export ("data")]
		NSData Data { get; }
	}

	// @interface MBXHttpResponse : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXHttpResponse
	{
		// @property (readonly, nonatomic) uint64_t requestId;
		[Export ("requestId")]
		ulong RequestId { get; }

		// @property (readonly, nonatomic) MBXHttpRequest * _Nonnull request;
		[Export ("request")]
		MBXHttpRequest Request { get; }
	}

    // typedef void (^MBXHttpServiceCancellationCallback)(uint64_t id_, MBXHttpRequest * _Nonnull request); // NOLINT(modernize-use-using)
    delegate void MBXHttpServiceCancellationCallback (ulong id_, MBXHttpRequest request);

	// @interface MBXHttpServiceFactory : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXHttpServiceFactory
	{
		// +(void)setHttpServiceInterceptorForInterceptor:(id<MBXHttpServiceInterceptorInterface> _Nullable)interceptor;
		[Static]
		[Export ("setHttpServiceInterceptorForInterceptor:")]
		void SetHttpServiceInterceptorForInterceptor ([NullAllowed] MBXHttpServiceInterceptorInterface interceptor);

        // + (nonnull id<MBXCancelable>)setCancellationCallbackForCallback:(nonnull MBXHttpServiceCancellationCallback)callback __attribute((ns_returns_retained));
        [Static]
		[Export ("setCancellationCallbackForCallback:")]
        IMBXCancelable setCancellationCallbackForCallback (MBXHttpServiceCancellationCallback interceptor);

		// +(void)setMaxRequestsPerHostForMax:(uint8_t)max;
		[Static]
		[Export ("setMaxRequestsPerHostForMax:")]
		void SetMaxRequestsPerHostForMax (byte max);
	}

	// typedef void (^MBXHttpServiceInterceptorRequestContinuation)(MBXHttpRequestOrResponse * _Nonnull);
	delegate void MBXHttpServiceInterceptorRequestContinuation (MBXHttpRequestOrResponse arg0);

	// typedef void (^MBXHttpServiceInterceptorResponseContinuation)(MBXHttpResponse * _Nonnull);
	delegate void MBXHttpServiceInterceptorResponseContinuation (MBXHttpResponse arg0);

	// @protocol MBXHttpServiceInterceptorInterface
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBXHttpServiceInterceptorInterface { }

    [Model, Protocol]
	[BaseType(typeof(NSObject))]
	interface MBXHttpServiceInterceptorInterface
	{
		// @required -(void)onRequestForRequest:(MBXHttpRequest * _Nonnull)request continuation:(MBXHttpServiceInterceptorRequestContinuation _Nonnull)continuation;
		[Abstract]
		[Export ("onRequestForRequest:continuation:")]
		void OnRequestForRequest (MBXHttpRequest request, MBXHttpServiceInterceptorRequestContinuation continuation);

		// @required -(void)onResponseForResponse:(MBXHttpResponse * _Nonnull)response continuation:(MBXHttpServiceInterceptorResponseContinuation _Nonnull)continuation;
		[Abstract]
		[Export ("onResponseForResponse:continuation:")]
		void OnResponseForResponse (MBXHttpResponse response, MBXHttpServiceInterceptorResponseContinuation continuation);
	}

	// typedef void (^MBXHttpResponseCallback)(MBXHttpResponse * _Nonnull);
	delegate void MBXHttpResponseCallback (MBXHttpResponse arg0);

	// @interface MBXHttpRequestOrResponse : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXHttpRequestOrResponse
	{
		// +(instancetype _Nonnull)fromHttpRequest:(MBXHttpRequest * _Nonnull)value;
		[Static]
		[Export ("fromHttpRequest:")]
		MBXHttpRequestOrResponse FromHttpRequest (MBXHttpRequest value);

		// +(instancetype _Nonnull)fromHttpResponse:(MBXHttpResponse * _Nonnull)value;
		[Static]
		[Export ("fromHttpResponse:")]
		MBXHttpRequestOrResponse FromHttpResponse (MBXHttpResponse value);

		// -(BOOL)isHttpRequest;
		[Export ("isHttpRequest")]
		bool IsHttpRequest { get; }

		// -(BOOL)isHttpResponse;
		[Export ("isHttpResponse")]
		bool IsHttpResponse { get; }

		// -(MBXHttpRequest * _Nonnull)getHttpRequest __attribute__((ns_returns_retained));
		[Export ("getHttpRequest")]
		MBXHttpRequest HttpRequest { get; }

		// -(MBXHttpResponse * _Nonnull)getHttpResponse __attribute__((ns_returns_retained));
		[Export ("getHttpResponse")]
		MBXHttpResponse HttpResponse { get; }

		// @property (readonly, nonatomic) MBXHttpRequestOrResponseType type;
		[Export ("type")]
		MBXHttpRequestOrResponseType Type { get; }
	}

	// @interface MBXHttpRequestFlags : NSObject
	[BaseType (typeof(NSObject))]
	interface MBXHttpRequestFlags
	{
		// @property (readonly, nonatomic, class) uint32_t None;
		[Static]
		[Export ("None")]
		uint None { get; }

		// @property (readonly, nonatomic, class) uint32_t KeepCompression;
		[Static]
		[Export ("KeepCompression")]
		uint KeepCompression { get; }

		// @property (readonly, nonatomic, class) uint32_t PauseInBackground;
		[Static]
		[Export ("PauseInBackground")]
		uint PauseInBackground { get; }

        // @property (nonatomic, class, readonly) uint32_t PreventCoalescing;
		[Static]
		[Export ("PreventCoalescing")]
		uint PreventCoalescing { get; }
	}

	// @interface MBXLocationError : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXLocationError
	{
		// -(instancetype _Nonnull)initWithCode:(MBXLocationErrorCode)code message:(NSString * _Nonnull)message;
		[Export ("initWithCode:message:")]
		NativeHandle Constructor (MBXLocationErrorCode code, string message);

		// @property (readonly, nonatomic) MBXLocationErrorCode code;
		[Export ("code")]
		MBXLocationErrorCode Code { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }
	}

	// @interface MBXIntervalSettings : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXIntervalSettings
	{
		// -(instancetype _Nonnull)initWithMinimumInterval:(NSNumber * _Nullable)minimumInterval maximumInterval:(NSNumber * _Nullable)maximumInterval interval:(NSNumber * _Nullable)interval;
		[Export ("initWithMinimumInterval:maximumInterval:interval:")]
		NativeHandle Constructor ([NullAllowed] NSNumber minimumInterval, [NullAllowed] NSNumber maximumInterval, [NullAllowed] NSNumber interval);

		// @property (readonly, nonatomic) NSNumber * _Nullable minimumInterval;
		[NullAllowed, Export ("minimumInterval")]
		NSNumber MinimumInterval { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable maximumInterval;
		[NullAllowed, Export ("maximumInterval")]
		NSNumber MaximumInterval { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable interval;
		[NullAllowed, Export ("interval")]
		NSNumber Interval { get; }

		// -(BOOL)isEqualToIntervalSettings:(MBXIntervalSettings * _Nonnull)other;
		[Export ("isEqualToIntervalSettings:")]
		bool IsEqualToIntervalSettings (MBXIntervalSettings other);
	}

	// @interface MBXLocationProviderRequest : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXLocationProviderRequest
	{
		// -(instancetype _Nonnull)initWithAccuracy:(NSNumber * _Nullable)accuracy displacement:(NSNumber * _Nullable)displacement interval:(MBXIntervalSettings * _Nullable)interval;
		[Export ("initWithAccuracy:displacement:interval:")]
		NativeHandle Constructor ([NullAllowed] NSNumber accuracy, [NullAllowed] NSNumber displacement, [NullAllowed] MBXIntervalSettings interval);

		// @property (readonly, nonatomic) NSNumber * _Nullable accuracy;
		[NullAllowed, Export ("accuracy")]
		NSNumber Accuracy { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable displacement;
		[NullAllowed, Export ("displacement")]
		NSNumber Displacement { get; }

		// @property (readonly, nonatomic) MBXIntervalSettings * _Nullable interval;
		[NullAllowed, Export ("interval")]
		MBXIntervalSettings Interval { get; }

		// -(BOOL)isEqualToLocationProviderRequest:(MBXLocationProviderRequest * _Nonnull)other;
		[Export ("isEqualToLocationProviderRequest:")]
		bool IsEqualToLocationProviderRequest (MBXLocationProviderRequest other);
	}

	// @interface MBXLocationServiceFactory : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXLocationServiceFactory
	{
	}

	// @protocol MBXLocationServiceObserver
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBXLocationServiceObserver {}

	[Model, Protocol]
	[BaseType(typeof(NSObject))]
	interface MBXLocationServiceObserver
	{
		// @required -(void)onAvailabilityChangedForIsAvailable:(BOOL)isAvailable;
		[Abstract]
		[Export ("onAvailabilityChangedForIsAvailable:")]
		void OnAvailabilityChangedForIsAvailable (bool isAvailable);

		// @required -(void)onPermissionStatusChangedForPermission:(MBXPermissionStatus)permission;
		[Abstract]
		[Export ("onPermissionStatusChangedForPermission:")]
		void OnPermissionStatusChangedForPermission (MBXPermissionStatus permission);

		// @required -(void)onAccuracyAuthorizationChangedForAuthorization:(MBXAccuracyAuthorization)authorization;
		[Abstract]
		[Export ("onAccuracyAuthorizationChangedForAuthorization:")]
		void OnAccuracyAuthorizationChangedForAuthorization (MBXAccuracyAuthorization authorization);
	}

	// @protocol MBXLocationObserver
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBXLocationObserver {}

	[Model, Protocol]
	[BaseType(typeof(NSObject))]
	interface MBXLocationObserver
	{
		// @required -(void)onLocationUpdateReceivedForLocations:(NSArray<MBXLocation *> * _Nonnull)locations;
		[Abstract]
		[Export ("onLocationUpdateReceivedForLocations:")]
		void OnLocationUpdateReceivedForLocations (MBXLocation[] locations);
	}

	// @protocol MBXLocationProvider
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBXLocationProvider { }

    [Model, Protocol]
[BaseType(typeof(NSObject))]
	interface MBXLocationProvider
	{
		// @required -(void)addLocationObserverForObserver:(id<MBXLocationObserver> _Nonnull)observer;
		[Abstract]
		[Export ("addLocationObserverForObserver:")]
		void AddLocationObserverForObserver (IMBXLocationObserver observer);

		// @required -(void)removeLocationObserverForObserver:(id<MBXLocationObserver> _Nonnull)observer;
		[Abstract]
		[Export ("removeLocationObserverForObserver:")]
		void RemoveLocationObserverForObserver (IMBXLocationObserver observer);

		// @required -(MBXLocation * _Nullable)getLastObservedLocation;
		[Abstract]
		[NullAllowed, Export ("getLastObservedLocation")]
		MBXLocation LastObservedLocation { get; }
	}

	// @protocol MBXDeviceLocationProvider <MBXLocationProvider>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBXDeviceLocationProvider { }

    [Model, Protocol]
	[BaseType(typeof(NSObject))]
    interface MBXDeviceLocationProvider : MBXLocationProvider
	{
		// @required -(NSString * _Nullable)getName;
		[Abstract]
		[NullAllowed, Export ("getName")]
		string Name { get; }
	}

	// typedef void (^MBXGetLocationCallback)(MBXLocation * _Nullable);
	delegate void MBXGetLocationCallback ([NullAllowed] MBXLocation arg0);

	// @interface MBXLocationExtraKeys : NSObject
	[BaseType (typeof(NSObject))]
	interface MBXLocationExtraKeys
	{
		// @property (readonly, nonatomic, class) NSString * IsMock;
		[Static]
		[Export ("IsMock")]
		string IsMock { get; }

		// @property (readonly, nonatomic, class) NSString * IsExternal;
		[Static]
		[Export ("IsExternal")]
		string IsExternal { get; }
	}

	// @interface MBXLogConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXLogConfiguration
	{
		// +(void)registerLogWriterBackendForLogWriter:(id<MBXLogWriterBackend> _Nullable)logWriter;
		[Static]
		[Export ("registerLogWriterBackendForLogWriter:")]
		void RegisterLogWriterBackendForLogWriter ([NullAllowed] MBXLogWriterBackend logWriter);

		// +(void)setLoggingLevelForUpTo:(NSNumber * _Nullable)upTo;
		[Static]
		[Export ("setLoggingLevelForUpTo:")]
		void SetLoggingLevelForUpTo ([NullAllowed] NSNumber upTo);

		// +(NSNumber * _Nullable)getLoggingLevel __attribute__((ns_returns_retained));
		[Static]
		[NullAllowed, Export("getLoggingLevel")]
		NSNumber GetLoggingLevel();

		// +(void)setLoggingLevelForCategory:(NSString * _Nonnull)category upTo:(NSNumber * _Nullable)upTo;
		[Static]
		[Export ("setLoggingLevelForCategory:upTo:")]
		void SetLoggingLevelForCategory (string category, [NullAllowed] NSNumber upTo);

		// +(NSNumber * _Nullable)getLoggingLevelForCategory:(NSString * _Nonnull)category __attribute__((ns_returns_retained));
		[Static]
		[Export ("getLoggingLevelForCategory:")]
		[return: NullAllowed]
		NSNumber GetLoggingLevelForCategory (string category);

		// +(void)resetLoggingLevelForCategory:(NSString * _Nonnull)category;
		[Static]
		[Export ("resetLoggingLevelForCategory:")]
		void ResetLoggingLevelForCategory (string category);
	}

	// @protocol MBXLogWriterBackend
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBXLogWriterBackend { }

    [Model, Protocol]
	[BaseType(typeof(NSObject))]
	interface MBXLogWriterBackend
	{
		// @required -(void)writeLogForLevel:(MBXLoggingLevel)level message:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("writeLogForLevel:message:")]
		void Message (MBXLoggingLevel level, string message);
	}

	// @interface MBXMapboxOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXMapboxOptions
	{
		// +(void)setAccessTokenForToken:(NSString * _Nonnull)token __attribute__((swift_private));
		[Static]
		[Export ("setAccessTokenForToken:")]
		void SetAccessTokenForToken (string token);

		// +(NSString * _Nonnull)getAccessToken __attribute__((ns_returns_retained)) __attribute__((swift_private));
		[Static]
		[Export ("getAccessToken")]
		string AccessToken { get; }
	}

	// @interface MBXOfflineSwitch : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXOfflineSwitch
	{
		// -(void)setMapboxStackConnectedForConnected:(BOOL)connected;
		[Export ("setMapboxStackConnectedForConnected:")]
		void SetMapboxStackConnectedForConnected (bool connected);

		// -(BOOL)isMapboxStackConnected;
		[Export("isMapboxStackConnected")]
		bool IsMapboxStackConnected { get; }

		// +(MBXOfflineSwitch * _Nonnull)getInstance __attribute__((ns_returns_retained));
		[Static]
		[Export("getInstance")]
		MBXOfflineSwitch Instance { get; }

		// +(void)reset;
		[Static]
		[Export ("reset")]
		void Reset ();
	}

	// @interface MBXSdkInformation : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXSdkInformation
	{
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name version:(NSString * _Nonnull)version packageName:(NSString * _Nullable)packageName;
		[Export ("initWithName:version:packageName:")]
		NativeHandle Constructor (string name, string version, [NullAllowed] string packageName);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable packageName;
		[NullAllowed, Export ("packageName")]
		string PackageName { get; }

		// -(BOOL)isEqualToSdkInformation:(MBXSdkInformation * _Nonnull)other;
		[Export ("isEqualToSdkInformation:")]
		bool IsEqualToSdkInformation (MBXSdkInformation other);
	}

	// @interface MBXSdkInformationQuery : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXSdkInformationQuery
	{
		// +(NSArray<MBXSdkInformation *> * _Nonnull)getSdkInformation __attribute__((ns_returns_retained));
		[Static]
		[Export ("getSdkInformation")]
		MBXSdkInformation[] SdkInformation { get; }

		// +(MBXSdkInformation * _Nullable)getSdkInformationByNameForName:(NSString * _Nonnull)name __attribute__((ns_returns_retained));
		[Static]
		[Export ("getSdkInformationByNameForName:")]
		[return: NullAllowed]
		MBXSdkInformation GetSdkInformationByNameForName (string name);
	}

	// @interface MBXSettingsService : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXSettingsService
	{
	}

	// @interface MBXSettingsServiceFactory : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXSettingsServiceFactory
	{
		// +(MBXSettingsService * _Nonnull)getInstanceForStorageType:(MBXSettingsServiceStorageType)storageType __attribute__((ns_returns_retained));
		[Static]
		[Export ("getInstanceForStorageType:")]
		MBXSettingsService GetInstanceForStorageType (MBXSettingsServiceStorageType storageType);
	}

	// @interface MBXMapboxCommonSettings : NSObject
	[BaseType (typeof(NSObject))]
	interface MBXMapboxCommonSettings
	{
		// @property (readonly, nonatomic, class) NSString * Language;
		[Static]
		[Export ("Language")]
		string Language { get; }

		// @property (readonly, nonatomic, class) NSString * Worldview;
		[Static]
		[Export ("Worldview")]
		string Worldview { get; }
	}

	// typedef void (^MBXTileRegionEstimateProgressCallback)(MBXTileRegionEstimateProgress * _Nonnull);
	delegate void MBXTileRegionEstimateProgressCallback (MBXTileRegionEstimateProgress arg0);

	// typedef void (^MBXTileRegionLoadProgressCallback)(MBXTileRegionLoadProgress * _Nonnull);
	delegate void MBXTileRegionLoadProgressCallback (MBXTileRegionLoadProgress arg0);

	// @interface MBXTileStore : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXTileStore
	{
		// +(MBXTileStore * _Nonnull)createForPath:(NSString * _Nonnull)path __attribute__((ns_returns_retained)) __attribute__((swift_private));
		[Static]
		[Export ("createForPath:")]
		MBXTileStore CreateForPath (string path);

		// +(MBXTileStore * _Nonnull)create __attribute__((ns_returns_retained)) __attribute__((swift_private));
		[Static]
		[Export("create")]
		MBXTileStore Create();

		// -(id<MBXCancelable> _Nonnull)loadTileRegionForId:(NSString * _Nonnull)id_ loadOptions:(MBXTileRegionLoadOptions * _Nonnull)loadOptions __attribute__((ns_returns_retained)) __attribute__((swift_private));
		[Export ("loadTileRegionForId:loadOptions:")]
		MBXCancelable LoadTileRegionForId (string id_, MBXTileRegionLoadOptions loadOptions);

		// -(void)removeTileRegionForId:(NSString * _Nonnull)id_;
		[Export ("removeTileRegionForId:")]
		void RemoveTileRegionForId (string id_);

		// -(void)setOptionForKey:(NSString * _Nonnull)key value:(id _Nonnull)value;
		[Export ("setOptionForKey:value:")]
		void SetOptionForKey (string key, NSObject value);

		// -(void)setOptionForKey:(NSString * _Nonnull)key domain:(MBXTileDataDomain)domain value:(id _Nonnull)value;
		[Export ("setOptionForKey:domain:value:")]
		void SetOptionForKey (string key, MBXTileDataDomain domain, NSObject value);
	}

	// @interface MBXTileRegion : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXTileRegion
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, nonatomic) uint64_t requiredResourceCount;
		[Export ("requiredResourceCount")]
		ulong RequiredResourceCount { get; }

		// @property (readonly, nonatomic) uint64_t completedResourceCount;
		[Export ("completedResourceCount")]
		ulong CompletedResourceCount { get; }

		// @property (readonly, nonatomic) uint64_t completedResourceSize;
		[Export ("completedResourceSize")]
		ulong CompletedResourceSize { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable expires;
		[NullAllowed, Export ("expires")]
		NSDate Expires { get; }
	}

	// @interface MBXTileRegionLoadProgress : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXTileRegionLoadProgress
	{
		// -(instancetype _Nonnull)initWithCompletedResourceCount:(uint64_t)completedResourceCount completedResourceSize:(uint64_t)completedResourceSize erroredResourceCount:(uint64_t)erroredResourceCount requiredResourceCount:(uint64_t)requiredResourceCount loadedResourceCount:(uint64_t)loadedResourceCount loadedResourceSize:(uint64_t)loadedResourceSize;
		[Export ("initWithCompletedResourceCount:completedResourceSize:erroredResourceCount:requiredResourceCount:loadedResourceCount:loadedResourceSize:")]
		NativeHandle Constructor (ulong completedResourceCount, ulong completedResourceSize, ulong erroredResourceCount, ulong requiredResourceCount, ulong loadedResourceCount, ulong loadedResourceSize);

		// @property (readonly, nonatomic) uint64_t completedResourceCount;
		[Export ("completedResourceCount")]
		ulong CompletedResourceCount { get; }

		// @property (readonly, nonatomic) uint64_t completedResourceSize;
		[Export ("completedResourceSize")]
		ulong CompletedResourceSize { get; }

		// @property (readonly, nonatomic) uint64_t erroredResourceCount;
		[Export ("erroredResourceCount")]
		ulong ErroredResourceCount { get; }

		// @property (readonly, nonatomic) uint64_t requiredResourceCount;
		[Export ("requiredResourceCount")]
		ulong RequiredResourceCount { get; }

		// @property (readonly, nonatomic) uint64_t loadedResourceCount;
		[Export ("loadedResourceCount")]
		ulong LoadedResourceCount { get; }

		// @property (readonly, nonatomic) uint64_t loadedResourceSize;
		[Export ("loadedResourceSize")]
		ulong LoadedResourceSize { get; }
	}

	// @interface MBXTileRegionError : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXTileRegionError
	{
		// -(instancetype _Nonnull)initWithType:(MBXTileRegionErrorType)type message:(NSString * _Nonnull)message;
		[Export ("initWithType:message:")]
		NativeHandle Constructor (MBXTileRegionErrorType type, string message);

		// @property (readonly, nonatomic) MBXTileRegionErrorType type;
		[Export ("type")]
		MBXTileRegionErrorType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }
	}

	// @interface MBXTileRegionLoadOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXTileRegionLoadOptions
	{
		// -(instancetype _Nonnull)initWithGeometry:(MBXGeometry * _Nullable)geometry descriptors:(NSArray<MBXTilesetDescriptor *> * _Nullable)descriptors metadata:(id _Nullable)metadata startLocation:(MBXCoordinate2D * _Nullable)startLocation averageBytesPerSecond:(NSNumber * _Nullable)averageBytesPerSecond extraOptions:(id _Nullable)extraOptions __attribute__((swift_private));
		[Export ("initWithGeometry:descriptors:metadata:startLocation:averageBytesPerSecond:extraOptions:")]
		NativeHandle Constructor ([NullAllowed] MBXGeometry geometry, [NullAllowed] MBXTilesetDescriptor[] descriptors, [NullAllowed] NSObject metadata, [NullAllowed] MBXCoordinate2D startLocation, [NullAllowed] NSNumber averageBytesPerSecond, [NullAllowed] NSObject extraOptions);

		// -(instancetype _Nonnull)initWithGeometry:(MBXGeometry * _Nullable)geometry descriptors:(NSArray<MBXTilesetDescriptor *> * _Nullable)descriptors metadata:(id _Nullable)metadata acceptExpired:(BOOL)acceptExpired networkRestriction:(MBXNetworkRestriction)networkRestriction startLocation:(MBXCoordinate2D * _Nullable)startLocation averageBytesPerSecond:(NSNumber * _Nullable)averageBytesPerSecond extraOptions:(id _Nullable)extraOptions __attribute__((swift_private));
		[Export ("initWithGeometry:descriptors:metadata:acceptExpired:networkRestriction:startLocation:averageBytesPerSecond:extraOptions:")]
		NativeHandle Constructor ([NullAllowed] MBXGeometry geometry, [NullAllowed] MBXTilesetDescriptor[] descriptors, [NullAllowed] NSObject metadata, bool acceptExpired, MBXNetworkRestriction networkRestriction, [NullAllowed] MBXCoordinate2D startLocation, [NullAllowed] NSNumber averageBytesPerSecond, [NullAllowed] NSObject extraOptions);

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT MBXGeometry * geometry __attribute__((swift_private));
		[Export ("geometry")]
		MBXGeometry Geometry { get; }

		// @property (readonly, copy, nonatomic) NSArray<MBXTilesetDescriptor *> * _Nullable descriptors;
		[NullAllowed, Export ("descriptors", ArgumentSemantic.Copy)]
		MBXTilesetDescriptor[] Descriptors { get; }

		// @property (readonly, copy, nonatomic) id _Nullable metadata;
		[NullAllowed, Export ("metadata", ArgumentSemantic.Copy)]
		NSObject Metadata { get; }

		// @property (readonly, nonatomic) BOOL acceptExpired;
		[Export ("acceptExpired")]
		bool AcceptExpired { get; }

		// @property (readonly, nonatomic) MBXNetworkRestriction networkRestriction;
		[Export ("networkRestriction")]
		MBXNetworkRestriction NetworkRestriction { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT MBXCoordinate2D * startLocation __attribute__((swift_private));
		[Export ("startLocation")]
		MBXCoordinate2D StartLocation { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * averageBytesPerSecond __attribute__((swift_private));
		[Export ("averageBytesPerSecond")]
		NSNumber AverageBytesPerSecond { get; }

		// @property (readonly, copy, nonatomic) id _Nullable extraOptions;
		[NullAllowed, Export ("extraOptions", ArgumentSemantic.Copy)]
		NSObject ExtraOptions { get; }
	}

	// @interface MBXTileRegionEstimateOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXTileRegionEstimateOptions
	{
		// -(instancetype _Nonnull)initWithExtraOptions:(id _Nullable)extraOptions;
		[Export ("initWithExtraOptions:")]
		NativeHandle Constructor ([NullAllowed] NSObject extraOptions);

		// -(instancetype _Nonnull)initWithErrorMargin:(float)errorMargin preciseEstimationTimeout:(NSTimeInterval)preciseEstimationTimeout timeout:(NSTimeInterval)timeout extraOptions:(id _Nullable)extraOptions;
		[Export ("initWithErrorMargin:preciseEstimationTimeout:timeout:extraOptions:")]
		NativeHandle Constructor (float errorMargin, double preciseEstimationTimeout, double timeout, [NullAllowed] NSObject extraOptions);

		// @property (readonly, nonatomic) float errorMargin;
		[Export ("errorMargin")]
		float ErrorMargin { get; }

		// @property (readonly, nonatomic) NSTimeInterval preciseEstimationTimeout;
		[Export ("preciseEstimationTimeout")]
		double PreciseEstimationTimeout { get; }

		// @property (readonly, nonatomic) NSTimeInterval timeout;
		[Export ("timeout")]
		double Timeout { get; }

		// @property (readonly, copy, nonatomic) id _Nullable extraOptions;
		[NullAllowed, Export ("extraOptions", ArgumentSemantic.Copy)]
		NSObject ExtraOptions { get; }

		// -(BOOL)isEqualToTileRegionEstimateOptions:(MBXTileRegionEstimateOptions * _Nonnull)other;
		[Export ("isEqualToTileRegionEstimateOptions:")]
		bool IsEqualToTileRegionEstimateOptions (MBXTileRegionEstimateOptions other);
	}

	// @interface MBXTileRegionEstimateResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXTileRegionEstimateResult
	{
		// -(instancetype _Nonnull)initWithErrorMargin:(double)errorMargin transferSize:(uint64_t)transferSize storageSize:(uint64_t)storageSize extraData:(id _Nullable)extraData;
		[Export ("initWithErrorMargin:transferSize:storageSize:extraData:")]
		NativeHandle Constructor (double errorMargin, ulong transferSize, ulong storageSize, [NullAllowed] NSObject extraData);

		// @property (readonly, nonatomic) double errorMargin;
		[Export ("errorMargin")]
		double ErrorMargin { get; }

		// @property (readonly, nonatomic) uint64_t transferSize;
		[Export ("transferSize")]
		ulong TransferSize { get; }

		// @property (readonly, nonatomic) uint64_t storageSize;
		[Export ("storageSize")]
		ulong StorageSize { get; }

		// @property (readonly, copy, nonatomic) id _Nullable extraData;
		[NullAllowed, Export ("extraData", ArgumentSemantic.Copy)]
		NSObject ExtraData { get; }

		// -(BOOL)isEqualToTileRegionEstimateResult:(MBXTileRegionEstimateResult * _Nonnull)other;
		[Export ("isEqualToTileRegionEstimateResult:")]
		bool IsEqualToTileRegionEstimateResult (MBXTileRegionEstimateResult other);
	}

	// @interface MBXTileRegionEstimateProgress : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXTileRegionEstimateProgress
	{
		// -(instancetype _Nonnull)initWithRequiredResourceCount:(uint64_t)requiredResourceCount erroredResourceCount:(uint64_t)erroredResourceCount completedResourceCount:(uint64_t)completedResourceCount partialResult:(MBXTileRegionEstimateResult * _Nonnull)partialResult;
		[Export ("initWithRequiredResourceCount:erroredResourceCount:completedResourceCount:partialResult:")]
		NativeHandle Constructor (ulong requiredResourceCount, ulong erroredResourceCount, ulong completedResourceCount, MBXTileRegionEstimateResult partialResult);

		// @property (readonly, nonatomic) uint64_t requiredResourceCount;
		[Export ("requiredResourceCount")]
		ulong RequiredResourceCount { get; }

		// @property (readonly, nonatomic) uint64_t erroredResourceCount;
		[Export ("erroredResourceCount")]
		ulong ErroredResourceCount { get; }

		// @property (readonly, nonatomic) uint64_t completedResourceCount;
		[Export ("completedResourceCount")]
		ulong CompletedResourceCount { get; }

		// @property (readonly, nonatomic) MBXTileRegionEstimateResult * _Nonnull partialResult;
		[Export ("partialResult")]
		MBXTileRegionEstimateResult PartialResult { get; }

		// -(BOOL)isEqualToTileRegionEstimateProgress:(MBXTileRegionEstimateProgress * _Nonnull)other;
		[Export ("isEqualToTileRegionEstimateProgress:")]
		bool IsEqualToTileRegionEstimateProgress (MBXTileRegionEstimateProgress other);
	}

	// @interface MBXTileStoreOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface MBXTileStoreOptions
	{
		// @property (readonly, nonatomic, class) NSString * DiskQuota;
		[Static]
		[Export ("DiskQuota")]
		string DiskQuota { get; }

		// @property (readonly, nonatomic, class) NSString * MapboxAPIURL;
		[Static]
		[Export ("MapboxAPIURL")]
		string MapboxAPIURL { get; }

		// @property (readonly, nonatomic, class) NSString * TileURLTemplate;
		[Static]
		[Export ("TileURLTemplate")]
		string TileURLTemplate { get; }
	}

	// @interface MBXValueConverter : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXValueConverter
	{
		// +(NSString * _Nonnull)toJsonForValue:(id _Nonnull)value __attribute__((ns_returns_retained));
		[Static]
		[Export ("toJsonForValue:")]
		string ToJsonForValue (NSObject value);

		// +(NSString * _Nonnull)toJsonForValue:(id _Nonnull)value indent:(uint32_t)indent __attribute__((ns_returns_retained));
		[Static]
		[Export ("toJsonForValue:indent:")]
		string ToJsonForValue (NSObject value, uint indent);
	}

	// @interface MBXDataRef : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBXDataRef
	{
		// @property (readonly, copy, nonatomic) NSData * _Nonnull data;
		[Export ("data", ArgumentSemantic.Copy)]
		NSData Data { get; }

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data __attribute__((objc_designated_initializer));
		[Export ("initWithData:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSData data);

	}
}
