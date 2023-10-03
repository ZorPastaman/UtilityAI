// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using JetBrains.Annotations;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Builder
{
	/// <summary>
	/// Interface for <see cref="Consideration"/> builders.
	/// </summary>
	internal interface IConsiderationBuilder
	{
		/// <summary>
		/// Built <see cref="Consideration"/> type.
		/// </summary>
		[NotNull]
		Type considerationType { get; }

		/// <summary>
		/// Builds a <see cref="Consideration"/>.
		/// </summary>
		/// <returns>Built <see cref="Consideration"/>.</returns>
		[NotNull]
		Consideration Build();

		/// <summary>
		/// Are consideration parameters equal to <paramref name="parameters"/>.
		/// </summary>
		/// <param name="parameters"></param>
		/// <returns>True if they're equal; false otherwise.</returns>
		bool AreEqual([CanBeNull, ItemCanBeNull] object[] parameters);
	}
}
