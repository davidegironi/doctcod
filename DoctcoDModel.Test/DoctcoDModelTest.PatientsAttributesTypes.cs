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
        public void PatientsAttributesTypes_Test1()
        {
            string[] errors = new string[] { };
            patientsattributestypes t_patientsattributestypes = null;

            _doctcodModel.PatientsAttributesTypes.Remove(_doctcodModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray());
            _doctcodModel.PatientsAttributesTypes.Remove(_doctcodModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX2").ToArray());

            t_patientsattributestypes = new patientsattributestypes()
            {
                //patientsattributestypes_name = "XX1"
            };
            Assert.IsFalse(_doctcodModel.PatientsAttributesTypes.CanAdd(t_patientsattributestypes));

            t_patientsattributestypes = new patientsattributestypes()
            {
                patientsattributestypes_name = "XX1"
            };
            Assert.IsTrue(_doctcodModel.PatientsAttributesTypes.CanAdd(t_patientsattributestypes));
            _doctcodModel.PatientsAttributesTypes.Add(t_patientsattributestypes);

            t_patientsattributestypes = new patientsattributestypes()
            {
                patientsattributestypes_name = "XX1"
            };
            Assert.IsFalse(_doctcodModel.PatientsAttributesTypes.CanAdd(t_patientsattributestypes));

            t_patientsattributestypes = new patientsattributestypes()
            {
                patientsattributestypes_name = "XX2"
            };
            _doctcodModel.PatientsAttributesTypes.Add(t_patientsattributestypes);

            t_patientsattributestypes = _doctcodModel.PatientsAttributesTypes.FirstOrDefault(r => r.patientsattributestypes_name == "XX1");
            t_patientsattributestypes.patientsattributestypes_name = "XX2";
            Assert.IsFalse(_doctcodModel.PatientsAttributesTypes.CanUpdate(t_patientsattributestypes));
            t_patientsattributestypes.patientsattributestypes_name = "XX3";
            Assert.IsTrue(_doctcodModel.PatientsAttributesTypes.CanUpdate(t_patientsattributestypes));

            _doctcodModel.PatientsAttributesTypes.Remove(_doctcodModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray());
            _doctcodModel.PatientsAttributesTypes.Remove(_doctcodModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX2").ToArray());
        }
        
        [Test]
        public void PatientsAttributesTypes_Test2()
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
                patients_id = t_patients.patients_id,
                patientsattributestypes_id = t_patientsattributestypes.patientsattributestypes_id,
                patientsattributes_value = "XX"
            };
            _doctcodModel.PatientsAttributes.Add(t_patientsattributes);

            Assert.IsFalse(_doctcodModel.PatientsAttributesTypes.CanRemove(_doctcodModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray()));

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Assert.IsTrue(_doctcodModel.PatientsAttributesTypes.CanRemove(_doctcodModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray()));

            _doctcodModel.PatientsAttributesTypes.Remove(_doctcodModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray());
        }
        
        [Test]
        public void PatientsAttributesTypes_Test3()
        {
            string[] errors = new string[] { };
            patientsattributestypes patientsattributestypesSendAppointmentsReminder = null;

            patientsattributestypesSendAppointmentsReminder = _doctcodModel.PatientsAttributesTypes.FirstOrDefault(r => r.patientsattributestypes_name == PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString());
            if (patientsattributestypesSendAppointmentsReminder == null)
            {
                patientsattributestypesSendAppointmentsReminder = new patientsattributestypes()
                {
                    patientsattributestypes_name = PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString(),
                };
                _doctcodModel.PatientsAttributesTypes.Add(patientsattributestypesSendAppointmentsReminder);
            }

            patientsattributestypesSendAppointmentsReminder.patientsattributestypes_name = "test";
            Assert.IsFalse(_doctcodModel.PatientsAttributesTypes.CanUpdate(patientsattributestypesSendAppointmentsReminder));

            patientsattributestypesSendAppointmentsReminder = _doctcodModel.PatientsAttributesTypes.FirstOrDefault(r => r.patientsattributestypes_name == PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString());
            Assert.IsFalse(_doctcodModel.PatientsAttributesTypes.CanRemove(patientsattributestypesSendAppointmentsReminder));
        }
    }
}
