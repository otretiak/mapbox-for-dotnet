// This file is generated and will be overwritten automatically.

#import <Foundation/Foundation.h>

/** Options for querying rendered raster values. */
NS_SWIFT_NAME(RenderedRasterQueryOptions)
__attribute__((visibility ("default")))
@interface MBMRenderedRasterQueryOptions : NSObject

// This class provides custom init which should be called
- (nonnull instancetype)init NS_UNAVAILABLE;

// This class provides custom init which should be called
+ (nonnull instancetype)new NS_UNAVAILABLE;

- (nonnull instancetype)initWithLayers:(nullable NSArray<NSString *> *)layers NS_REFINED_FOR_SWIFT;

/** Style layer ids to query. If not provided, all rendered raster array layers are queried. */
@property (nonatomic, readonly, nullable, copy) NSArray<NSString *> *layers;


@end
