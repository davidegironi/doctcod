﻿#region License
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
        public void Appointments_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            doctors t_doctors = null;
            rooms t_rooms = null;
            appointments t_appointments = null;

            t_patients = _doctcodModel.Patients.FirstOrDefault(r => r.patients_name == "XX1" && r.patients_surname == "XX1");
            if (t_patients != null)
                _doctcodModel.Appointments.Remove(_doctcodModel.Appointments.List(r => r.patients_id == t_patients.patients_id).ToArray());
            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());

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

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1236",
                doctors_password = "123456"
            };
            _doctcodModel.Doctors.Add(t_doctors);

            t_rooms = new rooms()
            {
                rooms_name = "XX1"
            };
            _doctcodModel.Rooms.Add(t_rooms);

            t_appointments = new appointments()
            {
                //patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(40),
                appointments_color = "#dddddd"
            };
            Assert.IsFalse(_doctcodModel.Appointments.CanAdd(t_appointments));

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                //doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(40),
                appointments_color = "#dddddd"
            };
            Assert.IsFalse(_doctcodModel.Appointments.CanAdd(t_appointments));

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                //rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(40),
                appointments_color = "#dddddd"
            };
            Assert.IsFalse(_doctcodModel.Appointments.CanAdd(t_appointments));

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                //appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(40),
                appointments_color = "#dddddd"
            };
            Assert.IsFalse(_doctcodModel.Appointments.CanAdd(t_appointments));

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(-40),
                appointments_color = "#dddddd"
            };
            Assert.IsFalse(_doctcodModel.Appointments.CanAdd(t_appointments));

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(40)
            };
            Assert.IsTrue(_doctcodModel.Appointments.CanAdd(t_appointments));

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(-40),
                appointments_color = "blue"
            };
            Assert.IsFalse(_doctcodModel.Appointments.CanAdd(t_appointments));

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(40),
                appointments_color = "#dddddd"
            };
            Assert.IsTrue(_doctcodModel.Appointments.CanAdd(t_appointments));
            _doctcodModel.Appointments.Add(t_appointments);

            t_patients = _doctcodModel.Patients.FirstOrDefault(r => r.patients_name == "XX1" && r.patients_surname == "XX1");
            if (t_patients != null)
                _doctcodModel.Appointments.Remove(_doctcodModel.Appointments.List(r => r.patients_id == t_patients.patients_id).ToArray());
            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());
        }

        [Test]
        public void Appointments_Purge()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            doctors t_doctors = null;
            rooms t_rooms = null;
            appointments t_appointments = null;

            t_patients = _doctcodModel.Patients.FirstOrDefault(r => r.patients_name == "XX1" && r.patients_surname == "XX1");
            if (t_patients != null)
                _doctcodModel.Appointments.Remove(_doctcodModel.Appointments.List(r => r.patients_id == t_patients.patients_id).ToArray());
            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());

            //remove all appointments
            _doctcodModel.Appointments.Remove(_doctcodModel.Appointments.List().ToArray());

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

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1236",
                doctors_password = "123456"
            };
            _doctcodModel.Doctors.Add(t_doctors);

            t_rooms = new rooms()
            {
                rooms_name = "XX1"
            };
            _doctcodModel.Rooms.Add(t_rooms);

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(40),
                appointments_color = "#dddddd"
            };
            _doctcodModel.Appointments.Add(t_appointments);

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now.AddDays(-10),
                appointments_to = DateTime.Now.AddDays(-10).AddMinutes(40),
                appointments_color = "#dddddd"
            };
            _doctcodModel.Appointments.Add(t_appointments);

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now.AddDays(-20),
                appointments_to = DateTime.Now.AddDays(-20).AddMinutes(40),
                appointments_color = "#dddddd"
            };
            _doctcodModel.Appointments.Add(t_appointments);

            int purgedAppointments = 0;

            _doctcodModel.Appointments.Purge(0, ref purgedAppointments);
            Assert.That(purgedAppointments, Is.EqualTo(0));

            _doctcodModel.Appointments.Purge(10, ref purgedAppointments);
            Assert.That(purgedAppointments, Is.EqualTo(0));

            _doctcodModel.Appointments.Purge(-11, ref purgedAppointments);
            Assert.That(purgedAppointments, Is.EqualTo(1));

            _doctcodModel.Appointments.Purge(-10, ref purgedAppointments);
            Assert.That(purgedAppointments, Is.EqualTo(1));

            t_patients = _doctcodModel.Patients.FirstOrDefault(r => r.patients_name == "XX1" && r.patients_surname == "XX1");
            if (t_patients != null)
                _doctcodModel.Appointments.Remove(_doctcodModel.Appointments.List(r => r.patients_id == t_patients.patients_id).ToArray());
            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());
        }
    }
}
