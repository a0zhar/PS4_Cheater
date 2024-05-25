using libdebug;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS4_Cheater {

    public class MappedSection {
        public ulong Start { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public bool Check { set; get; }
        public uint Prot { get; set; }

        public ResultList ResultList { get; set; }

        public MappedSection() {
            ResultList = null;
        }

        public void UpdateResultList(ProcessManager processManager, MemoryHelper memoryHelper,
            string default_value_0_str, string default_value_1_str, bool is_hex, bool newScan, int thread_id) {
            if (!Check) {
                ResultList = null;
                return;
            }

            ResultList new_result_list = new ResultList(memoryHelper.Length, memoryHelper.Alignment);

            ulong address = this.Start;
            uint base_address = 0;
            int length = this.Length;

            const int buffer_length = 1024 * 1024 * 128;

            while (length != 0) {
                int cur_length = buffer_length;

                if (cur_length > length) {
                    cur_length = length;
                    length = 0;
                }
                else {
                    length -= cur_length;
                }

                byte[] buffer = memoryHelper.ReadMemory(address, (int)cur_length, thread_id);

                byte[] default_value_0 = null;
                if (memoryHelper.ParseFirstValue) {
                    if (is_hex) {
                        default_value_0 = memoryHelper.HexStringToBytes(default_value_0_str);
                    }
                    else {
                        default_value_0 = memoryHelper.StringToBytes(default_value_0_str);
                    }
                }

                byte[] default_value_1 = null;
                if (memoryHelper.ParseSecondValue) {
                    if (is_hex) {
                        default_value_1 = memoryHelper.HexStringToBytes(default_value_1_str);
                    }
                    else {
                        default_value_1 = memoryHelper.StringToBytes(default_value_1_str);
                    }
                }

                if (newScan) {
                    memoryHelper.CompareWithMemoryBufferNewScanner(default_value_0, default_value_1, buffer, new_result_list, base_address);
                }
                else {
                    memoryHelper.CompareWithMemoryBufferNextScanner(default_value_0, default_value_1, buffer, ResultList, new_result_list);
                }

                address += (ulong)cur_length;
                base_address += (uint)cur_length;
            }
            ResultList = new_result_list;
        }

        public void PointerSearchInit(ProcessManager processManager, MemoryHelper memoryHelper, PointerList pointerList) {
            ulong address = this.Start;
            int length = this.Length;

            const int buffer_length = 1024 * 1024 * 128;

            while (length != 0) {
                int cur_length = buffer_length;

                if (cur_length > length) {
                    cur_length = length;
                    length = 0;
                }
                else {
                    length -= cur_length;
                }

                byte[] buffer = memoryHelper.ReadMemory(address, (int)cur_length);

                memoryHelper.CompareWithMemoryBufferPointerScanner(processManager, buffer, pointerList, address);

                address += (ulong)cur_length;
            }
        }
    }

    public class MappedSectionList {
        public ulong TotalMemorySize { get; set; }

        private List<MappedSection> mapped_section_list = new List<MappedSection>();

        public MappedSectionList() {
        }

        public MappedSection this[int index] => mapped_section_list[index];

        private int FindSectionID(ulong address) {
            int low = 0;
            int high = mapped_section_list.Count - 1;
            int middle;

            while (low <= high) {
                middle = (low + high) / 2;
                if (address >= mapped_section_list[middle].Start + (ulong)mapped_section_list[middle].Length) {
                    low = middle + 1;   // Search last half of the array
                }
                else if (address < mapped_section_list[middle].Start) {
                    high = middle - 1;  // Search first half of the array
                }
                else {
                    return middle;  // Found, returning index
                }
            }

            return -1;
        }

        public int GetMappedSectionID(ulong address) {
            ulong start = 0;
            ulong end = 0;

            if (mapped_section_list.Count > 0) {
                start = mapped_section_list[0].Start;
                end = mapped_section_list[mapped_section_list.Count - 1].Start + (ulong)mapped_section_list[mapped_section_list.Count - 1].Length;
            }

            if (start > address || end < address) {
                return -1;
            }

            return FindSectionID(address);
        }

        public MappedSection GetMappedSection(ulong address) {
            int sectionID = GetMappedSectionID(address);
            if (sectionID < 0) {
                return null;
            }
            return mapped_section_list[sectionID];
        }

        public void SectionCheck(int idx, bool _checked) {
            mapped_section_list[idx].Check = _checked;
            if (mapped_section_list[idx].Check) {
                TotalMemorySize += (ulong)mapped_section_list[idx].Length;
            }
            else {
                TotalMemorySize -= (ulong)mapped_section_list[idx].Length;
            }
        }

        /// <summary>
        /// This function is used to build a new string that will be used
        /// to display the name of a certain Process-Related Section.
        ///
        /// These names will be displayed in the section listbox.
        /// </summary>
        /// <param name="section_idx">The Index for the Section in the Process</param>
        /// <returns>String showing the section name, address, and size</returns>
        public string GetSectionName(int section_idx) {
            // Validate section index, return error value if invalid
            if (section_idx < 0) return $"Section Index {section_idx} Wrong!";
            MappedSection sectionInfo = mapped_section_list[section_idx];
            StringBuilder section_name = new StringBuilder();

            section_name.Append(sectionInfo.Name + "-");
            section_name.Append(String.Format("{0:X}", sectionInfo.Prot) + "-");
            section_name.Append(String.Format("{0:X}", sectionInfo.Start) + "-");
            section_name.Append((sectionInfo.Length / 1024).ToString() + "KB");

            return section_name.ToString();
        }

        public List<MappedSection> GetMappedSectionList(string name, int prot) {
            List<MappedSection> result_list = new List<MappedSection>();
            for (int idx = 0; idx < mapped_section_list.Count; ++idx) {
                if (mapped_section_list[idx].Prot == prot &&
                    mapped_section_list[idx].Name.StartsWith(name)) {
                    result_list.Add(mapped_section_list[idx]);
                }
            }
            return result_list;
        }

        public void InitMemorySectionList(ProcessMap pm) {
            mapped_section_list.Clear();
            TotalMemorySize = 0;

            for (int i = 0; i < pm.entries.Length; i++) {
                MemoryEntry entry = pm.entries[i];
                if ((entry.prot & 0x1) == 0x1) {
                    ulong length = entry.end - entry.start;
                    ulong start = entry.start;
                    string name = entry.name;
                    int idx = 0;
                    ulong buffer_length = 1024 * 1024 * 128;

                    // Executable section
                    if ((entry.prot & 0x5) == 0x5) {
                        buffer_length = length;
                    }

                    while (length != 0) {
                        ulong cur_length = buffer_length;

                        if (cur_length > length) {
                            cur_length = length;
                            length = 0;
                        }
                        else {
                            length -= cur_length;
                        }

                        MappedSection mappedSection = new MappedSection();
                        mappedSection.Start = start;
                        mappedSection.Length = (int)cur_length;
                        mappedSection.Name = entry.name + "[" + idx + "]";
                        mappedSection.Check = false;
                        mappedSection.Prot = entry.prot;

                        mapped_section_list.Add(mappedSection);

                        start += cur_length;
                        ++idx;
                    }
                }
            }
        }

        public ulong TotalResultCount() {
            ulong total_result_count = 0;
            for (int idx = 0; idx < mapped_section_list.Count; ++idx) {
                if (mapped_section_list[idx].Check && mapped_section_list[idx].ResultList != null) {
                    total_result_count += (ulong)mapped_section_list[idx].ResultList.Count;
                }
            }
            return total_result_count;
        }

        public void ClearResultList() {
            for (int idx = 0; idx < mapped_section_list.Count; ++idx) {
                if (mapped_section_list[idx].ResultList != null) {
                    mapped_section_list[idx].ResultList.Clear();
                }
            }
        }

        public int Count => mapped_section_list.Count;
    }

    public class ProcessManager {
        public MappedSectionList MappedSectionList { get; }

        public ProcessManager() {
            MappedSectionList = new MappedSectionList();
        }

        public ProcessInfo? GetProcessInfo(string process_name) {
            ProcessList processList = MemoryHelper.GetProcessList();
            ProcessInfo? processInfo = null;
            foreach (Process process in processList.processes) {
                if (process.name == process_name) {
                    processInfo = MemoryHelper.GetProcessInfo(process.pid);
                    break;
                }
            }

            return processInfo;
        }

        public string GetProcessName(int idx) {
            ProcessList processList = MemoryHelper.GetProcessList();
            return processList.processes[idx].name;
        }
    }
}