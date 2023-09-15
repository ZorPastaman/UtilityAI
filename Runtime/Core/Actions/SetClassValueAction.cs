// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public abstract class SetClassValueAction<T> : Action,
		ISetupable<T, BlackboardPropertyName>,
		ISetupable<T, string>
		where T : class
	{
		private T m_value;
		private BlackboardPropertyName m_propertyName;

		void ISetupable<T, BlackboardPropertyName>.Setup(T value, BlackboardPropertyName propertyName)
		{
			m_value = value;
			m_propertyName = propertyName;
		}

		void ISetupable<T, string>.Setup(T value, string propertyName)
		{
			m_value = value;
			m_propertyName = new BlackboardPropertyName(propertyName);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void OnBegin()
		{
			base.OnBegin();

			blackboard.SetClassValue(m_propertyName, m_value);
		}
	}
}
