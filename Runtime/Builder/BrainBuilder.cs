// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Builder
{
	public sealed class BrainBuilder
	{
		private readonly List<IActionBuilder> m_actionBuilders = new();
		private readonly List<IConsiderationBuilder> m_considerationBuilders = new();
		private readonly List<List<int>> m_actionConsiderationsBindings = new();

		private readonly List<int>[] m_fastConsiderationsLookup = new List<int>[9]
		{
			new(), new(), new(), new(), new(), new(), new(), new(), new()
		};

		public void AddAction<TAction>() where TAction : Action, INotSetupable, new()
		{
			m_actionBuilders.Add(new ActionBuilder<TAction>());
			m_actionConsiderationsBindings.Add(new List<int>());
		}

		public void AddAction<TAction, TArg>(TArg arg) where TAction : Action, ISetupable<TArg>, new()
		{
			m_actionBuilders.Add(new ActionBuilder<TAction, TArg>(arg));
			m_actionConsiderationsBindings.Add(new List<int>());
		}

		public void AddAction<TAction, TArg0, TArg1>(TArg0 arg0, TArg1 arg1)
			where TAction : Action, ISetupable<TArg0, TArg1>, new()
		{
			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1>(arg0, arg1));
			m_actionConsiderationsBindings.Add(new List<int>());
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2>(TArg0 arg0, TArg1 arg1, TArg2 arg2)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2>(arg0, arg1, arg2));
			m_actionConsiderationsBindings.Add(new List<int>());
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3>(arg0, arg1, arg2, arg3));
			m_actionConsiderationsBindings.Add(new List<int>());
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>(arg0, arg1, arg2, arg3, arg4));
			m_actionConsiderationsBindings.Add(new List<int>());
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(arg0, arg1, arg2, arg3, arg4, arg5));
			m_actionConsiderationsBindings.Add(new List<int>());
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg0, arg1, arg2, arg3, arg4, arg5, arg6));
			m_actionConsiderationsBindings.Add(new List<int>());
		}

		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7));
			m_actionConsiderationsBindings.Add(new List<int>());
		}

		public void AddConsideration<TConsideration>() where TConsideration : Consideration, INotSetupable, new()
		{
			List<int> considerationsLookup = m_fastConsiderationsLookup[0];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				if (m_considerationBuilders[considerationsLookup[i]] is ConsiderationBuilder<TConsideration>)
				{
					sameIndex = i;
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
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration>());
			}
		}

		public void AddConsideration<TConsideration, TArg>(TArg arg)
			where TConsideration : Consideration, ISetupable<TArg>, new()
		{
			List<int> considerationsLookup = m_fastConsiderationsLookup[1];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				if (m_considerationBuilders[considerationsLookup[i]] is ConsiderationBuilder<TConsideration, TArg> considerationBuilder &&
					EqualityComparer<TArg>.Default.Equals(considerationBuilder.arg, arg))
				{
					sameIndex = i;
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
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg>(arg));
			}
		}

		public void AddConsideration<TConsideration, TArg0, TArg1>(TArg0 arg0, TArg1 arg1)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1>, new()
		{
			List<int> considerationsLookup = m_fastConsiderationsLookup[2];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				if (m_considerationBuilders[considerationsLookup[i]] is ConsiderationBuilder<TConsideration, TArg0, TArg1> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1))
				{
					sameIndex = i;
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
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1>(arg0, arg1));
			}
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2>(TArg0 arg0, TArg1 arg1, TArg2 arg2)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			List<int> considerationsLookup = m_fastConsiderationsLookup[3];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				if (m_considerationBuilders[considerationsLookup[i]] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2))
				{
					sameIndex = i;
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
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2>(arg0, arg1, arg2));
			}
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			List<int> considerationsLookup = m_fastConsiderationsLookup[4];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				if (m_considerationBuilders[considerationsLookup[i]] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3))
				{
					sameIndex = i;
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
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3>(arg0, arg1, arg2, arg3));
			}
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			List<int> considerationsLookup = m_fastConsiderationsLookup[5];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				if (m_considerationBuilders[considerationsLookup[i]] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3) &&
					EqualityComparer<TArg4>.Default.Equals(considerationBuilder.arg4, arg4))
				{
					sameIndex = i;
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
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>(arg0, arg1, arg2, arg3, arg4));
			}
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			List<int> considerationsLookup = m_fastConsiderationsLookup[6];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				if (m_considerationBuilders[considerationsLookup[i]] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3) &&
					EqualityComparer<TArg4>.Default.Equals(considerationBuilder.arg4, arg4) &&
					EqualityComparer<TArg5>.Default.Equals(considerationBuilder.arg5, arg5))
				{
					sameIndex = i;
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
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(arg0, arg1, arg2, arg3, arg4, arg5));
			}
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			List<int> considerationsLookup = m_fastConsiderationsLookup[7];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				if (m_considerationBuilders[considerationsLookup[i]] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3) &&
					EqualityComparer<TArg4>.Default.Equals(considerationBuilder.arg4, arg4) &&
					EqualityComparer<TArg5>.Default.Equals(considerationBuilder.arg5, arg5) &&
					EqualityComparer<TArg6>.Default.Equals(considerationBuilder.arg6, arg6))
				{
					sameIndex = i;
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
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg0, arg1, arg2, arg3, arg4, arg5, arg6));
			}
		}

		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			List<int> considerationsLookup = m_fastConsiderationsLookup[8];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				if (m_considerationBuilders[considerationsLookup[i]] is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> considerationBuilder &&
					EqualityComparer<TArg0>.Default.Equals(considerationBuilder.arg0, arg0) &&
					EqualityComparer<TArg1>.Default.Equals(considerationBuilder.arg1, arg1) &&
					EqualityComparer<TArg2>.Default.Equals(considerationBuilder.arg2, arg2) &&
					EqualityComparer<TArg3>.Default.Equals(considerationBuilder.arg3, arg3) &&
					EqualityComparer<TArg4>.Default.Equals(considerationBuilder.arg4, arg4) &&
					EqualityComparer<TArg5>.Default.Equals(considerationBuilder.arg5, arg5) &&
					EqualityComparer<TArg6>.Default.Equals(considerationBuilder.arg6, arg6) &&
					EqualityComparer<TArg7>.Default.Equals(considerationBuilder.arg7, arg7))
				{
					sameIndex = i;
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
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7));
			}
		}

		public Brain Build()
		{
			return Build(new Blackboard());
		}

		public Brain Build([NotNull] Blackboard blackboard)
		{
			Consideration[] considerations = MakeConsiderations();
			Action[] actions = MakeActions();
			int[][] actionConsiderationsBindings = MakeActionConsiderationsBindings();

			return new Brain(considerations, actions, actionConsiderationsBindings, blackboard);
		}

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
	}
}
