---
slug: "/manual/avatar-masks"
---

# Avatar Masks

Masking allows you to discard some of the animation data within a clip, allowing the clip to animate only parts of a character rather than the entire thing. For example, you may have a standard walking animation that includes both arm and leg motion, but if a character is carrying a large object with both hands then you wouldn’t want their arms to swing to the side as they walk.

Mask assets can be used in Animator Controllers, when specifying Animation Layers to apply masking at runtime, or in the import settings of your animation files to apply masking during the import animation. A benefit of using masks is that they tend to reduce memory overheads since body parts that are not active do not need their associated animation curves.

<img src="https://docs.unity3d.com/uploads/Main/AvatarMaskInspectorHumanoid.png" width="240px"/>
<br/>
<br/>

## 🦾 Included Assets

The **Animation Library** package includes avatar mask assets for the following:

- Arms
- FullBody
- Hands
- Head
- LeftArm
- LeftHand
- LeftLeg
- Legs
- LowerBody
- RightArm
- RightHand
- RightLeg
- Root
- Torso
- TorsoHead
- UpperBody
