﻿// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

namespace Vortice.Direct2D1.Effects
{
    public sealed class Composite : ID2D1Effect
    {
        public Composite(ID2D1DeviceContext context)
            : base(context.CreateEffect(EffectGuids.Composite))
        {
        }

        public Composite(ID2D1EffectContext context)
            : base(context.CreateEffect(EffectGuids.Composite))
        {
        }

        public CompositeMode Mode
        {
            set => SetValue((int)CompositeProperties.Mode, value);
            get => GetEnumValue<CompositeMode>((int)CompositeProperties.Mode);
        }
    }
}
