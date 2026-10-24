// This file is generated and will be overwritten automatically.

#import <Foundation/Foundation.h>

/**
 * The style attributions has been changed. The event will be emitted every time attributions have been changed
 * due to style change, source metadata change, or if sources were removed or added.
 *
 * Note: The event may be emitted synchronously, for example, when `removeSource` was called
 * or if newly added source doesn't require to load metadata from network.
 */
NS_SWIFT_NAME(StyleAttributionsChanged)
__attribute__((visibility ("default")))
@interface MBMStyleAttributionsChanged : NSObject

// This class provides custom init which should be called
- (nonnull instancetype)init NS_UNAVAILABLE;

// This class provides custom init which should be called
+ (nonnull instancetype)new NS_UNAVAILABLE;

- (nonnull instancetype)initWithAttributions:(nonnull NSArray<NSString *> *)attributions
                                   timestamp:(nonnull NSDate *)timestamp;

/** Attributions for the data used by the Map's style. */
@property (nonatomic, readonly, nonnull, copy) NSArray<NSString *> *attributions;

/** The timestamp of the `StyleAttributionsChanged` event. */
@property (nonatomic, readonly, nonnull) NSDate *timestamp;


@end
