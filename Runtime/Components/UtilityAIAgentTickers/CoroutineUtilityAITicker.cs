// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Collections;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAIAgentTickers
{
	public abstract class CoroutineUtilityAITicker : UtilityAITicker
	{
		/// <summary>
		/// Instruction that is processed before each tick.
		/// </summary>
		[CanBeNull] private YieldInstruction m_instruction;
		/// <summary>
		/// Current coroutine.
		/// </summary>
		[CanBeNull] private Coroutine m_process;

		/// <summary>
		/// Instruction that is processed before each tick.
		/// </summary>
		/// <remarks>
		/// It's called on Awake, OnValidate and <see cref="UpdateInstruction"/>
		/// and the result is set to the private field.
		/// </remarks>
		[CanBeNull]
		protected abstract YieldInstruction instruction { get; }

		/// <summary>
		/// Updates instruction. It calls <see cref="instruction"/>.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining), ContextMenu("Update Instruction")]
		protected void UpdateInstruction()
		{
			m_instruction = instruction;
		}

		protected override void OnValidate()
		{
			m_instruction = instruction;
		}

		private void Awake()
		{
			m_instruction = instruction;
		}

		protected override void OnEnable()
		{
			base.OnEnable();

			if (!enabled)
			{
				return;
			}

			m_process = StartCoroutine(Process());
		}

		private void OnDisable()
		{
			if (m_process != null)
			{
				StopCoroutine(m_process);
				m_process = null;
			}
		}

		private IEnumerator Process()
		{
			while (true)
			{
				yield return m_instruction;
				Tick();
			}
		}
	}
}
