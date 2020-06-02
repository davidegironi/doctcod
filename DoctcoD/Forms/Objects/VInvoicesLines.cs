﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

namespace DG.DoctcoD.Forms.Objects
{
    public class VInvoicesLines
    {
        public int invoiceslines_id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public double unitprice { get; set; }
        public double taxrate { get; set; }
        public double totalprice { get; set; }
    }
}
