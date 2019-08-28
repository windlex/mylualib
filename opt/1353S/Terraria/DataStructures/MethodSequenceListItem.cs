using System;
using System.Collections.Generic;

namespace Terraria.DataStructures
{
	// Token: 0x0200018B RID: 395
	public class MethodSequenceListItem
	{
		// Token: 0x060012B0 RID: 4784 RVA: 0x00418DB0 File Offset: 0x00416FB0
		public MethodSequenceListItem(string name, Func<bool> method, MethodSequenceListItem parent = null)
		{
			this.Name = name;
			this.Method = method;
			this.Parent = parent;
		}

		// Token: 0x060012B1 RID: 4785 RVA: 0x00418DD0 File Offset: 0x00416FD0
		public bool ShouldAct(List<MethodSequenceListItem> sequence)
		{
			return !this.Skip && sequence.Contains(this) && (this.Parent == null || this.Parent.ShouldAct(sequence));
		}

		// Token: 0x060012B2 RID: 4786 RVA: 0x00418E00 File Offset: 0x00417000
		public bool Act()
		{
			return this.Method();
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x00418E10 File Offset: 0x00417010
		public static void ExecuteSequence(List<MethodSequenceListItem> sequence)
		{
			foreach (MethodSequenceListItem current in sequence)
			{
				if (current.ShouldAct(sequence) && !current.Act())
				{
					break;
				}
			}
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x00418E70 File Offset: 0x00417070
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"name: ",
				this.Name,
				" skip: ",
				this.Skip.ToString(),
				" parent: ",
				this.Parent
			});
		}

		// Token: 0x0400345E RID: 13406
		public string Name;

		// Token: 0x0400345F RID: 13407
		public MethodSequenceListItem Parent;

		// Token: 0x04003460 RID: 13408
		public Func<bool> Method;

		// Token: 0x04003461 RID: 13409
		public bool Skip;
	}
}
