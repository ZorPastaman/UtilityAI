﻿// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using Zor.SimpleBlackboard.Components;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.Debugging;
using Zor.UtilityAI.Serialization;

namespace Zor.UtilityAI.Components
{
	[AddComponentMenu("Utility AI/Utility AI Agent")]
	public sealed class UtilityAIAgent : MonoBehaviour
	{
		[SerializeField, Tooltip("Serialized brain. It's automatically deserialized on Awake.")]
		private SerializedBrain_Base m_SerializedBrain;
		[SerializeField, Tooltip("Blackboard container. It's used as a blackboard for the behavior tree.")]
		private SimpleBlackboardContainer m_BlackboardContainer;

		private Brain m_brain;

		public void Tick()
		{
			m_brain.Tick();
		}

		[ContextMenu("Recreate Brain")]
		public void RecreateBrain()
		{
			Awake();
		}

		private void Awake()
		{
#if DEBUG
			if (m_SerializedBrain == null)
			{
				UtilityAIDebug.LogError(this, "Serialized brain is null");
				return;
			}

			if (m_BlackboardContainer == null)
			{
				UtilityAIDebug.LogError(this, "Blackboard container is null");
				return;
			}
#endif

			m_brain = m_SerializedBrain.CreateBrain(m_BlackboardContainer.blackboard);
			m_brain.Initialize();
		}

		private void OnDestroy()
		{
			m_brain?.Dispose();
		}
	}
}