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
    public class ComputedLinesRepository : GenericDataRepository<computedlines, DoctcoDModel>
    {
        public ComputedLinesRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Name can not be empty.";
            public string text002 = "Line already inserted.";
            public string text003 = "Invalid tax.";
            public string text004 = "Code can not be empty.";
            public string text005 = "Invalid code format. 3 character, uppercase letters [A-Z] or numbers [0-9], or minus '-'.";
            public string text006 = "A treatment already has this code.";
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
        public override bool CanAdd(ref string[] errors, params computedlines[] items)
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
        public override bool CanUpdate(ref string[] errors, params computedlines[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params computedlines[] items)
        {
            bool ret = true;

            foreach (computedlines item in items)
            {
                if (String.IsNullOrEmpty(item.computedlines_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.computedlines_code))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text004 }).ToArray();
                }

                if (!ret)
                    break;

                if (!Regex.Match(item.computedlines_code, @"^[A-Z0-9\-]{3}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text005 }).ToArray();
                }

                if (!ret)
                    break;

                if (item.taxes_id != null && BaseModel.Taxes.Find(item.taxes_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Treatments.Any(r => r.treatments_code == item.computedlines_code))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text006 }).ToArray();
                }

                if (!isUpdate)
                {
                    if (Any(r => r.computedlines_code == item.computedlines_code) ||
                        Any(r => r.computedlines_name == item.computedlines_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text002 }).ToArray();
                    }
                }
                else
                {
                    if (Any(r => r.computedlines_id != item.computedlines_id && r.computedlines_code == item.computedlines_code) ||
                        Any(r => r.computedlines_id != item.computedlines_id && r.computedlines_name == item.computedlines_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text002 }).ToArray();
                    }
                }

                if (!ret)
                    break;
            }

            return ret;
        }

    }

}

