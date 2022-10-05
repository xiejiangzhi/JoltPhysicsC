// Copyright � Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using static JoltPhysicsSharp.JoltApi;

namespace JoltPhysicsSharp;

public readonly struct Body : IEquatable<Body>
{
    public Body(IntPtr handle) { Handle = handle; }
    public IntPtr Handle { get; }
    public bool IsNull => Handle == IntPtr.Zero;
    public static Body Null => new(IntPtr.Zero);
    public static implicit operator Body(IntPtr handle) => new(handle);
    public static bool operator ==(Body left, Body right) => left.Handle == right.Handle;
    public static bool operator !=(Body left, Body right) => left.Handle != right.Handle;
    public static bool operator ==(Body left, IntPtr right) => left.Handle == right;
    public static bool operator !=(Body left, IntPtr right) => left.Handle != right;
    public bool Equals(Body other) => Handle == other.Handle;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Body handle && Equals(handle);
    /// <inheritdoc/>
    public override int GetHashCode() => Handle.GetHashCode();

    public readonly BodyID ID => JPH_Body_GetID(Handle);
}
