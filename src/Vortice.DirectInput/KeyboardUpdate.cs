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

using System;
using System.Runtime.InteropServices;

namespace Vortice.DirectInput
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardUpdate : IStateUpdate
    {
        public int RawOffset
        {
            get;
            set;
        }

        public int Value
        {
            get;
            set;
        }

        public int Timestamp
        {
            get;
            set;
        }

        public int Sequence
        {
            get;
            set;
        }

        public Key Key => ConvertRawKey(RawOffset);
        public bool IsPressed => (Value & 0x80) != 0;
        public bool IsReleased => !IsPressed;

        private static Key ConvertRawKey(int rawKey)
        {
            if (Enum.IsDefined(typeof(Key), rawKey))
            {
                return (Key)rawKey;
            }

            return Key.Unknown;
        }

        public override string ToString()
        {
            return $"Key: {Key}, IsPressed: {IsPressed} Timestamp: {Timestamp} Sequence: {Sequence}";
        }
    }
}
