﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model;
using DG.DoctcoD.Model.Entity;
using System;
using System.Linq;

namespace DG.DoctcoD.Model.Repositories
{
    public class PatientsContactsRepository : GenericDataRepository<patientscontacts, DoctcoDModel>
    {
        public PatientsContactsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Contact can not be empty.";
            public string text002 = "Patient is mandatory.";
            public string text003 = "Contact type is mandatory.";
            public string text004 = "System contact type already inserted.";
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
        public override bool CanAdd(ref string[] errors, params patientscontacts[] items)
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
        public override bool CanUpdate(ref string[] errors, params patientscontacts[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params patientscontacts[] items)
        {
            bool ret = true;

            foreach (patientscontacts item in items)
            {
                if (String.IsNullOrEmpty(item.patientscontacts_value))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Patients.Find(item.patients_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }
                if (BaseModel.ContactsTypes.Find(item.contactstypes_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }

                if (!ret)
                    break;

                //check one system type per patient
                contactstypes contactstype = BaseModel.ContactsTypes.Find(item.contactstypes_id);
                if (contactstype != null)
                {
                    if (Enum.GetNames(typeof(ContactsTypesRepository.SystemAttributes)).ToArray().Contains(contactstype.contactstypes_name))
                    {
                        if (!isUpdate)
                        {
                            if (Any(r => r.patients_id == item.patients_id && r.contactstypes_id == item.contactstypes_id))
                            {
                                ret = false;
                                errors = errors.Concat(new string[] { language.text004 }).ToArray();
                            }
                        }
                        else
                        {
                            if (Any(r => r.contactstypes_id != item.contactstypes_id && r.patients_id == item.patients_id && r.contactstypes_id == item.contactstypes_id))
                            {
                                ret = false;
                                errors = errors.Concat(new string[] { language.text004 }).ToArray();
                            }
                        }
                    }
                }

                if (!ret)
                    break;
            }

            return ret;
        }
    }

}

