﻿// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using Zor.UtilityAI.EditorTools;
using Zor.UtilityAI.Helpers;
using Zor.UtilityAI.Serialization;
using Zor.UtilityAI.Serialization.SerializedActions;
using Zor.UtilityAI.Serialization.SerializedConsiderations;
using Object = UnityEngine.Object;

namespace Zor.UtilityAI.CustomEditors
{
	[CustomEditor(typeof(SerializedBrain))]
	public sealed class SerializedBrainEditor : Editor
	{
		private const string SerializedActionsPropertyName = "m_SerializedActions";
		private const string SerializedConsiderationsPropertyName = "m_SerializedConsiderations";
		private const string SerializedConsiderationIndicesPropertyName = "m_ConsiderationIndices";
		private const string ConsiderationsPropertyName = "m_Considerations";
		private const string BrainSettingsPropertyName = "m_BrainSettings";

		[NotNull] private readonly Dictionary<Object, Editor> m_editors = new();

		private static bool s_considerationsFoldout = true;
		private static bool s_actionsFoldout = true;

		public override void OnInspectorGUI()
		{
			SerializedProperty actionsProperty = serializedObject.FindProperty(SerializedActionsPropertyName);
			SerializedProperty considerationsProperty =
				serializedObject.FindProperty(SerializedConsiderationsPropertyName);
			SerializedProperty considerationIndicesProperty =
				serializedObject.FindProperty(SerializedConsiderationIndicesPropertyName);

			s_considerationsFoldout = EditorGUILayout.Foldout(s_considerationsFoldout, "Consideration");
			if (s_considerationsFoldout)
			{
				EditorGUILayout.BeginVertical(GUI.skin.window);

				for (int i = 0, count = considerationsProperty.arraySize; i < count; ++i)
				{
					SerializedProperty considerationProperty = considerationsProperty.GetArrayElementAtIndex(i);
					var objectValue = (SerializedConsideration_Base)considerationProperty.objectReferenceValue;

					if (!m_editors.TryGetValue(objectValue, out Editor editor))
					{
						editor = CreateEditorWithContext(new Object[] { objectValue }, target);
						m_editors.Add(objectValue, editor);
					}

					EditorGUILayout.BeginVertical(GUI.skin.box);

					EditorGUILayout.LabelField(GetUIName(objectValue.considerationType), EditorStyles.boldLabel);
					objectValue.name = EditorGUILayout.TextField("Name", objectValue.name);

					editor.OnInspectorGUI();

					if (GUILayout.Button("Remove Consideration"))
					{
						DestroyImmediate(objectValue, true);
						SerializedPropertyHelper.CompletelyRemove(considerationsProperty, i);
						RemoveConsiderationIndex(considerationIndicesProperty, i);

						--i;
						count = considerationsProperty.arraySize;

						serializedObject.ApplyModifiedProperties();
						AssetDatabase.SaveAssets();
						AssetDatabase.Refresh();
					}

					EditorGUILayout.EndVertical();
				}

				EditorGUILayout.Separator();

				if (GUILayout.Button("Add Consideration"))
				{
					AddConsideration(considerationsProperty);
				}

				EditorGUILayout.EndVertical();
			}

			EditorGUILayout.Space();

			s_actionsFoldout = EditorGUILayout.Foldout(s_actionsFoldout, "Actions");
			if (s_actionsFoldout)
			{
				EditorGUILayout.BeginVertical(GUI.skin.window);

				for (int i = 0, count = actionsProperty.arraySize; i < count; ++i)
				{
					SerializedProperty actionProperty = actionsProperty.GetArrayElementAtIndex(i);
					var objectValue = (SerializedAction_Base)actionProperty.objectReferenceValue;

					if (!m_editors.TryGetValue(objectValue, out Editor editor))
					{
						editor = CreateEditorWithContext(new Object[] { objectValue }, target);
						m_editors.Add(objectValue, editor);
					}

					EditorGUILayout.BeginVertical(GUI.skin.box);

					EditorGUILayout.LabelField(GetUIName(objectValue.actionType), EditorStyles.boldLabel);
					objectValue.name = EditorGUILayout.TextField("Name", objectValue.name);

					editor.OnInspectorGUI();

					EditorGUILayout.LabelField("Considerations");

					SerializedProperty considerations = considerationIndicesProperty.GetArrayElementAtIndex(i)
						.FindPropertyRelative(ConsiderationsPropertyName);
					MakeConsiderationsMenu(considerations, considerationsProperty);

					if (GUILayout.Button("Remove Action"))
					{
						DestroyImmediate(objectValue, true);
						SerializedPropertyHelper.CompletelyRemove(actionsProperty, i);
						SerializedPropertyHelper.CompletelyRemove(considerationIndicesProperty, i);

						--i;
						count = actionsProperty.arraySize;

						serializedObject.ApplyModifiedProperties();
						AssetDatabase.SaveAssets();
						AssetDatabase.Refresh();
					}

					EditorGUILayout.EndVertical();
				}

				EditorGUILayout.Separator();

				if (GUILayout.Button("Add Action"))
				{
					AddAction(actionsProperty, considerationIndicesProperty);
				}

				EditorGUILayout.EndVertical();
			}

			EditorGUI.BeginChangeCheck();
			SerializedProperty brainSettingsProperty = serializedObject.FindProperty(BrainSettingsPropertyName);
			EditorGUILayout.PropertyField(brainSettingsProperty);
			if (EditorGUI.EndChangeCheck())
			{
				serializedObject.ApplyModifiedProperties();
			}
		}

