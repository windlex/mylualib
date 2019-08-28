using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Terraria.Cinematics
{
	// Token: 0x02000197 RID: 407
	public class Film
	{
		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06001330 RID: 4912 RVA: 0x0041B03C File Offset: 0x0041923C
		public int Frame
		{
			get
			{
				return this._frame;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06001331 RID: 4913 RVA: 0x0041B044 File Offset: 0x00419244
		public int FrameCount
		{
			get
			{
				return this._frameCount;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06001332 RID: 4914 RVA: 0x0041B04C File Offset: 0x0041924C
		public int AppendPoint
		{
			get
			{
				return this._nextSequenceAppendTime;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06001333 RID: 4915 RVA: 0x0041B054 File Offset: 0x00419254
		public bool IsActive
		{
			get
			{
				return this._isActive;
			}
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x0041B05C File Offset: 0x0041925C
		public void AddSequence(int start, int duration, FrameEvent frameEvent)
		{
			this._sequences.Add(new Film.Sequence(frameEvent, start, duration));
			this._nextSequenceAppendTime = Math.Max(this._nextSequenceAppendTime, start + duration);
			this._frameCount = Math.Max(this._frameCount, start + duration);
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x0041B09C File Offset: 0x0041929C
		public void AppendSequence(int duration, FrameEvent frameEvent)
		{
			this.AddSequence(this._nextSequenceAppendTime, duration, frameEvent);
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x0041B0AC File Offset: 0x004192AC
		public void AddSequences(int start, int duration, params FrameEvent[] frameEvents)
		{
			for (int i = 0; i < frameEvents.Length; i++)
			{
				FrameEvent frameEvent = frameEvents[i];
				this.AddSequence(start, duration, frameEvent);
			}
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x0041B0D8 File Offset: 0x004192D8
		public void AppendSequences(int duration, params FrameEvent[] frameEvents)
		{
			int nextSequenceAppendTime = this._nextSequenceAppendTime;
			for (int i = 0; i < frameEvents.Length; i++)
			{
				FrameEvent frameEvent = frameEvents[i];
				this._sequences.Add(new Film.Sequence(frameEvent, nextSequenceAppendTime, duration));
				this._nextSequenceAppendTime = Math.Max(this._nextSequenceAppendTime, nextSequenceAppendTime + duration);
				this._frameCount = Math.Max(this._frameCount, nextSequenceAppendTime + duration);
			}
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x0041B13C File Offset: 0x0041933C
		public void AppendEmptySequence(int duration)
		{
			this.AddSequence(this._nextSequenceAppendTime, duration, new FrameEvent(Film.EmptyFrameEvent));
		}

		// Token: 0x06001339 RID: 4921 RVA: 0x0041B158 File Offset: 0x00419358
		public void AppendKeyFrame(FrameEvent frameEvent)
		{
			this.AddKeyFrame(this._nextSequenceAppendTime, frameEvent);
		}

		// Token: 0x0600133A RID: 4922 RVA: 0x0041B168 File Offset: 0x00419368
		public void AppendKeyFrames(params FrameEvent[] frameEvents)
		{
			int nextSequenceAppendTime = this._nextSequenceAppendTime;
			for (int i = 0; i < frameEvents.Length; i++)
			{
				FrameEvent frameEvent = frameEvents[i];
				this._sequences.Add(new Film.Sequence(frameEvent, nextSequenceAppendTime, 1));
			}
			this._frameCount = Math.Max(this._frameCount, nextSequenceAppendTime + 1);
		}

		// Token: 0x0600133B RID: 4923 RVA: 0x0041B1B8 File Offset: 0x004193B8
		public void AddKeyFrame(int frame, FrameEvent frameEvent)
		{
			this._sequences.Add(new Film.Sequence(frameEvent, frame, 1));
			this._frameCount = Math.Max(this._frameCount, frame + 1);
		}

		// Token: 0x0600133C RID: 4924 RVA: 0x0041B1E4 File Offset: 0x004193E4
		public void AddKeyFrames(int frame, params FrameEvent[] frameEvents)
		{
			for (int i = 0; i < frameEvents.Length; i++)
			{
				FrameEvent frameEvent = frameEvents[i];
				this.AddKeyFrame(frame, frameEvent);
			}
		}

		// Token: 0x0600133D RID: 4925 RVA: 0x0041B210 File Offset: 0x00419410
		public bool OnUpdate(GameTime gameTime)
		{
			if (this._sequences.Count == 0)
			{
				return false;
			}
			foreach (Film.Sequence current in this._sequences)
			{
				int num = this._frame - current.Start;
				if (num >= 0 && num < current.Duration)
				{
					current.Event(new FrameEventData(this._frame, current.Start, current.Duration));
				}
			}
			int num2 = this._frame + 1;
			this._frame = num2;
			return num2 != this._frameCount;
		}

		// Token: 0x0600133E RID: 4926 RVA: 0x0041B2C4 File Offset: 0x004194C4
		public virtual void OnBegin()
		{
			this._isActive = true;
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x0041B2D0 File Offset: 0x004194D0
		public virtual void OnEnd()
		{
			this._isActive = false;
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x0041B2DC File Offset: 0x004194DC
		private static void EmptyFrameEvent(FrameEventData evt)
		{
		}

		// Token: 0x040034A2 RID: 13474
		private int _frame;

		// Token: 0x040034A3 RID: 13475
		private int _frameCount;

		// Token: 0x040034A4 RID: 13476
		private int _nextSequenceAppendTime;

		// Token: 0x040034A5 RID: 13477
		private bool _isActive;

		// Token: 0x040034A6 RID: 13478
		private List<Film.Sequence> _sequences = new List<Film.Sequence>();

		// Token: 0x020002C1 RID: 705
		private class Sequence
		{
			// Token: 0x170001D6 RID: 470
			// (get) Token: 0x060017AD RID: 6061 RVA: 0x0043CB94 File Offset: 0x0043AD94
			public FrameEvent Event
			{
				get
				{
					return this._frameEvent;
				}
			}

			// Token: 0x170001D7 RID: 471
			// (get) Token: 0x060017AE RID: 6062 RVA: 0x0043CB9C File Offset: 0x0043AD9C
			public int Duration
			{
				get
				{
					return this._duration;
				}
			}

			// Token: 0x170001D8 RID: 472
			// (get) Token: 0x060017AF RID: 6063 RVA: 0x0043CBA4 File Offset: 0x0043ADA4
			public int Start
			{
				get
				{
					return this._start;
				}
			}

			// Token: 0x060017B0 RID: 6064 RVA: 0x0043CBAC File Offset: 0x0043ADAC
			public Sequence(FrameEvent frameEvent, int start, int duration)
			{
				this._frameEvent = frameEvent;
				this._start = start;
				this._duration = duration;
			}

			// Token: 0x04003D72 RID: 15730
			private FrameEvent _frameEvent;

			// Token: 0x04003D73 RID: 15731
			private int _duration;

			// Token: 0x04003D74 RID: 15732
			private int _start;
		}
	}
}
