# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.4.2] - 2021/07/01

### Changed

- Animator parameter ids are now generated automatically without ever having to call a function

## [1.4.1] - 2021/06/28

### Changed

- [AddComponentMenu] attribute added to all behaviors

## [1.4.0] - 2021/06/27

### Added

- Support for different update modes on common animation scripts
- New RotateAround script

### Changed

- Increased default speed values
- Separated speed from rotation axis

## [1.3.1] - 2021/06/22

### Added

- Editor property drawer for AnimatorParameter

## [1.3.0] - 2021/06/22

### Added

- AnimatorParameter - new serializable data structure that manages parameter hashes
- Restart function added to AnimatedSprite

## [1.2.0] - 2021/06/10

### Added

- New FollowPath script
- Support for reversed AnimatedSprite

## [1.1.0] - 2021/05/19

### Added

- AnimatedSprite

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
