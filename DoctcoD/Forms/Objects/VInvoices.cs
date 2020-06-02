﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DoctcoD.Forms.Objects
{
    public class VInvoices
    {
        public int invoices_id { get; set; }
        public string number { get; set; }
        public DateTime date { get; set; }
        public string patient { get; set; }
        public bool ispaid { get; set; }
    }
}
