// This file is generated and will be overwritten automatically.

#import <Foundation/Foundation.h>

@class MBMCanonicalTileID;

/**
 * Note! This is an experimental feature. It can be changed or removed in future versions.
 *
 * Represents a tile coordinate at the zoom level it was requested at, which may differ
 * from the `canonical` zoom level when the tile is overscaled, along with the `wrap`
 * offset for tiles that repeat across the antimeridian.
 *
 * As of v11.30, the tile cover API (`tileCover`) returns `OverscaledTileID` instead of `CanonicalTileID`
 * so that callers can distinguish overscaled tiles from tiles at their native zoom level, and
 * so that tiles repeating across the antimeridian can be told apart via `wrap`.
 * When used with `tileCover`, overscaling only happens when `TileCoverOptions::maxZoom` is
 * set and the camera's zoom exceeds it: the tile is clamped to `maxZoom`, and `canonical`
 * holds the coordinate at that clamped zoom level.
 */
NS_SWIFT_NAME(OverscaledTileID)
__attribute__((visibility ("default")))
@interface MBMOverscaledTileID : NSObject

// This class provides custom init which should be called
- (nonnull instancetype)init NS_UNAVAILABLE;

// This class provides custom init which should be called
+ (nonnull instancetype)new NS_UNAVAILABLE;

- (nonnull instancetype)initWithOverscaledZ:(uint8_t)overscaledZ
                                       wrap:(int16_t)wrap
                                  canonical:(nonnull MBMCanonicalTileID *)canonical;

/** The zoom level this tile was requested/rendered at. */
@property (nonatomic, readonly) uint8_t overscaledZ;

/** The horizontal wrap offset, for tiles that repeat across the antimeridian. */
@property (nonatomic, readonly) int16_t wrap;

/** The canonical tile coordinate backing this overscaled tile. */
@property (nonatomic, readonly, nonnull) MBMCanonicalTileID *canonical;


- (BOOL)isEqualToOverscaledTileID:(nonnull MBMOverscaledTileID *)other;

@end
