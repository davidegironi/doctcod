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
        public void ContactsTypes_Test1()
        {
            string[] errors = new string[] { };
            contactstypes t_contactstypes = null;

            _doctcodModel.ContactsTypes.Remove(_doctcodModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());
            _doctcodModel.ContactsTypes.Remove(_doctcodModel.ContactsTypes.List(r => r.contactstypes_name == "XX2").ToArray());

            t_contactstypes = new contactstypes()
            {
                //contactstypes_name = "XX1"
            };
            Assert.IsFalse(_doctcodModel.ContactsTypes.CanAdd(t_contactstypes));

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX1"
            };
            Assert.IsTrue(_doctcodModel.ContactsTypes.CanAdd(t_contactstypes));
            _doctcodModel.ContactsTypes.Add(t_contactstypes);

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX1"
            };
            Assert.IsFalse(_doctcodModel.ContactsTypes.CanAdd(t_contactstypes));

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX2"
            };
            _doctcodModel.ContactsTypes.Add(t_contactstypes);

            t_contactstypes = _doctcodModel.ContactsTypes.FirstOrDefault(r => r.contactstypes_name == "XX1");
            t_contactstypes.contactstypes_name = "XX2";
            Assert.IsFalse(_doctcodModel.ContactsTypes.CanUpdate(t_contactstypes));
            t_contactstypes.contactstypes_name = "XX3";
            Assert.IsTrue(_doctcodModel.ContactsTypes.CanUpdate(t_contactstypes));

            _doctcodModel.ContactsTypes.Remove(_doctcodModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());
            _doctcodModel.ContactsTypes.Remove(_doctcodModel.ContactsTypes.List(r => r.contactstypes_name == "XX2").ToArray());
        }

        [Test]
        public void ContactsTypes_Test2()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            contactstypes t_contactstypes = null;
            patientscontacts t_patientscontacts = null;

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.ContactsTypes.Remove(_doctcodModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());

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

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX1"
            };
            _doctcodModel.ContactsTypes.Add(t_contactstypes);

            t_patientscontacts = new patientscontacts()
            {
                patients_id = t_patients.patients_id,
                contactstypes_id = t_contactstypes.contactstypes_id,
                patientscontacts_value = "XX"
            };
            _doctcodModel.PatientsContacts.Add(t_patientscontacts);

            Assert.IsFalse(_doctcodModel.ContactsTypes.CanRemove(_doctcodModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray()));

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Assert.IsTrue(_doctcodModel.ContactsTypes.CanRemove(_doctcodModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray()));

            _doctcodModel.ContactsTypes.Remove(_doctcodModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());
        }

        [Test]
        public void ContactsTypes_Test3()
        {
            string[] errors = new string[] { };
            contactstypes contactstypesEMail = null;

            contactstypesEMail = _doctcodModel.ContactsTypes.FirstOrDefault(r => r.contactstypes_name == ContactsTypesRepository.SystemAttributes.EMail.ToString());
            if (contactstypesEMail == null)
            {
                contactstypesEMail = new contactstypes()
                {
                    contactstypes_name = ContactsTypesRepository.SystemAttributes.EMail.ToString(),
                };
                _doctcodModel.ContactsTypes.Add(contactstypesEMail);
            }

            contactstypesEMail.contactstypes_name = "test";
            Assert.IsFalse(_doctcodModel.ContactsTypes.CanUpdate(contactstypesEMail));

            contactstypesEMail = _doctcodModel.ContactsTypes.FirstOrDefault(r => r.contactstypes_name == ContactsTypesRepository.SystemAttributes.EMail.ToString());
            Assert.IsFalse(_doctcodModel.ContactsTypes.CanRemove(contactstypesEMail));
        }
    }
}
