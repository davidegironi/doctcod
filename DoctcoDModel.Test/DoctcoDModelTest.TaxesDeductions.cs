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
        public void TaxesDeductions_Test1()
        {
            string[] errors = new string[] { };
            taxesdeductions t_taxesdeductions = null;

            _doctcodModel.TaxesDeductions.Remove(_doctcodModel.TaxesDeductions.List(r => r.taxesdeductions_name == "XX1").ToArray());
            _doctcodModel.TaxesDeductions.Remove(_doctcodModel.TaxesDeductions.List(r => r.taxesdeductions_name == "XX2").ToArray());

            t_taxesdeductions = new taxesdeductions()
            {
                //taxesdeductions_name = "XX1",
                taxesdeductions_rate = 20
            };
            Assert.IsFalse(_doctcodModel.TaxesDeductions.CanAdd(t_taxesdeductions));

            t_taxesdeductions = new taxesdeductions()
            {
                taxesdeductions_name = "XX1",
                taxesdeductions_rate = -20
            };
            Assert.IsFalse(_doctcodModel.TaxesDeductions.CanAdd(t_taxesdeductions));

            t_taxesdeductions = new taxesdeductions()
            {
                taxesdeductions_name = "XX1",
                taxesdeductions_rate = 20
            };
            Assert.IsTrue(_doctcodModel.TaxesDeductions.CanAdd(t_taxesdeductions));
            _doctcodModel.TaxesDeductions.Add(t_taxesdeductions);

            t_taxesdeductions = new taxesdeductions()
            {
                taxesdeductions_name = "XX1",
                taxesdeductions_rate = 20
            };
            Assert.IsFalse(_doctcodModel.TaxesDeductions.CanAdd(t_taxesdeductions));

            t_taxesdeductions = new taxesdeductions()
            {
                taxesdeductions_name = "XX2",
                taxesdeductions_rate = 20
            };
            _doctcodModel.TaxesDeductions.Add(t_taxesdeductions);

            t_taxesdeductions = _doctcodModel.TaxesDeductions.FirstOrDefault(r => r.taxesdeductions_name == "XX1");
            t_taxesdeductions.taxesdeductions_name = "XX2";
            Assert.IsFalse(_doctcodModel.TaxesDeductions.CanUpdate(t_taxesdeductions));
            t_taxesdeductions.taxesdeductions_name = "XX3";
            Assert.IsTrue(_doctcodModel.TaxesDeductions.CanUpdate(t_taxesdeductions));

            _doctcodModel.TaxesDeductions.Remove(_doctcodModel.TaxesDeductions.List(r => r.taxesdeductions_name == "XX1").ToArray());
            _doctcodModel.TaxesDeductions.Remove(_doctcodModel.TaxesDeductions.List(r => r.taxesdeductions_name == "XX2").ToArray());
        }
    }
}
