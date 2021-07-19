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

- [Unity's Package Manager](https://docs.unity3d.com/Manual/Packages.html)
- [Installing from a Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html)

### Importing

Import the package namespace in each script or file you want to use it.

> **Note**: You may need to regenerate project files/assemblies first.

```csharp
using Zigurous.Animation;
```

## Reference

- [Behaviors](https://docs.zigurous.com/com.zigurous.animation/manual/behaviors.html)
- [Data Structures](https://docs.zigurous.com/com.zigurous.animation/manual/data-structures.html)
- [Animator Parameters](https://docs.zigurous.com/com.zigurous.animation/manual/animator-parameters.html)
- [Avatar Masks](https://docs.zigurous.com/com.zigurous.animation/manual/avatar-masks.html)
