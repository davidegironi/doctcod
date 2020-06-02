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
    public class PatientsAttributesTypesRepository : GenericDataRepository<patientsattributestypes, DoctcoDModel>
    {
        public PatientsAttributesTypesRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Name can not be empty.";
            public string text002 = "Attribute type already inserted.";
            public string text003 = "This item can not be removed. A attribute depends on it.";
            public string text004 = "This is a system type, therefore code can not be changed.";
            public string text005 = "This is a system type, therefore it can not be removed.";
        }

        /// <summary>
        /// Repository language
        /// </summary>
        public RepositoryLanguage language = new RepositoryLanguage();

        /// <summary>
        /// System attributes
        /// </summary>
        public enum SystemAttributes
        {
            SendAppointmentsReminder
        }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params patientsattributestypes[] items)
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
        public override bool CanUpdate(ref string[] errors, params patientsattributestypes[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params patientsattributestypes[] items)
        {
            bool ret = true;

            foreach (patientsattributestypes item in items)
            {
                if (String.IsNullOrEmpty(item.patientsattributestypes_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (Any(r => r.patientsattributestypes_name == item.patientsattributestypes_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text002 }).ToArray();
                    }
                }
                else
                {
                    if (Any(r => r.patientsattributestypes_id != item.patientsattributestypes_id && r.patientsattributestypes_name == item.patientsattributestypes_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text002 }).ToArray();
                    }

                    patientsattributestypes patientsattributestype = Find(item.patientsattributestypes_id);
                    if (patientsattributestype != null)
                    {
                        if (Enum.GetNames(typeof(SystemAttributes)).ToArray().Contains(patientsattributestype.patientsattributestypes_name) &&
                            patientsattributestype.patientsattributestypes_name != item.patientsattributestypes_name)
                        {
                            ret = false;
                            errors = errors.Concat(new string[] { language.text004 }).ToArray();
                        }
                    }
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
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params patientsattributestypes[] items)
        {
            bool ret = true;

            errors = new string[] { };

            foreach (patientsattributestypes item in items)
            {
                if (Enum.GetNames(typeof(SystemAttributes)).ToArray().Contains(item.patientsattributestypes_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text005 }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.PatientsAttributes.Any(r => r.patientsattributestypes_id == item.patientsattributestypes_id))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }

                if (!ret)
                    break;
            }

            if (!ret)
                return ret;

            ret = base.CanRemove(checkForeingKeys, excludedForeingKeys, ref errors, items);

            return ret;
        }

    }

}

