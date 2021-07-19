# Animation Library

[![](https://img.shields.io/badge/github-repo-blue?logo=github)](https://github.com/zigurous/unity-animation-library)
[![](https://img.shields.io/github/package-json/v/zigurous/unity-animation-library)](https://github.com/zigurous/unity-animation-library/releases)
[![](https://img.shields.io/badge/docs-link-success)](https://docs.zigurous.com/com.zigurous.animation)
[![](https://img.shields.io/github/license/zigurous/unity-animation-library)](https://github.com/zigurous/unity-animation-library/blob/main/LICENSE.md)

The Animation Library package contains assets and scripts for animating Unity objects. Animation behaviors include Blink, FollowPath, Move, Orbit, Rotate, Scale, SmoothFollow, SmoothLookAt, and more. The package also contains several animation-related data structures and predefined avatar masks.

## Reference

- [Behaviors](https://docs.zigurous.com/com.zigurous.animation/manual/behaviors.html)
- [Data Structures](https://docs.zigurous.com/com.zigurous.animation/manual/data-structures.html)
- [Animator Parameters](https://docs.zigurous.com/com.zigurous.animation/manual/animator-parameters.html)
- [Avatar Masks](https://docs.zigurous.com/com.zigurous.animation/manual/avatar-masks.html)

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
