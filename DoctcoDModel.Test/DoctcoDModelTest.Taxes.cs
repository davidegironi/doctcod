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
        public void Taxes_Test1()
        {
            string[] errors = new string[] { };
            taxes t_taxes = null;

            _doctcodModel.Taxes.Remove(_doctcodModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());
            _doctcodModel.Taxes.Remove(_doctcodModel.Taxes.List(r => r.taxes_name == "XX2").ToArray());

            t_taxes = new taxes()
            {
                //taxes_name = "XX1",
                taxes_rate = 20
            };
            Assert.IsFalse(_doctcodModel.Taxes.CanAdd(t_taxes));

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = -20
            };
            Assert.IsFalse(_doctcodModel.Taxes.CanAdd(t_taxes));

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = 20
            };
            Assert.IsTrue(_doctcodModel.Taxes.CanAdd(t_taxes));
            _doctcodModel.Taxes.Add(t_taxes);

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = 20
            };
            Assert.IsFalse(_doctcodModel.Taxes.CanAdd(t_taxes));

            t_taxes = new taxes()
            {
                taxes_name = "XX2",
                taxes_rate = 20
            };
            _doctcodModel.Taxes.Add(t_taxes);

            t_taxes = _doctcodModel.Taxes.FirstOrDefault(r => r.taxes_name == "XX1");
            t_taxes.taxes_name = "XX2";
            Assert.IsFalse(_doctcodModel.Taxes.CanUpdate(t_taxes));
            t_taxes.taxes_name = "XX3";
            Assert.IsTrue(_doctcodModel.Taxes.CanUpdate(t_taxes));

            _doctcodModel.Taxes.Remove(_doctcodModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());
            _doctcodModel.Taxes.Remove(_doctcodModel.Taxes.List(r => r.taxes_name == "XX2").ToArray());
        }
    }
}
