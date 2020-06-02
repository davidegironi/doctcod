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
        public void TreatmentsPrices_Test1()
        {
            string[] errors = new string[] { };
            treatmentsprices t_treatmentsprices = null;
            treatments t_treatments1 = null;
            treatments t_treatments2 = null;
            treatmentstypes t_treatmentstypes = null;
            treatmentspriceslists t_treatmentspriceslists = null;

            _doctcodModel.Treatments.Remove(_doctcodModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _doctcodModel.Treatments.Remove(_doctcodModel.Treatments.List(r => r.treatments_code == "XX2").ToArray());
            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _doctcodModel.TreatmentsPricesLists.Remove(_doctcodModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());

            t_treatmentspriceslists = new treatmentspriceslists()
            {
                treatmentspriceslists_name = "XX1"
            };
            _doctcodModel.TreatmentsPricesLists.Add(t_treatmentspriceslists);

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            _doctcodModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatments1 = new treatments()
            {
                treatmentstypes_id = t_treatmentstypes.treatmentstypes_id,
                treatments_code = "XX1",
                treatments_name = "XX1",
                treatments_price = 10
            };
            _doctcodModel.Treatments.Add(t_treatments1);

            t_treatments2 = new treatments()
            {
                treatmentstypes_id = t_treatmentstypes.treatmentstypes_id,
                treatments_code = "XX2",
                treatments_name = "XX2",
                treatments_price = 10
            };
            _doctcodModel.Treatments.Add(t_treatments2);

            t_treatmentsprices = new treatmentsprices()
            {
                //treatments_id = t_treatments1.treatments_id,
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 10
            };
            Assert.IsFalse(_doctcodModel.TreatmentsPrices.CanAdd(t_treatmentsprices));

            t_treatmentsprices = new treatmentsprices()
            {
                treatments_id = t_treatments1.treatments_id,
                //treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 10
            };
            Assert.IsFalse(_doctcodModel.TreatmentsPrices.CanAdd(t_treatmentsprices));

            t_treatmentsprices = new treatmentsprices()
            {
                treatments_id = t_treatments1.treatments_id,
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 10
            };
            Assert.IsTrue(_doctcodModel.TreatmentsPrices.CanAdd(t_treatmentsprices));
            _doctcodModel.TreatmentsPrices.Add(t_treatmentsprices);

            t_treatmentsprices = new treatmentsprices()
            {
                treatments_id = t_treatments1.treatments_id,
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 10
            };
            Assert.IsFalse(_doctcodModel.TreatmentsPrices.CanAdd(t_treatmentsprices));

            t_treatmentsprices = new treatmentsprices()
            {
                treatments_id = t_treatments2.treatments_id,
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 20
            };
            Assert.IsTrue(_doctcodModel.TreatmentsPrices.CanAdd(t_treatmentsprices));
            _doctcodModel.TreatmentsPrices.Add(t_treatmentsprices);

            _doctcodModel.Treatments.Remove(_doctcodModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _doctcodModel.Treatments.Remove(_doctcodModel.Treatments.List(r => r.treatments_code == "XX2").ToArray());
            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _doctcodModel.TreatmentsPricesLists.Remove(_doctcodModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());
        }
    }
}
