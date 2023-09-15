// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public sealed class NavMeshAgentPatrolAction : Action,
		ISetupable<BlackboardPropertyName, BlackboardPropertyName>,
		ISetupable<string, string>
	{
		private BlackboardPropertyName m_agentPropertyName;
		private BlackboardPropertyName m_cornersPropertyName;

		private NavMeshAgent m_agent;
		private Vector3[] m_corners;

		private int m_currentCornerIndex;

		void ISetupable<BlackboardPropertyName, BlackboardPropertyName>.Setup(BlackboardPropertyName agentPropertyName,
			BlackboardPropertyName cornersPropertyName)
		{
			m_agentPropertyName = agentPropertyName;
			m_cornersPropertyName = cornersPropertyName;
		}

		void ISetupable<string, string>.Setup(string agentPropertyName, string cornersPropertyName)
		{
			m_agentPropertyName = new BlackboardPropertyName(agentPropertyName);
			m_cornersPropertyName = new BlackboardPropertyName(cornersPropertyName);
		}

		protected override void OnBegin()
		{
			base.OnBegin();

			if (blackboard.TryGetClassValue(m_agentPropertyName, out m_agent) & m_agent != null &
				blackboard.TryGetClassValue(m_cornersPropertyName, out m_corners) & m_corners != null)
			{
				m_currentCornerIndex = GetClosestCorner(m_agent, m_corners);
				m_agent.SetDestination(m_corners[m_currentCornerIndex]);
			}
		}

		protected override void OnTick()
		{
			base.OnTick();

			if (m_agent != null & m_corners != null)
			{
				if (!m_agent.pathPending && m_agent.remainingDistance <= m_agent.radius)
				{
					m_currentCornerIndex = GetNextCorner();
				}
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

		private static int GetClosestCorner([NotNull] NavMeshAgent agent, [NotNull] Vector3[] corners)
		{
			Vector3 agentPosition = agent.transform.position;
			float sqrLength = float.MaxValue;
			int index = 0;

			for (int i = 0, count = corners.Length; i < count; ++i)
			{
				Vector3 corner = corners[i];
				float sqrMagnitude = (corner - agentPosition).sqrMagnitude;

				if (sqrMagnitude < sqrLength)
				{
					sqrLength = sqrMagnitude;
					index = i;
				}
			}

			return index;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetNextCorner()
		{
			return (m_currentCornerIndex + 1) % m_corners.Length;
		}
	}
}
