// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using Zor.UtilityAI.Core.Considerations;
using Zor.UtilityAI.DrawingAttributes;

namespace Zor.UtilityAI.Serialization.SerializedConsiderations
{
	[NameOverride("Utility", 0)]
	public sealed class SerializedConstantConsideration : SerializedConsideration<ConstantConsideration, float>
	{
	}
}
