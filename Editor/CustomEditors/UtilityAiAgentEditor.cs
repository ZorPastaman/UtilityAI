// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using UnityEditor;
using Zor.UtilityAI.Components;
using Zor.UtilityAI.Debugging;

namespace Zor.UtilityAI.CustomEditors
{
	[CustomEditor(typeof(UtilityAIAgent))]
	public sealed class UtilityAiAgentEditor : Editor
	{
		[NotNull] private readonly BrainDebugInfo m_info = new();
		private bool m_debugFoldout;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			m_debugFoldout = EditorGUILayout.Foldout(m_debugFoldout, "Debug");
			if (m_debugFoldout)
			{
				((UtilityAIAgent)target).FillDebugInfo(m_info);

				EditorGUILayout.LabelField("Minimal Utility Difference",
					m_info.brainSettings.minimalUtilityDifference.ToString(CultureInfo.CurrentCulture));

				EditorGUILayout.Separator();

				List<BrainDebugInfo.ActionInfo> actionInfos = m_info.actionInfos;
				for (int actionIndex = 0, actionCount = actionInfos.Count; actionIndex < actionCount; ++actionIndex)
				{
					BrainDebugInfo.ActionInfo actionInfo = actionInfos[actionIndex];

					EditorGUILayout.BeginHorizontal();

					EditorGUILayout.LabelField($"{actionInfo.name} : {actionInfo.utility}");

					if (actionInfo.isActive)
					{
						EditorGUILayout.LabelField("Active");
					}

					EditorGUILayout.EndHorizontal();

					++EditorGUI.indentLevel;

					List<BrainDebugInfo.ConsiderationInfo> considerationInfos = actionInfo.considerationInfos;

					for (int considerationIndex = 0, considerationCount = considerationInfos.Count;
						considerationIndex < considerationCount;
						++considerationIndex)
					{
						BrainDebugInfo.ConsiderationInfo considerationInfo = considerationInfos[considerationIndex];
						EditorGUILayout.LabelField($"{considerationInfo.name} : {considerationInfo.utility}");
					}

					--EditorGUI.indentLevel;

					EditorGUILayout.Separator();
				}
			}
		}
	}
}
