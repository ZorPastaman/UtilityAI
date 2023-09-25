// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine.Profiling;
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

		private readonly BrainSettings m_brainSettings;

		private int m_currentActionIndex;

		public Brain([NotNull, ItemNotNull] Consideration[] considerations, [NotNull, ItemNotNull] Action[] actions,
			[NotNull] int[][] actionConsiderationsBindings, [NotNull] Blackboard blackboard,
			BrainSettings brainSettings)
		{
			m_considerations = considerations;
			m_actions = actions;
			m_blackboard = blackboard;
			m_actionConsiderationsBindings = actionConsiderationsBindings;
			m_brainSettings = brainSettings;

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
			Profiler.BeginSample("Brain.Initialize");

			InitializeConsiderations();
			InitializeActions();
			UpdateUtilities();
			UpdateActionUtilities();
			m_currentActionIndex = FindBestActionIndex();
			m_actions[m_currentActionIndex].Begin();

			Profiler.EndSample();
		}

		public void Tick()
		{
			Profiler.BeginSample("Brain.Tick");

			UpdateUtilities();
			UpdateActionUtilities();
			int bestActionIndex = FindBestActionIndex();
			SwitchAction(bestActionIndex);
			m_actions[m_currentActionIndex].Tick();

			Profiler.EndSample();
		}

		public void Dispose()
		{
			Profiler.BeginSample("Brain.Dispose");

			DisposeConsiderations();
			DisposeActions();

			Profiler.EndSample();
		}

		private void InitializeConsiderations()
		{
			Profiler.BeginSample("Brain.InitializeConsiderations");

			for (int i = 0, count = m_considerations.Length; i < count; ++i)
			{
				m_considerations[i].Initialize();
			}

			Profiler.EndSample();
		}

		private void InitializeActions()
		{
			Profiler.BeginSample("Brain.InitializeActions");

			for (int i = 0, count = m_actions.Length; i < count; ++i)
			{
				m_actions[i].Initialize();
			}

			Profiler.EndSample();
		}

		private void UpdateUtilities()
		{
			Profiler.BeginSample("Brain.UpdateUtilities");

			for (int i = 0, count = m_utilities.Length; i < count; ++i)
			{
				Consideration consideration = m_considerations[i];

				Profiler.BeginSample(consideration.GetType().FullName);

				m_utilities[i] = consideration.ComputeUtility();

				Profiler.EndSample();
			}

			Profiler.EndSample();
		}

		private void UpdateActionUtilities()
		{
			Profiler.BeginSample("Brain.UpdateActionUtilities");

			for (int i = 0, count = m_actionUtilities.Length; i < count; ++i)
			{
				m_actionUtilities[i] = MultiplyUtilities(i);
			}

			Profiler.EndSample();
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
			Profiler.BeginSample("Brain.FindBestActionIndex");

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

			Profiler.EndSample();

			return bestActionIndex;
		}

		private void SwitchAction(int newActionIndex)
		{
			Profiler.BeginSample("Brain.TrySwitchAction");

			if (m_currentActionIndex == newActionIndex)
			{
				return;
			}

			float currentUtility = m_actionUtilities[m_currentActionIndex];
			float newUtility = m_actionUtilities[newActionIndex];

			if (newUtility - currentUtility < m_brainSettings.minimalUtilityDifference)
			{
				return;
			}

			Profiler.BeginSample("Brain.SwitchAction");

			m_actions[m_currentActionIndex].End();
			m_currentActionIndex = newActionIndex;
			m_actions[m_currentActionIndex].Begin();

			Profiler.EndSample();
			Profiler.EndSample();
		}

		private void DisposeConsiderations()
		{
			Profiler.BeginSample("Brain.DisposeConsiderations");

			for (int i = 0, count = m_considerations.Length; i < count; ++i)
			{
				m_considerations[i].Dispose();
			}

			Profiler.EndSample();
		}

		private void DisposeActions()
		{
			Profiler.BeginSample("Brain.DisposeActions");

			for (int i = 0, count = m_actions.Length; i < count; ++i)
			{
				m_actions[i].Dispose();
			}

			Profiler.EndSample();
		}
	}
}
