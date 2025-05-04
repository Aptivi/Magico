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

using Magico.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;

namespace Magico.Tests.Enumeration
{
    [TestClass]
    public class EnumerableExtensionsTests
    {
        [TestMethod]
        public void LengthEmpty()
        {
            IEnumerable values = Enumerable.Empty<object>();
            int count = values.Length();
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void LengthFull()
        {
            IEnumerable values = Enumerable.Range(0, 200);
            int count = values.Length();
            Assert.AreEqual(200, count);
        }

        [TestMethod]
        public void GetElementFromIndex()
        {
            IEnumerable values = Enumerable.Range(0, 200);
            object? element = values.GetElementFromIndex(3);
            Assert.AreEqual(3, element);
        }
    }
}
