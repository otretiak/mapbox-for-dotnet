// This file is generated and will be overwritten automatically.

#import <Foundation/Foundation.h>
#import <CoreLocation/CoreLocation.h>
@class MBXCoordinate2D;

@class MBXTileStoreFilter;

/** Tile store import operation options. */
NS_SWIFT_NAME(TileStoreImportOptions)
__attribute__((visibility ("default")))
@interface MBXTileStoreImportOptions : NSObject

// This class provides custom init which should be called
- (nonnull instancetype)init NS_UNAVAILABLE;

// This class provides custom init which should be called
+ (nonnull instancetype)new NS_UNAVAILABLE;

/** Creates a TileStoreImportOptions instance without any applied options. */
+ (nonnull MBXTileStoreImportOptions *)make __attribute((ns_returns_retained));
/**
 * Sets the list of archive file descriptors from the TileStore archive package. A TileStore archive package is made
 * up of one or more files with a specific order (whose extension is typically ".tsdp"). The file descriptors passed
 * to this function should point to all files in the archive, and must be in the same order as the files in the
 * package. The file descriptors must have read permissions.
 *
 * NOTE: After calling this function, the file descriptors passed as arguments can be safely closed by the caller.
 * This function duplicates the input file descriptors, and will close them when they are no longer needed.
 */
- (nonnull MBXTileStoreImportOptions *)setArchiveFileDescriptorsForDescriptors:(nonnull NSArray<NSNumber *> *)descriptors __attribute((ns_returns_retained));
/**
 * Gets the list of archive file descriptors. See `setArchiveFileDescriptors()`.
 *
 * NOTE: The caller must not close the file descriptors returned by this function, as they are owned by the
 * `TileStoreImportOptions` instance and will be closed automatically when they are no longer needed. If the caller
 * needs to keep the file descriptors open, it should either keep the owning `TileStoreImportOptions` instance
 * alive, or duplicate the file descriptors before use.
 *
 * The values of the file descriptors returned by this function will be different than the values inputted in
 * `setArchiveFileDescriptors()`, since the input file descriptors are duplicated for internal use.
 */
- (nonnull NSArray<NSNumber *> *)getArchiveFileDescriptors __attribute((ns_returns_retained));
/**
 * Imports starts at the given location and then proceeds to tiles that are further away from it. If not provided,
 * the imports starts from the first valid point in geometry.
 */
- (nonnull MBXTileStoreImportOptions *)startLocationForLocation:(nullable MBXCoordinate2D *)location __attribute((ns_returns_retained));
/** See startLocation. */
- (nullable MBXCoordinate2D *)getStartLocation __attribute((ns_returns_retained));
/**
 * The size of the chunks in which the import operation will be split for tiles and resources (default: 32MiB).
 * Larger chunks increase throughput but reduce TileStore responsiveness during import operations, while smaller
 * chunks maintain system responsiveness at the cost of decreased overall import speed due to increased overhead.
 *
 * The default 32MiB was chosen so that a chunk is processed in well under ~1 second at 50MiB/s transfer rates
 * (typical USB 2.0 to SSD performance), balancing import efficiency with system responsiveness. USB-to-SSD transfer
 * speeds are limited by the slower of the two interfaces, with USB 2.0 theoretical maximum of 480Mbps often reduced
 * to 30-60MiB/s in practice due to protocol overhead, device capabilities, and storage write speeds.
 */
- (nonnull MBXTileStoreImportOptions *)setMaxImportChunkSizeForMaxChunkSize:(uint64_t)maxChunkSize __attribute((ns_returns_retained));
/** See setMaxImportChunkSize. */
- (uint64_t)getMaxImportChunkSize;
/** Reserved for future use. */
- (nonnull MBXTileStoreImportOptions *)setFilterForFilter:(nullable MBXTileStoreFilter *)filter __attribute((ns_returns_retained));
/** Reserved for future use. */
- (nullable MBXTileStoreFilter *)getFilter __attribute((ns_returns_retained));

@end
