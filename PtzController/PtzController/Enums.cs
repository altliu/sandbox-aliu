using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PtzController
{
    enum Command
    {
        Stop = 0x0,
        Right = 0x02,
        Left = 0x04,
        Up = 0x08,
        Down = 0x10,
        ZoomTele = 0x20,
        ZoomWide = 0x40,
        FocusFar = 0x80,
        FocusNear = 0x0100,
        IrisOpen = 0x0200,
        IrisClose = 0x0400,
        AutoFocus = 0x2B,
        AutoIris = 0x2D,
        AutoGainControl = 0x2F,
        SetPanPosition = 0x4B,
        SetTiltPosition = 0x4D,
        SetZoomPosition = 0x5F,
        QueryPanPosition = 0x51,
        QueryTiltPosition = 0x53,
        QueryZoomPosition = 0x61,
        SetZoomSpeed = 0x25,
        SetFocusSpeed = 0x27,
        SavePreset = 0x03,
        GotoPreset = 0x07
    }

    enum ResponseLength
    {
        Short = 4,
        Extended = 7,
        PartNumber = 18
    }
}
