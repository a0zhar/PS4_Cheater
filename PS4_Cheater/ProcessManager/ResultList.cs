using System;
using System.Collections.Generic;

namespace PS4_Cheater {

    public class ResultList {
        private const int buffer_size = 65536; // 4096 * 16
        private List<byte[]> buffer_list = new List<byte[]>();

        private int buffer_tag_offset = 0;
        private int buffer_tag_elem_count = 0;
        private int buffer_id = 0;

        private int count = 0;
        private int iterator = 0;
        private int element_size = 0;
        private int element_alignment = 1;

        private const int OFFSET_SIZE = 4;
        private const int BIT_MAP_SIZE = 8;

        public ResultList(int element_size, int element_alignment) {
            buffer_list.Add(new byte[buffer_size]);
            this.element_size = element_size;
            this.element_alignment = element_alignment;
        }

        private int bit_count(ulong data, int end) {
            int sum = 0;
            for (int i = 0; i <= end; ++i) {
                if ((data & (1ul << i)) != 0) {
                    ++sum;
                }
            }
            return sum;
        }

        private int bit_position(ulong data, int pos) {
            int sum = 0;
            for (int i = 0; i <= 63; ++i) {
                if ((data & (1ul << i)) != 0) {
                    if (sum == pos)
                        return i;

                    ++sum;
                }
            }
            return -1;
        }

        public void Add(uint memoryAddressOffset, byte[] memoryValue) {
            if (memoryValue.Length != element_size) {
                throw new Exception("Function Add() Exception! - Invalid address!");
            }

            byte[] dense_buffer = buffer_list[buffer_id];

            uint tag_address_offset_base = BitConverter.ToUInt32(dense_buffer, buffer_tag_offset);
            ulong bit_map = BitConverter.ToUInt64(dense_buffer, buffer_tag_offset + OFFSET_SIZE);

            if (tag_address_offset_base > memoryAddressOffset) {
                throw new Exception("Invalid address!");
            }

            if (bit_map == 0) {
                tag_address_offset_base = memoryAddressOffset;
                Buffer.BlockCopy(BitConverter.GetBytes(memoryAddressOffset), 0, dense_buffer, buffer_tag_offset, OFFSET_SIZE);
            }

            int offset_in_bit_map = (int)(memoryAddressOffset - tag_address_offset_base) / element_alignment;
            if (offset_in_bit_map < 64) {
                dense_buffer[buffer_tag_offset + OFFSET_SIZE + (offset_in_bit_map / 8)] |= (byte)(1 << (offset_in_bit_map % 8)); //bit map
                Buffer.BlockCopy(memoryValue, 0, dense_buffer, buffer_tag_offset + OFFSET_SIZE + BIT_MAP_SIZE + (element_size * buffer_tag_elem_count), element_size);//value
                ++buffer_tag_elem_count;
            }
            else {
                buffer_tag_offset += OFFSET_SIZE + BIT_MAP_SIZE + (element_size * buffer_tag_elem_count);

                // Allocate new page
                if (buffer_tag_offset + OFFSET_SIZE + BIT_MAP_SIZE + (element_size * 64) >= buffer_size) {
                    buffer_list.Add(new byte[buffer_size]);
                    ++buffer_id;
                    buffer_tag_offset = 0;
                    buffer_tag_elem_count = 0;
                    dense_buffer = buffer_list[buffer_id];
                }

                // Tag Address Base
                Buffer.BlockCopy(
                    BitConverter.GetBytes(memoryAddressOffset),
                    0,
                    dense_buffer,
                    buffer_tag_offset,
                    OFFSET_SIZE
                );

                // Bit map
                dense_buffer[buffer_tag_offset + OFFSET_SIZE] = (byte)1;

                // Value
                Buffer.BlockCopy(
                    memoryValue,
                    0,
                    dense_buffer,
                    buffer_tag_offset + OFFSET_SIZE + BIT_MAP_SIZE,
                    element_size
                );

                buffer_tag_elem_count = 1;
            }
            count++;
        }

        public void Clear() {
            count = 0;
            buffer_tag_offset = 0;
            buffer_tag_elem_count = 0;
            buffer_id = 0;
            buffer_list.Clear();
            buffer_list.Add(new byte[buffer_size]);
        }

        public void Get(ref uint memoryAddressOffset, ref byte[] memoryValue) {
            byte[] dense_buffer = buffer_list[buffer_id];
            memoryValue = new byte[element_size];

            uint offset_base = BitConverter.ToUInt32(dense_buffer, buffer_tag_offset);
            ulong bit_map = BitConverter.ToUInt64(dense_buffer, buffer_tag_offset + OFFSET_SIZE);
            memoryAddressOffset = (uint)(bit_position(bit_map, buffer_tag_elem_count) * element_alignment) + offset_base;

            Buffer.BlockCopy(
                dense_buffer,
                buffer_tag_offset + OFFSET_SIZE + BIT_MAP_SIZE + (element_size * buffer_tag_elem_count),
                memoryValue,
                0,
                element_size
            );
        }

        public void Set(byte[] memoryValue) {
            byte[] dense_buffer = buffer_list[buffer_id];
            Buffer.BlockCopy(
                memoryValue,
                0,
                dense_buffer,
                buffer_tag_offset + OFFSET_SIZE + BIT_MAP_SIZE + (element_size * buffer_tag_elem_count),
                element_size
            );
        }

        public void Begin() {
            iterator = 0;
            buffer_tag_offset = 0;
            buffer_tag_elem_count = 0;
            buffer_id = 0;
        }

        public void Next() {
            ++iterator;

            byte[] dense_buffer = buffer_list[buffer_id];
            uint base_offset = BitConverter.ToUInt32(dense_buffer, buffer_tag_offset);
            ulong bit_map = BitConverter.ToUInt64(dense_buffer, buffer_tag_offset + 4);
            ++buffer_tag_elem_count;

            if (bit_count(bit_map, 63) <= buffer_tag_elem_count) {
                buffer_tag_offset += OFFSET_SIZE + BIT_MAP_SIZE + (element_size * buffer_tag_elem_count);
                if (buffer_tag_offset + OFFSET_SIZE + BIT_MAP_SIZE + (element_size * 64) >= buffer_size) {
                    ++buffer_id;
                    buffer_tag_offset = 0;
                    buffer_tag_elem_count = 0;
                }
                else {
                    buffer_tag_elem_count = 0;
                }
            }
        }

        public bool End() {
            return iterator == count;
        }

        public int Count => count;
    }
}