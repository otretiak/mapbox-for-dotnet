// This file is generated and will be overwritten automatically.

#import <Foundation/Foundation.h>

/**
 * A tile region's load progress includes counts
 * of the number of resources that have completed downloading
 * and the total number of resources that are required.
 */
NS_SWIFT_SENDABLE
NS_SWIFT_NAME(TileRegionLoadProgress)
__attribute__((visibility ("default")))
@interface MBXTileRegionLoadProgress : NSObject

// This class provides custom init which should be called
- (nonnull instancetype)init NS_UNAVAILABLE;

// This class provides custom init which should be called
+ (nonnull instancetype)new NS_UNAVAILABLE;

- (nonnull instancetype)initWithCompletedResourceCount:(uint64_t)completedResourceCount
                                 completedResourceSize:(uint64_t)completedResourceSize
                                  erroredResourceCount:(uint64_t)erroredResourceCount
                                 requiredResourceCount:(uint64_t)requiredResourceCount
                                   loadedResourceCount:(uint64_t)loadedResourceCount
                                    loadedResourceSize:(uint64_t)loadedResourceSize;

- (nonnull instancetype)initWithCompletedResourceCount:(uint64_t)completedResourceCount
                                 completedResourceSize:(uint64_t)completedResourceSize
                                  erroredResourceCount:(uint64_t)erroredResourceCount
                                 requiredResourceCount:(uint64_t)requiredResourceCount
                                   loadedResourceCount:(uint64_t)loadedResourceCount
                                    loadedResourceSize:(uint64_t)loadedResourceSize
                                          backoffUntil:(nullable NSDate *)backoffUntil
                        totalTransfersWithBackoffCount:(uint64_t)totalTransfersWithBackoffCount
                             totalScheduledBackoffTime:(NSTimeInterval)totalScheduledBackoffTime;

/** The number of resources that are ready for offline access. */
@property (nonatomic, readonly) uint64_t completedResourceCount;

/**
 * The cumulative size, in bytes, of all resources (inclusive of tiles) that
 * are ready for offline access.
 */
@property (nonatomic, readonly) uint64_t completedResourceSize;

/** The number of resources that have failed to download due to an error. */
@property (nonatomic, readonly) uint64_t erroredResourceCount;

/** The number of resources that are known to be required for this tile region. */
@property (nonatomic, readonly) uint64_t requiredResourceCount;

/**
 * The number of resources that are ready for offline use and that (at least partially)
 * have been downloaded from the network.
 */
@property (nonatomic, readonly) uint64_t loadedResourceCount;

/**
 * The cumulative size, in bytes, of all resources (inclusive of tiles) that have
 * been downloaded from the network.
 */
@property (nonatomic, readonly) uint64_t loadedResourceSize;

/**
 * Indicates whether the load operation is blocked. If not empty, the value indicates the earliest time point before
 * any network request can progress. Requests may be prevented from progressing due to rate limiting, lack of
 * network connectivity, server errors, etc.
 */
@property (nonatomic, readonly, nullable) NSDate *backoffUntil;

/**
 * The total number of network requests that have been retried with backoff. This count includes backoff events for
 * all network requests, even those that did not cause the load operation to stall and therefore did not trigger a
 * report with a non-empty value in `backoffUntil`.
 */
@property (nonatomic, readonly) uint64_t totalTransfersWithBackoffCount;

/**
 * The total cumulative backoff time that has been scheduled for all network requests (includes the time that has
 * already been waited for and all currently scheduled backoff). This includes backoff events for all network
 * requests, even those that did not cause the load operation to stall and therefore did not trigger a report with a
 * non-empty value in `backoffUntil`.
 */
@property (nonatomic, readonly) NSTimeInterval totalScheduledBackoffTime;


@end
