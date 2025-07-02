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

using Magico.Languages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Magico.Reflection
{
    /// <summary>
    /// Field management module
    /// </summary>
    public static class FieldManager
    {
        /// <summary>
        /// Sets the value of a field to the new value dynamically
        /// </summary>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <param name="VariableValue">New value</param>
        /// <param name="VariableType">Field type</param>
        public static void SetFieldValue(string Variable, object? VariableValue, Type? VariableType)
        {
            // Get field for specified variable
            FieldInfo? TargetField;
            if (VariableType is not null)
                TargetField = GetField(Variable, VariableType);
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_COMMON_EXCEPTION_NEEDSTYPE"));

            // Set the variable if found
            SetFieldValue(TargetField, VariableValue);
        }

        /// <summary>
        /// Sets the value of a field to the new value dynamically
        /// </summary>
        /// <param name="Variable">Field info instance.</param>
        /// <param name="VariableValue">New value</param>
        public static void SetFieldValue(FieldInfo? Variable, object? VariableValue)
        {
            // Check the field
            if (Variable is null)
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_COMMON_EXCEPTION_NEEDSVAR"));

            // The "obj" description says this: "The object whose field value will be set."
            // Apparently, SetValue works on modules if you specify a variable name as an object (first argument). Not only classes.
            // Unfortunately, there are no examples on the MSDN that showcase such situations; classes are being used.
            Variable.SetValue(Variable, VariableValue);
        }

        /// <summary>
        /// Sets the value of a field to the new value dynamically
        /// </summary>
        /// <param name="instance">Instance class to make changes on</param>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <param name="VariableValue">New value</param>
        public static void SetFieldValueInstance<T>(T instance, string Variable, object? VariableValue) =>
            SetFieldValueInstance(instance, Variable, VariableValue, instance?.GetType());

        /// <summary>
        /// Sets the value of a field to the new value dynamically
        /// </summary>
        /// <param name="instance">Instance class to make changes on</param>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <param name="VariableValue">New value</param>
        /// <param name="VariableType">Field type</param>
        public static void SetFieldValueInstance<T>(T instance, string Variable, object? VariableValue, Type? VariableType)
        {
            // Get field for specified variable
            FieldInfo? TargetField;
            if (VariableType is not null)
                TargetField = GetField(Variable, VariableType);
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_COMMON_EXCEPTION_NEEDSTYPE"));

            // Set the variable if found
            SetFieldValueInstance(instance, TargetField, VariableValue);
        }

        /// <summary>
        /// Sets the value of a field to the new value dynamically
        /// </summary>
        /// <param name="instance">Instance class to make changes on</param>
        /// <param name="Variable">Field info instance.</param>
        /// <param name="VariableValue">New value</param>
        public static void SetFieldValueInstance<T>(T instance, FieldInfo? Variable, object? VariableValue)
        {
            // Check the field
            if (Variable is null)
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_COMMON_EXCEPTION_NEEDSVAR"));

            // This is how to set a value in instance variables.
            Variable.SetValue(instance, VariableValue);
        }

        /// <summary>
        /// Sets the value of a field to the new value dynamically
        /// </summary>
        /// <param name="instance">Instance class to make changes on</param>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <param name="VariableValue">New value</param>
        /// <param name="VariableType">Field type</param>
        public static void SetFieldValueInstanceExplicit(object instance, string Variable, object? VariableValue, Type? VariableType)
        {
            // Get field for specified variable
            FieldInfo? TargetField = default;
            if (VariableType is not null)
                TargetField = GetField(Variable, VariableType);

            // Set the variable if found
            SetFieldValueInstance(instance, TargetField, VariableValue);
        }

        /// <summary>
        /// Gets the value of a field dynamically 
        /// </summary>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <param name="VariableType">Field type</param>
        /// <returns>Value of a field</returns>
        public static object? GetFieldValue(string Variable, Type? VariableType)
        {
            // Get field for specified variable
            FieldInfo? TargetField;
            if (VariableType is not null)
                TargetField = GetField(Variable, VariableType);
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_COMMON_EXCEPTION_NEEDSTYPE"));

            // Get the variable if found
            return GetFieldValue(TargetField);
        }

        /// <summary>
        /// Gets the value of a field dynamically 
        /// </summary>
        /// <param name="Variable">Field info instance.</param>
        /// <returns>Value of a field</returns>
        public static object? GetFieldValue(FieldInfo? Variable)
        {
            // Check the field
            if (Variable is null)
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_COMMON_EXCEPTION_NEEDSVAR"));

            // The "obj" description says this: "The object whose field value will be set."
            // Apparently, SetValue works on modules if you specify a variable name as an object (first argument). Not only classes.
            // Unfortunately, there are no examples on the MSDN that showcase such situations; classes are being used.
            return Variable.GetValue(Variable);
        }

        /// <summary>
        /// Gets the value of a field dynamically 
        /// </summary>
        /// <param name="instance">Instance class to fetch value from</param>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <returns>Value of a field</returns>
        public static object? GetFieldValueInstance<T>(T instance, string Variable) =>
            GetFieldValueInstance(instance, Variable, instance?.GetType());

        /// <summary>
        /// Gets the value of a field dynamically 
        /// </summary>
        /// <param name="instance">Instance class to fetch value from</param>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <param name="VariableType">Field type</param>
        /// <returns>Value of a field</returns>
        public static object? GetFieldValueInstance<T>(T instance, string Variable, Type? VariableType)
        {
            // Get field for specified variable
            FieldInfo? TargetField;
            if (VariableType is not null)
                TargetField = GetField(Variable, VariableType);
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_COMMON_EXCEPTION_NEEDSTYPE"));

            // Get the variable if found
            return GetFieldValueInstance(instance, TargetField);
        }

        /// <summary>
        /// Gets the value of a field dynamically 
        /// </summary>
        /// <param name="instance">Instance class to fetch value from</param>
        /// <param name="Variable">Field info instance.</param>
        /// <returns>Value of a field</returns>
        public static object? GetFieldValueInstance<T>(T instance, FieldInfo? Variable)
        {
            // Check the field
            if (Variable is null)
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_COMMON_EXCEPTION_NEEDSVAR"));

            // This is how to get a value in instance variables.
            return Variable.GetValue(instance);
        }

        /// <summary>
        /// Gets the value of a field dynamically 
        /// </summary>
        /// <param name="instance">Instance class to fetch value from</param>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <param name="VariableType">Field type</param>
        /// <returns>Value of a field</returns>
        public static object? GetFieldValueInstanceExplicit(object instance, string Variable, Type? VariableType)
        {
            // Get field for specified variable
            FieldInfo? TargetField = default;
            if (VariableType is not null)
                TargetField = GetField(Variable, VariableType);

            // Get the variable if found
            return GetFieldValueInstance(instance, TargetField);
        }

        /// <summary>
        /// Gets a field from variable name
        /// </summary>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <param name="Type">Field type</param>
        /// <returns>Field information</returns>
        public static FieldInfo? GetField(string Variable, Type Type)
        {
            // Get fields of specified type
            var FieldInstance = Type.GetField(Variable);

            // Check if any of them contains the specified variable
            if (FieldInstance is not null)
                return FieldInstance;
            return null;
        }

        /// <summary>
        /// Checks the specified field if it exists
        /// </summary>
        /// <param name="Variable">Field name. Use operator NameOf to get name.</param>
        /// <param name="Type">Field type</param>
        public static bool CheckField(string Variable, Type Type)
        {
            // Get field for specified variable
            var TargetField = GetField(Variable, Type);

            // Set the variable if found
            return TargetField is not null;
        }

        /// <summary>
        /// Gets the fields from the type dynamically
        /// </summary>
        /// <param name="VariableType">Variable type</param>
        /// <returns>Dictionary containing all fields</returns>
        public static Dictionary<string, object?> GetFields(Type VariableType)
        {
            // Get field for specified variable
            var Fields = VariableType.GetFields();
            var FieldDict = new Dictionary<string, object?>();

            // Get the fields and get their values
            foreach (FieldInfo VarField in Fields)
            {
                try
                {
                    var FieldValue = VarField.GetValue(VariableType);
                    FieldDict.Add(VarField.Name, FieldValue);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting field value {VarField.Name} for {VariableType.Name}: {ex}");
                }
            }
            return FieldDict;
        }

        /// <summary>
        /// Gets the fields from the type dynamically
        /// </summary>
        /// <param name="VariableType">Variable type</param>
        /// <param name="instance">Instance</param>
        /// <returns>Dictionary containing all fields</returns>
        public static Dictionary<string, object?> GetFields<T>(T instance, Type VariableType)
        {
            // Get field for specified variable
            var Fields = VariableType.GetFields();
            var FieldDict = new Dictionary<string, object?>();

            // Get the fields and get their values
            foreach (FieldInfo VarField in Fields)
            {
                try
                {
                    var FieldValue = VarField.GetValue(instance);
                    FieldDict.Add(VarField.Name, FieldValue);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting field value {VarField.Name} for {VariableType.Name}: {ex}");
                }
            }
            return FieldDict;
        }

        /// <summary>
        /// Gets the fields from the type without evaluation
        /// </summary>
        /// <param name="VariableType">Variable type</param>
        /// <returns>Dictionary containing all fields</returns>
        public static Dictionary<string, Type> GetFieldsNoEvaluation(Type VariableType)
        {
            // Get field for specified variable
            var Fields = VariableType.GetFields();
            var FieldDict = new Dictionary<string, Type>();

            // Get the fields and get their values
            foreach (FieldInfo VarField in Fields)
                FieldDict.Add(VarField.Name, VarField.FieldType);
            return FieldDict;
        }

        /// <summary>
        /// Gets all the fields from the type dynamically
        /// </summary>
        /// <param name="types">Array of types to query</param>
        /// <returns>Dictionary containing all fields</returns>
        public static Dictionary<string, object?> GetAllFields(Type[] types)
        {
            // Get field for specified variable
            var FieldDict = new Dictionary<string, object?>();
            foreach (var type in types)
            {
                try
                {
                    var fields = GetFields(type);
                    foreach (var field in fields)
                        FieldDict.Add(field.Key, field.Value);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting field value for {type.Name}: {ex}");
                }
            }
            return FieldDict;
        }

        /// <summary>
        /// Gets all the fields from the type without evaluation
        /// </summary>
        /// <param name="types">Array of types to query</param>
        /// <returns>Dictionary containing all fields</returns>
        public static Dictionary<string, Type> GetAllFieldsNoEvaluation(Type[] types)
        {
            // Get field for specified variable
            var FieldDict = new Dictionary<string, Type>();
            foreach (var type in types)
            {
                try
                {
                    var fields = GetFieldsNoEvaluation(type);
                    foreach (var field in fields)
                        FieldDict.Add(field.Key, field.Value);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting field for {type.Name}: {ex}");
                }
            }
            return FieldDict;
        }

        /// <summary>
        /// Gets all the fields from the type dynamically
        /// </summary>
        /// <param name="instance">Instance</param>
        /// <param name="types">Array of types to query</param>
        /// <returns>Dictionary containing all fields</returns>
        public static Dictionary<string, object?> GetAllFields<T>(T instance, Type[] types)
        {
            // Get field for specified variable
            var FieldDict = new Dictionary<string, object?>();
            foreach (var type in types)
            {
                try
                {
                    var fields = GetFields(instance, type);
                    foreach (var field in fields)
                        FieldDict.Add(field.Key, field.Value);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting field value for {type.Name}: {ex}");
                }
            }
            return FieldDict;
        }
    }
}
