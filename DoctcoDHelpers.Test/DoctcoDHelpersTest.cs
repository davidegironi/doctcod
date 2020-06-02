#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DoctcoD.Model;
using NUnit.Framework;
using System.Configuration;
using System.IO;

namespace DG.DoctcoD.Helpers.Test
{
    [TestFixture]
    public partial class DoctcoDHelpersTest
    {
        private DoctcoDModel _doctcodModel = null;
        private readonly string tmpdir = "";

        public DoctcoDHelpersTest()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);

            _doctcodModel = new DoctcoDModel();
            tmpdir = ConfigurationManager.AppSettings["tmpdir"];
        }
    }
}
