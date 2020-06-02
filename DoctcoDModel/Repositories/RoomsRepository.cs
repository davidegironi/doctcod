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
    public class RoomsRepository : GenericDataRepository<rooms, DoctcoDModel>
    {
        public RoomsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Room already inserted.";
            public string text002 = "Name can not be empty.";
            public string text003 = "Remove appointments before deleting this item.";
            public string text004 = "Invalid color.";
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
        public override bool CanAdd(ref string[] errors, params rooms[] items)
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
        public override bool CanUpdate(ref string[] errors, params rooms[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params rooms[] items)
        {
            bool ret = true;

            foreach (rooms item in items)
            {
                if (String.IsNullOrEmpty(item.rooms_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }

                if (!ret)
                    break;

                if (!String.IsNullOrEmpty(item.rooms_color) && !Regex.Match(item.rooms_color, @"^#(?:[0-9a-fA-F]{3}){2}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text004 }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (Any(r => r.rooms_name == item.rooms_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text001 }).ToArray();
                    }
                }
                else
                {
                    if (Any(r => r.rooms_id != item.rooms_id && r.rooms_name == item.rooms_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text001 }).ToArray();
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
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params rooms[] items)
        {
            bool ret = true;

            errors = new string[] { };

            foreach (rooms item in items)
            {
                if (BaseModel.Appointments.Any(r => r.rooms_id == item.rooms_id))
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

