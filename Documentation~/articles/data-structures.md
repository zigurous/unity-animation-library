---
slug: "/manual/data-structures"
---

# Data Structures

The **Animation Library** package includes several data structures to assist in animation-related purposes, mainly when writing custom scripts.

<br/>

### [AnimatorParameter](/api/Zigurous.Animation/AnimatorParameter)

An animation parameter that can be set on an Animator. A hash id is automatically created for the parameter. Ids are used for optimized setters and getters on Animator parameters.

<hr/>

### [SmoothDampFloat](/api/Zigurous.Animation/SmoothDampFloat)

Gradually changes a float over time using a spring-damper function, which will never overshoot.

<hr/>

### [SmoothDampVector2](/api/Zigurous.Animation/SmoothDampVector2)

Gradually changes a Vector2 over time using a spring-damper function, which will never overshoot.

<hr/>

### [SmoothDampVector3](/api/Zigurous.Animation/SmoothDampVector3)

Gradually changes a Vector3 over time using a spring-damper function, which will never overshoot.

<hr/>

### [SmoothDampQuaternion](/api/Zigurous.Animation/SmoothDampQuaternion)

Gradually changes a Quaternion over time using a spring-damper function, which will never overshoot.

<hr/>

### [Timing](/api/Zigurous.Animation/Timing)

The start and end time of an animation.

<hr/>

### [Timing01](/api/Zigurous.Animation/Timing01)

The start and end time of an animation normalized between 0 and 1.

<hr/>

### [TimingRange](/api/Zigurous.Animation/TimingRange)

An animation timing range between a lower and upper bound.

<hr/>

### [TimingRange01](/api/Zigurous.Animation/TimingRange01)

An animation timing range normalized between 0 and 1.

<hr/>

### [Vector2AnimationCurve](/api/Zigurous.Animation/Vector2AnimationCurve)

Stores a collection of keyframes that can be evaluated over time as a Vector2.

<hr/>

### [Vector3AnimationCurve](/api/Zigurous.Animation/Vector3AnimationCurve)

Stores a collection of keyframes that can be evaluated over time as a Vector3.

<hr/>

### [Vector4AnimationCurve](/api/Zigurous.Animation/Vector4AnimationCurve)

Stores a collection of keyframes that can be evaluated over time as a Vector4.
