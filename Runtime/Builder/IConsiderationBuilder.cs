// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using JetBrains.Annotations;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Builder
{
	internal interface IConsiderationBuilder
	{
		[NotNull]
		Type considerationType { get; }

		[NotNull]
		public Consideration Build();
	}
}
