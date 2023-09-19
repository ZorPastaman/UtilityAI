// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using Zor.UtilityAI.Core.Considerations;
using Zor.UtilityAI.DrawingAttributes;

namespace Zor.UtilityAI.Serialization.SerializedConsiderations
{
	[NameOverride("Slope", 0), NameOverride("Vertical Shift", 1), NameOverride("Horizontal Shift", 2),
	NameOverride("Value Property Name", 3)]
	public sealed class SerializedLinearConsideration : SerializedConsideration<LinearConsideration, float, float, float, string>
	{
	}
}
