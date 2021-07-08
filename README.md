# Animation Library

The Animation Library package contains assets and scripts for animating Unity objects. Animation behaviors include Blink, FollowPath, Move, Orbit, Rotate, Scale, SmoothFollow, SmoothLookAt, and more. The package also contains several animation-related data structures and predefined avatar masks.

## Installation

Use the Unity [Package Manager](https://docs.unity3d.com/Manual/upm-ui.html) to install the Animation Library package.

1. Open the Package Manager in `Window > Package Manager`
2. Click the add (`+`) button in the status bar
3. Select `Add package from git URL` from the add menu
4. Enter the following Git URL in the text box and click Add:

```http
https://github.com/zigurous/unity-animation-library.git
```

For more information on the Package Manager and installing packages, see the following pages:

- [Unity’s Package Manager](https://docs.unity3d.com/Manual/Packages.html)
- [Installing from a Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html)

### Importing

Import the package namespace in each script you want to use it. You may need to regenerate project files/assemblies first.

```csharp
using Zigurous.Animation;
```

## Index

### Behaviors

- [AnimatedSprite](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.AnimatedSprite.html)
- [Blink](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Blink.html)
- [FollowPath](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.FollowPath.html)
- [Move](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Move.html)
- [Orbit](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Orbit.html)
- [Rotate](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Rotate.html)
- [RotateAround](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.RotateAround.html)
- [Scale](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Scale.html)
- [SmoothFollow](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.SmoothFollow.html)
- [SmoothLookAt](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.SmoothLookAt.html)

### Data Structures

- [AnimatorParameter](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.AnimatorParameter.html)
- [Timing](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Timing.html)
- [Timing01](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Timing01.html)
- [TimingRange](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.TimingRange.html)
- [TimingRange01](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.TimingRange01.html)
- [Vector2AnimationCurve](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Vector2AnimationCurve.html)
- [Vector3AnimationCurve](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Vector3AnimationCurve.html)
- [Vector4AnimationCurve](https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation.Vector4AnimationCurve.html)
