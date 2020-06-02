﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DoctcoD.Forms.Objects
{
    public class VPatientsNotes
    {
        public int patientsnotes_id { get; set; }
        public DateTime date { get; set; }
        public string note { get; set; }
    }
}
