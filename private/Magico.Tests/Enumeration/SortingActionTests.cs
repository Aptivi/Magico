//
// Magico  Copyright (C) 2024  Aptivi
//
// This file is part of Magico
//
// Magico is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Magico is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Linq;
using Magico.Enumeration;
using System;

namespace Magico.Tests.Enumeration
{
    [TestClass]
    public class SortingActionTests
    {

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt8BestCase()
        {
            byte[] expected = [1, 4, 8, 64, 255];
            byte[] data = [1, 4, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt16BestCase()
        {
            short[] expected = [1, 4, 8, 64, 255];
            short[] data = [1, 4, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt32BestCase()
        {
            int[] expected = [1, 4, 8, 64, 255];
            int[] data = [1, 4, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt64BestCase()
        {
            long[] expected = [1, 4, 8, 64, 255];
            long[] data = [1, 4, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

#if NET8_0_OR_GREATER
        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt128BestCase()
        {
            Int128[] expected = [1, 4, 8, 64, 255];
            Int128[] data = [1, 4, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }
#endif

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersFloatBestCase()
        {
            float[] expected = [1.2f, 1.3f, 8.4f, 64.5f, 255.6f];
            float[] data = [1.2f, 1.3f, 8.4f, 64.5f, 255.6f];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersDoubleBestCase()
        {
            double[] expected = [1.2f, 1.3f, 8.4f, 64.5f, 255.6f];
            double[] data = [1.2f, 1.3f, 8.4f, 64.5f, 255.6f];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt8MidCase()
        {
            byte[] expected = [1, 4, 8, 64, 255];
            byte[] data = [4, 1, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt16MidCase()
        {
            short[] expected = [1, 4, 8, 64, 255];
            short[] data = [4, 1, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt32MidCase()
        {
            int[] expected = [1, 4, 8, 64, 255];
            int[] data = [4, 1, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt64MidCase()
        {
            long[] expected = [1, 4, 8, 64, 255];
            long[] data = [4, 1, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

#if NET8_0_OR_GREATER
        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt128MidCase()
        {
            Int128[] expected = [1, 4, 8, 64, 255];
            Int128[] data = [4, 1, 8, 64, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }
#endif

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersFloatMidCase()
        {
            float[] expected = [1.2f, 1.3f, 8.4f, 64.5f, 255.6f];
            float[] data = [1.3f, 1.2f, 8.4f, 64.5f, 255.6f];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersDoubleMidCase()
        {
            double[] expected = [1.2f, 1.3f, 8.4f, 64.5f, 255.6f];
            double[] data = [1.3f, 1.2f, 8.4f, 64.5f, 255.6f];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt8WorstCase()
        {
            byte[] expected = [1, 4, 8, 64, 255];
            byte[] data = [8, 4, 64, 1, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt16WorstCase()
        {
            short[] expected = [1, 4, 8, 64, 255];
            short[] data = [8, 4, 64, 1, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt32WorstCase()
        {
            int[] expected = [1, 4, 8, 64, 255];
            int[] data = [8, 4, 64, 1, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt64WorstCase()
        {
            long[] expected = [1, 4, 8, 64, 255];
            long[] data = [8, 4, 64, 1, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

#if NET8_0_OR_GREATER
        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersInt128WorstCase()
        {
            Int128[] expected = [1, 4, 8, 64, 255];
            Int128[] data = [8, 4, 64, 1, 255];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }
#endif

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersFloatWorstCase()
        {
            float[] expected = [1.2f, 1.3f, 8.4f, 64.5f, 255.6f];
            float[] data = [8.4f, 1.3f, 64.5f, 1.2f, 255.6f];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }

        [TestMethod]
        [Description("Action")]
        public void TestSortNumbersDoubleWorstCase()
        {
            double[] expected = [1.2f, 1.3f, 8.4f, 64.5f, 255.6f];
            double[] data = [8.4f, 1.3f, 64.5f, 1.2f, 255.6f];
            data.SortNumbers().SequenceEqual(expected).ShouldBeTrue();
        }
    }
}
