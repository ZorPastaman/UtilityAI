// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public abstract class SetStructValueAction<T> : Action where T : struct
	{
		private readonly T m_value;
		private readonly BlackboardPropertyName m_propertyName;

		protected SetStructValueAction(T value, BlackboardPropertyName propertyName)
		{
			m_value = value;
			m_propertyName = propertyName;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void OnBegin()
		{
			base.OnBegin();

			blackboard.SetStructValue(m_propertyName, m_value);
		}
	}
}
