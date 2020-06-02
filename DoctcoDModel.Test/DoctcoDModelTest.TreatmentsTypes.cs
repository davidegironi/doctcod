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
        public void TreatmentsTypes_Test1()
        {
            string[] errors = new string[] { };
            treatmentstypes t_treatmentstypes = null;

            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX2").ToArray());

            t_treatmentstypes = new treatmentstypes()
            {
                //treatmentstypes_name = "XX1"
            };
            Assert.IsFalse(_doctcodModel.TreatmentsTypes.CanAdd(t_treatmentstypes));

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            Assert.IsTrue(_doctcodModel.TreatmentsTypes.CanAdd(t_treatmentstypes));
            _doctcodModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            Assert.IsFalse(_doctcodModel.TreatmentsTypes.CanAdd(t_treatmentstypes));

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX2"
            };
            _doctcodModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatmentstypes = _doctcodModel.TreatmentsTypes.FirstOrDefault(r => r.treatmentstypes_name == "XX1");
            t_treatmentstypes.treatmentstypes_name = "XX2";
            Assert.IsFalse(_doctcodModel.TreatmentsTypes.CanUpdate(t_treatmentstypes));
            t_treatmentstypes.treatmentstypes_name = "XX3";
            Assert.IsTrue(_doctcodModel.TreatmentsTypes.CanUpdate(t_treatmentstypes));

            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX2").ToArray());
        }

        [Test]
        public void TreatmentsTypes_Test2()
        {
            string[] errors = new string[] { };
            taxes t_taxes = null;
            treatments t_treatments = null;
            treatmentstypes t_treatmentstypes = null;

            _doctcodModel.Treatments.Remove(_doctcodModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _doctcodModel.Taxes.Remove(_doctcodModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = 20
            };
            _doctcodModel.Taxes.Add(t_taxes);

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            _doctcodModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatments = new treatments()
            {
                treatmentstypes_id = t_treatmentstypes.treatmentstypes_id,
                taxes_id = t_taxes.taxes_id,
                treatments_code = "XX1",
                treatments_name = "XX1",
                treatments_price = 10
            };
            _doctcodModel.Treatments.Add(t_treatments);

            Assert.IsFalse(_doctcodModel.TreatmentsTypes.CanRemove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray()));

            _doctcodModel.Treatments.Remove(_doctcodModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());

            Assert.IsTrue(_doctcodModel.TreatmentsTypes.CanRemove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray()));

            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _doctcodModel.Taxes.Remove(_doctcodModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());
        }
    }
}
