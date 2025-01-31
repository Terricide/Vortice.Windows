﻿// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;

namespace Vortice.Direct3D12
{
    public partial struct ResourceUnorderedAccessViewBarrier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceUnorderedAccessViewBarrier"/> struct.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <exception cref="System.ArgumentNullException">resourceBefore</exception>
        public ResourceUnorderedAccessViewBarrier(ID3D12Resource? resource)
        {
            ResourcePointer = resource != null ?  resource.NativePointer : IntPtr.Zero;
        }
    }
}
