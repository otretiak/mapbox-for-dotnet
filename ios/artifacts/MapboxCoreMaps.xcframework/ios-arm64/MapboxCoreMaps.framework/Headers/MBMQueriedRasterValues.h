// This file is generated and will be overwritten automatically.

#import <Foundation/Foundation.h>

/** Result of a raster array query. Contains each layer's query results. */
NS_SWIFT_NAME(QueriedRasterValues)
__attribute__((visibility ("default")))
@interface MBMQueriedRasterValues : NSObject

// This class provides custom init which should be called
- (nonnull instancetype)init NS_UNAVAILABLE;

// This class provides custom init which should be called
+ (nonnull instancetype)new NS_UNAVAILABLE;

- (nonnull instancetype)initWithLayers:(nonnull NSDictionary<NSString *, NSArray<NSNumber *> *> *)layers NS_REFINED_FOR_SWIFT;

@property (nonatomic, readonly, nonnull, copy) NSDictionary<NSString *, NSArray<NSNumber *> *> *layers;

@end
