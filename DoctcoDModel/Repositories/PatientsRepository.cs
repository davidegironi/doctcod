﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model;
using DG.DoctcoD.Model.Entity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DG.DoctcoD.Model.Repositories
{
    public class PatientsRepository : GenericDataRepository<patients, DoctcoDModel>
    {
        public PatientsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Name can not be empty.";
            public string text002 = "Surname can not be empty.";
            public string text003 = "Birth city can not be empty.";
            public string text004 = "Invoices text can not be empty.";
            public string text005 = "Invalid sex. Can be 'M' or 'F'.";
            public string text006 = "Invalid treatment price list.";
            public string text007 = "Patient already inserted.";
            public string text008 = "Username can not be empty.";
            public string text009 = "Password can not be empty.";
            public string text010 = "Invalid username format. 8 character, lower letters [a-z] or numbers [0-9].";
            public string text011 = "Invalid password format. 6 numbers [0-9].";
            public string text012 = "A doctor already exists with this username.";
        }

        /// <summary>
        /// Repository language
        /// </summary>
        public RepositoryLanguage language = new RepositoryLanguage();

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params patients[] items)
        {
            errors = new string[] { };

            bool ret = Validate(false, ref errors, items);
            if (!ret)
                return ret;

            ret = base.CanAdd(ref errors, items);

            return ret;
        }

        /// <summary>
        /// Check if an item can be updated
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanUpdate(ref string[] errors, params patients[] items)
        {
            errors = new string[] { };

            bool ret = Validate(true, ref errors, items);
            if (!ret)
                return ret;

            ret = base.CanUpdate(ref errors, items);

            return ret;
        }

        /// <summary>
        /// Validate an item
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool Validate(bool isUpdate, ref string[] errors, params patients[] items)
        {
            bool ret = true;

            foreach (patients item in items)
            {
                if (String.IsNullOrEmpty(item.patients_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patients_surname))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patients_birthcity))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patients_doctext))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text004 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patients_username))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text008 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patients_password))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text009 }).ToArray();
                }

                if (!ret)
                    break;

                if (item.patients_sex != "M" && item.patients_sex != "F")
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text005 }).ToArray();
                }

                if (!Regex.Match(item.patients_username, @"^[a-z0-9]{8}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text010 }).ToArray();
                }

                if (!Regex.Match(item.patients_password, @"^[0-9]{6}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text011 }).ToArray();
                }

                if (!ret)
                    break;

                if (item.treatmentspriceslists_id != null && BaseModel.TreatmentsPricesLists.Find(item.treatmentspriceslists_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text006 }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (Any(r => r.patients_username == item.patients_username))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text007 }).ToArray();
                    }
                }
                else
                {
                    if (Any(r => r.patients_id != item.patients_id && r.patients_username == item.patients_username))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text007 }).ToArray();
                    }
                }

                if (BaseModel.Doctors.Any(r => r.doctors_username == item.patients_username))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text012 }).ToArray();
                }

                if (!ret)
                    break;
            }

            return ret;
        }

        /// <summary>
        /// Check if an item can be removed
        /// </summary>
        /// <param name="checkForeingKeys"></param>
        /// <param name="excludedForeingKeys"></param>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params patients[] items)
        {
            bool ret = true;

            errors = new string[] { };

            if (excludedForeingKeys == null)
                excludedForeingKeys = new string[] { };
            if (!excludedForeingKeys.Contains("FK_appointments_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_appointments_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_patientsattributes_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_patientsattributes_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_estimates_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_estimates_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_invoices_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_invoices_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_patientsaddresses_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_patientsaddresses_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_patientsattachments_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_patientsattachments_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_patientscontacts_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_patientscontacts_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_patientsmedicalrecords_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_patientsmedicalrecords_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_patientsnotes_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_patientsnotes_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_patientstreatments_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_patientstreatments_patients" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_payments_patients"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_payments_patients" }).ToArray();

            ret = base.CanRemove(checkForeingKeys, excludedForeingKeys, ref errors, items);

            return ret;
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="items"></param>
        public override void Remove(params patients[] items)
        {
            //remove or unset all related items
            foreach (patients item in items)
            {
                BaseModel.PatientsAddresses.Remove(BaseModel.PatientsAddresses.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsAttachments.Remove(BaseModel.PatientsAttachments.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsAttributes.Remove(BaseModel.PatientsAttributes.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsContacts.Remove(BaseModel.PatientsContacts.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsMedicalrecords.Remove(BaseModel.PatientsMedicalrecords.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsNotes.Remove(BaseModel.PatientsNotes.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsTreatments.Remove(BaseModel.PatientsTreatments.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.Payments.Remove(BaseModel.Payments.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.Appointments.Remove(BaseModel.Appointments.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.Estimates.Remove(BaseModel.Estimates.List(r => r.patients_id == item.patients_id).ToArray());
                foreach (invoices invoice in BaseModel.Invoices.List(r => r.patients_id == item.patients_id))
                {
                    invoice.patients_id = null;
                    BaseModel.Invoices.Update(invoice);
                }
            }

            base.Remove(items);
        }
    }

}

