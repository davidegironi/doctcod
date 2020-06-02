#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DoctcoD.Model.Entity;
using NUnit.Framework;
using System;
using System.Linq;

namespace DG.DoctcoD.Model.Test
{
    [TestFixture]
    public partial class DoctcoDModelTest
    {
        [Test]
        public void PatientsAddresses_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            addressestypes t_addressestypes = null;
            patientsaddresses t_patientsaddresses = null;

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.AddressesTypes.Remove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());

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

            t_addressestypes = new addressestypes()
            {
                addressestypes_name = "XX1"
            };
            _doctcodModel.AddressesTypes.Add(t_addressestypes);

            t_patientsaddresses = new patientsaddresses()
            {
                //patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_doctcodModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                //addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_doctcodModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                //patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_doctcodModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                //patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_doctcodModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                //patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_doctcodModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                //patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_doctcodModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsTrue(_doctcodModel.PatientsAddresses.CanAdd(t_patientsaddresses));
            _doctcodModel.PatientsAddresses.Add(t_patientsaddresses);

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.AddressesTypes.Remove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());
        }
    }
}
