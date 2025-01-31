// Copyright � Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.WIC;

public unsafe partial class IWICBitmap
{
    public IWICBitmapLock Lock(BitmapLockFlags flags) => Lock(null, flags);

    public IWICBitmapLock Lock(RectI lockRectangle, BitmapLockFlags flags = BitmapLockFlags.None)
    {
        return Lock(&lockRectangle, flags);
    }
}
