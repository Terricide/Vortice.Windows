﻿// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;

namespace Vortice.Direct3D12
{
    public partial class ID3D12Object
    {
        /// <summary>
        /// Gets or sets a name with the device object. 
        /// </summary>
        /// <remarks>
        /// This name is for use in debug diagnostics and tools.
        /// </remarks>
        public string Name
        {
            get
            {
                unsafe
                {
                    byte* pname = stackalloc byte[1024];
                    int size = 1024 - 1;
                    if (GetPrivateData(CommonGuid.DebugObjectNameW, ref size, pname).Failure)
                    {
                        return string.Empty;
                    }

                    pname[size] = 0;
                    return Marshal.PtrToStringUni(new IntPtr(pname));
                }
            }
            set
            {
                SetName(value);
            }
        }
    }
}
