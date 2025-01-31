﻿// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using Vortice.Mathematics;
using Vortice.DCommon;

namespace Vortice.DirectWrite;

public partial class IDWriteFactory4
{
    public Result TranslateColorGlyphRun(
        in Point baselineOrigin,
        GlyphRun glyphRun,
        GlyphImageFormats desiredGlyphImageFormats,
        MeasuringMode measuringMode,
        out IDWriteColorGlyphRunEnumerator1 colorLayers)
    {
        return TranslateColorGlyphRun(baselineOrigin, glyphRun, null, desiredGlyphImageFormats, measuringMode, null, 0, out colorLayers);
    }

    public IDWriteColorGlyphRunEnumerator1 TranslateColorGlyphRun(
        in Point baselineOrigin,
        GlyphRun glyphRun,
        GlyphImageFormats desiredGlyphImageFormats,
        MeasuringMode measuringMode = MeasuringMode.Natural)
    {
        TranslateColorGlyphRun(baselineOrigin, glyphRun, null,
            desiredGlyphImageFormats,
            measuringMode, null, 0, out IDWriteColorGlyphRunEnumerator1 colorLayers).CheckError();
        return colorLayers;
    }
}
