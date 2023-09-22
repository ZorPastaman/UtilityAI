// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Zor.UtilityAI.Debugging
{
	/// <summary>
	/// Class for logging the utility ai system.
	/// </summary>
	public static class UtilityAIDebug
	{
		/// <summary>
		/// If it's defined, the utility ai system's logs are logged.
		/// </summary>
		public const string LogDefine = "UTILITY_AI_LOG";

		/// <summary>
		/// If it's defined, the utility ai system's warnings are logged.
		/// </summary>
		public const string WarningDefine = "UTILITY_AI_WARNING";

		/// <summary>
		/// If it's defined, the utility ai system's errors are logged.
		/// </summary>
		public const string ErrorDefine = "UTILITY_AI_ERROR";

		private const string Format = "[UtilityAI] {0}.";

		[Conditional(LogDefine), MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Log(string message)
		{
			Debug.LogFormat(Format, message);
		}

		[Conditional(WarningDefine), MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void LogWarning(string message)
		{
			Debug.LogWarningFormat(Format, message);
		}

		[Conditional(WarningDefine), MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void LogWarning(Object context, string message)
		{
			Debug.LogWarningFormat(context, Format, message);
		}

		[Conditional(ErrorDefine), MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void LogError(string message)
		{
			Debug.LogErrorFormat(Format, message);
		}

		[Conditional(ErrorDefine), MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void LogError(Object context, string message)
		{
			Debug.LogErrorFormat(context, Format, message);
		}
	}
}
