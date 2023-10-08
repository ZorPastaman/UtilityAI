// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using UnityEngine.AI;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	/// <summary>
	/// <para>
	/// Makes a <see cref="NavMeshAgent"/> go to a position.
	/// </para>
	/// <para>
	/// <list type="number">
	/// 	<listheader>
	/// 		<term>Setup arguments:</term>
	/// 	</listheader>
	/// 	<item>
	/// 		<description>Property name of an agent of type <see cref="NavMeshAgent"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Property name of a position of type <see cref="Vector3"/>.</description>
	/// 	</item>
	/// </list>
	/// </para>
	/// </summary>
	public sealed class NavMeshAgentGoToAction : Action,
		ISetupable<BlackboardPropertyName, BlackboardPropertyName>,
		ISetupable<string, string>
	{
		private BlackboardPropertyName m_agentPropertyName;
		private BlackboardPropertyName m_targetPropertyName;

		private NavMeshAgent m_agent;

		void ISetupable<BlackboardPropertyName, BlackboardPropertyName>.Setup(BlackboardPropertyName agentPropertyName,
			BlackboardPropertyName targetPropertyName)
		{
			m_agentPropertyName = agentPropertyName;
			m_targetPropertyName = targetPropertyName;
		}

		void ISetupable<string, string>.Setup(string agentPropertyName, string targetPropertyName)
		{
			m_agentPropertyName = new BlackboardPropertyName(agentPropertyName);
			m_targetPropertyName = new BlackboardPropertyName(targetPropertyName);
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
