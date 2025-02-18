namespace BunnyTail.ObjectProjection.Generator.Models;

using Microsoft.CodeAnalysis;

internal sealed record MethodModel(
    string Namespace,
    string ClassName,
    bool IsValueType,
    Accessibility MethodAccessibility,
    string MethodName);
