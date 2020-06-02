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
    public class TreatmentsRepository : GenericDataRepository<treatments, DoctcoDModel>
    {
        public TreatmentsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Name can not be empty.";
            public string text002 = "Code can not be empty.";
            public string text003 = "Invalid code format. 3 character, uppercase letters [A-Z] or numbers [0-9], or minus '-'.";
            public string text004 = "Invalid expiration period. Insert from 1 to 48 month, or leave empty.";
            public string text005 = "Treatment type is mandatory.";
            public string text006 = "Treatment already inserted.";
            public string text007 = "Invalid tax.";
            public string text008 = "A computed line already has this code.";
            public string text009 = "This item can not be removed. A patient treatment depends on it.";
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
        public override bool CanAdd(ref string[] errors, params treatments[] items)
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
        public override bool CanUpdate(ref string[] errors, params treatments[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params treatments[] items)
        {
            bool ret = true;

            foreach (treatments item in items)
            {
                if (String.IsNullOrEmpty(item.treatments_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.treatments_code))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }

                if (!ret)
                    break;

                if (!Regex.Match(item.treatments_code, @"^[A-Z0-9\-]{3}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }
                if (item.treatments_mexpiration != null && (item.treatments_mexpiration <= 0 || item.treatments_mexpiration > 48))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text004 }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.TreatmentsTypes.Find(item.treatmentstypes_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text005 }).ToArray();
                }

                if (item.taxes_id != null && BaseModel.Taxes.Find(item.taxes_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text007 }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.ComputedLines.Any(r => r.computedlines_code == item.treatments_code))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text008 }).ToArray();
                }

                if (!isUpdate)
                {
                    if (Any(r => r.treatments_code == item.treatments_code) ||
                        Any(r => r.treatments_name == item.treatments_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text006 }).ToArray();
                    }
                }
                else
                {
                    if (Any(r => r.treatments_id != item.treatments_id && r.treatments_code == item.treatments_code) ||
                        Any(r => r.treatments_id != item.treatments_id && r.treatments_name == item.treatments_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text006 }).ToArray();
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
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params treatments[] items)
        {
            bool ret = true;

            errors = new string[] { };

            foreach (treatments item in items)
            {
                if (BaseModel.PatientsTreatments.Any(r => r.treatments_id == item.treatments_id))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text009 }).ToArray();
                }

                if (!ret)
                    break;
            }

            if (!ret)
                return ret;

            if (excludedForeingKeys == null)
                excludedForeingKeys = new string[] { };
            if (!excludedForeingKeys.Contains("FK_treatmentsprices_treatments"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_treatmentsprices_treatments" }).ToArray();

            ret = base.CanRemove(checkForeingKeys, excludedForeingKeys, ref errors, items);

            return ret;
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="items"></param>
        public override void Remove(params treatments[] items)
        {
            //remove all related items
            foreach (treatments item in items)
            {
                BaseModel.TreatmentsPrices.Remove(BaseModel.TreatmentsPrices.List(r => r.treatments_id == item.treatments_id).ToArray());
            }

            base.Remove(items);
        }
    }

}

