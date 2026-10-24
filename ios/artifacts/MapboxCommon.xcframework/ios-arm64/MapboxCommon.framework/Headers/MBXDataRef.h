#ifndef MBXDataRef_h
#define MBXDataRef_h

#import <Foundation/Foundation.h>

NS_SWIFT_NAME(DataRef)
__attribute__((visibility("default")))
@interface MBXDataRef : NSObject

@property (nonatomic, strong, nonnull) NSData *data;

- (nonnull instancetype)init NS_UNAVAILABLE;
+ (nonnull instancetype)new NS_UNAVAILABLE;

/**
 * Create object that wraps the data
 * @param data data object
 */
- (nonnull instancetype)initWithData:(nonnull NSData *)data;

@end

#endif /* MBXDataRef_h */
