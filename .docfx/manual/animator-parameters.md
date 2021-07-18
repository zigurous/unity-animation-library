# Animator Parameters

When setting animator parameters in code, it is more efficient to use hash ids instead of strings. The Animation Library package comes with a static class [Parameter](xref:Zigurous.Animation.Parameter) with predefined ids for common animator parameters.

```csharp
private void Foo()
{
    animator.SetBool(Parameter.Grounded, false);
    animator.SetTrigger(Parameter.Jump, true);
    animator.SetFloat(Parameter.Speed, 4.0f);
}
```

### Automatic Hash Ids

The [AnimatorParameter](xref:Zigurous.Animation.AnimatorParameter) struct included in the Animation Library package automatically creates a hash id for a given animator parameter name. Anywhere you might declare a variable for a custom animator paramter name use `AnimatorParameter` instead. It will still be serialized as a string in the editor, but you can use the id when getting or setting an animator parameter.

To learn more, see https://docs.unity3d.com/ScriptReference/Animator.StringToHash.html.

```csharp
public AnimatorParameter parameter = "Time";
public float time;

private void Update()
{
    animator.SetFloat(parameter.id, time);
}
```
