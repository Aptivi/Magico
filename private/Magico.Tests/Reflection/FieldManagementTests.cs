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
    public class FieldManagementTests
    {

        public static string tryToChangeIt = "No.";
        public static string tryToQueryIt = "Query successful";

        /// <summary>
        /// Tests getting value
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetFieldValueInstance()
        {
            var instance = new InstanceDataClass();
            var Value = FieldManager.GetFieldValueInstance(instance, nameof(InstanceDataClass.tryToChangeInstance));
            if (Value is not string)
                Assert.Fail("Can't get field value");
        }

        /// <summary>
        /// Tests setting value
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestSetFieldValueInstance()
        {
            var instance = new InstanceDataClass();
            FieldManager.SetFieldValueInstance(instance, nameof(InstanceDataClass.tryToChangeInstance), "Yes!");
            string Value = Convert.ToString(FieldManager.GetFieldValueInstance(instance, nameof(InstanceDataClass.tryToChangeInstance))) ?? "";
            Value.ShouldBe("Yes!");
        }

        /// <summary>
        /// Tests getting value
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetFieldValue()
        {
            var Value = FieldManager.GetFieldValue(nameof(tryToChangeIt), typeof(FieldManagementTests));
            if (Value is string value)
                value.ShouldNotBeNullOrEmpty();
            else
                Assert.Fail("Can't get field value");
        }

        /// <summary>
        /// Tests setting value
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestSetFieldValue()
        {
            FieldManager.SetFieldValue(nameof(tryToChangeIt), "Yes!", typeof(FieldManagementTests));
            var Value = FieldManager.GetFieldValue(nameof(tryToChangeIt), typeof(FieldManagementTests));
            if (Value is string value)
                value.ShouldBe("Yes!");
            else
                Assert.Fail("Can't set field value");
        }

        /// <summary>
        /// Tests getting field
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetField()
        {
            var Field = FieldManager.GetField(nameof(tryToQueryIt), typeof(FieldManagementTests));
            Field.ShouldNotBeNull();
            Field.Name.ShouldBe(nameof(tryToQueryIt));
            Field.DeclaringType.ShouldBe(typeof(FieldManagementTests));
        }

        /// <summary>
        /// Tests getting fields
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetFields()
        {
            var Fields = FieldManager.GetFields(typeof(FieldManagementTests));
            Fields.ShouldNotBeNull();
            Fields.ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests getting fields
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetFieldsNoEvaluation()
        {
            var Fields = FieldManager.GetFieldsNoEvaluation(typeof(FieldManagementTests));
            Fields.ShouldNotBeNull();
            Fields.ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests getting fields
        /// </summary>
        [TestMethod]
        [Description("Management")]
        public void TestGetFieldsInstance()
        {
            var instance = new InstanceDataClass();
            var Fields = FieldManager.GetFields(instance, typeof(FieldManagementTests));
            Fields.ShouldNotBeNull();
            Fields.ShouldNotBeEmpty();
        }
    }
}
