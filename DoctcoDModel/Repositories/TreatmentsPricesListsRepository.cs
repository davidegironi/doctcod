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
    public class TreatmentsPricesListsRepository : GenericDataRepository<treatmentspriceslists, DoctcoDModel>
    {
        public TreatmentsPricesListsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Name can not be empty.";
            public string text002 = "Invalid multiplier. Insert from 1 to 10, or leave empty.";
            public string text003 = "Treatments price list already inserted.";
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
        public override bool CanAdd(ref string[] errors, params treatmentspriceslists[] items)
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
        public override bool CanUpdate(ref string[] errors, params treatmentspriceslists[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params treatmentspriceslists[] items)
        {
            bool ret = true;

            foreach (treatmentspriceslists item in items)
            {
                if (String.IsNullOrEmpty(item.treatmentspriceslists_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }

                if (!ret)
                    break;

                if (item.treatmentspriceslists_multiplier < 1 || item.treatmentspriceslists_multiplier > 10)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (Any(r => r.treatmentspriceslists_name == item.treatmentspriceslists_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text003 }).ToArray();
                    }
                }
                else
                {
                    if (Any(r => r.treatmentspriceslists_id != item.treatmentspriceslists_id && r.treatmentspriceslists_name == item.treatmentspriceslists_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text003 }).ToArray();
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
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params treatmentspriceslists[] items)
        {
            bool ret = true;

            errors = new string[] { };

            if (excludedForeingKeys == null)
                excludedForeingKeys = new string[] { };
            if (!excludedForeingKeys.Contains("FK_treatmentsprices_treatmentspriceslists"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_treatmentsprices_treatmentspriceslists" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_patients_treatmentspriceslists"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_patients_treatmentspriceslists" }).ToArray();

            ret = base.CanRemove(checkForeingKeys, excludedForeingKeys, ref errors, items);

            return ret;
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="items"></param>
        public override void Remove(params treatmentspriceslists[] items)
        {
            //remove or unset all related items
            foreach (treatmentspriceslists item in items)
            {
                BaseModel.TreatmentsPrices.Remove(BaseModel.TreatmentsPrices.List(r => r.treatmentspriceslists_id == item.treatmentspriceslists_id).ToArray());
                foreach (patients patient in BaseModel.Patients.List(r => r.treatmentspriceslists_id == item.treatmentspriceslists_id))
                {
                    patient.treatmentspriceslists_id = null;
                    BaseModel.Patients.Update(patient);
                }
            }

            base.Remove(items);
        }
    }

}

