#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using NUnit.Framework;
using System.IO;

namespace DG.DoctcoD.Model.Test
{
    [TestFixture]
    public partial class DoctcoDModelTest
    {
        private DoctcoDModel _doctcodModel = null;

        public DoctcoDModelTest()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);

            _doctcodModel = new DoctcoDModel();
        }
    }
}
