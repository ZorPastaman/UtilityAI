// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using UnityEngine.AI;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	/// <summary>
	/// <para>
	/// Makes a <see cref="NavMeshAgent"/> warp to a destination.
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
	/// 		<description>Property name of a destination of type <see cref="Vector3"/>.</description>
	/// 	</item>
	/// </list>
	/// </para>
	/// </summary>
	public sealed class NavMeshAgentWarpAction : Action,
		ISetupable<BlackboardPropertyName, BlackboardPropertyName>,
		ISetupable<string, string>
	{
		private BlackboardPropertyName m_agentPropertyName;
		private BlackboardPropertyName m_destinationPropertyName;

		void ISetupable<BlackboardPropertyName, BlackboardPropertyName>.Setup(BlackboardPropertyName agentPropertyName,
			BlackboardPropertyName destinationPropertyName)
		{
			m_agentPropertyName = agentPropertyName;
			m_destinationPropertyName = destinationPropertyName;
		}

		void ISetupable<string, string>.Setup(string agentPropertyName, string destinationPropertyName)
		{
			m_agentPropertyName = new BlackboardPropertyName(agentPropertyName);
			m_destinationPropertyName = new BlackboardPropertyName(destinationPropertyName);
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
