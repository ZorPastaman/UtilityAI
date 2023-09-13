// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using UnityEngine.AI;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public sealed class NavMeshAgentGoToAction : Action
	{
		private readonly BlackboardPropertyName m_agentPropertyName;
		private readonly BlackboardPropertyName m_targetPropertyName;

		private NavMeshAgent m_agent;

		public NavMeshAgentGoToAction(BlackboardPropertyName agentPropertyName,
			BlackboardPropertyName targetPropertyName)
		{
			m_agentPropertyName = agentPropertyName;
			m_targetPropertyName = targetPropertyName;
		}

		protected override void OnBegin()
		{
			base.OnBegin();

			if (!(blackboard.TryGetClassValue(m_agentPropertyName, out m_agent) &
					blackboard.TryGetStructValue(m_targetPropertyName, out Vector3 target) &
					m_agent != null))
			{
				return;
			}

			m_agent.SetDestination(target);
		}

		protected override void OnEnd()
		{
			base.OnEnd();

			if (m_agent != null)
			{
				m_agent.ResetPath();
			}
		}
	}
}
