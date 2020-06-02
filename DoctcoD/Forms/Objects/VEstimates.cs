﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DoctcoD.Forms.Objects
{
    public class VEstimates
    {
        public int estimates_id { get; set; }
        public string number { get; set; }
        public DateTime date { get; set; }
        public string patient { get; set; }
        public bool isinvoiced { get; set; }
    }
}
