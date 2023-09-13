// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using UnityEngine.AI;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public sealed class NavMeshAgentFollowAction : Action
	{
		private readonly BlackboardPropertyName m_agentPropertyName;
		private readonly BlackboardPropertyName m_targetPropertyName;

		private NavMeshAgent m_agent;
		private Transform m_target;

		public NavMeshAgentFollowAction(BlackboardPropertyName agentPropertyName,
			BlackboardPropertyName targetPropertyName)
		{
			m_agentPropertyName = agentPropertyName;
			m_targetPropertyName = targetPropertyName;
		}

		protected override void OnBegin()
		{
			base.OnBegin();

			blackboard.TryGetClassValue(m_agentPropertyName, out m_agent);
			blackboard.TryGetClassValue(m_targetPropertyName, out m_target);
		}

		protected override void OnTick()
		{
			base.OnTick();

			if (m_agent != null & m_target != null)
			{
				m_agent.SetDestination(m_target.position);
			}
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
