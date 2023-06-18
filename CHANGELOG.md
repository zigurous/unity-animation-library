# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.8.0] - 2022/11/30

## Added

- New `BillboardRotation` behavior
- New `AnimatedMaterialTiling` behavior
- New behaviors to rotate based on user input (Input System dependency added)
  - `InputRotation`
  - `LookAtMouse`
- New match transform behaviors
  - `MatchPosition`
  - `MatchRotation`
  - `MatchScale`
  - `MatchTransform`
- New lock transform behaviors
  - `LockPosition`
  - `LockRotation`
  - `LockScale`
  - `LockTransform`
- Optional axis constraints added to `SmoothFollow` and `SmoothLookAt`
- Option to change coordinate space for most animation behaviors
- Help URLs added to every behavior script

## Changed

- Default execution order set to +100 for behaviors using LateUpdate
- Update strategies hidden from component menu
- Renamed `UpdateBehavior` to `UpdateBehaviour`
- Documentation changes

## Removed

- Deleted `Parameter` static class
- Deleted internal `Processors` class

## [1.7.0] - 2022/05/20

### Added

- Implemented an update strategy pattern to reduce overhead and improve performance
- New `SmoothDampQuaternion` data structure
- New `Processors` internal helper class

### Changed

- Moved animation behaviors to a new directory
- Changed `SmoothDamp<T>` fields from protected to private

## [1.6.2] - 2021/11/14

### Changed

- Rewrote and simplified custom propety drawers

### Fixed

- Indentation of AnimatorParameter label in the editor

## [1.6.1] - 2021/10/28

### Changed

- Naming convention of private serialized properties to match Unity conventions

## [1.6.0] - 2021/07/18

### Added

- New `Parameter` static class with predefined hash ids
- New `SmoothDamp<T>` abstract class
- New `SmoothDampFloat` data structure
- New `SmoothDampVector2` data structure
- New `SmoothDampVector3` data structure

### Fixed

- Hash ids on `AnimatorParameter` were not updating when the name was changed in the editor

## [1.5.0] - 2021/07/07

### Added

- New `Timing01` struct
- New `TimingRange01` struct
- New `IAnimationCurve<T>` interface

### Changed

- Removed root bone from avatar masks
- Updated documentation comments
- Updated package metadata

## [1.4.2] - 2021/07/01

### Changed

- Hash ids on `AnimatorParameter` are now generated automatically without ever having to call a function

## [1.4.1] - 2021/06/28

### Changed

- Attribute `[AddComponentMenu]` added to all behaviors

## [1.4.0] - 2021/06/27

### Added

- Support for different update modes on common animation scripts
- New `RotateAround` script

### Changed

- Increased default speed values
- Separated speed from rotation axis

## [1.3.1] - 2021/06/22

### Added

- Editor property drawer for `AnimatorParameter`

## [1.3.0] - 2021/06/22

### Added

- New `AnimatorParameter` data structure
- Restart function added to `AnimatedSprite`

## [1.2.0] - 2021/06/10

### Added

- New `FollowPath` script
- Support for reversed `AnimatedSprite`

## [1.1.0] - 2021/05/19

### Added

- New `AnimatedSprite` behavior

## [1.0.1] - 2021/04/13

### Changed

- Package description

### Fixed

- Set Editor assembly to only compile for the Editor platform
- Moved non-compiled assets outside of the Runtime directory

## [1.0.0] - 2021/03/24

### Added

- 16 Humanoid Animation Masks
- Animation Scripts
  - SmoothFollow
  - SmoothLookAt
  - Blink
  - Move
  - Orbit
  - Rotate
  - Scale
- Data Structures
  - Timing
  - TimingRange
  - Vector2AnimationCurve
  - Vector3AnimationCurve
  - Vector4AnimationCurve
