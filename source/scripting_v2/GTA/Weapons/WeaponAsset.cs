using System;
using GTA.Native;

namespace GTA
{
	public struct WeaponAsset : IEquatable<WeaponAsset>
	{
		public WeaponAsset(int weaponHash) : this()
		{
			Hash = weaponHash;
		}
		public WeaponAsset(uint weaponHash) : this((int)weaponHash)
		{
		}
		public WeaponAsset(WeaponHash weaponHash) : this((int)weaponHash)
		{
		}

		public int Hash { get; private set; }
		public bool IsValid => Function.Call<bool>(Native.Hash.IS_WEAPON_VALID, Hash);
		public bool IsLoaded => Function.Call<bool>(Native.Hash.HAS_WEAPON_ASSET_LOADED, Hash);

		public void Request()
		{
			Function.Call(Native.Hash.REQUEST_WEAPON_ASSET, Hash, 31, 0);
		}
		public bool Request(int timeout)
		{
			Request();

			DateTime endtime = timeout >= 0 ? DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, timeout) : DateTime.MaxValue;

			while (!IsLoaded)
			{
				Script.Yield();
				Request();

				if (DateTime.UtcNow >= endtime)
				{
					return false;
				}
			}

			return true;
		}
		public void Dismiss()
		{
			Function.Call(Native.Hash.REMOVE_WEAPON_ASSET, Hash);
		}

		public bool Equals(WeaponAsset weaponAsset)
		{
			return Hash == weaponAsset.Hash;
		}
		public override bool Equals(object obj)
		{
			return obj != null && obj.GetType() == GetType() && Equals((WeaponAsset)obj);
		}

		public override int GetHashCode()
		{
			return Hash;
		}

		public override string ToString()
		{
			return "0x" + ((uint)Hash).ToString("X");
		}

		public static implicit operator WeaponAsset(int hash)
		{
			return new WeaponAsset(hash);
		}
		public static implicit operator WeaponAsset(uint hash)
		{
			return new WeaponAsset(hash);
		}
		public static implicit operator WeaponAsset(WeaponHash hash)
		{
			return new WeaponAsset(hash);
		}

		public static bool operator ==(WeaponAsset left, WeaponAsset right)
		{
			return left.Equals(right);
		}
		public static bool operator !=(WeaponAsset left, WeaponAsset right)
		{
			return !left.Equals(right);
		}
	}
}
