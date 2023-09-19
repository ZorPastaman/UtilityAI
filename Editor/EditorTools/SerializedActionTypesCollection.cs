// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using Zor.UtilityAI.Serialization.SerializedActions;
using Object = UnityEngine.Object;

namespace Zor.UtilityAI.EditorTools
{
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

		public static IReadOnlyList<Type> actionTypes => s_actionTypes;

		public static Type GetSerializedActionType(Type actionType)
		{
			int index = Array.IndexOf(s_actionTypes, actionType);
			return index >= 0 ? s_serializedActionTypes[index] : null;
		}
	}
}
