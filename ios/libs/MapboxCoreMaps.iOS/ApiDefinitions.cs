using System;
using CoreLocation;
using Foundation;
using MapboxCoreMaps;
using Metal;
using ObjCRuntime;
using MapboxCommon;

namespace MapboxCoreMaps
{
    // @protocol MBMCustomRasterSourceTileRenderer
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBMCustomRasterSourceTileRenderer
    {
        // - (void)initializeForDevice:(uint64_t)device
        //         colorPixelFormat:(uint64_t)colorPixelFormat;
        [Export("initializeForDevice:colorPixelFormat:")]
        void InitializeForDevice(long device, long colorPixelFormat);
        
        // - (BOOL)isTileRenderableForTileID:(nonnull MBMCanonicalTileID *)tileID
        //                         status:(MBMCustomRasterSourceTileStatus)status;
        [Export("isTileRenderableForTileID:status:")]
        void IsTileRenderableForTileID(MBMCanonicalTileID tileID, MBMCustomRasterSourceTileStatus status);
        
        // - (void)prerenderForParameters:(nonnull MBMCustomLayerRenderParameters *)parameters
        //                 commandBuffer:(uint64_t)commandBuffer;
        [Export("prerenderForParameters:commandBuffer:")]
        void PrerenderForParameters(MBMCustomLayerRenderParameters parameters, long commandBuffer);
        
        // - (void)renderToTileForTileID:(nonnull MBMCanonicalTileID *)tileID
        //             commandEncoder:(uint64_t)commandEncoder;
        [Export("renderToTileForTileID:commandEncoder:")]
        void renderToTileForTileID(MBMCanonicalTileID parameters, long commandEncoder);
        
        // - (void)deinitialize;
        [Export("deinitialize")]
        void Deinitialize();
    }

    partial interface IMBMCustomRasterSourceTileRenderer {}

    // @interface MBMCustomRasterSourceClient : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCustomRasterSourceClient
	{
        // + (nonnull instancetype)fromCustomRasterSourceTileStatusChangedCallback:(nonnull MBMCustomRasterSourceTileStatusChangedCallback)value;
		[Static, Export ("fromCustomRasterSourceTileStatusChangedCallback:")]
		NativeHandle FromCustomRasterSourceTileStatusChangedCallback (MBMCustomRasterSourceTileStatusChangedCallback value);

        // + (nonnull instancetype)fromCustomRasterSourceTileRenderer:(nonnull id<MBMCustomRasterSourceTileRenderer>)value;
        [Static, Export ("fromCustomRasterSourceTileRenderer:")]
		NativeHandle FromCustomRasterSourceTileRenderer (IMBMCustomRasterSourceTileRenderer value);

        // - (BOOL)isCustomRasterSourceTileStatusChangedCallback;
        [Export("isCustomRasterSourceTileStatusChangedCallback")]
        bool IsCustomRasterSourceTileStatusChangedCallback();

        // - (BOOL)isCustomRasterSourceTileRenderer;
        [Export("isCustomRasterSourceTileRenderer")]
        bool IsCustomRasterSourceTileRenderer();

        // - (nonnull MBMCustomRasterSourceTileStatusChangedCallback)getCustomRasterSourceTileStatusChangedCallback __attribute((ns_returns_retained));
        [Export("getCustomRasterSourceTileStatusChangedCallback")]
        MBMCustomRasterSourceTileStatusChangedCallback GetCustomRasterSourceTileStatusChangedCallback();

        // - (nonnull id<MBMCustomRasterSourceTileRenderer>)getCustomRasterSourceTileRenderer __attribute((ns_returns_retained));
        [Export("getCustomRasterSourceTileRenderer")]
        IMBMCustomRasterSourceTileRenderer GetCustomRasterSourceTileRenderer();

        // @property (nonatomic, readonly) MBMCustomRasterSourceClientType type;
		[Export ("type")]
		MBMCustomRasterSourceClientType Type { get; }
    }

    // typedef void (^MBMCustomRasterSourceTileStatusChangedCallback)(MBMCanonicalTileID * _Nonnull tileId, MBMCustomRasterSourceTileStatus status); 
    delegate void MBMCustomRasterSourceTileStatusChangedCallback(MBMCanonicalTileID tileID, MBMCustomRasterSourceTileStatus status);
    
    // @interface MBMCustomRasterSourceTileData : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCustomRasterSourceTileData
	{
        // // This class provides custom init which should be called
        // - (nonnull instancetype)init NS_UNAVAILABLE;

        // // This class provides custom init which should be called
        // + (nonnull instancetype)new NS_UNAVAILABLE;


        // /** A `canonical tile id` of the tile. */
        // @property (nonatomic, readonly, nonnull) MBMCanonicalTileID *tileId;
		[Export ("tileId")]
		MBMCanonicalTileID TileId { get; }
    }


	// @interface MBMCoordinateInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCoordinateInfo
	{
		// -(instancetype _Nonnull)initWithCoordinate:(CLLocationCoordinate2D)coordinate isOnSurface:(BOOL)isOnSurface;
		[Export ("initWithCoordinate:isOnSurface:")]
		NativeHandle Constructor (CLLocationCoordinate2D coordinate, bool isOnSurface);

		// @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		// @property (readonly, nonatomic) BOOL isOnSurface;
		[Export ("isOnSurface")]
		bool IsOnSurface { get; }
	}

	// @interface MBMCoordinateBounds : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCoordinateBounds
	{
		// -(instancetype _Nonnull)initWithSouthwest:(CLLocationCoordinate2D)southwest northeast:(CLLocationCoordinate2D)northeast;
		[Export ("initWithSouthwest:northeast:")]
		NativeHandle Constructor (CLLocationCoordinate2D southwest, CLLocationCoordinate2D northeast);

		// -(instancetype _Nonnull)initWithSouthwest:(CLLocationCoordinate2D)southwest northeast:(CLLocationCoordinate2D)northeast infiniteBounds:(BOOL)infiniteBounds;
		[Export ("initWithSouthwest:northeast:infiniteBounds:")]
		NativeHandle Constructor (CLLocationCoordinate2D southwest, CLLocationCoordinate2D northeast, bool infiniteBounds);

		// +(MBMCoordinateBounds * _Nonnull)world __attribute__((ns_returns_retained)) __attribute__((swift_private));
		[Static]
		[Export ("world")]
		MBMCoordinateBounds World { get; }

		// +(MBMCoordinateBounds * _Nonnull)singletonForPoint:(CLLocationCoordinate2D)point __attribute__((ns_returns_retained)) __attribute__((swift_private));
		[Static]
		[Export ("singletonForPoint:")]
		MBMCoordinateBounds SingletonForPoint (CLLocationCoordinate2D point);

		// +(MBMCoordinateBounds * _Nonnull)hullForA:(CLLocationCoordinate2D)a b:(CLLocationCoordinate2D)b __attribute__((ns_returns_retained)) __attribute__((swift_private));
		[Static]
		[Export ("hullForA:b:")]
		MBMCoordinateBounds HullForA (CLLocationCoordinate2D a, CLLocationCoordinate2D b);

		// -(BOOL)isValid __attribute__((swift_private));
		[Export ("isValid")]
		bool IsValid { get; }

		// -(double)south __attribute__((swift_private));
		[Export ("south")]
		double South { get; }

		// -(double)west __attribute__((swift_private));
		[Export ("west")]
		double West { get; }

		// -(double)north __attribute__((swift_private));
		[Export ("north")]
		double North { get; }

		// -(double)east __attribute__((swift_private));
		[Export ("east")]
		double East { get; }

		// -(CLLocationCoordinate2D)southeast __attribute__((swift_private));
		[Export ("southeast")]
		CLLocationCoordinate2D Southeast { get; }

		// -(CLLocationCoordinate2D)northwest __attribute__((swift_private));
		[Export ("northwest")]
		CLLocationCoordinate2D Northwest { get; }

		// -(CLLocationCoordinate2D)center __attribute__((swift_private));
		[Export ("center")]
		CLLocationCoordinate2D Center { get; }

		// -(CLLocationCoordinate2D)constrainForPoint:(CLLocationCoordinate2D)point;
		[Export ("constrainForPoint:")]
		CLLocationCoordinate2D ConstrainForPoint (CLLocationCoordinate2D point);

		// -(BOOL)isEmpty __attribute__((swift_private));
		[Export ("isEmpty")]
		bool IsEmpty { get; }

		// -(BOOL)isBounded __attribute__((swift_private));
		[Export ("isBounded")]
		bool IsBounded { get; }

		// -(BOOL)crossesAntimeridian __attribute__((swift_private));
		[Export ("crossesAntimeridian")]
		bool CrossesAntimeridian { get; }

		// -(BOOL)containsForPoint:(CLLocationCoordinate2D)point wrappedCoordinates:(BOOL)wrappedCoordinates;
		[Export ("containsForPoint:wrappedCoordinates:")]
		bool ContainsForPoint (CLLocationCoordinate2D point, bool wrappedCoordinates);

		// -(BOOL)containsForArea:(MBMCoordinateBounds * _Nonnull)area wrappedCoordinates:(BOOL)wrappedCoordinates;
		[Export ("containsForArea:wrappedCoordinates:")]
		bool ContainsForArea (MBMCoordinateBounds area, bool wrappedCoordinates);

		// -(BOOL)containsLatitudeForLatitude:(double)latitude;
		[Export ("containsLatitudeForLatitude:")]
		bool ContainsLatitudeForLatitude (double latitude);

		// -(BOOL)containsLongitudeForLongitude:(double)longitude;
		[Export ("containsLongitudeForLongitude:")]
		bool ContainsLongitudeForLongitude (double longitude);

		// -(double)latitudeSpan __attribute__((swift_private));
		[Export ("latitudeSpan")]
		double LatitudeSpan { get; }

		// -(double)longitudeSpan __attribute__((swift_private));
		[Export ("longitudeSpan")]
		double LongitudeSpan { get; }

		// -(BOOL)intersectsForArea:(MBMCoordinateBounds * _Nonnull)area wrappedCoordinates:(BOOL)wrappedCoordinates;
		[Export ("intersectsForArea:wrappedCoordinates:")]
		bool IntersectsForArea (MBMCoordinateBounds area, bool wrappedCoordinates);

		// -(MBMCoordinateBounds * _Nonnull)extendForPoint:(CLLocationCoordinate2D)point __attribute__((ns_returns_retained));
		[Export ("extendForPoint:")]
		MBMCoordinateBounds ExtendForPoint (CLLocationCoordinate2D point);

		// -(MBMCoordinateBounds * _Nonnull)extendForArea:(MBMCoordinateBounds * _Nonnull)area __attribute__((ns_returns_retained));
		[Export ("extendForArea:")]
		MBMCoordinateBounds ExtendForArea (MBMCoordinateBounds area);

		// @property (readonly, nonatomic) CLLocationCoordinate2D southwest;
		[Export ("southwest")]
		CLLocationCoordinate2D Southwest { get; }

		// @property (readonly, nonatomic) CLLocationCoordinate2D northeast;
		[Export ("northeast")]
		CLLocationCoordinate2D Northeast { get; }

		// @property (readonly, nonatomic) BOOL infiniteBounds;
		[Export ("infiniteBounds")]
		bool InfiniteBounds { get; }
	}

