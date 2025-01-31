﻿// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;

namespace Vortice.DirectInput
{
    public partial class ObjectDataFormat
    {
        public ObjectDataFormat()
        {
        }

        public ObjectDataFormat(Guid guid, int offset, DeviceObjectTypeFlags typeFlags, ObjectDataFormatFlags flags)
            : this(guid, offset, typeFlags, flags, 0)
        {
        }

        public ObjectDataFormat(Guid guid, int offset, DeviceObjectTypeFlags typeFlags, ObjectDataFormatFlags flags, int instanceNumber)
        {
            Guid = guid;
            Offset = offset;
            TypeFlags = typeFlags;
            InstanceNumber = instanceNumber;
            Flags = flags;
        }

        /// <summary>
        /// Name of this DataObjectFormat. Default is using field name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets Guid for the axis, button, or other input source. When requesting a data format, making this member empty indicates that any type of object is permissible. 
        /// </summary>
        /// <value>The GUID.</value>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the field offset. This is used internally.
        /// </summary>
        /// <value>The offset.</value>
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the device type that describes the object. 
        /// </summary>
        /// <value>The type.</value>
        public DeviceObjectTypeFlags TypeFlags { get; set; }

        /// <summary>
        /// Gets or sets the instance number. Setting -1 is applied to any object instance.
        /// </summary>
        /// <value>The instance number.</value>
        public int InstanceNumber { get; set; }

        /// <summary>
        /// Gets or sets the extra flags used to describe the data format.
        /// </summary>
        /// <value>The flags.</value>
        public ObjectDataFormatFlags Flags { get; set; }

        #region Marshal
        // Internal native struct used for marshalling
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        internal partial struct __Native
        {
            public IntPtr GuidPointer;
            public int Offset;
            public int Type;
            public ObjectDataFormatFlags Flags;

            internal unsafe void __MarshalFree()
            {
                //if (GuidPointer != IntPtr.Zero)
                //{
                //    var handle = GCHandle.FromIntPtr(GuidPointer);
                //    handle.Free();
                //}
            }
        }

        internal unsafe void __MarshalFree(ref __Native @ref)
        {
            @ref.__MarshalFree();
        }

        internal unsafe void __MarshalTo(ref __Native @ref)
        {
            @ref.Offset = Offset;
            @ref.Type = ((int)TypeFlags) | (((TypeFlags & DeviceObjectTypeFlags.AnyInstance) == DeviceObjectTypeFlags.AnyInstance ? 0 : InstanceNumber) << 8);
            @ref.Flags = Flags;

            if (Guid == Guid.Empty)
                @ref.GuidPointer = IntPtr.Zero;
            else
            {
                var handle = GCHandle.Alloc(Guid, GCHandleType.Pinned);
                @ref.GuidPointer = handle.AddrOfPinnedObject();
            }
        }
        #endregion Marshal
    }
}