		private void OnDestroy()
		{
			foreach (Editor editor in m_editors.Values)
			{
				DestroyImmediate(editor);
			}
		}

		private void AddConsideration(SerializedProperty considerationsProperty)
		{
			var genericMenu = new GenericMenu();
			IReadOnlyList<Type> considerationTypes = SerializedConsiderationTypesCollection.considerationTypes;

			for (int i = 0, count = considerationTypes.Count; i < count; ++i)
			{
				Type type = considerationTypes[i];
				string uiName = GetUIName(type);
				genericMenu.AddItem(new GUIContent(uiName), false, () =>
				{
					Type serializedConsiderationType =
						SerializedConsiderationTypesCollection.GetSerializedConsiderationType(type);
					ScriptableObject instance = CreateInstance(serializedConsiderationType);
					instance.name = uiName.Replace(" ", string.Empty);

					AssetDatabase.AddObjectToAsset(instance, target);

					int index = considerationsProperty.arraySize++;
					considerationsProperty.GetArrayElementAtIndex(index).objectReferenceValue = instance;

					serializedObject.ApplyModifiedProperties();
					AssetDatabase.SaveAssets();
				});
			}

			genericMenu.ShowAsContext();
		}

		private void AddAction(SerializedProperty actionsProperty, SerializedProperty considerationIndicesProperty)
		{
			var genericMenu = new GenericMenu();
			IReadOnlyList<Type> actionTypes = SerializedActionTypesCollection.actionTypes;

			for (int i = 0, count = actionTypes.Count; i < count; ++i)
			{
				Type type = actionTypes[i];
				string uiName = GetUIName(type);
				genericMenu.AddItem(new GUIContent(uiName), false, () =>
				{
					Type serializedActionType = SerializedActionTypesCollection.GetSerializedActionType(type);
					ScriptableObject instance = CreateInstance(serializedActionType);
					instance.name = uiName.Replace(" ", string.Empty);

					AssetDatabase.AddObjectToAsset(instance, target);

					int index = actionsProperty.arraySize++;
					actionsProperty.GetArrayElementAtIndex(index).objectReferenceValue = instance;
					++considerationIndicesProperty.arraySize;
					considerationIndicesProperty.GetArrayElementAtIndex(considerationIndicesProperty.arraySize - 1)
						.FindPropertyRelative(ConsiderationsPropertyName).ClearArray();

					serializedObject.ApplyModifiedProperties();
					AssetDatabase.SaveAssets();
				});
			}

			genericMenu.ShowAsContext();
		}

