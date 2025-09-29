using System;

namespace GUITest.scripts.EX;

// ReSharper disable once InconsistentNaming
public static class VariantEX
{
    // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
    // ReSharper disable once MemberCanBePrivate.Global
    public static bool IsGodotObject(this Variant variant) => variant.AsGodotObject() != null;

    public static T? IfIsGodotObject<T>(this Variant variant, Func<Variant, T> ifTrue) =>
        variant.IsGodotObject() ? ifTrue(variant) : default;
}