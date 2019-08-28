using System;

namespace Extensions
{
	// Token: 0x02000003 RID: 3
	public static class EnumerationExtensions
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00002FC8 File Offset: 0x000011C8
		public static T Include<T>(this Enum value, T append)
		{
			Type type = value.GetType();
			object obj = value;
			EnumerationExtensions._Value value2 = new EnumerationExtensions._Value(append, type);
			if (value2.Signed is long)
			{
				obj = (Convert.ToInt64(value) | value2.Signed.Value);
			}
			else if (value2.Unsigned is ulong)
			{
				obj = (Convert.ToUInt64(value) | value2.Unsigned.Value);
			}
			return (T)((object)Enum.Parse(type, obj.ToString()));
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003054 File Offset: 0x00001254
		public static T Remove<T>(this Enum value, T remove)
		{
			Type type = value.GetType();
			object obj = value;
			EnumerationExtensions._Value value2 = new EnumerationExtensions._Value(remove, type);
			if (value2.Signed is long)
			{
				obj = (Convert.ToInt64(value) & ~value2.Signed.Value);
			}
			else if (value2.Unsigned is ulong)
			{
				obj = (Convert.ToUInt64(value) & ~value2.Unsigned.Value);
			}
			return (T)((object)Enum.Parse(type, obj.ToString()));
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000030E0 File Offset: 0x000012E0
		public static bool Has<T>(this Enum value, T check)
		{
			Type type = value.GetType();
			EnumerationExtensions._Value value2 = new EnumerationExtensions._Value(check, type);
			if (value2.Signed is long)
			{
				return (Convert.ToInt64(value) & value2.Signed.Value) == value2.Signed.Value;
			}
			return value2.Unsigned is ulong && (Convert.ToUInt64(value) & value2.Unsigned.Value) == value2.Unsigned.Value;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003168 File Offset: 0x00001368
		public static bool Missing<T>(this Enum obj, T value)
		{
			return !obj.Has(value);
		}

		// Token: 0x020001B3 RID: 435
		private class _Value
		{
			// Token: 0x060013DF RID: 5087 RVA: 0x0041CB20 File Offset: 0x0041AD20
			public _Value(object value, Type type)
			{
				if (!type.IsEnum)
				{
					throw new ArgumentException("Value provided is not an enumerated type!");
				}
				Type underlyingType = Enum.GetUnderlyingType(type);
				if (underlyingType.Equals(EnumerationExtensions._Value._UInt32) || underlyingType.Equals(EnumerationExtensions._Value._UInt64))
				{
					this.Unsigned = new ulong?(Convert.ToUInt64(value));
					return;
				}
				this.Signed = new long?(Convert.ToInt64(value));
			}

			// Token: 0x04003605 RID: 13829
			private static Type _UInt64 = typeof(ulong);

			// Token: 0x04003606 RID: 13830
			private static Type _UInt32 = typeof(long);

			// Token: 0x04003607 RID: 13831
			public long? Signed;

			// Token: 0x04003608 RID: 13832
			public ulong? Unsigned;
		}
	}
}
