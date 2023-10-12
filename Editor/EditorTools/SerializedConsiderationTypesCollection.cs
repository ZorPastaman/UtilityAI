// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.Serialization.SerializedConsiderations;
using Object = UnityEngine.Object;

namespace Zor.UtilityAI.EditorTools
{
	/// <summary>
	/// Collection of all <see cref="SerializedConsideration_Base"/> types.
	/// It's automatically filled.
	/// </summary>
	[InitializeOnLoad]
	public static class SerializedConsiderationTypesCollection
	{
		[NotNull] private static readonly Type[] s_serializedConsiderationTypes;
		[NotNull] private static readonly Type[] s_considerationTypes;

		static SerializedConsiderationTypesCollection()
		{
			s_serializedConsiderationTypes = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
					where !domainAssembly.IsDynamic
					from assemblyType in domainAssembly.GetExportedTypes()
					where !assemblyType.IsAbstract && !assemblyType.IsGenericType
						&& assemblyType.IsSubclassOf(typeof(SerializedConsideration_Base))
					select assemblyType)
				.ToArray();

			int count = s_serializedConsiderationTypes.Length;
			s_considerationTypes = new Type[count];

			for (int i = 0; i < count; ++i)
			{
				var tempSerializedTable =
					(SerializedConsideration_Base)ScriptableObject.CreateInstance(s_serializedConsiderationTypes[i]);
				s_considerationTypes[i] = tempSerializedTable.considerationType;
				Object.DestroyImmediate(tempSerializedTable);
			}
		}

		/// <summary>
		/// <see cref="Consideration"/> types.
		/// </summary>
		public static IReadOnlyList<Type> considerationTypes => s_considerationTypes;

		/// <summary>
		/// Finds a paired serialized <see cref="Consideration"/> type by <see cref="Consideration"/> type.
		/// </summary>
		/// <param name="considerationType"><see cref="Consideration"/> type.</param>
		/// <returns>Serialized <see cref="Consideration"/> type or null if not found.</returns>
		public static Type GetSerializedConsiderationType(Type considerationType)
		{
			int index = Array.IndexOf(s_considerationTypes, considerationType);
			return index >= 0 ? s_serializedConsiderationTypes[index] : null;
		}
	}
}
