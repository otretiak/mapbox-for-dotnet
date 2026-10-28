using System.Runtime.InteropServices;
using Foundation;
using MapboxCoreMaps;
using ObjCRuntime;

namespace MapboxCoreMaps
{
    [Native]
	public enum MBMCustomRasterSourceClientType : long
    {
        CustomRasterSourceTileStatusChangedCallback,
        CustomRasterSourceTileRenderer,
    }

	[Native]
	public enum MBMCustomRasterSourceTileStatus : long
    {
        /**
        * Tile best suited for current camera position.
        * Should be loaded if possible.
        */
        Required,
        /**
        * Tile can be used if required tile is missing.
        * Can be provided if already present in a cache.
        */
        Optional,
        /** Tile is not visible and no more needed. */
        NotNeeded
    }
	[Native]
	public enum MBMGlyphsRasterizationMode : long
	{
		NoGlyphsRasterizedLocally,
		IdeographsRasterizedLocally,
		AllGlyphsRasterizedLocally
	}

	[Native]
	public enum MBMContextMode : long
	{
		Unique,
		Shared
	}

	[Native]
	public enum MBMConstrainMode : long
	{
		None,
		HeightOnly,
		WidthAndHeight
	}

	[Native]
	public enum MBMViewportMode : long
	{
		Default,
		FlippedY
	}

	[Native]
	public enum MBMNorthOrientation : long
	{
		Upwards,
		Rightwards,
		Downwards,
		Leftwards
	}

	[Native]
	public enum MBMMapCenterAltitudeMode : long
	{
		Terrain,
		Sea
	}

	[Native]
	public enum MBMMapDebugOptions : long
	{
		TileBorders,
		ParseStatus,
		Timestamps,
		Collision,
		Overdraw,
		StencilClip,
		DepthBuffer,
		ModelBounds,
		TerrainWireframe,
		Layers2DWireframe,
		Layers3DWireframe,
		Light,
		ElevationID
	}

	[Native]
	public enum MBMViewAnnotationAnchor : long
	{
		Center,
		Top,
		Left,
		Bottom,
		Right,
		TopLeft,
		BottomRight,
		TopRight,
		BottomLeft
	}

	[Native]
	public enum MBMTileCacheBudgetType : long
	{
		Megabytes,
		Tiles
	}

	[Native]
	public enum MBMMapLoadingErrorType : long
	{
		Style,
		Sprite,
		Source,
		Glyphs,
		Tile
	}

	// static class CFunctions
	// {
	// 	// extern NSString * MBMMapLoadingErrorTypeToString (MBMMapLoadingErrorType map_loading_error_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMMapLoadingErrorTypeToString (MBMMapLoadingErrorType map_loading_error_type);

	// 	// extern NSString * MBMStyleDataLoadedTypeToString (MBMStyleDataLoadedType style_data_loaded_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMStyleDataLoadedTypeToString (MBMStyleDataLoadedType style_data_loaded_type);

	// 	// extern NSString * MBMSourceDataLoadedTypeToString (MBMSourceDataLoadedType source_data_loaded_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMSourceDataLoadedTypeToString (MBMSourceDataLoadedType source_data_loaded_type);

	// 	// extern NSString * MBMRenderModeTypeToString (MBMRenderModeType render_mode_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMRenderModeTypeToString (MBMRenderModeType render_mode_type);

	// 	// extern NSString * MBMRequestDataSourceTypeToString (MBMRequestDataSourceType request_data_source_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMRequestDataSourceTypeToString (MBMRequestDataSourceType request_data_source_type);

	// 	// extern NSString * MBMRequestResourceTypeToString (MBMRequestResourceType request_resource_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMRequestResourceTypeToString (MBMRequestResourceType request_resource_type);

	// 	// extern NSString * MBMRequestPriorityTypeToString (MBMRequestPriorityType request_priority_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMRequestPriorityTypeToString (MBMRequestPriorityType request_priority_type);

	// 	// extern NSString * MBMRequestLoadingMethodTypeToString (MBMRequestLoadingMethodType request_loading_method_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMRequestLoadingMethodTypeToString (MBMRequestLoadingMethodType request_loading_method_type);

	// 	// extern NSString * MBMRequestErrorTypeToString (MBMRequestErrorType request_error_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMRequestErrorTypeToString (MBMRequestErrorType request_error_type);

	// 	// extern NSString * MBMResponseSourceTypeToString (MBMResponseSourceType response_source_type);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMResponseSourceTypeToString (MBMResponseSourceType response_source_type);

	// 	// extern NSString * MBMTileStoreUsageModeToString (MBMTileStoreUsageMode tile_store_usage_mode);
	// 	[DllImport ("__Internal")]
	// 	[Verify (PlatformInvoke)]
	// 	static extern NSString MBMTileStoreUsageModeToString (MBMTileStoreUsageMode tile_store_usage_mode);
	// }

	[Native]
	public enum MBMStyleDataLoadedType : long
	{
		tyle,
		prite,
		ources
	}

	[Native]
	public enum MBMSourceDataLoadedType : long
	{
		Metadata,
		Tile
	}

	[Native]
	public enum MBMRenderModeType : long
	{
		Partial,
		Full
	}

	[Native]
	public enum MBMRequestDataSourceType : long
	{
		Asset,
		Database,
		FileSystem,
		Network,
		ResourceLoader
	}

	[Native]
	public enum MBMRequestResourceType : long
	{
		Unknown,
		Style,
		Source,
		Tile,
		Glyphs,
		SpriteImage,
		SpriteJSON,
		Image,
		Model
	}

	[Native]
	public enum MBMRequestPriorityType : long
	{
		Regular,
		Low
	}

	[Native]
	public enum MBMRequestLoadingMethodType : long
	{
		Network,
		Cache
	}

	[Native]
	public enum MBMRequestErrorType : long
	{
		Success,
		NotFound,
		Server,
		Connection,
		RateLimit,
		InOfflineMode,
		Other
	}

	[Native]
	public enum MBMResponseSourceType : long
	{
		Network,
		Cache,
		TileStore,
		LocalFile
	}

	[Native]
	public enum MBMOfflineRegionErrorType : long
	{
		NotFound,
		Server,
		Connection,
		RateLimit,
		DiskFull,
		TileCountLimitExceeded,
		Other
	}

	[Native]
	public enum MBMOfflineRegionDownloadState : long
	{
		Inactive,
		Active
	}

	[Native]
	public enum MBMTileStoreUsageMode : long
	{
		Disabled,
		ReadOnly,
		ReadAndUpdate
	}

}
