using System;

namespace PS4_Cheater {
    public partial class MemoryHelper {
        public bool scan_type_equal_hex(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            if (defaultVal0.Length != newValue.Length) {
                throw new ArgumentException("Length!!!");
            }

            for (int i = 0; i < defaultVal0.Length; ++i) {
                if (defaultVal0[i] != newValue[i]) {
                    return false;
                }
            }

            return true;
        }

        bool scan_type_equal_string(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            if (defaultVal0.Length != newValue.Length) {
                throw new ArgumentException("Length!!!");
            }

            for (int i = 0; i < defaultVal0.Length; ++i) {
                if (defaultVal0[i] != newValue[i]) {
                    return false;
                }
            }
            return true;
        }

        bool scan_type_pointer_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(newValue, 0) != 0;
        }

        bool scan_type_any_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(newValue, 0) != 0;
        }

        bool scan_type_between_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(newValue, 0) <= BitConverter.ToUInt64(defaultVal1, 0) &&
                BitConverter.ToUInt64(newValue, 0) >= BitConverter.ToUInt64(defaultVal0, 0);
        }

        bool scan_type_increased_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(newValue, 0) > BitConverter.ToUInt64(oldValue, 0);
        }
        bool scan_type_increased_by_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(newValue, 0) ==
                BitConverter.ToUInt64(oldValue, 0) + BitConverter.ToUInt64(defaultVal0, 0);
        }
        bool scan_type_bigger_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(newValue, 0) > BitConverter.ToUInt64(defaultVal0, 0);
        }
        bool scan_type_decreased_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(newValue, 0) < BitConverter.ToUInt64(oldValue, 0);
        }

        bool scan_type_decreased_by_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(newValue, 0) ==
                BitConverter.ToUInt64(oldValue, 0) - BitConverter.ToUInt64(defaultVal0, 0);
        }

        bool scan_type_less_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(newValue, 0) < BitConverter.ToUInt64(defaultVal0, 0);
        }
        bool scan_type_unchanged_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(oldValue, 0) == BitConverter.ToUInt64(newValue, 0);
        }
        bool scan_type_equal_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(defaultVal0, 0) == BitConverter.ToUInt64(newValue, 0);
        }
        bool scan_type_changed_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(oldValue, 0) != BitConverter.ToUInt64(newValue, 0);
        }
        bool scan_type_not_ulong(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt64(defaultVal0, 0) != BitConverter.ToUInt64(newValue, 0);
        }


        bool scan_type_any_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(newValue, 0) != 0;
        }

        bool scan_type_between_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(newValue, 0) <= BitConverter.ToUInt32(defaultVal1, 0) &&
                BitConverter.ToUInt32(newValue, 0) >= BitConverter.ToUInt32(defaultVal0, 0);
        }

        bool scan_type_increased_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(newValue, 0) > BitConverter.ToUInt32(oldValue, 0);
        }
        bool scan_type_increased_by_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(newValue, 0) ==
                BitConverter.ToUInt32(oldValue, 0) + BitConverter.ToUInt32(defaultVal0, 0);
        }
        bool scan_type_bigger_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(newValue, 0) > BitConverter.ToUInt32(defaultVal0, 0);
        }
        bool scan_type_decreased_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(newValue, 0) < BitConverter.ToUInt32(oldValue, 0);
        }

        bool scan_type_decreased_by_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(newValue, 0) ==
                BitConverter.ToUInt32(oldValue, 0) - BitConverter.ToUInt32(defaultVal0, 0);
        }

        bool scan_type_less_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(newValue, 0) < BitConverter.ToUInt32(defaultVal0, 0);
        }
        bool scan_type_unchanged_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(oldValue, 0) == BitConverter.ToUInt32(newValue, 0);
        }
        bool scan_type_equal_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(defaultVal0, 0) == BitConverter.ToUInt32(newValue, 0);
        }
        bool scan_type_changed_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(oldValue, 0) != BitConverter.ToUInt32(newValue, 0);
        }
        bool scan_type_not_uint(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt32(defaultVal0, 0) != BitConverter.ToUInt32(newValue, 0);
        }

        bool scan_type_any_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(newValue, 0) != 0;
        }

        bool scan_type_between_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(newValue, 0) <= BitConverter.ToUInt16(defaultVal1, 0) &&
                BitConverter.ToUInt16(newValue, 0) >= BitConverter.ToUInt16(defaultVal0, 0);
        }

        bool scan_type_increased_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(newValue, 0) > BitConverter.ToUInt16(oldValue, 0);
        }
        bool scan_type_increased_by_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(newValue, 0) ==
                BitConverter.ToUInt16(oldValue, 0) + BitConverter.ToUInt16(defaultVal0, 0);
        }
        bool scan_type_bigger_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(newValue, 0) > BitConverter.ToUInt16(defaultVal0, 0);
        }
        bool scan_type_decreased_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(newValue, 0) < BitConverter.ToUInt16(oldValue, 0);
        }

        bool scan_type_decreased_by_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(newValue, 0) ==
                BitConverter.ToUInt16(oldValue, 0) - BitConverter.ToUInt16(defaultVal0, 0);
        }

        bool scan_type_less_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(newValue, 0) < BitConverter.ToUInt16(defaultVal0, 0);
        }
        bool scan_type_unchanged_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(oldValue, 0) == BitConverter.ToUInt16(newValue, 0);
        }
        bool scan_type_equal_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(defaultVal0, 0) == BitConverter.ToUInt16(newValue, 0);
        }
        bool scan_type_changed_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(oldValue, 0) != BitConverter.ToUInt16(newValue, 0);
        }
        bool scan_type_not_uint16(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToUInt16(defaultVal0, 0) != BitConverter.ToUInt16(newValue, 0);
        }

        bool scan_type_any_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return newValue[0] != 0;
        }

        bool scan_type_between_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return newValue[0] <= defaultVal1[0] &&
                newValue[0] >= defaultVal0[0];
        }

        bool scan_type_increased_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return newValue[0] > oldValue[0];
        }
        bool scan_type_increased_by_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return newValue[0] ==
                oldValue[0] + defaultVal0[0];
        }
        bool scan_type_bigger_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return newValue[0] > defaultVal0[0];
        }
        bool scan_type_decreased_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return newValue[0] < oldValue[0];
        }

        bool scan_type_decreased_by_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return newValue[0] ==
                oldValue[0] - defaultVal0[0];
        }

        bool scan_type_less_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return newValue[0] < defaultVal0[0];
        }
        bool scan_type_unchanged_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return oldValue[0] == newValue[0];
        }
        bool scan_type_equal_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return defaultVal0[0] == newValue[0];
        }
        bool scan_type_changed_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return oldValue[0] != newValue[0];
        }

        bool scan_type_not_uint8(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return defaultVal0[0] != newValue[0];
        }
        bool scan_type_any_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToDouble(newValue, 0) != 0;
        }
        bool scan_type_fuzzy_equal_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToDouble(defaultVal0, 0) -
                BitConverter.ToDouble(newValue, 0)) < 1;
        }
        bool scan_type_between_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToDouble(newValue, 0) <= BitConverter.ToDouble(defaultVal1, 0) &&
                BitConverter.ToDouble(newValue, 0) >= BitConverter.ToDouble(defaultVal0, 0);
        }
        bool scan_type_increased_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToDouble(newValue, 0) > BitConverter.ToDouble(oldValue, 0);
        }
        bool scan_type_increased_by_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToDouble(newValue, 0) -
                (BitConverter.ToDouble(defaultVal0, 0) + BitConverter.ToDouble(oldValue, 0))) < 0.0001;
        }
        bool scan_type_bigger_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToDouble(newValue, 0) > BitConverter.ToDouble(defaultVal0, 0);
        }
        bool scan_type_decreased_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToDouble(newValue, 0) < BitConverter.ToDouble(oldValue, 0);
        }
        bool scan_type_decreased_by_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToDouble(newValue, 0) -
                (BitConverter.ToDouble(oldValue, 0) - BitConverter.ToDouble(defaultVal0, 0))) < 0.0001;
        }
        bool scan_type_less_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToDouble(newValue, 0) < BitConverter.ToDouble(defaultVal0, 0);
        }
        bool scan_type_unchanged_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToDouble(oldValue, 0) -
                BitConverter.ToDouble(newValue, 0)) < 0.0001;
        }
        bool scan_type_equal_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToDouble(defaultVal0, 0) -
                BitConverter.ToDouble(newValue, 0)) < 0.0001;
        }
        bool scan_type_changed_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return !scan_type_unchanged_double(defaultVal0, defaultVal1, oldValue, newValue);
        }
        bool scan_type_not_double(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return !scan_type_equal_double(defaultVal0, defaultVal1, oldValue, newValue);
        }

        bool scan_type_any_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToSingle(newValue, 0) != 0;
        }
        bool scan_type_fuzzy_equal_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToSingle(defaultVal0, 0) -
                BitConverter.ToSingle(newValue, 0)) < 1;
        }
        bool scan_type_between_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToSingle(newValue, 0) <= BitConverter.ToSingle(defaultVal1, 0) &&
                BitConverter.ToSingle(newValue, 0) >= BitConverter.ToSingle(defaultVal0, 0);
        }
        bool scan_type_increased_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToSingle(newValue, 0) > BitConverter.ToSingle(oldValue, 0);
        }
        bool scan_type_increased_by_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToSingle(newValue, 0) -
                (BitConverter.ToSingle(defaultVal0, 0) + BitConverter.ToSingle(oldValue, 0))) < 0.0001;
        }
        bool scan_type_bigger_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToSingle(newValue, 0) > BitConverter.ToSingle(defaultVal0, 0);
        }
        bool scan_type_decreased_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToSingle(newValue, 0) < BitConverter.ToSingle(oldValue, 0);
        }
        bool scan_type_decreased_by_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToSingle(newValue, 0) -
                (BitConverter.ToSingle(oldValue, 0) - BitConverter.ToSingle(defaultVal0, 0))) < 0.0001;
        }
        bool scan_type_less_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return BitConverter.ToSingle(newValue, 0) < BitConverter.ToSingle(defaultVal0, 0);
        }
        bool scan_type_unchanged_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToSingle(oldValue, 0) -
                BitConverter.ToSingle(newValue, 0)) < 0.0001;
        }

        bool scan_type_equal_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return Math.Abs(BitConverter.ToSingle(defaultVal0, 0) -
                BitConverter.ToSingle(newValue, 0)) < 0.0001;
        }
        bool scan_type_changed_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return !scan_type_unchanged_float(defaultVal0, defaultVal1, oldValue, newValue);
        }

        bool scan_type_not_float(Byte[] defaultVal0, Byte[] defaultVal1, Byte[] oldValue, Byte[] newValue) {
            return !scan_type_equal_float(defaultVal0, defaultVal1, oldValue, newValue);
        }

    }
}
