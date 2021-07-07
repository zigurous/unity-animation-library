# Avatar Masks

Masking allows you to discard some of the animation data within a clip, allowing the clip to animate only parts of the object or character rather than the entire thing. For example, you may have a standard walking animation that includes both arm and leg motion, but if a character is carrying a large object with both hands then you wouldn’t want their arms to swing to the side as they walk. However, you could still use the standard walking animation while carrying the object by using a mask to only play the upper body portion of the carrying animation over the top of the walking animation.

Mask assets can be used in Animator Controllers, when specifying Animation Layers to apply masking at runtime, or in the import settings of your animation files to apply masking during the import animation.

A benefit of using Masks is that they tend to reduce memory overheads since body parts that are not active do not need their associated animation curves. Also, the unused curves need not be calculated during playback which will tend to reduce the CPU overhead of the animation.

### Included Assets

The Animation Library package contains 16+ avatar masks to represent different humanoid body parts:

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
