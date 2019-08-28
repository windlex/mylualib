using System;

namespace Terraria.DataStructures
{
	// Token: 0x02000191 RID: 401
	public struct PlacementHook
	{
		// Token: 0x060012F1 RID: 4849 RVA: 0x00419B8C File Offset: 0x00417D8C
		public PlacementHook(Func<int, int, int, int, int, int> hook, int badReturn, int badResponse, bool processedCoordinates)
		{
			this.hook = hook;
			this.badResponse = badResponse;
			this.badReturn = badReturn;
			this.processedCoordinates = processedCoordinates;
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x00419BAC File Offset: 0x00417DAC
		public static bool operator ==(PlacementHook first, PlacementHook second)
		{
			return first.hook == second.hook && first.badResponse == second.badResponse && first.badReturn == second.badReturn && first.processedCoordinates == second.processedCoordinates;
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x00419BF8 File Offset: 0x00417DF8
		public static bool operator !=(PlacementHook first, PlacementHook second)
		{
			return first.hook != second.hook || first.badResponse != second.badResponse || first.badReturn != second.badReturn || first.processedCoordinates != second.processedCoordinates;
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x00419C48 File Offset: 0x00417E48
		public override bool Equals(object obj)
		{
			return obj is PlacementHook && this == (PlacementHook)obj;
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x00419C68 File Offset: 0x00417E68
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x0400348D RID: 13453
		public Func<int, int, int, int, int, int> hook;

		// Token: 0x0400348E RID: 13454
		public int badReturn;

		// Token: 0x0400348F RID: 13455
		public int badResponse;

		// Token: 0x04003490 RID: 13456
		public bool processedCoordinates;

		// Token: 0x04003491 RID: 13457
		public static PlacementHook Empty = new PlacementHook(null, 0, 0, false);

		// Token: 0x04003492 RID: 13458
		public const int Response_AllInvalid = 0;
	}
}
