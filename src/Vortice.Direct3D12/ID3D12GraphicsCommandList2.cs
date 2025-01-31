﻿// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.Direct3D12;

public partial class ID3D12GraphicsCommandList2
{
    public void WriteBufferImmediate(int count, WriteBufferImmediateParameter[] @params, WriteBufferImmediateMode[] modes)
    {
        WriteBufferImmediate_(count, @params, modes);
    }

    public void WriteBufferImmediate(WriteBufferImmediateParameter[] @params, WriteBufferImmediateMode[] modes)
    {
        if (@params.Length != modes.Length)
        {
            throw new InvalidOperationException($"params and modes need to have same length");
        }

        WriteBufferImmediate_(@params.Length, @params, modes);
    }
}
