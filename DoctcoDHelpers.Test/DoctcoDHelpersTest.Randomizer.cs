﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using NUnit.Framework;

namespace DG.DoctcoD.Helpers.Test
{
    [TestFixture]
    public partial class DoctcoDHelpersTest
    {
        [Test]
        public void Randomizer_BuildRandomString()
        {
            Assert.That(Randomizer.BuildRandomString(5).Length, Is.EqualTo(5));
        }

        [Test]
        public void Randomizer_BuildRandomNumberString()
        {
            Assert.That(Randomizer.BuildRandomNumberString(5).Length, Is.EqualTo(5));
        }

        [Test]
        public void Randomizer_BuildRandomNumber()
        {
            int n;
            Assert.That(Randomizer.BuildRandomNumber(5).Length, Is.EqualTo(5));
            Assert.IsTrue(int.TryParse(Randomizer.BuildRandomNumber(5), out n));
        }

    }
}
