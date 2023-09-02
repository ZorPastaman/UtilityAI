// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core
{
	public sealed class Brain : IDisposable
	{
		[NotNull, ItemNotNull] private readonly Consideration[] m_considerations;
		[NotNull, ItemNotNull] private readonly Action[] m_actions;
		[NotNull] private readonly Blackboard m_blackboard;

		[NotNull] private readonly float[] m_utilities;
		[NotNull] private readonly float[] m_actionUtilities;
		[NotNull] private readonly int[][] m_actionConsiderationsBindings;

		private int m_currentActionIndex;

		public Brain([NotNull, ItemNotNull] Consideration[] considerations, [NotNull, ItemNotNull] Action[] actions,
			[NotNull] int[][] actionConsiderationsBindings, [NotNull] Blackboard blackboard)
		{
			m_considerations = considerations;
			m_actions = actions;
			m_blackboard = blackboard;
			m_actionConsiderationsBindings = actionConsiderationsBindings;

			m_utilities = new float[m_considerations.Length];
			m_actionUtilities = new float[m_actions.Length];

			for (int i = 0, count = m_considerations.Length; i < count; ++i)
			{
				m_considerations[i].SetBlackboard(m_blackboard);
			}

			for (int i = 0, count = m_actions.Length; i < count; ++i)
			{
				m_actions[i].SetBlackboard(m_blackboard);
			}
		}

		[NotNull]
		public Blackboard blackboard
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_blackboard;
		}

		public void Initialize()
		{
			InitializeConsiderations();
			InitializeActions();
			UpdateUtilities();
			UpdateActionUtilities();
			m_currentActionIndex = FindBestActionIndex();
			m_actions[m_currentActionIndex].Begin();
		}

		public void Tick()
		{
			UpdateUtilities();
			UpdateActionUtilities();
			int bestActionIndex = FindBestActionIndex();
			SwitchAction(bestActionIndex);
			m_actions[m_currentActionIndex].Tick();
		}

		public void Dispose()
		{
			DisposeConsiderations();
			DisposeActions();
		}

		private void InitializeConsiderations()
		{
			for (int i = 0, count = m_considerations.Length; i < count; ++i)
			{
				m_considerations[i].Initialize();
			}
		}

		private void InitializeActions()
		{
			for (int i = 0, count = m_actions.Length; i < count; ++i)
			{
				m_actions[i].Initialize();
			}
		}

		private void UpdateUtilities()
		{
			for (int i = 0, count = m_utilities.Length; i < count; ++i)
			{
				m_utilities[i] = m_considerations[i].ComputeUtility();
			}
		}

		private void UpdateActionUtilities()
		{
			for (int i = 0, count = m_actionUtilities.Length; i < count; ++i)
			{
				m_actionUtilities[i] = MultiplyUtilities(i);
			}
		}

		private float MultiplyUtilities(int actionIndex)
		{
			int[] utilityIndices = m_actionConsiderationsBindings[actionIndex];
			float utility = 1f;

			for (int i = 0, count = utilityIndices.Length; i < count; ++i)
			{
				utility *= m_utilities[utilityIndices[i]];
			}

			return utility;
		}

		private int FindBestActionIndex()
		{
			int bestActionIndex = 0;
			float bestActionUtility = m_actionUtilities[bestActionIndex];

			for (int i = 1, count = m_actionUtilities.Length; i < count; ++i)
			{
				float actionUtility = m_actionUtilities[i];

				if (actionUtility > bestActionUtility)
				{
					bestActionIndex = i;
					bestActionUtility = actionUtility;
				}
			}

			return bestActionIndex;
		}

		private void SwitchAction(int newActionIndex)
		{
			if (m_currentActionIndex == newActionIndex)
			{
				return;
			}

			m_actions[m_currentActionIndex].End();
			m_currentActionIndex = newActionIndex;
			m_actions[m_currentActionIndex].Begin();
		}

		private void DisposeConsiderations()
		{
			for (int i = 0, count = m_considerations.Length; i < count; ++i)
			{
				m_considerations[i].Dispose();
			}
		}

		private void DisposeActions()
		{
			for (int i = 0, count = m_actions.Length; i < count; ++i)
			{
				m_actions[i].Dispose();
			}
		}
	}
}
