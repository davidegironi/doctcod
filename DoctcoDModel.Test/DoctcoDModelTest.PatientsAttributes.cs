#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DoctcoD.Model.Entity;
using DG.DoctcoD.Model.Repositories;
using NUnit.Framework;
using System;
using System.Linq;

namespace DG.DoctcoD.Model.Test
{
    [TestFixture]
    public partial class DoctcoDModelTest
    {
        [Test]
        public void PatientsAttributes_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            patientsattributestypes t_patientsattributestypes = null;
            patientsattributes t_patientsattributes = null;

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.PatientsAttributesTypes.Remove(_doctcodModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray());

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            _doctcodModel.Patients.Add(t_patients);

            t_patientsattributestypes = new patientsattributestypes()
            {
                patientsattributestypes_name = "XX1"
            };
            _doctcodModel.PatientsAttributesTypes.Add(t_patientsattributestypes);

            t_patientsattributes = new patientsattributes()
            {
                //patients_id = t_patients.patients_id,
                patientsattributestypes_id = t_patientsattributestypes.patientsattributestypes_id,
                patientsattributes_value = "XX"
            };
            Assert.IsFalse(_doctcodModel.PatientsAttributes.CanAdd(t_patientsattributes));

            t_patientsattributes = new patientsattributes()
            {
                patients_id = t_patients.patients_id,
                //patientsattributestypes_id = t_patientsattributestypes.patientsattributestypes_id,
                patientsattributes_value = "XX"
            };
            Assert.IsFalse(_doctcodModel.PatientsAttributes.CanAdd(t_patientsattributes));

            t_patientsattributes = new patientsattributes()
            {
                patients_id = t_patients.patients_id,
                patientsattributestypes_id = t_patientsattributestypes.patientsattributestypes_id,
                //patientsattributes_value = "XX"
            };
            Assert.IsTrue(_doctcodModel.PatientsAttributes.CanAdd(t_patientsattributes));

            t_patientsattributes = new patientsattributes()
            {
                patients_id = t_patients.patients_id,
                patientsattributestypes_id = t_patientsattributestypes.patientsattributestypes_id,
                patientsattributes_value = "XX"
            };
            Assert.IsTrue(_doctcodModel.PatientsAttributes.CanAdd(t_patientsattributes));
            _doctcodModel.PatientsAttributes.Add(t_patientsattributes);

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.PatientsAttributesTypes.Remove(_doctcodModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray());
        }

        [Test]
        public void PatientsAttributes_TestSystemAttribute()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            patientsattributestypes patientsattributestypesSendAppointmentsReminder = null;
            patientsattributes t_patientsattributes = null;

            patientsattributestypesSendAppointmentsReminder = _doctcodModel.PatientsAttributesTypes.FirstOrDefault(r => r.patientsattributestypes_name == PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString());
            if (patientsattributestypesSendAppointmentsReminder == null)
            {
                patientsattributestypesSendAppointmentsReminder = new patientsattributestypes()
                {
                    patientsattributestypes_name = PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString(),
                };
                _doctcodModel.PatientsAttributesTypes.Add(patientsattributestypesSendAppointmentsReminder);
            }

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            _doctcodModel.Patients.Add(t_patients);

            t_patientsattributes = new patientsattributes()
            {
                patients_id = t_patients.patients_id,
                patientsattributestypes_id = patientsattributestypesSendAppointmentsReminder.patientsattributestypes_id,
                patientsattributes_value = "XX"
            };
            Assert.IsTrue(_doctcodModel.PatientsAttributes.CanAdd(t_patientsattributes));
            _doctcodModel.PatientsAttributes.Add(t_patientsattributes);

            t_patientsattributes = new patientsattributes()
            {
                patients_id = t_patients.patients_id,
                patientsattributestypes_id = patientsattributestypesSendAppointmentsReminder.patientsattributestypes_id,
                patientsattributes_value = "XX2"
            };
            Assert.IsFalse(_doctcodModel.PatientsAttributes.CanAdd(t_patientsattributes));

            t_patientsattributes = _doctcodModel.PatientsAttributes.FirstOrDefault(r => r.patients_id == t_patients.patients_id && r.patientsattributestypes_id == patientsattributestypesSendAppointmentsReminder.patientsattributestypes_id);
            t_patientsattributes.patientsattributes_value = "XX3";
            Assert.IsTrue(_doctcodModel.PatientsAttributes.CanUpdate(t_patientsattributes));
            _doctcodModel.PatientsAttributes.Update(t_patientsattributes);

            t_patientsattributes = new patientsattributes()
            {
                patients_id = t_patients.patients_id,
                patientsattributestypes_id = patientsattributestypesSendAppointmentsReminder.patientsattributestypes_id,
                patientsattributes_value = "XX2"
            };
            Assert.IsFalse(_doctcodModel.PatientsAttributes.CanAdd(t_patientsattributes));

            t_patientsattributes = _doctcodModel.PatientsAttributes.FirstOrDefault(r => r.patients_id == t_patients.patients_id && r.patientsattributestypes_id == patientsattributestypesSendAppointmentsReminder.patientsattributestypes_id);
            _doctcodModel.PatientsAttributes.Remove(t_patientsattributes);

            t_patientsattributes = new patientsattributes()
            {
                patients_id = t_patients.patients_id,
                patientsattributestypes_id = patientsattributestypesSendAppointmentsReminder.patientsattributestypes_id,
                patientsattributes_value = "XX2"
            };
            Assert.IsTrue(_doctcodModel.PatientsAttributes.CanAdd(t_patientsattributes));

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
        }
    }
}
