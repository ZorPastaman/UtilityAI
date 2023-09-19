// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using Zor.UtilityAI.Core.Considerations;
using Zor.UtilityAI.DrawingAttributes;

namespace Zor.UtilityAI.Serialization.SerializedConsiderations
{
	[NameOverride("Curve", 0), NameOverride("Value Property Name", 1)]
	public sealed class SerializedCurveConsideration : SerializedConsideration<CurveConsideration, AnimationCurve, string>
	{
	}
}
