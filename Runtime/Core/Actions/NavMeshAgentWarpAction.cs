// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using UnityEngine.AI;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public sealed class NavMeshAgentWarpAction : Action
	{
		private readonly BlackboardPropertyName m_agentPropertyName;
		private readonly BlackboardPropertyName m_destinationPropertyName;

		public NavMeshAgentWarpAction(BlackboardPropertyName agentPropertyName,
			BlackboardPropertyName destinationPropertyName)
		{
			m_agentPropertyName = agentPropertyName;
			m_destinationPropertyName = destinationPropertyName;
		}

		protected override void OnBegin()
		{
			base.OnBegin();

			if (!(blackboard.TryGetClassValue(m_agentPropertyName, out NavMeshAgent agent) &
					blackboard.TryGetStructValue(m_destinationPropertyName, out Vector3 destination) &
					agent != null))
			{
				return;
			}

			agent.Warp(destination);
		}
	}
}