	// @interface MBMFreeCameraOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMFreeCameraOptions
	{
		// -(MBMVec3 * _Nullable)getPosition __attribute__((ns_returns_retained));
		[NullAllowed, Export ("getPosition")]
		MBMVec3 Position { get; }

		// -(void)setPositionForPosition:(MBMVec3 * _Nullable)position;
		[Export ("setPositionForPosition:")]
		void SetPositionForPosition ([NullAllowed] MBMVec3 position);

		// -(MBMVec4 * _Nullable)getOrientation __attribute__((ns_returns_retained));
		[NullAllowed, Export ("getOrientation")]
		MBMVec4 Orientation { get; }

		// -(void)setOrientationForOrientation:(MBMVec4 * _Nullable)orientation;
		[Export ("setOrientationForOrientation:")]
		void SetOrientationForOrientation ([NullAllowed] MBMVec4 orientation);

		// -(MBXCoordinate2D * _Nullable)getLocation __attribute__((ns_returns_retained)) __attribute__((swift_private));
		[NullAllowed, Export ("getLocation")]
		MBXCoordinate2D Location { get; }

		// -(NSNumber * _Nullable)getAltitude __attribute__((ns_returns_retained)) __attribute__((swift_private));
		[NullAllowed, Export ("getAltitude")]
		NSNumber Altitude { get; }

		// -(void)setLocationForLocation:(CLLocationCoordinate2D)location __attribute__((swift_private));
		[Export ("setLocationForLocation:")]
		void SetLocationForLocation (CLLocationCoordinate2D location);

		// -(void)setAltitudeForAltitude:(double)altitude __attribute__((swift_private));
		[Export ("setAltitudeForAltitude:")]
		void SetAltitudeForAltitude (double altitude);

		// -(void)setLocationForLocation:(CLLocationCoordinate2D)location altitude:(double)altitude;
		[Export ("setLocationForLocation:altitude:")]
		void SetLocationForLocation (CLLocationCoordinate2D location, double altitude);

		// -(void)lookAtPointForLocation:(CLLocationCoordinate2D)location;
		[Export ("lookAtPointForLocation:")]
		void LookAtPointForLocation (CLLocationCoordinate2D location);

		// -(void)lookAtPointForLocation:(CLLocationCoordinate2D)location altitude:(double)altitude;
		[Export ("lookAtPointForLocation:altitude:")]
		void LookAtPointForLocation (CLLocationCoordinate2D location, double altitude);

		// -(void)lookAtPointForLocation:(CLLocationCoordinate2D)location altitude:(double)altitude upVector:(MBMVec3 * _Nonnull)upVector;
		[Export ("lookAtPointForLocation:altitude:upVector:")]
		void LookAtPointForLocation (CLLocationCoordinate2D location, double altitude, MBMVec3 upVector);

		// -(void)setPitchBearingForPitch:(double)pitch bearing:(double)bearing;
		[Export ("setPitchBearingForPitch:bearing:")]
		void SetPitchBearingForPitch (double pitch, double bearing);
	}

	// @interface MBMImageStretches : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMImageStretches
	{
		// -(instancetype _Nonnull)initWithFirst:(float)first second:(float)second;
		[Export ("initWithFirst:second:")]
		NativeHandle Constructor (float first, float second);

		// @property (readonly, nonatomic) float first;
		[Export ("first")]
		float First { get; }

		// @property (readonly, nonatomic) float second;
		[Export ("second")]
		float Second { get; }

		// -(BOOL)isEqualToImageStretches:(MBMImageStretches * _Nonnull)other;
		[Export ("isEqualToImageStretches:")]
		bool IsEqualToImageStretches (MBMImageStretches other);
	}

	// @interface MBMImageContent : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMImageContent
	{
		// -(instancetype _Nonnull)initWithLeft:(float)left top:(float)top right:(float)right bottom:(float)bottom;
		[Export ("initWithLeft:top:right:bottom:")]
		NativeHandle Constructor (float left, float top, float right, float bottom);

		// @property (readonly, nonatomic) float left;
		[Export ("left")]
		float Left { get; }

		// @property (readonly, nonatomic) float top;
		[Export ("top")]
		float Top { get; }

		// @property (readonly, nonatomic) float right;
		[Export ("right")]
		float Right { get; }

		// @property (readonly, nonatomic) float bottom;
		[Export ("bottom")]
		float Bottom { get; }

		// -(BOOL)isEqualToImageContent:(MBMImageContent * _Nonnull)other;
		[Export ("isEqualToImageContent:")]
		bool IsEqualToImageContent (MBMImageContent other);
	}

	// @interface MBMGlyphsRasterizationOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMGlyphsRasterizationOptions
	{
		// -(instancetype _Nonnull)initWithRasterizationMode:(MBMGlyphsRasterizationMode)rasterizationMode fontFamily:(NSString * _Nullable)fontFamily;
		[Export ("initWithRasterizationMode:fontFamily:")]
		NativeHandle Constructor (MBMGlyphsRasterizationMode rasterizationMode, [NullAllowed] string fontFamily);

		// @property (readonly, nonatomic) MBMGlyphsRasterizationMode rasterizationMode;
		[Export ("rasterizationMode")]
		MBMGlyphsRasterizationMode RasterizationMode { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable fontFamily;
		[NullAllowed, Export ("fontFamily")]
		string FontFamily { get; }
	}

	// @interface MBMTileCacheBudgetInMegabytes : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMTileCacheBudgetInMegabytes
	{
		// -(instancetype _Nonnull)initWithSize:(uint64_t)size;
		[Export ("initWithSize:")]
		NativeHandle Constructor (ulong size);

		// @property (readonly, nonatomic) uint64_t size;
		[Export ("size")]
		ulong Size { get; }

		// -(BOOL)isEqualToTileCacheBudgetInMegabytes:(MBMTileCacheBudgetInMegabytes * _Nonnull)other;
		[Export ("isEqualToTileCacheBudgetInMegabytes:")]
		bool IsEqualToTileCacheBudgetInMegabytes (MBMTileCacheBudgetInMegabytes other);
	}

	// @interface MBMTileCacheBudgetInTiles : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMTileCacheBudgetInTiles
	{
		// -(instancetype _Nonnull)initWithSize:(uint64_t)size;
		[Export ("initWithSize:")]
		NativeHandle Constructor (ulong size);

		// @property (readonly, nonatomic) uint64_t size;
		[Export ("size")]
		ulong Size { get; }

		// -(BOOL)isEqualToTileCacheBudgetInTiles:(MBMTileCacheBudgetInTiles * _Nonnull)other;
		[Export ("isEqualToTileCacheBudgetInTiles:")]
		bool IsEqualToTileCacheBudgetInTiles (MBMTileCacheBudgetInTiles other);
	}

	// @interface MBMMapOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMMapOptions
	{
		// -(nonnull instancetype)initWithContextMode:(nullable NSNumber *)contextMode constrainMode:(nullable NSNumber *)constrainMode viewportMode:(nullable NSNumber *)viewportMode orientation:(nullable NSNumber *)orientation crossSourceCollisions:(nullable NSNumber *)crossSourceCollisions size:(nullable MBMSize *)size glyphsRasterizationOptions:(nullable MBMGlyphsRasterizationOptions *)glyphsRasterizationOptions emissiveColorPrecision:(nullable NSNumber *)emissiveColorPrecision NS_REFINED_FOR_SWIFT;
		[Export ("initWithContextMode:constrainMode:viewportMode:orientation:crossSourceCollisions:size:glyphsRasterizationOptions:emissiveColorPrecision:")]
		NativeHandle Constructor ([NullAllowed] NSNumber contextMode, [NullAllowed] NSNumber constrainMode, [NullAllowed] NSNumber viewportMode, [NullAllowed] NSNumber orientation, [NullAllowed] NSNumber crossSourceCollisions, [NullAllowed] MBMSize size, [NullAllowed] MBMGlyphsRasterizationOptions glyphsRasterizationOptions, [NullAllowed] NSNumber emissiveColorPrecision);

		// -(nonnull instancetype)initWithContextMode:(nullable NSNumber *)contextMode constrainMode:(nullable NSNumber *)constrainMode viewportMode:(nullable NSNumber *)viewportMode orientation:(nullable NSNumber *)orientation crossSourceCollisions:(nullable NSNumber *)crossSourceCollisions size:(nullable MBMSize *)size pixelRatio:(float)pixelRatio glyphsRasterizationOptions:(nullable MBMGlyphsRasterizationOptions *)glyphsRasterizationOptions scaleFactor:(float)scaleFactor emissiveColorPrecision:(nullable NSNumber *)emissiveColorPrecision NS_REFINED_FOR_SWIFT;
		[Export ("initWithContextMode:constrainMode:viewportMode:orientation:crossSourceCollisions:size:pixelRatio:glyphsRasterizationOptions:scaleFactor:emissiveColorPrecision:")]
		NativeHandle Constructor ([NullAllowed] NSNumber contextMode, [NullAllowed] NSNumber constrainMode, [NullAllowed] NSNumber viewportMode, [NullAllowed] NSNumber orientation, [NullAllowed] NSNumber crossSourceCollisions, [NullAllowed] MBMSize size, float pixelRatio, [NullAllowed] MBMGlyphsRasterizationOptions glyphsRasterizationOptions, float scaleFactor, [NullAllowed] NSNumber emissiveColorPrecision);

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * contextMode __attribute__((swift_private));
		[Export ("contextMode")]
		NSNumber ContextMode { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * constrainMode __attribute__((swift_private));
		[Export ("constrainMode")]
		NSNumber ConstrainMode { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * viewportMode __attribute__((swift_private));
		[Export ("viewportMode")]
		NSNumber ViewportMode { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * orientation __attribute__((swift_private));
		[Export ("orientation")]
		NSNumber Orientation { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * crossSourceCollisions __attribute__((swift_private));
		[Export ("crossSourceCollisions")]
		NSNumber CrossSourceCollisions { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT MBMSize * size __attribute__((swift_private));
		[Export ("size")]
		MBMSize Size { get; }

		// @property (readonly, nonatomic) float pixelRatio;
		[Export ("pixelRatio")]
		float PixelRatio { get; }

		// @property (readonly, nonatomic) MBMGlyphsRasterizationOptions * _Nullable glyphsRasterizationOptions;
		[NullAllowed, Export ("glyphsRasterizationOptions")]
		MBMGlyphsRasterizationOptions GlyphsRasterizationOptions { get; }

		// @property (nonatomic, readonly) float scaleFactor NS_REFINED_FOR_SWIFT;
		[Export ("scaleFactor")]
		float ScaleFactor { get; }

		// @property (nonatomic, readonly, nullable) NSNumber *emissiveColorPrecision NS_REFINED_FOR_SWIFT;
		[NullAllowed, Export ("emissiveColorPrecision")]
		NSNumber EmissiveColorPrecision { get; }
	}

	// @interface MBMCoordinateBoundsZoom : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCoordinateBoundsZoom
	{
		// -(instancetype _Nonnull)initWithBounds:(MBMCoordinateBounds * _Nonnull)bounds zoom:(double)zoom;
		[Export ("initWithBounds:zoom:")]
		NativeHandle Constructor (MBMCoordinateBounds bounds, double zoom);

		// @property (readonly, nonatomic) MBMCoordinateBounds * _Nonnull bounds;
		[Export ("bounds")]
		MBMCoordinateBounds Bounds { get; }

		// @property (readonly, nonatomic) double zoom;
		[Export ("zoom")]
		double Zoom { get; }
	}

	// @interface MBMSize : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMSize
	{
		// -(instancetype _Nonnull)initWithWidth:(float)width height:(float)height;
		[Export ("initWithWidth:height:")]
		NativeHandle Constructor (float width, float height);

		// @property (readonly, nonatomic) float width;
		[Export ("width")]
		float Width { get; }

		// @property (readonly, nonatomic) float height;
		[Export ("height")]
		float Height { get; }

		// -(BOOL)isEqualToSize:(MBMSize * _Nonnull)other;
		[Export ("isEqualToSize:")]
		bool IsEqualToSize (MBMSize other);
	}

	// @interface MBMRenderedQueryOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMRenderedQueryOptions
	{
		// -(instancetype _Nonnull)initWithLayerIds:(NSArray<NSString *> * _Nullable)layerIds filter:(id _Nullable)filter __attribute__((swift_private));
		[Export ("initWithLayerIds:filter:")]
		NativeHandle Constructor ([NullAllowed] string[] layerIds, [NullAllowed] NSObject filter);

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable layerIds;
		[NullAllowed, Export ("layerIds", ArgumentSemantic.Copy)]
		string[] LayerIds { get; }

		// @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT id filter __attribute__((swift_private));
		[Export ("filter", ArgumentSemantic.Copy)]
		NSObject Filter { get; }
	}

	// @interface MBMSourceQueryOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMSourceQueryOptions
	{
		// -(instancetype _Nonnull)initWithSourceLayerIds:(NSArray<NSString *> * _Nullable)sourceLayerIds filter:(id _Nonnull)filter;
		[Export ("initWithSourceLayerIds:filter:")]
		NativeHandle Constructor ([NullAllowed] string[] sourceLayerIds, NSObject filter);

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable sourceLayerIds;
		[NullAllowed, Export ("sourceLayerIds", ArgumentSemantic.Copy)]
		string[] SourceLayerIds { get; }

		// @property (readonly, copy, nonatomic) id _Nonnull filter;
		[Export ("filter", ArgumentSemantic.Copy)]
		NSObject Filter { get; }
	}

	// @interface MBMFeatureExtensionValue : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMFeatureExtensionValue
	{
		// -(instancetype _Nonnull)initWithValue:(id _Nullable)value featureCollection:(NSArray<MBXFeature *> * _Nullable)featureCollection __attribute__((swift_private));
		[Export ("initWithValue:featureCollection:")]
		NativeHandle Constructor ([NullAllowed] NSObject value, [NullAllowed] MBXFeature[] featureCollection);

		// @property (readonly, copy, nonatomic) id _Nullable value;
		[NullAllowed, Export ("value", ArgumentSemantic.Copy)]
		NSObject Value { get; }

		// @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSArray<MBXFeature *> * featureCollection __attribute__((swift_private));
		[Export ("featureCollection", ArgumentSemantic.Copy)]
		MBXFeature[] FeatureCollection { get; }
	}

	// @interface MBMQueriedFeature : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMQueriedFeature
	{
		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT MBXFeature * feature __attribute__((swift_private));
		[Export ("feature")]
		MBXFeature Feature { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull source;
		[Export ("source")]
		string Source { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sourceLayer;
		[NullAllowed, Export ("sourceLayer")]
		string SourceLayer { get; }

		// @property (readonly, copy, nonatomic) id _Nonnull state;
		[Export ("state", ArgumentSemantic.Copy)]
		NSObject State { get; }
	}

	// @interface MBMQueriedRenderedFeature : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMQueriedRenderedFeature
	{
		// @property (readonly, nonatomic) MBMQueriedFeature * _Nonnull queriedFeature;
		[Export ("queriedFeature")]
		MBMQueriedFeature QueriedFeature { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull layers;
		[Export ("layers", ArgumentSemantic.Copy)]
		string[] Layers { get; }
	}

	// @interface MBMQueriedSourceFeature : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMQueriedSourceFeature
	{
		// @property (readonly, nonatomic) MBMQueriedFeature * _Nonnull queriedFeature;
		[Export ("queriedFeature")]
		MBMQueriedFeature QueriedFeature { get; }
	}

	// @interface MBMViewAnnotationAnchorConfig : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMViewAnnotationAnchorConfig
	{
		// -(instancetype _Nonnull)initWithAnchor:(MBMViewAnnotationAnchor)anchor offsetX:(double)offsetX offsetY:(double)offsetY __attribute__((swift_private));
		[Export ("initWithAnchor:offsetX:offsetY:")]
		NativeHandle Constructor (MBMViewAnnotationAnchor anchor, double offsetX, double offsetY);

		// @property (readonly, nonatomic) MBMViewAnnotationAnchor anchor;
		[Export ("anchor")]
		MBMViewAnnotationAnchor Anchor { get; }

		// @property (readonly, nonatomic) double offsetX;
		[Export ("offsetX")]
		double OffsetX { get; }

		// @property (readonly, nonatomic) double offsetY;
		[Export ("offsetY")]
		double OffsetY { get; }

		// -(BOOL)isEqualToViewAnnotationAnchorConfig:(MBMViewAnnotationAnchorConfig * _Nonnull)other;
		[Export ("isEqualToViewAnnotationAnchorConfig:")]
		bool IsEqualToViewAnnotationAnchorConfig (MBMViewAnnotationAnchorConfig other);
	}

	// @interface MBMTileCacheBudget : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMTileCacheBudget
	{
		// +(instancetype _Nonnull)fromTileCacheBudgetInMegabytes:(MBMTileCacheBudgetInMegabytes * _Nonnull)value;
		[Static]
		[Export ("fromTileCacheBudgetInMegabytes:")]
		MBMTileCacheBudget FromTileCacheBudgetInMegabytes (MBMTileCacheBudgetInMegabytes value);

		// +(instancetype _Nonnull)fromTileCacheBudgetInTiles:(MBMTileCacheBudgetInTiles * _Nonnull)value;
		[Static]
		[Export ("fromTileCacheBudgetInTiles:")]
		MBMTileCacheBudget FromTileCacheBudgetInTiles (MBMTileCacheBudgetInTiles value);

		// -(BOOL)isTileCacheBudgetInMegabytes;
		[Export ("isTileCacheBudgetInMegabytes")]
		bool IsTileCacheBudgetInMegabytes { get; }

		// -(BOOL)isTileCacheBudgetInTiles;
		[Export ("isTileCacheBudgetInTiles")]
		bool IsTileCacheBudgetInTiles { get; }

		// -(MBMTileCacheBudgetInMegabytes * _Nonnull)getTileCacheBudgetInMegabytes __attribute__((ns_returns_retained));
		[Export ("getTileCacheBudgetInMegabytes")]
		MBMTileCacheBudgetInMegabytes TileCacheBudgetInMegabytes { get; }

		// -(MBMTileCacheBudgetInTiles * _Nonnull)getTileCacheBudgetInTiles __attribute__((ns_returns_retained));
		[Export ("getTileCacheBudgetInTiles")]
		MBMTileCacheBudgetInTiles TileCacheBudgetInTiles { get; }

		// @property (readonly, nonatomic) MBMTileCacheBudgetType type;
		[Export ("type")]
		MBMTileCacheBudgetType Type { get; }
	}

	// @interface MBMMapConstants : NSObject
	[BaseType (typeof(NSObject))]
	interface MBMMapConstants
	{
		// @property (readonly, nonatomic, class) double MinPitch;
		[Static]
		[Export ("MinPitch")]
		double MinPitch { get; }

		// @property (readonly, nonatomic, class) double MaxPitch;
		[Static]
		[Export ("MaxPitch")]
		double MaxPitch { get; }

		// @property (readonly, nonatomic, class) double MinZoom;
		[Static]
		[Export ("MinZoom")]
		double MinZoom { get; }

		// @property (readonly, nonatomic, class) double MaxZoom;
		[Static]
		[Export ("MaxZoom")]
		double MaxZoom { get; }

		// @property (readonly, nonatomic, class) uint64_t DefaultTransitionDuration;
		[Static]
		[Export ("DefaultTransitionDuration")]
		ulong DefaultTransitionDuration { get; }
	}

	// @interface MBMMapRecorder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMMapRecorder
	{
		// -(MBXDataRef * _Nonnull)stopRecording __attribute__((ns_returns_retained));
		[Export ("stopRecording")]
		MBXDataRef StopRecording { get; }

		// -(void)togglePauseReplay;
		[Export ("togglePauseReplay")]
		void TogglePauseReplay ();

		// -(NSString * _Nonnull)getPlaybackState __attribute__((ns_returns_retained));
		[Export ("getPlaybackState")]
		string PlaybackState { get; }
	}

	// @interface MBMMapLoaded : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMMapLoaded
	{
		// -(instancetype _Nonnull)initWithTimeInterval:(MBMEventTimeInterval * _Nonnull)timeInterval;
		[Export ("initWithTimeInterval:")]
		NativeHandle Constructor (MBMEventTimeInterval timeInterval);

		// @property (readonly, nonatomic) MBMEventTimeInterval * _Nonnull timeInterval;
		[Export ("timeInterval")]
		MBMEventTimeInterval TimeInterval { get; }
	}

	// @interface MBMMapIdle : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMMapIdle
	{
		// -(instancetype _Nonnull)initWithTimestamp:(NSDate * _Nonnull)timestamp;
		[Export ("initWithTimestamp:")]
		NativeHandle Constructor (NSDate timestamp);

		// @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }
	}

	// @interface MBMMapLoadingError : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMMapLoadingError
	{
		// -(instancetype _Nonnull)initWithType:(MBMMapLoadingErrorType)type message:(NSString * _Nonnull)message sourceId:(NSString * _Nullable)sourceId tileId:(MBMCanonicalTileID * _Nullable)tileId timestamp:(NSDate * _Nonnull)timestamp;
		[Export ("initWithType:message:sourceId:tileId:timestamp:")]
		NativeHandle Constructor (MBMMapLoadingErrorType type, string message, [NullAllowed] string sourceId, [NullAllowed] MBMCanonicalTileID tileId, NSDate timestamp);

		// @property (readonly, nonatomic) MBMMapLoadingErrorType type;
		[Export ("type")]
		MBMMapLoadingErrorType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sourceId;
		[NullAllowed, Export ("sourceId")]
		string SourceId { get; }

		// @property (readonly, nonatomic) MBMCanonicalTileID * _Nullable tileId;
		[NullAllowed, Export ("tileId")]
		MBMCanonicalTileID TileId { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }
	}

	// @interface MBMStyleLoaded : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMStyleLoaded
	{
		// -(instancetype _Nonnull)initWithTimeInterval:(MBMEventTimeInterval * _Nonnull)timeInterval;
		[Export ("initWithTimeInterval:")]
		NativeHandle Constructor (MBMEventTimeInterval timeInterval);

		// @property (readonly, nonatomic) MBMEventTimeInterval * _Nonnull timeInterval;
		[Export ("timeInterval")]
		MBMEventTimeInterval TimeInterval { get; }
	}

	// @interface MBMStyleDataLoaded : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMStyleDataLoaded
	{
		// -(instancetype _Nonnull)initWithType:(MBMStyleDataLoadedType)type timeInterval:(MBMEventTimeInterval * _Nonnull)timeInterval;
		[Export ("initWithType:timeInterval:")]
		NativeHandle Constructor (MBMStyleDataLoadedType type, MBMEventTimeInterval timeInterval);

		// @property (readonly, nonatomic) MBMStyleDataLoadedType type;
		[Export ("type")]
		MBMStyleDataLoadedType Type { get; }

		// @property (readonly, nonatomic) MBMEventTimeInterval * _Nonnull timeInterval;
		[Export ("timeInterval")]
		MBMEventTimeInterval TimeInterval { get; }
	}

	// @interface MBMSourceDataLoaded : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMSourceDataLoaded
	{
		// -(instancetype _Nonnull)initWithSourceId:(NSString * _Nonnull)sourceId type:(MBMSourceDataLoadedType)type loaded:(NSNumber * _Nullable)loaded tileId:(MBMCanonicalTileID * _Nullable)tileId dataId:(NSString * _Nullable)dataId timeInterval:(MBMEventTimeInterval * _Nonnull)timeInterval __attribute__((swift_private));
		[Export ("initWithSourceId:type:loaded:tileId:dataId:timeInterval:")]
		NativeHandle Constructor (string sourceId, MBMSourceDataLoadedType type, [NullAllowed] NSNumber loaded, [NullAllowed] MBMCanonicalTileID tileId, [NullAllowed] string dataId, MBMEventTimeInterval timeInterval);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sourceId;
		[Export ("sourceId")]
		string SourceId { get; }

		// @property (readonly, nonatomic) MBMSourceDataLoadedType type;
		[Export ("type")]
		MBMSourceDataLoadedType Type { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * loaded __attribute__((swift_private));
		[Export ("loaded")]
		NSNumber Loaded { get; }

		// @property (readonly, nonatomic) MBMCanonicalTileID * _Nullable tileId;
		[NullAllowed, Export ("tileId")]
		MBMCanonicalTileID TileId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable dataId;
		[NullAllowed, Export ("dataId")]
		string DataId { get; }

		// @property (readonly, nonatomic) MBMEventTimeInterval * _Nonnull timeInterval;
		[Export ("timeInterval")]
		MBMEventTimeInterval TimeInterval { get; }
	}

	// @interface MBMSourceAdded : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMSourceAdded
	{
		// -(instancetype _Nonnull)initWithSourceId:(NSString * _Nonnull)sourceId timestamp:(NSDate * _Nonnull)timestamp;
		[Export ("initWithSourceId:timestamp:")]
		NativeHandle Constructor (string sourceId, NSDate timestamp);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sourceId;
		[Export ("sourceId")]
		string SourceId { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }
	}

	// @interface MBMSourceRemoved : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMSourceRemoved
	{
		// -(instancetype _Nonnull)initWithSourceId:(NSString * _Nonnull)sourceId timestamp:(NSDate * _Nonnull)timestamp;
		[Export ("initWithSourceId:timestamp:")]
		NativeHandle Constructor (string sourceId, NSDate timestamp);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sourceId;
		[Export ("sourceId")]
		string SourceId { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }
	}

	// @interface MBMStyleImageMissing : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMStyleImageMissing
	{
		// -(instancetype _Nonnull)initWithImageId:(NSString * _Nonnull)imageId timestamp:(NSDate * _Nonnull)timestamp;
		[Export ("initWithImageId:timestamp:")]
		NativeHandle Constructor (string imageId, NSDate timestamp);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull imageId;
		[Export ("imageId")]
		string ImageId { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }
	}

	// @interface MBMStyleImageRemoveUnused : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMStyleImageRemoveUnused
	{
		// -(instancetype _Nonnull)initWithImageId:(NSString * _Nonnull)imageId timestamp:(NSDate * _Nonnull)timestamp;
		[Export ("initWithImageId:timestamp:")]
		NativeHandle Constructor (string imageId, NSDate timestamp);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull imageId;
		[Export ("imageId")]
		string ImageId { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }
	}

	// @interface MBMCameraChanged : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCameraChanged
	{
		// @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }
	}

	// @interface MBMRenderFrameStarted : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMRenderFrameStarted
	{
		// -(instancetype _Nonnull)initWithTimestamp:(NSDate * _Nonnull)timestamp;
		[Export ("initWithTimestamp:")]
		NativeHandle Constructor (NSDate timestamp);

		// @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
		[Export ("timestamp")]
		NSDate Timestamp { get; }
	}

	// @interface MBMRenderFrameFinished : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMRenderFrameFinished
	{
		// -(instancetype _Nonnull)initWithRenderMode:(MBMRenderModeType)renderMode needsRepaint:(BOOL)needsRepaint placementChanged:(BOOL)placementChanged timeInterval:(MBMEventTimeInterval * _Nonnull)timeInterval;
		[Export ("initWithRenderMode:needsRepaint:placementChanged:timeInterval:")]
		NativeHandle Constructor (MBMRenderModeType renderMode, bool needsRepaint, bool placementChanged, MBMEventTimeInterval timeInterval);

		// @property (readonly, nonatomic) MBMRenderModeType renderMode;
		[Export ("renderMode")]
		MBMRenderModeType RenderMode { get; }

		// @property (readonly, nonatomic) BOOL needsRepaint;
		[Export ("needsRepaint")]
		bool NeedsRepaint { get; }

		// @property (readonly, nonatomic) BOOL placementChanged;
		[Export ("placementChanged")]
		bool PlacementChanged { get; }

		// @property (readonly, nonatomic) MBMEventTimeInterval * _Nonnull timeInterval;
		[Export ("timeInterval")]
		MBMEventTimeInterval TimeInterval { get; }
	}

	// @interface MBMResourceRequest : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMResourceRequest
	{
		// -(instancetype _Nonnull)initWithSource:(MBMRequestDataSourceType)source request:(MBMRequestInfo * _Nonnull)request response:(MBMResponseInfo * _Nullable)response cancelled:(BOOL)cancelled timeInterval:(MBMEventTimeInterval * _Nonnull)timeInterval;
		[Export ("initWithSource:request:response:cancelled:timeInterval:")]
		NativeHandle Constructor (MBMRequestDataSourceType source, MBMRequestInfo request, [NullAllowed] MBMResponseInfo response, bool cancelled, MBMEventTimeInterval timeInterval);

		// @property (readonly, nonatomic) MBMRequestDataSourceType source;
		[Export ("source")]
		MBMRequestDataSourceType Source { get; }

		// @property (readonly, nonatomic) MBMRequestInfo * _Nonnull request;
		[Export ("request")]
		MBMRequestInfo Request { get; }

		// @property (readonly, nonatomic) MBMResponseInfo * _Nullable response;
		[NullAllowed, Export ("response")]
		MBMResponseInfo Response { get; }

		// @property (readonly, nonatomic) BOOL cancelled;
		[Export ("cancelled")]
		bool Cancelled { get; }

		// @property (readonly, nonatomic) MBMEventTimeInterval * _Nonnull timeInterval;
		[Export ("timeInterval")]
		MBMEventTimeInterval TimeInterval { get; }
	}

	// @interface MBMRequestInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMRequestInfo
	{
		// -(instancetype _Nonnull)initWithUrl:(NSString * _Nonnull)url resource:(MBMRequestResourceType)resource priority:(MBMRequestPriorityType)priority loadingMethod:(NSArray<NSNumber *> * _Nonnull)loadingMethod;
		[Export ("initWithUrl:resource:priority:loadingMethod:")]
		NativeHandle Constructor (string url, MBMRequestResourceType resource, MBMRequestPriorityType priority, NSNumber[] loadingMethod);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; }

		// @property (readonly, nonatomic) MBMRequestResourceType resource;
		[Export ("resource")]
		MBMRequestResourceType Resource { get; }

		// @property (readonly, nonatomic) MBMRequestPriorityType priority;
		[Export ("priority")]
		MBMRequestPriorityType Priority { get; }

		// @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSArray<NSNumber *> * loadingMethod __attribute__((swift_private));
		[Export ("loadingMethod", ArgumentSemantic.Copy)]
		NSNumber[] LoadingMethod { get; }
	}

	// @interface MBMResourceRequestError : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMResourceRequestError
	{
		// -(instancetype _Nonnull)initWithReason:(MBMRequestErrorType)reason message:(NSString * _Nonnull)message;
		[Export ("initWithReason:message:")]
		NativeHandle Constructor (MBMRequestErrorType reason, string message);

		// @property (readonly, nonatomic) MBMRequestErrorType reason;
		[Export ("reason")]
		MBMRequestErrorType Reason { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }
	}

	// @interface MBMResponseInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMResponseInfo
	{
		// -(instancetype _Nonnull)initWithNoContent:(BOOL)noContent notModified:(BOOL)notModified mustRevalidate:(BOOL)mustRevalidate source:(MBMResponseSourceType)source size:(uint64_t)size modified:(NSDate * _Nullable)modified expires:(NSDate * _Nullable)expires etag:(NSString * _Nullable)etag error:(MBMResourceRequestError * _Nullable)error;
		[Export ("initWithNoContent:notModified:mustRevalidate:source:size:modified:expires:etag:error:")]
		NativeHandle Constructor (bool noContent, bool notModified, bool mustRevalidate, MBMResponseSourceType source, ulong size, [NullAllowed] NSDate modified, [NullAllowed] NSDate expires, [NullAllowed] string etag, [NullAllowed] MBMResourceRequestError error);

		// @property (readonly, nonatomic) BOOL noContent;
		[Export ("noContent")]
		bool NoContent { get; }

		// @property (readonly, nonatomic) BOOL notModified;
		[Export ("notModified")]
		bool NotModified { get; }

		// @property (readonly, nonatomic) BOOL mustRevalidate;
		[Export ("mustRevalidate")]
		bool MustRevalidate { get; }

		// @property (readonly, nonatomic) MBMResponseSourceType source;
		[Export ("source")]
		MBMResponseSourceType Source { get; }

		// @property (readonly, nonatomic) uint64_t size;
		[Export ("size")]
		ulong Size { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable modified;
		[NullAllowed, Export ("modified")]
		NSDate Modified { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable expires;
		[NullAllowed, Export ("expires")]
		NSDate Expires { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable etag;
		[NullAllowed, Export ("etag")]
		string Etag { get; }

		// @property (readonly, nonatomic) MBMResourceRequestError * _Nullable error;
		[NullAllowed, Export ("error")]
		MBMResourceRequestError Error { get; }
	}

	// @interface MBMEventTimeInterval : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMEventTimeInterval
	{
		// -(instancetype _Nonnull)initWithBegin:(NSDate * _Nonnull)begin end:(NSDate * _Nonnull)end;
		[Export ("initWithBegin:end:")]
		NativeHandle Constructor (NSDate begin, NSDate end);

		// @property (readonly, nonatomic) NSDate * _Nonnull begin;
		[Export ("begin")]
		NSDate Begin { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull end;
		[Export ("end")]
		NSDate End { get; }
	}

	// @interface MBMGenericEvent : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMGenericEvent
	{
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name data:(id _Nonnull)data timeInterval:(MBMEventTimeInterval * _Nonnull)timeInterval;
		[Export ("initWithName:data:timeInterval:")]
		NativeHandle Constructor (string name, NSObject data, MBMEventTimeInterval timeInterval);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) id _Nonnull data;
		[Export ("data", ArgumentSemantic.Copy)]
		NSObject Data { get; }

		// @property (readonly, nonatomic) MBMEventTimeInterval * _Nonnull timeInterval;
		[Export ("timeInterval")]
		MBMEventTimeInterval TimeInterval { get; }
	}

	// typedef void (^MBMMapLoadedCallback)(MBMMapLoaded * _Nonnull);
	delegate void MBMMapLoadedCallback (MBMMapLoaded arg0);

	// typedef void (^MBMMapIdleCallback)(MBMMapIdle * _Nonnull);
	delegate void MBMMapIdleCallback (MBMMapIdle arg0);

	// typedef void (^MBMMapLoadingErrorCallback)(MBMMapLoadingError * _Nonnull);
	delegate void MBMMapLoadingErrorCallback (MBMMapLoadingError arg0);

	// typedef void (^MBMStyleLoadedCallback)(MBMStyleLoaded * _Nonnull);
	delegate void MBMStyleLoadedCallback (MBMStyleLoaded arg0);

	// typedef void (^MBMStyleDataLoadedCallback)(MBMStyleDataLoaded * _Nonnull);
	delegate void MBMStyleDataLoadedCallback (MBMStyleDataLoaded arg0);

	// typedef void (^MBMSourceDataLoadedCallback)(MBMSourceDataLoaded * _Nonnull);
	delegate void MBMSourceDataLoadedCallback (MBMSourceDataLoaded arg0);

	// typedef void (^MBMSourceAddedCallback)(MBMSourceAdded * _Nonnull);
	delegate void MBMSourceAddedCallback (MBMSourceAdded arg0);

	// typedef void (^MBMSourceRemovedCallback)(MBMSourceRemoved * _Nonnull);
	delegate void MBMSourceRemovedCallback (MBMSourceRemoved arg0);

	// typedef void (^MBMStyleImageMissingCallback)(MBMStyleImageMissing * _Nonnull);
	delegate void MBMStyleImageMissingCallback (MBMStyleImageMissing arg0);

	// typedef void (^MBMStyleImageRemoveUnusedCallback)(MBMStyleImageRemoveUnused * _Nonnull);
	delegate void MBMStyleImageRemoveUnusedCallback (MBMStyleImageRemoveUnused arg0);

	// typedef void (^MBMCameraChangedCallback)(MBMCameraChanged * _Nonnull);
	delegate void MBMCameraChangedCallback (MBMCameraChanged arg0);

	// typedef void (^MBMRenderFrameStartedCallback)(MBMRenderFrameStarted * _Nonnull);
	delegate void MBMRenderFrameStartedCallback (MBMRenderFrameStarted arg0);

	// typedef void (^MBMRenderFrameFinishedCallback)(MBMRenderFrameFinished * _Nonnull);
	delegate void MBMRenderFrameFinishedCallback (MBMRenderFrameFinished arg0);

	// typedef void (^MBMResourceRequestCallback)(MBMResourceRequest * _Nonnull);
	delegate void MBMResourceRequestCallback (MBMResourceRequest arg0);

	// typedef void (^MBMGenericEventCallback)(MBMGenericEvent * _Nonnull);
	delegate void MBMGenericEventCallback (MBMGenericEvent arg0);

	// @interface MBMStylePack : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMStylePack
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull styleURI;
		[Export ("styleURI")]
		string StyleURI { get; }

		// @property (readonly, nonatomic) MBMGlyphsRasterizationMode glyphsRasterizationMode;
		[Export ("glyphsRasterizationMode")]
		MBMGlyphsRasterizationMode GlyphsRasterizationMode { get; }

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

	// @interface MBMStylePackLoadProgress : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMStylePackLoadProgress
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

	// @interface MBMStylePackError : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMStylePackError
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }
	}

	// @interface MBMStylePackLoadOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMStylePackLoadOptions
	{
		// -(instancetype _Nonnull)initWithGlyphsRasterizationMode:(NSNumber * _Nullable)glyphsRasterizationMode metadata:(id _Nullable)metadata extraOptions:(id _Nullable)extraOptions __attribute__((swift_private));
		[Export ("initWithGlyphsRasterizationMode:metadata:extraOptions:")]
		NativeHandle Constructor ([NullAllowed] NSNumber glyphsRasterizationMode, [NullAllowed] NSObject metadata, [NullAllowed] NSObject extraOptions);

		// -(instancetype _Nonnull)initWithGlyphsRasterizationMode:(NSNumber * _Nullable)glyphsRasterizationMode metadata:(id _Nullable)metadata acceptExpired:(BOOL)acceptExpired extraOptions:(id _Nullable)extraOptions __attribute__((swift_private));
		[Export ("initWithGlyphsRasterizationMode:metadata:acceptExpired:extraOptions:")]
		NativeHandle Constructor ([NullAllowed] NSNumber glyphsRasterizationMode, [NullAllowed] NSObject metadata, bool acceptExpired, [NullAllowed] NSObject extraOptions);

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * glyphsRasterizationMode __attribute__((swift_private));
		[Export ("glyphsRasterizationMode")]
		NSNumber GlyphsRasterizationMode { get; }

		// @property (readonly, copy, nonatomic) id _Nullable metadata;
		[NullAllowed, Export ("metadata", ArgumentSemantic.Copy)]
		NSObject Metadata { get; }

		// @property (readonly, nonatomic) BOOL acceptExpired;
		[Export ("acceptExpired")]
		bool AcceptExpired { get; }

		// @property (readonly, copy, nonatomic) id _Nullable extraOptions;
		[NullAllowed, Export ("extraOptions", ArgumentSemantic.Copy)]
		NSObject ExtraOptions { get; }
	}

	// @interface MBMTilesetDescriptorOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMTilesetDescriptorOptions
	{
		// -(instancetype _Nonnull)initWithStyleURI:(NSString * _Nonnull)styleURI minZoom:(uint8_t)minZoom maxZoom:(uint8_t)maxZoom tilesets:(NSArray<NSString *> * _Nullable)tilesets stylePackOptions:(MBMStylePackLoadOptions * _Nullable)stylePackOptions extraOptions:(id _Nullable)extraOptions;
		[Export ("initWithStyleURI:minZoom:maxZoom:tilesets:stylePackOptions:extraOptions:")]
		NativeHandle Constructor (string styleURI, byte minZoom, byte maxZoom, [NullAllowed] string[] tilesets, [NullAllowed] MBMStylePackLoadOptions stylePackOptions, [NullAllowed] NSObject extraOptions);

		// -(instancetype _Nonnull)initWithStyleURI:(NSString * _Nonnull)styleURI minZoom:(uint8_t)minZoom maxZoom:(uint8_t)maxZoom pixelRatio:(float)pixelRatio tilesets:(NSArray<NSString *> * _Nullable)tilesets stylePackOptions:(MBMStylePackLoadOptions * _Nullable)stylePackOptions extraOptions:(id _Nullable)extraOptions;
		[Export ("initWithStyleURI:minZoom:maxZoom:pixelRatio:tilesets:stylePackOptions:extraOptions:")]
		NativeHandle Constructor (string styleURI, byte minZoom, byte maxZoom, float pixelRatio, [NullAllowed] string[] tilesets, [NullAllowed] MBMStylePackLoadOptions stylePackOptions, [NullAllowed] NSObject extraOptions);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull styleURI;
		[Export ("styleURI")]
		string StyleURI { get; }

		// @property (readonly, nonatomic) uint8_t minZoom;
		[Export ("minZoom")]
		byte MinZoom { get; }

		// @property (readonly, nonatomic) uint8_t maxZoom;
		[Export ("maxZoom")]
		byte MaxZoom { get; }

		// @property (readonly, nonatomic) float pixelRatio;
		[Export ("pixelRatio")]
		float PixelRatio { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable tilesets;
		[NullAllowed, Export ("tilesets", ArgumentSemantic.Copy)]
		string[] Tilesets { get; }

		// @property (readonly, nonatomic) MBMStylePackLoadOptions * _Nullable stylePackOptions;
		[NullAllowed, Export ("stylePackOptions")]
		MBMStylePackLoadOptions StylePackOptions { get; }

		// @property (readonly, copy, nonatomic) id _Nullable extraOptions;
		[NullAllowed, Export ("extraOptions", ArgumentSemantic.Copy)]
		NSObject ExtraOptions { get; }
	}

	// typedef void (^MBMStylePackLoadProgressCallback)(MBMStylePackLoadProgress * _Nonnull);
	delegate void MBMStylePackLoadProgressCallback (MBMStylePackLoadProgress arg0);

	// @interface MBMOfflineManager : NSObject
	[BaseType (typeof(NSObject))]
	interface MBMOfflineManager
	{
		// -(MBXTilesetDescriptor * _Nonnull)createTilesetDescriptorForTilesetDescriptorOptions:(MBMTilesetDescriptorOptions * _Nonnull)tilesetDescriptorOptions __attribute__((ns_returns_retained));
		[Export ("createTilesetDescriptorForTilesetDescriptorOptions:")]
		MBXTilesetDescriptor CreateTilesetDescriptorForTilesetDescriptorOptions (MBMTilesetDescriptorOptions tilesetDescriptorOptions);

		// -(void)removeStylePackForStyleURI:(NSString * _Nonnull)styleURI;
		[Export ("removeStylePackForStyleURI:")]
		void RemoveStylePackForStyleURI (string styleURI);
	}

	// @interface MBMOfflineRegionError : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMOfflineRegionError
	{
		// -(instancetype _Nonnull)initWithType:(MBMOfflineRegionErrorType)type message:(NSString * _Nonnull)message isFatal:(BOOL)isFatal retryAfter:(NSDate * _Nullable)retryAfter;
		[Export ("initWithType:message:isFatal:retryAfter:")]
		NativeHandle Constructor (MBMOfflineRegionErrorType type, string message, bool isFatal, [NullAllowed] NSDate retryAfter);

		// @property (readonly, nonatomic) MBMOfflineRegionErrorType type;
		[Export ("type")]
		MBMOfflineRegionErrorType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull message;
		[Export ("message")]
		string Message { get; }

		// @property (readonly, nonatomic) BOOL isFatal;
		[Export ("isFatal")]
		bool IsFatal { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable retryAfter;
		[NullAllowed, Export ("retryAfter")]
		NSDate RetryAfter { get; }
	}

	// @interface MBMOfflineRegionStatus : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMOfflineRegionStatus
	{
		// -(instancetype _Nonnull)initWithDownloadState:(MBMOfflineRegionDownloadState)downloadState completedResourceCount:(uint64_t)completedResourceCount completedResourceSize:(uint64_t)completedResourceSize completedTileCount:(uint64_t)completedTileCount requiredTileCount:(uint64_t)requiredTileCount completedTileSize:(uint64_t)completedTileSize requiredResourceCount:(uint64_t)requiredResourceCount requiredResourceCountIsPrecise:(BOOL)requiredResourceCountIsPrecise;
		[Export ("initWithDownloadState:completedResourceCount:completedResourceSize:completedTileCount:requiredTileCount:completedTileSize:requiredResourceCount:requiredResourceCountIsPrecise:")]
		NativeHandle Constructor (MBMOfflineRegionDownloadState downloadState, ulong completedResourceCount, ulong completedResourceSize, ulong completedTileCount, ulong requiredTileCount, ulong completedTileSize, ulong requiredResourceCount, bool requiredResourceCountIsPrecise);

		// @property (readonly, nonatomic) MBMOfflineRegionDownloadState downloadState;
		[Export ("downloadState")]
		MBMOfflineRegionDownloadState DownloadState { get; }

		// @property (readonly, nonatomic) uint64_t completedResourceCount;
		[Export ("completedResourceCount")]
		ulong CompletedResourceCount { get; }

		// @property (readonly, nonatomic) uint64_t completedResourceSize;
		[Export ("completedResourceSize")]
		ulong CompletedResourceSize { get; }

		// @property (readonly, nonatomic) uint64_t completedTileCount;
		[Export ("completedTileCount")]
		ulong CompletedTileCount { get; }

		// @property (readonly, nonatomic) uint64_t requiredTileCount;
		[Export ("requiredTileCount")]
		ulong RequiredTileCount { get; }

		// @property (readonly, nonatomic) uint64_t completedTileSize;
		[Export ("completedTileSize")]
		ulong CompletedTileSize { get; }

		// @property (readonly, nonatomic) uint64_t requiredResourceCount;
		[Export ("requiredResourceCount")]
		ulong RequiredResourceCount { get; }

		// @property (readonly, nonatomic) BOOL requiredResourceCountIsPrecise;
		[Export ("requiredResourceCountIsPrecise")]
		bool RequiredResourceCountIsPrecise { get; }
	}

	// @interface MBMOfflineRegionGeometryDefinition : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMOfflineRegionGeometryDefinition
	{
		// -(instancetype _Nonnull)initWithStyleURL:(NSString * _Nonnull)styleURL geometry:(MBXGeometry * _Nonnull)geometry minZoom:(double)minZoom maxZoom:(double)maxZoom pixelRatio:(float)pixelRatio glyphsRasterizationMode:(MBMGlyphsRasterizationMode)glyphsRasterizationMode __attribute__((swift_private));
		[Export ("initWithStyleURL:geometry:minZoom:maxZoom:pixelRatio:glyphsRasterizationMode:")]
		NativeHandle Constructor (string styleURL, MBXGeometry geometry, double minZoom, double maxZoom, float pixelRatio, MBMGlyphsRasterizationMode glyphsRasterizationMode);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull styleURL;
		[Export ("styleURL")]
		string StyleURL { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT MBXGeometry * geometry __attribute__((swift_private));
		[Export ("geometry")]
		MBXGeometry Geometry { get; }

		// @property (readonly, nonatomic) double minZoom;
		[Export ("minZoom")]
		double MinZoom { get; }

		// @property (readonly, nonatomic) double maxZoom;
		[Export ("maxZoom")]
		double MaxZoom { get; }

		// @property (readonly, nonatomic) float pixelRatio;
		[Export ("pixelRatio")]
		float PixelRatio { get; }

		// @property (readonly, nonatomic) MBMGlyphsRasterizationMode glyphsRasterizationMode;
		[Export ("glyphsRasterizationMode")]
		MBMGlyphsRasterizationMode GlyphsRasterizationMode { get; }
	}

	// @interface MBMOfflineRegionTilePyramidDefinition : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMOfflineRegionTilePyramidDefinition
	{
		// -(instancetype _Nonnull)initWithStyleURL:(NSString * _Nonnull)styleURL bounds:(MBMCoordinateBounds * _Nonnull)bounds minZoom:(double)minZoom maxZoom:(double)maxZoom pixelRatio:(float)pixelRatio glyphsRasterizationMode:(MBMGlyphsRasterizationMode)glyphsRasterizationMode;
		[Export ("initWithStyleURL:bounds:minZoom:maxZoom:pixelRatio:glyphsRasterizationMode:")]
		NativeHandle Constructor (string styleURL, MBMCoordinateBounds bounds, double minZoom, double maxZoom, float pixelRatio, MBMGlyphsRasterizationMode glyphsRasterizationMode);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull styleURL;
		[Export ("styleURL")]
		string StyleURL { get; }

		// @property (readonly, nonatomic) MBMCoordinateBounds * _Nonnull bounds;
		[Export ("bounds")]
		MBMCoordinateBounds Bounds { get; }

		// @property (readonly, nonatomic) double minZoom;
		[Export ("minZoom")]
		double MinZoom { get; }

		// @property (readonly, nonatomic) double maxZoom;
		[Export ("maxZoom")]
		double MaxZoom { get; }

		// @property (readonly, nonatomic) float pixelRatio;
		[Export ("pixelRatio")]
		float PixelRatio { get; }

		// @property (readonly, nonatomic) MBMGlyphsRasterizationMode glyphsRasterizationMode;
		[Export ("glyphsRasterizationMode")]
		MBMGlyphsRasterizationMode GlyphsRasterizationMode { get; }
	}

	// @interface MBMOfflineRegion : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMOfflineRegion
	{
		// -(int64_t)getIdentifier;
		[Export ("getIdentifier")]
		long Identifier { get; }

		// -(MBMOfflineRegionTilePyramidDefinition * _Nullable)getTilePyramidDefinition __attribute__((ns_returns_retained));
		[NullAllowed, Export ("getTilePyramidDefinition")]
		MBMOfflineRegionTilePyramidDefinition TilePyramidDefinition { get; }

		// -(MBMOfflineRegionGeometryDefinition * _Nullable)getGeometryDefinition __attribute__((ns_returns_retained));
		[NullAllowed, Export ("getGeometryDefinition")]
		MBMOfflineRegionGeometryDefinition GeometryDefinition { get; }

		// -(NSData * _Nonnull)getMetadata __attribute__((ns_returns_retained));
		[Export ("getMetadata")]
		NSData Metadata { get; }

		// -(void)setOfflineRegionDownloadStateForState:(MBMOfflineRegionDownloadState)state;
		[Export ("setOfflineRegionDownloadStateForState:")]
		void SetOfflineRegionDownloadStateForState (MBMOfflineRegionDownloadState state);

		// -(void)setOfflineRegionObserverForObserver:(id<MBMOfflineRegionObserver> _Nonnull)observer;
		[Export ("setOfflineRegionObserverForObserver:")]
		void SetOfflineRegionObserverForObserver (IMBMOfflineRegionObserver observer);
	}

	// @interface MBMOfflineRegionManager : NSObject
	[BaseType (typeof(NSObject))]
	interface MBMOfflineRegionManager
	{
		// -(void)setOfflineMapboxTileCountLimitForLimit:(uint64_t)limit;
		[Export ("setOfflineMapboxTileCountLimitForLimit:")]
		void SetOfflineMapboxTileCountLimitForLimit (ulong limit);
	}

	// @protocol MBMOfflineRegionObserver
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBMOfflineRegionObserver { }

    [Model, Protocol]
	[BaseType(typeof(NSObject))]
	interface MBMOfflineRegionObserver
	{
		// @required -(void)statusChangedForStatus:(MBMOfflineRegionStatus * _Nonnull)status;
		[Abstract]
		[Export ("statusChangedForStatus:")]
		void StatusChangedForStatus (MBMOfflineRegionStatus status);

		// @required -(void)errorOccurredForError:(MBMOfflineRegionError * _Nonnull)error;
		[Abstract]
		[Export ("errorOccurredForError:")]
		void ErrorOccurredForError (MBMOfflineRegionError error);
	}

	// @interface MBMPerformanceStatisticsOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMPerformanceStatisticsOptions
	{
		// @property (readonly, nonatomic) double samplingDurationMillis;
		[Export ("samplingDurationMillis")]
		double SamplingDurationMillis { get; }

		// -(BOOL)isEqualToPerformanceStatisticsOptions:(MBMPerformanceStatisticsOptions * _Nonnull)other;
		[Export ("isEqualToPerformanceStatisticsOptions:")]
		bool IsEqualToPerformanceStatisticsOptions (MBMPerformanceStatisticsOptions other);
	}

	// @interface MBMCumulativeRenderingStatistics : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCumulativeRenderingStatistics
	{
		// (nonnull instancetype)initWithDrawCalls:(nullable NSNumber *)drawCalls
        //                          textureBytes:(nullable NSNumber *)textureBytes
        //                           vertexBytes:(nullable NSNumber *)vertexBytes
        //                      graphicsPrograms:(nullable NSNumber *)graphicsPrograms
        //    graphicsProgramsCreationTimeMillis:(nullable NSNumber *)graphicsProgramsCreationTimeMillis
        //                   fboSwitchCount:(nullable NSNumber *)fboSwitchCount
		[Export ("initWithDrawCalls:textureBytes:vertexBytes:graphicsPrograms:graphicsProgramsCreationTimeMillis:fboSwitchCount:")]
		NativeHandle Constructor ([NullAllowed] NSNumber drawCalls, [NullAllowed] NSNumber textureBytes, [NullAllowed] NSNumber vertexBytes, [NullAllowed] NSNumber graphicsPrograms, [NullAllowed] NSNumber graphicsProgramsCreationTimeMillis, [NullAllowed] NSNumber fboSwitchCount);

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * drawCalls __attribute__((swift_private));
		[Export ("drawCalls")]
		NSNumber DrawCalls { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * textureBytes __attribute__((swift_private));
		[Export ("textureBytes")]
		NSNumber TextureBytes { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * vertexBytes __attribute__((swift_private));
		[Export ("vertexBytes")]
		NSNumber VertexBytes { get; }

        // @property (nonatomic, readonly, nullable) NSNumber *graphicsPrograms NS_REFINED_FOR_SWIFT;
		[Export ("graphicsPrograms")]
		NSNumber GraphicsPrograms { get; }

        // @property (nonatomic, readonly, nullable) NSNumber *graphicsProgramsCreationTimeMillis NS_REFINED_FOR_SWIFT;
		[Export ("graphicsProgramsCreationTimeMillis")]
		NSNumber GraphicsProgramsCreationTimeMillis { get; }

        // @property (nonatomic, readonly, nullable) NSNumber *fboSwitchCount NS_REFINED_FOR_SWIFT;
        [Export ("fboSwitchCount")]
        NSNumber FboSwitchCount { get; }
	}

	// @interface MBMDurationStatistics : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMDurationStatistics
	{
		// -(instancetype _Nonnull)initWithMaxMillis:(double)maxMillis medianMillis:(double)medianMillis;
		[Export ("initWithMaxMillis:medianMillis:")]
		NativeHandle Constructor (double maxMillis, double medianMillis);

		// @property (readonly, nonatomic) double maxMillis;
		[Export ("maxMillis")]
		double MaxMillis { get; }

		// @property (readonly, nonatomic) double medianMillis;
		[Export ("medianMillis")]
		double MedianMillis { get; }
	}

	// @interface MBMGroupPerformanceStatistics : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMGroupPerformanceStatistics
	{
		// -(instancetype _Nonnull)initWithDurationMillis:(double)durationMillis name:(NSString * _Nonnull)name;
		[Export ("initWithDurationMillis:name:")]
		NativeHandle Constructor (double durationMillis, string name);

		// @property (readonly, nonatomic) double durationMillis;
		[Export ("durationMillis")]
		double DurationMillis { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }
	}

	// @interface MBMPerFrameRenderingStatistics : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMPerFrameRenderingStatistics
	{
		// -(instancetype _Nonnull)initWithTopRenderGroups:(NSArray<MBMGroupPerformanceStatistics *> * _Nonnull)topRenderGroups topRenderLayers:(NSArray<MBMGroupPerformanceStatistics *> * _Nonnull)topRenderLayers shadowMapDurationStatistics:(MBMDurationStatistics * _Nonnull)shadowMapDurationStatistics uploadDurationStatistics:(MBMDurationStatistics * _Nonnull)uploadDurationStatistics;
		[Export ("initWithTopRenderGroups:topRenderLayers:shadowMapDurationStatistics:uploadDurationStatistics:")]
		NativeHandle Constructor (MBMGroupPerformanceStatistics[] topRenderGroups, MBMGroupPerformanceStatistics[] topRenderLayers, MBMDurationStatistics shadowMapDurationStatistics, MBMDurationStatistics uploadDurationStatistics);

		// @property (readonly, copy, nonatomic) NSArray<MBMGroupPerformanceStatistics *> * _Nonnull topRenderGroups;
		[Export ("topRenderGroups", ArgumentSemantic.Copy)]
		MBMGroupPerformanceStatistics[] TopRenderGroups { get; }

		// @property (readonly, copy, nonatomic) NSArray<MBMGroupPerformanceStatistics *> * _Nonnull topRenderLayers;
		[Export ("topRenderLayers", ArgumentSemantic.Copy)]
		MBMGroupPerformanceStatistics[] TopRenderLayers { get; }

		// @property (readonly, nonatomic) MBMDurationStatistics * _Nonnull shadowMapDurationStatistics;
		[Export ("shadowMapDurationStatistics")]
		MBMDurationStatistics ShadowMapDurationStatistics { get; }

		// @property (readonly, nonatomic) MBMDurationStatistics * _Nonnull uploadDurationStatistics;
		[Export ("uploadDurationStatistics")]
		MBMDurationStatistics UploadDurationStatistics { get; }
	}

	// @interface MBMPerformanceStatistics : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMPerformanceStatistics
	{
		// -(instancetype _Nonnull)initWithCollectionDurationMillis:(double)collectionDurationMillis mapRenderDurationStatistics:(MBMDurationStatistics * _Nonnull)mapRenderDurationStatistics cumulativeStatistics:(MBMCumulativeRenderingStatistics * _Nullable)cumulativeStatistics perFrameStatistics:(MBMPerFrameRenderingStatistics * _Nullable)perFrameStatistics;
		[Export ("initWithCollectionDurationMillis:mapRenderDurationStatistics:cumulativeStatistics:perFrameStatistics:")]
		NativeHandle Constructor (double collectionDurationMillis, MBMDurationStatistics mapRenderDurationStatistics, [NullAllowed] MBMCumulativeRenderingStatistics cumulativeStatistics, [NullAllowed] MBMPerFrameRenderingStatistics perFrameStatistics);

		// @property (readonly, nonatomic) double collectionDurationMillis;
		[Export ("collectionDurationMillis")]
		double CollectionDurationMillis { get; }

		// @property (readonly, nonatomic) MBMDurationStatistics * _Nonnull mapRenderDurationStatistics;
		[Export ("mapRenderDurationStatistics")]
		MBMDurationStatistics MapRenderDurationStatistics { get; }

		// @property (readonly, nonatomic) MBMCumulativeRenderingStatistics * _Nullable cumulativeStatistics;
		[NullAllowed, Export ("cumulativeStatistics")]
		MBMCumulativeRenderingStatistics CumulativeStatistics { get; }

		// @property (readonly, nonatomic) MBMPerFrameRenderingStatistics * _Nullable perFrameStatistics;
		[NullAllowed, Export ("perFrameStatistics")]
		MBMPerFrameRenderingStatistics PerFrameStatistics { get; }
	}

	// typedef void (^MBMPerformanceStatisticsCallback)(MBMPerformanceStatistics * _Nonnull);
	delegate void MBMPerformanceStatisticsCallback (MBMPerformanceStatistics arg0);

	// @interface MBMProjectedMeters : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMProjectedMeters
	{
		// -(instancetype _Nonnull)initWithNorthing:(double)northing easting:(double)easting;
		[Export ("initWithNorthing:easting:")]
		NativeHandle Constructor (double northing, double easting);

		// @property (readonly, nonatomic) double northing;
		[Export ("northing")]
		double Northing { get; }

		// @property (readonly, nonatomic) double easting;
		[Export ("easting")]
		double Easting { get; }
	}

	// @interface MBMMercatorCoordinate : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMMercatorCoordinate
	{
		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y;
		[Export ("initWithX:y:")]
		NativeHandle Constructor (double x, double y);

		// @property (readonly, nonatomic) double x;
		[Export ("x")]
		double X { get; }

		// @property (readonly, nonatomic) double y;
		[Export ("y")]
		double Y { get; }

		// -(BOOL)isEqualToMercatorCoordinate:(MBMMercatorCoordinate * _Nonnull)other;
		[Export ("isEqualToMercatorCoordinate:")]
		bool IsEqualToMercatorCoordinate (MBMMercatorCoordinate other);
	}

	// @interface MBMStyleObjectInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMStyleObjectInfo
	{
		// -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id_ type:(NSString * _Nonnull)type;
		[Export ("initWithId:type:")]
		NativeHandle Constructor (string id_, string type);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }
	}

	// @interface MBMTransitionOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMTransitionOptions
	{
		// -(instancetype _Nonnull)initWithDuration:(NSNumber * _Nullable)duration delay:(NSNumber * _Nullable)delay enablePlacementTransitions:(NSNumber * _Nullable)enablePlacementTransitions __attribute__((swift_private));
		[Export ("initWithDuration:delay:enablePlacementTransitions:")]
		NativeHandle Constructor ([NullAllowed] NSNumber duration, [NullAllowed] NSNumber delay, [NullAllowed] NSNumber enablePlacementTransitions);

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * duration __attribute__((swift_private));
		[Export ("duration")]
		NSNumber Duration { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * delay __attribute__((swift_private));
		[Export ("delay")]
		NSNumber Delay { get; }

		// @property (readonly, nonatomic) NS_REFINED_FOR_SWIFT NSNumber * enablePlacementTransitions __attribute__((swift_private));
		[Export ("enablePlacementTransitions")]
		NSNumber EnablePlacementTransitions { get; }
	}

	// @interface MBMCanonicalTileID : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCanonicalTileID
	{
		// -(instancetype _Nonnull)initWithZ:(uint8_t)z x:(uint32_t)x y:(uint32_t)y;
		[Export ("initWithZ:x:y:")]
		NativeHandle Constructor (byte z, uint x, uint y);

		// @property (readonly, nonatomic) uint8_t z;
		[Export ("z")]
		byte Z { get; }

		// @property (readonly, nonatomic) uint32_t x;
		[Export ("x")]
		uint X { get; }

		// @property (readonly, nonatomic) uint32_t y;
		[Export ("y")]
		uint Y { get; }

		// -(BOOL)isEqualToCanonicalTileID:(MBMCanonicalTileID * _Nonnull)other;
		[Export ("isEqualToCanonicalTileID:")]
		bool IsEqualToCanonicalTileID (MBMCanonicalTileID other);
	}

	// @interface MBMTileOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface MBMTileOptions
	{
		// -(instancetype _Nonnull)initWithTolerance:(double)tolerance tileSize:(uint16_t)tileSize buffer:(uint16_t)buffer clip:(BOOL)clip wrap:(BOOL)wrap;
		[Export ("initWithTolerance:tileSize:buffer:clip:wrap:")]
		NativeHandle Constructor (double tolerance, ushort tileSize, ushort buffer, bool clip, bool wrap);

		// @property (readonly, nonatomic) double tolerance;
		[Export ("tolerance")]
		double Tolerance { get; }

		// @property (readonly, nonatomic) uint16_t tileSize;
		[Export ("tileSize")]
		ushort TileSize { get; }

		// @property (readonly, nonatomic) uint16_t buffer;
		[Export ("buffer")]
		ushort Buffer { get; }

		// @property (readonly, nonatomic) BOOL clip;
		[Export ("clip")]
		bool Clip { get; }

		// @property (readonly, nonatomic) BOOL wrap;
		[Export ("wrap")]
		bool Wrap { get; }
	}

	// typedef void (^MBMTileFunctionCallback)(MBMCanonicalTileID * _Nonnull);
	delegate void MBMTileFunctionCallback (MBMCanonicalTileID arg0);

	// @interface MBMCustomGeometrySourceOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCustomGeometrySourceOptions
	{
		// -(nonnull instancetype)initWithFetchTileFunction:(nonnull MBMTileFunctionCallback)fetchTileFunction cancelTileFunction:(nonnull MBMTileFunctionCallback)cancelTileFunction tileOptions:(nonnull MBMTileOptions *)tileOptions;
		[Export ("initWithFetchTileFunction:cancelTileFunction:tileOptions:")]
		NativeHandle Constructor (MBMTileFunctionCallback fetchTileFunction, MBMTileFunctionCallback cancelTileFunction, MBMTileOptions tileOptions);

		// -(nonnull instancetype)initWithFetchTileFunction:(nonnull MBMTileFunctionCallback)fetchTileFunction cancelTileFunction:(nonnull MBMTileFunctionCallback)cancelTileFunction minZoom:(uint8_t)minZoom maxZoom:(uint8_t)maxZoom tileOptions:(nonnull MBMTileOptions *)tileOptions;
		[Export ("initWithFetchTileFunction:cancelTileFunction:minZoom:maxZoom:tileOptions:")]
		NativeHandle Constructor (MBMTileFunctionCallback fetchTileFunction, MBMTileFunctionCallback cancelTileFunction, byte minZoom, byte maxZoom, MBMTileOptions tileOptions);

		// @property (nonatomic, readonly, nonnull) MBMTileFunctionCallback fetchTileFunction;
		[Export ("fetchTileFunction")]
		MBMTileFunctionCallback FetchTileFunction { get; }

		// @property (nonatomic, readonly, nonnull) MBMTileFunctionCallback cancelTileFunction;
		[Export ("cancelTileFunction")]
		MBMTileFunctionCallback CancelTileFunction { get; }

		// @property (readonly, nonatomic) uint8_t minZoom;
		[Export ("minZoom")]
		byte MinZoom { get; }

		// @property (readonly, nonatomic) uint8_t maxZoom;
		[Export ("maxZoom")]
		byte MaxZoom { get; }

		// @property (nonatomic, readonly, nonnull) MBMTileOptions *tileOptions;
		[Export ("tileOptions")]
		MBMTileOptions TileOptions { get; }
	}

	// @interface MBMCustomRasterSourceOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCustomRasterSourceOptions
	{
		// - (nonnull instancetype)initWithClientCallback:(nonnull MBMCustomRasterSourceClient *)clientCallback;
		[Export ("initWithClientCallback:")]
		NativeHandle Constructor (MBMCustomRasterSourceClient clientCallback);

		// - (nonnull instancetype)initWithClientCallback:(nonnull MBMCustomRasterSourceClient *)clientCallback
        //                               minZoom:(uint8_t)minZoom
        //                               maxZoom:(uint8_t)maxZoom
        //                              tileSize:(uint16_t)tileSize;
		[Export ("initWithClientCallback:minZoom:maxZoom:tileSize:")]
		NativeHandle Constructor (MBMCustomRasterSourceClient clientCallback, byte minZoom, byte maxZoom, ushort tileSize);

		// @property (nonatomic, readonly, nonnull) MBMCustomRasterSourceClient *clientCallback;
		[Export ("clientCallback")]
		MBMCustomRasterSourceClient ClientCallback { get; }

		// @property (readonly, nonatomic) uint8_t minZoom;
		[Export ("minZoom")]
		byte MinZoom { get; }

		// @property (readonly, nonatomic) uint8_t maxZoom;
		[Export ("maxZoom")]
		byte MaxZoom { get; }

		// @property (readonly, nonatomic) uint16_t tileSize;
		[Export ("tileSize")]
		ushort TileSize { get; }
	}

	// @interface MBMCustomLayerRenderParameters : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMCustomLayerRenderParameters
	{
		// @property (readonly, nonatomic) double width;
		[Export ("width")]
		double Width { get; }

		// @property (readonly, nonatomic) double height;
		[Export ("height")]
		double Height { get; }

		// @property (readonly, nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; }

		// @property (readonly, nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; }

		// @property (readonly, nonatomic) double zoom;
		[Export ("zoom")]
		double Zoom { get; }

		// @property (readonly, nonatomic) double bearing;
		[Export ("bearing")]
		double Bearing { get; }

		// @property (readonly, nonatomic) double pitch;
		[Export ("pitch")]
		double Pitch { get; }

		// @property (readonly, nonatomic) double fieldOfView;
		[Export ("fieldOfView")]
		double FieldOfView { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nonnull projectionMatrix;
		[Export ("projectionMatrix", ArgumentSemantic.Copy)]
		NSNumber[] ProjectionMatrix { get; }

		// @property (readonly, nonatomic) id<MBMElevationData> _Nullable elevationData;
		[NullAllowed, Export ("elevationData")]
		MBMElevationData ElevationData { get; }

		// @property (readonly, copy, nonatomic) NSArray<MBMCanonicalTileID *> * _Nullable renderToTilesIDs;
		[NullAllowed, Export ("renderToTilesIDs", ArgumentSemantic.Copy)]
		MBMCanonicalTileID[] RenderToTilesIDs { get; }
	}

	// @interface MBMCustomLayerRenderConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	interface MBMCustomLayerRenderConfiguration
	{
		// -(instancetype _Nonnull)initWithIsRenderToTileSupported:(BOOL)isRenderToTileSupported shouldRerenderTiles:(BOOL)shouldRerenderTiles;
		[Export ("initWithIsRenderToTileSupported:shouldRerenderTiles:")]
		NativeHandle Constructor (bool isRenderToTileSupported, bool shouldRerenderTiles);

		// @property (readonly, nonatomic) BOOL isRenderToTileSupported;
		[Export ("isRenderToTileSupported")]
		bool IsRenderToTileSupported { get; }

		// @property (readonly, nonatomic) BOOL shouldRerenderTiles;
		[Export ("shouldRerenderTiles")]
		bool ShouldRerenderTiles { get; }
	}

	// @protocol MBMElevationData
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBMElevationData { }

    [Model, Protocol]
	[BaseType(typeof(NSObject))]
	interface MBMElevationData
	{
		// @required -(NSNumber * _Nullable)getElevationForCoordinate:(CLLocationCoordinate2D)coordinate;
		[Abstract]
		[Export ("getElevationForCoordinate:")]
		[return: NullAllowed]
		NSNumber GetElevationForCoordinate (CLLocationCoordinate2D coordinate);

		// @required -(double)getTerrainExaggeration;
		[Abstract]
		[Export ("getTerrainExaggeration")]
		double TerrainExaggeration { get; }
	}

	// @protocol MBMCustomLayerHost <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	partial interface IMBMCustomLayerHost { }

    [Model, Protocol]
	[BaseType (typeof(NSObject))]
	interface MBMCustomLayerHost
	{
		// @required -(void)renderingWillStart:(id<MTLDevice> _Nonnull)metalDevice colorPixelFormat:(NSUInteger)colorPixelFormat depthStencilPixelFormat:(NSUInteger)depthStencilPixelFormat;
		[Abstract]
		[Export ("renderingWillStart:colorPixelFormat:depthStencilPixelFormat:")]
		void RenderingWillStart (IMTLDevice metalDevice, nuint colorPixelFormat, nuint depthStencilPixelFormat);

		// @required -(void)render:(MBMCustomLayerRenderParameters * _Nonnull)parameters mtlCommandBuffer:(id<MTLCommandBuffer> _Nonnull)mtlCommandBuffer mtlRenderPassDescriptor:(MTLRenderPassDescriptor * _Nonnull)mtlRenderPassDescriptor;
		[Abstract]
		[Export ("render:mtlCommandBuffer:mtlRenderPassDescriptor:")]
		void Render (MBMCustomLayerRenderParameters parameters, IMTLCommandBuffer mtlCommandBuffer, MTLRenderPassDescriptor mtlRenderPassDescriptor);

		// @required -(void)renderingWillEnd;
		[Abstract]
		[Export ("renderingWillEnd")]
		void RenderingWillEnd ();

		// @optional -(MBMCustomLayerRenderConfiguration * _Nonnull)prerender:(MBMCustomLayerRenderParameters * _Nonnull)parameters mtlCommandBuffer:(id<MTLCommandBuffer> _Nonnull)mtlCommandBuffer;
		[Export ("prerender:mtlCommandBuffer:")]
		MBMCustomLayerRenderConfiguration Prerender (MBMCustomLayerRenderParameters parameters, IMTLCommandBuffer mtlCommandBuffer);

		// @optional -(void)renderToTile:(MBMCanonicalTileID * _Nonnull)tileID mtlRenderCommandEncoder:(id<MTLRenderCommandEncoder> _Nonnull)mtlRenderCommandEncoder;
		[Export ("renderToTile:mtlRenderCommandEncoder:")]
		void RenderToTile (MBMCanonicalTileID tileID, IMTLRenderCommandEncoder mtlRenderCommandEncoder);

		// @optional -(void)renderingWillStartOpenGL;
		[Export ("renderingWillStartOpenGL")]
		void RenderingWillStartOpenGL ();

		// @optional -(void)renderOpenGL:(MBMCustomLayerRenderParameters * _Nonnull)parameters;
		[Export ("renderOpenGL:")]
		void RenderOpenGL (MBMCustomLayerRenderParameters parameters);

		// @optional -(void)openGLContextLost;
		[Export ("openGLContextLost")]
		void OpenGLContextLost ();
	}

	// @interface MBMVec3 : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMVec3
	{
		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y z:(double)z;
		[Export ("initWithX:y:z:")]
		NativeHandle Constructor (double x, double y, double z);

		// @property (readonly, nonatomic) double x;
		[Export ("x")]
		double X { get; }

		// @property (readonly, nonatomic) double y;
		[Export ("y")]
		double Y { get; }

		// @property (readonly, nonatomic) double z;
		[Export ("z")]
		double Z { get; }
	}

	// @interface MBMVec4 : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMVec4
	{
		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y z:(double)z w:(double)w;
		[Export ("initWithX:y:z:w:")]
		NativeHandle Constructor (double x, double y, double z, double w);

		// @property (readonly, nonatomic) double x;
		[Export ("x")]
		double X { get; }

		// @property (readonly, nonatomic) double y;
		[Export ("y")]
		double Y { get; }

		// @property (readonly, nonatomic) double z;
		[Export ("z")]
		double Z { get; }

		// @property (readonly, nonatomic) double w;
		[Export ("w")]
		double W { get; }
	}

	// @interface MBMViewAnnotationPositionDescriptor : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBMViewAnnotationPositionDescriptor
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, nonatomic) double width;
		[Export ("width")]
		double Width { get; }

		// @property (readonly, nonatomic) double height;
		[Export ("height")]
		double Height { get; }

		// @property (readonly, nonatomic) CLLocationCoordinate2D anchorCoordinate;
		[Export ("anchorCoordinate")]
		CLLocationCoordinate2D AnchorCoordinate { get; }

		// @property (readonly, nonatomic) MBMViewAnnotationAnchorConfig * _Nonnull anchorConfig;
		[Export ("anchorConfig")]
		MBMViewAnnotationAnchorConfig AnchorConfig { get; }
	}
}
