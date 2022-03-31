---
slug: "/manual/animator-parameters"
---

# Animator Parameters

When setting animator parameters in code, it is more efficient to use hash ids instead of strings. The **Animation Library** package comes with a static class [Parameter](/api/Zigurous.Animation/Parameter) with predefined ids for common animator parameters.

```csharp
private void Foo()
{
    animator.SetTrigger(Parameter.Jump);
    animator.SetBool(Parameter.Grounded, false);
    animator.SetFloat(Parameter.Speed, 4f);
}
```

<hr/>

## 🔖 Automatic Hash Ids

The [AnimatorParameter](/api/Zigurous.Animation/AnimatorParameter) struct included in the **Animation Library** package automatically creates a hash id for a given parameter name. Anywhere you might declare a variable for a custom parameter use `AnimatorParameter` instead. It will still be serialized as a string in the editor, but you can use the id when getting or setting an animator parameter.

```csharp
public AnimatorParameter parameter = "Time";

private void Update()
{
    animator.SetFloat(parameter.id, time);
}
```
