// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using Zor.UtilityAI.Serialization.SerializedActions;
using Object = UnityEngine.Object;
using Action = Zor.UtilityAI.Core.Action;

namespace Zor.UtilityAI.EditorTools
{
	/// <summary>
	/// Collection of all <see cref="SerializedAction_Base"/> types.
	/// It's automatically filled.
	/// </summary>
	[InitializeOnLoad]
	public static class SerializedActionTypesCollection
	{
		[NotNull] private static readonly Type[] s_serializedActionTypes;
		[NotNull] private static readonly Type[] s_actionTypes;

		static SerializedActionTypesCollection()
		{
			s_serializedActionTypes = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
					where !domainAssembly.IsDynamic
					from assemblyType in domainAssembly.GetExportedTypes()
					where !assemblyType.IsAbstract && !assemblyType.IsGenericType
						&& assemblyType.IsSubclassOf(typeof(SerializedAction_Base))
					select assemblyType)
				.ToArray();

			int count = s_serializedActionTypes.Length;
			s_actionTypes = new Type[count];

			for (int i = 0; i < count; ++i)
			{
				var tempSerializedTable =
					(SerializedAction_Base)ScriptableObject.CreateInstance(s_serializedActionTypes[i]);
				s_actionTypes[i] = tempSerializedTable.actionType;
				Object.DestroyImmediate(tempSerializedTable);
			}
		}

		/// <summary>
		/// <see cref="Action"/> types.
		/// </summary>
		public static IReadOnlyList<Type> actionTypes => s_actionTypes;

		/// <summary>
		/// Finds a paired serialized <see cref="Action"/> type by <see cref="Action"/> type.
		/// </summary>
		/// <param name="actionType"><see cref="Action"/> type.</param>
		/// <returns>Serialized <see cref="Action"/> type or null if not found.</returns>
		public static Type GetSerializedActionType(Type actionType)
		{
			int index = Array.IndexOf(s_actionTypes, actionType);
			return index >= 0 ? s_serializedActionTypes[index] : null;
		}
	}
}
