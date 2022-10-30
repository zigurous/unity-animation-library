---
slug: "/manual/animator-parameters"
---

# Animator Parameters

When setting animator parameters in code, it is more efficient to use hash ids instead of strings. The **Animation Library** package includes the struct [AnimatorParameter](/api/Zigurous.Animation/AnimatorParameter) that automatically creates a hash id for a given parameter name. Use `AnimatorParameter` anywhere you might declare a variable for a custom parameter instead of a string. It will still be serialized as a string in the editor, but you can use the id when getting or setting an animator parameter.

```csharp
public AnimatorParameter parameter = "Time";

private void Update()
{
    // implicitly converts the parameter to a hash id
    animator.SetFloat(parameter, time);
}
```
