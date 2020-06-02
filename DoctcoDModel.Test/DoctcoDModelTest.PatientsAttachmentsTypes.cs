﻿#region License
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
        public void PatientsAttachmentsTypes_Test1()
        {
            string[] errors = new string[] { };
            patientsattachmentstypes t_patientsattachmentstypes = null;

            _doctcodModel.PatientsAttachmentsTypes.Remove(_doctcodModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());
            _doctcodModel.PatientsAttachmentsTypes.Remove(_doctcodModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX2").ToArray());

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                //patientsattachmentstypes_name = "XX1",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            Assert.IsFalse(_doctcodModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1",
                //patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            Assert.IsFalse(_doctcodModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            Assert.IsTrue(_doctcodModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));
            _doctcodModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            Assert.IsFalse(_doctcodModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX2",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            _doctcodModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachmentstypes = _doctcodModel.PatientsAttachmentsTypes.FirstOrDefault(r => r.patientsattachmentstypes_name == "XX1");
            t_patientsattachmentstypes.patientsattachmentstypes_name = "XX2";
            Assert.IsFalse(_doctcodModel.PatientsAttachmentsTypes.CanUpdate(t_patientsattachmentstypes));
            t_patientsattachmentstypes.patientsattachmentstypes_name = "XX3";
            Assert.IsTrue(_doctcodModel.PatientsAttachmentsTypes.CanUpdate(t_patientsattachmentstypes));

            _doctcodModel.PatientsAttachmentsTypes.Remove(_doctcodModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());
            _doctcodModel.PatientsAttachmentsTypes.Remove(_doctcodModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX2").ToArray());
        }

        [Test]
        public void PatientsAttachmentsTypes_Test2()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            patientsattachmentstypes t_patientsattachmentstypes = null;
            patientsattachments t_patientsattachments = null;

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.PatientsAttachmentsTypes.Remove(_doctcodModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());

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

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            _doctcodModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachments = new patientsattachments()
            {
                patients_id = t_patients.patients_id,
                patientsattachmentstypes_id = t_patientsattachmentstypes.patientsattachmentstypes_id,
                patientsattachments_value = "XX",
                patientsattachments_date = DateTime.Now
            };
            _doctcodModel.PatientsAttachments.Add(t_patientsattachments);

            Assert.IsFalse(_doctcodModel.PatientsAttachmentsTypes.CanRemove(_doctcodModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray()));

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Assert.IsTrue(_doctcodModel.PatientsAttachmentsTypes.CanRemove(_doctcodModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray()));

            _doctcodModel.PatientsAttachmentsTypes.Remove(_doctcodModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());
        }
    }
}
