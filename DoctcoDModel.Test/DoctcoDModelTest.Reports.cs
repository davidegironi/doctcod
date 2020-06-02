#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DoctcoD.Model.Entity;
using NUnit.Framework;
using System.Linq;

namespace DG.DoctcoD.Model.Test
{
    [TestFixture]
    public partial class DoctcoDModelTest
    {
        [Test]
        public void Reports_Test1()
        {
            string[] errors = new string[] { };
            reports t_reports = null;

            _doctcodModel.Reports.Remove(_doctcodModel.Reports.List(r => r.reports_name == "XX1").ToArray());
            _doctcodModel.Reports.Remove(_doctcodModel.Reports.List(r => r.reports_name == "XX2").ToArray());

            t_reports = new reports()
            {
                //reports_name = "XX1",
                reports_query = "SELECT * FROM reports"
            };
            Assert.IsFalse(_doctcodModel.Reports.CanAdd(t_reports));
            t_reports = new reports()
            {
                reports_name = "XX1",
                //reports_query = "SELECT * FROM reports"
            };
            Assert.IsFalse(_doctcodModel.Reports.CanAdd(t_reports));

            t_reports = new reports()
            {
                reports_name = "XX1",
                reports_query = "SELECT * FROM reports"
            };
            Assert.IsTrue(_doctcodModel.Reports.CanAdd(t_reports));
            _doctcodModel.Reports.Add(t_reports);

            t_reports = new reports()
            {
                reports_name = "XX1",
                reports_query = "SELECT * FROM reports"
            };
            Assert.IsFalse(_doctcodModel.Reports.CanAdd(t_reports));

            t_reports = new reports()
            {
                reports_name = "XX2",
                reports_query = "SELECT * FROM reports"
            };
            _doctcodModel.Reports.Add(t_reports);

            t_reports = _doctcodModel.Reports.FirstOrDefault(r => r.reports_name == "XX1");
            t_reports.reports_name = "XX2";
            Assert.IsFalse(_doctcodModel.Reports.CanUpdate(t_reports));
            t_reports.reports_name = "XX3";
            Assert.IsTrue(_doctcodModel.Reports.CanUpdate(t_reports));

            _doctcodModel.Reports.Remove(_doctcodModel.Reports.List(r => r.reports_name == "XX1").ToArray());
            _doctcodModel.Reports.Remove(_doctcodModel.Reports.List(r => r.reports_name == "XX2").ToArray());
        }
    }
}
