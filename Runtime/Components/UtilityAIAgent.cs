// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using Zor.SimpleBlackboard.Components;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Components
{
	[AddComponentMenu("Utility AI/Utility AI Agent")]
	public sealed class UtilityAIAgent : MonoBehaviour
	{
		[SerializeField, Tooltip("Blackboard container. It's used as a blackboard for the behavior tree.")]
		private SimpleBlackboardContainer m_BlackboardContainer;

		private Brain m_brain;

		public void Tick()
		{
			m_brain.Tick();
		}

		private void Awake()
		{
			var builder = new BrainBuilder();
			m_brain = builder.Build(m_BlackboardContainer.blackboard);
			m_brain.Initialize();
		}

		private void OnDestroy()
		{
			m_brain.Dispose();
		}
	}
}
