﻿// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	/// <summary>
	/// <para>
	/// Sets a struct value into the <see cref="Blackboard"/>.
	/// </para>
	/// <para>
	/// <list type="number">
	/// 	<listheader>
	/// 		<term>Setup arguments:</term>
	/// 	</listheader>
	/// 	<item>
	/// 		<description>Struct value of type <typeparamref name="T"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Target property name.</description>
	/// 	</item>
	/// </list>
	/// </para>
	/// </summary>
	public sealed class SetStructValueAction<T> : Action,
		ISetupable<T, BlackboardPropertyName>,
		ISetupable<T, string>
		where T : struct
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

			blackboard.SetStructValue(m_propertyName, m_value);
		}
	}
}
