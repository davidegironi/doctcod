﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DoctcoD.Forms.Objects
{
    public class VPatientsTreatments
    {
        public int patientstreatments_id { get; set; }
        public DateTime date { get; set; }
        public string treatment { get; set; }
        public bool isfulfilled { get; set; }
        public bool ispaid { get; set; }
    }
}