		private static void RemoveConsiderationIndex(SerializedProperty considerationIndices, int index)
		{
			for (int actionIndex = 0, actionCount = considerationIndices.arraySize;
				actionIndex < actionCount;
				++actionIndex)
			{
				SerializedProperty considerations = considerationIndices.GetArrayElementAtIndex(actionIndex)
					.FindPropertyRelative(ConsiderationsPropertyName);

				for (int considerationIndex = 0, considerationCount = considerations.arraySize;
					considerationIndex < considerationCount;
					++considerationIndex)
				{
					int consideration = considerations.GetArrayElementAtIndex(considerationIndex).intValue;

					if (consideration > index)
					{
						--considerations.GetArrayElementAtIndex(considerationIndex).intValue;
					}
					else if (consideration == index)
					{
						SerializedPropertyHelper.CompletelyRemove(considerations, considerationIndex);
						--considerationIndex;
						considerationCount = considerations.arraySize;
					}
				}
			}
		}

		private void MakeConsiderationsMenu(SerializedProperty considerations, SerializedProperty considerationsProperty)
		{
			for (int i = 0, count = considerations.arraySize; i < count; ++i)
			{
				EditorGUILayout.BeginHorizontal(GUI.skin.box);

				var consideration = (SerializedConsideration_Base)considerationsProperty
					.GetArrayElementAtIndex(considerations.GetArrayElementAtIndex(i).intValue).objectReferenceValue;

				EditorGUILayout.LabelField($"{consideration.name} : {GetUIName(consideration.considerationType)}");

				if (GUILayout.Button("X", GUILayout.Width(20f)))
				{
					SerializedPropertyHelper.CompletelyRemove(considerations, i);
					--i;
					count = considerations.arraySize;

					serializedObject.ApplyModifiedProperties();
					AssetDatabase.SaveAssets();
				}

				EditorGUILayout.EndHorizontal();
			}

			if (GUILayout.Button("Add Consideration"))
			{
				var genericMenu = new GenericMenu();

				for (int i = 0, count = considerationsProperty.arraySize; i < count; ++i)
				{
					if (HasValue(considerations, i))
					{
						continue;
					}

					int index = i;
					var consideration =
						(SerializedConsideration_Base)considerationsProperty.GetArrayElementAtIndex(index)
							.objectReferenceValue;

					genericMenu.AddItem(new GUIContent($"{consideration.name} : {GetUIName(consideration.considerationType)}"), false,
						() =>
						{
							int addIndex = considerations.arraySize++;
							considerations.GetArrayElementAtIndex(addIndex).intValue = index;

							serializedObject.ApplyModifiedProperties();
							AssetDatabase.SaveAssets();
						});
				}

				genericMenu.ShowAsContext();
			}
		}

		private static bool HasValue(SerializedProperty property, int value)
		{
			for (int i = 0, count = property.arraySize; i < count; ++i)
			{
				if (property.GetArrayElementAtIndex(i).intValue == value)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Transforms a type name. The method inserts spaces between words and adds generic argument types.
		/// </summary>
		/// <param name="type">Type.</param>
		/// <returns>Transformed type name.</returns>
		[NotNull]
		public static string GetUIName([NotNull] Type type)
		{
			if (!type.IsGenericType)
			{
				// "object" name not to confuse it with UnityEngine.Object.
				return type == typeof(object) ? "object" : GetNameWithSpaces(type.Name);
			}

			string genericName = type.Name;
			genericName = genericName[..genericName.IndexOf("`", StringComparison.Ordinal)];
			var stringBuilder = new StringBuilder(GetNameWithSpaces(genericName));
			stringBuilder.Append(" <");

			Type[] genericParameters = type.GetGenericArguments();

			for (int i = 0, count = genericParameters.Length; i < count; ++i)
			{
				stringBuilder.Append(GetUIName(genericParameters[i]));

				if (i < count - 1)
				{
					stringBuilder.Append(", ");
				}
			}

			stringBuilder.Append('>');

			return stringBuilder.ToString();
		}

		[NotNull]
		private static string GetNameWithSpaces([NotNull] string typeName)
		{
			return Regex.Replace(typeName, @"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))", " $0");
		}
	}
}
