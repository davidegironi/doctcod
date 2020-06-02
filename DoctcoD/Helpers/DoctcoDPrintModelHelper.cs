#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.IO;
using System.Reflection;

namespace DG.DoctcoD.Helpers
{
    public class DoctcoDPrintModelHelper
    {
        /// <summary>
        /// Build and instance of a printmodel
        /// </summary>
        /// <param name="assemblyPath"></param>
        /// <returns></returns>
        public static IDoctcoDPrintModel DoctcoDPrintModelInstance(string assemblyPath)
        {
            IDoctcoDPrintModel printModel = null;

            string assemblyType = "DG.DoctcoD.DoctcoDPrintModel";
            try
            {
                Assembly a = Assembly.Load(File.ReadAllBytes(Path.GetFullPath(assemblyPath)));
                Type t = a.GetType(assemblyType);
                printModel = (IDoctcoDPrintModel)Activator.CreateInstance(t, null);
            }
            catch { }

            return printModel;
        }
    }
}
