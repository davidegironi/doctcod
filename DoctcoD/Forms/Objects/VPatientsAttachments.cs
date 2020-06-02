﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DoctcoD.Forms.Objects
{
    public class VPatientsAttachments
    {
        public int patientsattachments_id { get; set; }
        public string attachmentstype { get; set; }
        public DateTime date { get; set; }
        public string attachment { get; set; }
    }
}
