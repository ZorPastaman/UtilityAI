// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using UnityEngine.Profiling;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Core;
using Action = Zor.UtilityAI.Core.Action;

namespace Zor.UtilityAI.Builder
{
	public sealed class BrainBuilder
	{
		[NotNull] private readonly List<IActionBuilder> m_actionBuilders = new();
		[NotNull] private readonly List<IConsiderationBuilder> m_considerationBuilders = new();
		[NotNull] private readonly List<List<int>> m_actionConsiderationsBindings = new();

		[NotNull] private readonly List<int>[] m_fastConsiderationsLookup = new List<int>[9]
		{
			new(), new(), new(), new(), new(), new(), new(), new(), new()
		};

		public void AddAction<TAction>([NotNull] string name = "") where TAction : Action, INotSetupable, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction>(name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddAction<TAction, TArg>([CanBeNull] TArg arg, [NotNull] string name = "") where TAction : Action, ISetupable<TArg>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg>(arg, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddAction<TAction, TArg0, TArg1>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1>(arg0, arg1, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2>(arg0, arg1, arg2, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3>(arg0, arg1, arg2, arg3, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>(arg0, arg1, arg2, arg3, arg4, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(arg0, arg1, arg2, arg3, arg4, arg5, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddAction([NotNull] Type actionType, string name = "",
			[CanBeNull, ItemCanBeNull] params object[] parameters)
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(actionType.FullName);

			m_actionBuilders.Add(new ActionBuilder(actionType, parameters, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration<TConsideration>([NotNull] string name = "") where TConsideration : Consideration, INotSetupable, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			List<int> considerationsLookup = m_fastConsiderationsLookup[0];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];

				if (m_considerationBuilders[considerationIndex] is ConsiderationBuilder<TConsideration>)
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration>(name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration<TConsideration, TArg>([CanBeNull] TArg arg, [NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			List<int> considerationsLookup = m_fastConsiderationsLookup[1];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];

				if (m_considerationBuilders[considerationIndex] is ConsiderationBuilder<TConsideration, TArg> considerationBuilder &&
					EqualityComparer<TArg>.Default.Equals(considerationBuilder.arg, arg))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg>(arg, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration<TConsideration, TArg0, TArg1>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			List<int> considerationsLookup = m_fastConsiderationsLookup[2];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];

				if (m_considerationBuilders[considerationIndex] is ConsiderationBuilder<TConsideration, TArg0, TArg1> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1>(arg0, arg1, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			List<int> considerationsLookup = m_fastConsiderationsLookup[3];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];

				if (m_considerationBuilders[considerationIndex] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2>(arg0, arg1, arg2, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			List<int> considerationsLookup = m_fastConsiderationsLookup[4];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];

				if (m_considerationBuilders[considerationIndex] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3>(arg0, arg1, arg2, arg3, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			List<int> considerationsLookup = m_fastConsiderationsLookup[5];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];

				if (m_considerationBuilders[considerationIndex] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3) &&
					EqualityComparer<TArg4>.Default.Equals(considerationBuilder.arg4, arg4))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>(arg0, arg1, arg2, arg3, arg4, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			List<int> considerationsLookup = m_fastConsiderationsLookup[6];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];

				if (m_considerationBuilders[considerationIndex] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3) &&
					EqualityComparer<TArg4>.Default.Equals(considerationBuilder.arg4, arg4) &&
					EqualityComparer<TArg5>.Default.Equals(considerationBuilder.arg5, arg5))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(arg0, arg1, arg2, arg3, arg4, arg5, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			List<int> considerationsLookup = m_fastConsiderationsLookup[7];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];

				if (m_considerationBuilders[considerationIndex] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3) &&
					EqualityComparer<TArg4>.Default.Equals(considerationBuilder.arg4, arg4) &&
					EqualityComparer<TArg5>.Default.Equals(considerationBuilder.arg5, arg5) &&
					EqualityComparer<TArg6>.Default.Equals(considerationBuilder.arg6, arg6))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			List<int> considerationsLookup = m_fastConsiderationsLookup[8];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];

				if (m_considerationBuilders[considerationIndex] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3) &&
					EqualityComparer<TArg4>.Default.Equals(considerationBuilder.arg4, arg4) &&
					EqualityComparer<TArg5>.Default.Equals(considerationBuilder.arg5, arg5) &&
					EqualityComparer<TArg6>.Default.Equals(considerationBuilder.arg6, arg6) &&
					EqualityComparer<TArg7>.Default.Equals(considerationBuilder.arg7, arg7))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		public void AddConsideration([NotNull] Type considerationType, [NotNull] string name ="",
			[CanBeNull, ItemCanBeNull] params object[] parameters)
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(considerationType.FullName);

			int count = m_considerationBuilders.Count;
			m_actionConsiderationsBindings[^1].Add(count);
			m_considerationBuilders.Add(new ConsiderationBuilder(considerationType, parameters, name));

			Profiler.EndSample();
			Profiler.EndSample();
		}

		[NotNull]
		public Brain Build(BrainSettings brainSettings)
		{
			Profiler.BeginSample("BrainBuilder.Build");

			Brain brain = Build(new Blackboard(), brainSettings);

			Profiler.EndSample();

			return brain;
		}

		[NotNull]
		public Brain Build([NotNull] Blackboard blackboard, BrainSettings brainSettings)
		{
			Profiler.BeginSample("BrainBuilder.Build");

			Consideration[] considerations = MakeConsiderations();
			Action[] actions = MakeActions();
			int[][] actionConsiderationsBindings = MakeActionConsiderationsBindings();

			var brain = new Brain(considerations, actions, actionConsiderationsBindings, blackboard, brainSettings);

			Profiler.EndSample();

			return brain;
		}

		[NotNull, ItemNotNull]
		private Consideration[] MakeConsiderations()
		{
			int count = m_considerationBuilders.Count;
			var considerations = new Consideration[count];

			for (int i = 0; i < count; ++i)
			{
				considerations[i] = m_considerationBuilders[i].Build();
			}

			return considerations;
		}

		[NotNull, ItemNotNull]
		private Action[] MakeActions()
		{
			int count = m_actionBuilders.Count;
			var actions = new Action[count];

			for (int i = 0; i < count; ++i)
			{
				actions[i] = m_actionBuilders[i].Build();
			}

			return actions;
		}

		[NotNull]
		private int[][] MakeActionConsiderationsBindings()
		{
			int count = m_actionConsiderationsBindings.Count;
			int[][] bindings = new int[count][];

			for (int i = 0; i < count; ++i)
			{
				bindings[i] = m_actionConsiderationsBindings[i].ToArray();
			}

			return bindings;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("BrainBuilder");

			for (int actionIndex = 0, actionCount = m_actionConsiderationsBindings.Count;
				actionIndex < actionCount;
				++actionIndex)
			{
				stringBuilder.AppendLine($"\t{m_actionBuilders[actionIndex]}");

				List<int> considerationIndices = m_actionConsiderationsBindings[actionIndex];

				for (int considerationIndex = 0, considerationCount = considerationIndices.Count;
					considerationIndex < considerationCount;
					++considerationIndex)
				{
					stringBuilder.AppendLine(
						$"\t\t{m_considerationBuilders[considerationIndices[considerationIndex]]}");
				}
			}

			return stringBuilder.ToString();
		}
	}
}
