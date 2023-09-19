// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Zor.UtilityAI.DrawingAttributes;

namespace Zor.UtilityAI.CustomEditors
{
	[CustomPropertyDrawer(typeof(NameOverridenAttribute))]
	public sealed class NameOverridenAttributeEditor : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			string name = GetName(property);

			if (name != null)
			{
				label.text = name;
			}

			EditorGUI.PropertyField(position, property, label);
		}

		public override VisualElement CreatePropertyGUI(SerializedProperty property)
		{
			string name = GetName(property);

			return name != null ? new PropertyField(property, name) : new PropertyField(property);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label);
		}

		private string GetName(SerializedProperty property)
		{
			var nameOverriden = (NameOverridenAttribute)attribute;
			NameOverrideAttribute[] nameOverrides = property.serializedObject.targetObject.GetType()
				.GetCustomAttributes<NameOverrideAttribute>().ToArray();

			for (int i = 0, count = nameOverrides.Length; i < count; ++i)
			{
				NameOverrideAttribute nameOverride = nameOverrides[i];

				if (nameOverride.index == nameOverriden.index)
				{
					return nameOverride.name;
				}
			}

			return null;
		}
	}
}
