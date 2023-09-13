// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public sealed class SetFloatAction : SetStructValueAction<float>
	{
		public SetFloatAction(float value, BlackboardPropertyName propertyName) : base(value, propertyName)
		{
		}
	}
}
