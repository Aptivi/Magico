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

using System;
using Magico.Reflection;
using Magico.Tests.Reflection.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Magico.Tests.Reflection
{

    [TestClass]
    public class PropertyManagementTests
    {
        public static string TryToChangeIt { get; set; } = "No.";
        public static string TryToQueryIt { get; set; } = "Query successful";

        /// <summary>
        /// Tests getting value
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetPropertyValueInstance()
        {
            var instance = new InstanceDataClass();
            var Value = PropertyManager.GetPropertyValueInstance(instance, nameof(InstanceDataClass.TryToChangeInstance));
            if (Value is not string)
                Assert.Fail("Can't get property value");
        }

        /// <summary>
        /// Tests setting value
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestSetPropertyValueInstance()
        {
            var instance = new InstanceDataClass();
            PropertyManager.SetPropertyValueInstance(instance, nameof(InstanceDataClass.TryToChangeInstance), "Yes!");
            string Value = Convert.ToString(PropertyManager.GetPropertyValueInstance(instance, nameof(InstanceDataClass.TryToChangeInstance))) ?? "";
            Value.ShouldBe("Yes!");
        }

        /// <summary>
        /// Tests getting value
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetPropertyValue()
        {
            var Value = PropertyManager.GetPropertyValue(nameof(TryToChangeIt), typeof(PropertyManagementTests));
            if (Value is string value)
                value.ShouldNotBeNullOrEmpty();
            else
                Assert.Fail("Can't get property value");
        }

        /// <summary>
        /// Tests setting value
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestSetPropertyValue()
        {
            PropertyManager.SetPropertyValue(nameof(TryToChangeIt), "Yes!", typeof(PropertyManagementTests));
            var Value = PropertyManager.GetPropertyValue(nameof(TryToChangeIt), typeof(PropertyManagementTests));
            if (Value is string value)
                value.ShouldBe("Yes!");
            else
                Assert.Fail("Can't set property value");
        }

        /// <summary>
        /// Tests getting property
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetProperty()
        {
            var Property = PropertyManager.GetProperty(nameof(TryToQueryIt), typeof(PropertyManagementTests));
            Property.ShouldNotBeNull();
            Property.Name.ShouldBe(nameof(TryToQueryIt));
            Property.DeclaringType.ShouldBe(typeof(PropertyManagementTests));
        }

        /// <summary>
        /// Tests getting properties
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetProperties()
        {
            var Properties = PropertyManager.GetProperties(typeof(PropertyManagementTests));
            Properties.ShouldNotBeNull();
            Properties.ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests getting properties
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetPropertiesNoEvaluation()
        {
            var Properties = PropertyManager.GetPropertiesNoEvaluation(typeof(PropertyManagementTests));
            Properties.ShouldNotBeNull();
            Properties.ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests getting properties
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetPropertiesInstance()
        {
            var instance = new InstanceDataClass();
            var Properties = PropertyManager.GetProperties(instance, typeof(InstanceDataClass));
            Properties.ShouldNotBeNull();
            Properties.ShouldNotBeEmpty();
        }
    }
}
