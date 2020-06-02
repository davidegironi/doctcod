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
        public void ComputedLines_Test1()
        {
            string[] errors = new string[] { };
            taxes t_taxes = null;
            computedlines t_computedlines = null;

            _doctcodModel.ComputedLines.Remove(_doctcodModel.ComputedLines.List(r => r.computedlines_code == "XX1").ToArray());
            _doctcodModel.ComputedLines.Remove(_doctcodModel.ComputedLines.List(r => r.computedlines_code == "XX2").ToArray());
            _doctcodModel.Taxes.Remove(_doctcodModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = 20
            };
            _doctcodModel.Taxes.Add(t_taxes);

            t_computedlines = new computedlines()
            {
                //computedlines_code = "XX1",
                computedlines_name = "XX1",
                taxes_id = t_taxes.taxes_id,
                computedlines_rate = 20
            };
            Assert.IsFalse(_doctcodModel.ComputedLines.CanAdd(t_computedlines));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                //computedlines_name = "XX1",
                taxes_id = t_taxes.taxes_id,
                computedlines_rate = 20
            };
            Assert.IsFalse(_doctcodModel.ComputedLines.CanAdd(t_computedlines));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                computedlines_name = "XX1",
                //taxes_id = t_taxes.taxes_id,
                computedlines_rate = 20
            };
            Assert.IsTrue(_doctcodModel.ComputedLines.CanAdd(t_computedlines));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                computedlines_name = "XX1",
                taxes_id = -999,
                computedlines_rate = 20
            };
            Assert.IsFalse(_doctcodModel.ComputedLines.CanAdd(t_computedlines));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                computedlines_name = "XX1",
                taxes_id = t_taxes.taxes_id,
                computedlines_rate = 20
            };
            Assert.IsTrue(_doctcodModel.ComputedLines.CanAdd(t_computedlines));
            _doctcodModel.ComputedLines.Add(t_computedlines);

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                computedlines_name = "XX1",
                computedlines_rate = 20
            };
            Assert.IsFalse(_doctcodModel.ComputedLines.CanAdd(t_computedlines));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX2",
                computedlines_name = "XX2",
                computedlines_rate = 20
            };
            _doctcodModel.ComputedLines.Add(t_computedlines);

            t_computedlines = _doctcodModel.ComputedLines.FirstOrDefault(r => r.computedlines_code == "XX1");
            t_computedlines.computedlines_code = "XX2";
            Assert.IsFalse(_doctcodModel.ComputedLines.CanUpdate(t_computedlines));
            t_computedlines.computedlines_code = "XX3";
            Assert.IsTrue(_doctcodModel.ComputedLines.CanUpdate(t_computedlines));

            _doctcodModel.ComputedLines.Remove(_doctcodModel.ComputedLines.List(r => r.computedlines_code == "XX1").ToArray());
            _doctcodModel.ComputedLines.Remove(_doctcodModel.ComputedLines.List(r => r.computedlines_code == "XX2").ToArray());
            _doctcodModel.Taxes.Remove(_doctcodModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());
        }
    }
}
