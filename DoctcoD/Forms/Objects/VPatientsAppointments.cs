#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DoctcoD.Forms.Objects
{
    public class VPatientsAppointments
    {
        public int appointments_id { get; set; }
        public DateTime fromday { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string title { get; set; }
    }
}
