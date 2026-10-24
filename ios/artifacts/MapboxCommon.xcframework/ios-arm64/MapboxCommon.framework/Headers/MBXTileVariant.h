// This file is generated and will be overwritten automatically.

#import <Foundation/Foundation.h>

typedef NS_ENUM(NSInteger, MBXTileDataDomain);

/**
 * WARNING: This API is not intended for public usage. It can be deleted or changed without any notice.
 * A tile variant identifies tiles associated with a specific domain, dataset, and version.
 */
NS_SWIFT_NAME(TileVariant)
__attribute__((visibility ("default")))
@interface MBXTileVariant : NSObject <NSCopying>

// This class provides custom init which should be called
- (nonnull instancetype)init NS_UNAVAILABLE;

// This class provides custom init which should be called
+ (nonnull instancetype)new NS_UNAVAILABLE;

- (nonnull instancetype)initWithDomain:(MBXTileDataDomain)domain
                               dataset:(nonnull NSString *)dataset
                               version:(nonnull NSString *)version;

/** The data domain the tile is referring to. */
@property (nonatomic, readonly) MBXTileDataDomain domain;

/** The dataset the tile is referring to, e.g. `mapbox/driving`. */
@property (nonatomic, readonly, nonnull, copy) NSString *dataset;

/**
 * The version the tile is referring to, e.g. `2021_03_14-03_00_00`.
 *
 * For Maps must be a query string *including* the starting `&`, e.g. `&language=en&worldview=US`.
 */
@property (nonatomic, readonly, nonnull, copy) NSString *version;


- (BOOL)isEqualToTileVariant:(nonnull MBXTileVariant *)other;

@end
