using libdebug;
using System.Collections.Generic;

namespace PS4_Cheater {
    public class GameInfo {

        //
        // All 5 of the following variables and their assigned value,
        // can be used for the system firmwares 5.05, 6.72, and 7.02
        const string GAME_INFO_UNIVERSAL_PROCESS_NAME = "SceCdlgApp";
        const string GAME_INFO_UNIVERSAL_SECTION_NAME = "libSceCdlgUtilServer.sprx";
        const int GAME_INFO_UNIVERSAL_SECTION_PROT = 3;
        const int GAME_INFO_UNIVERSAL_ID_OFFSET = 0XA0;
        const int GAME_INFO_UNIVERSAL_VERSION_OFFSET = 0XC8;


        public string GameID = "";
        public string Version = "";

        public GameInfo() {
            string process_name = "";
            string section_name = "";
            ulong id_offset = 0;
            ulong version_offset = 0;
            int section_prot = 0;

            switch (Util.Version) {
                // In case of the PS4 Firmware version being either:
                // 5.05, 6.72, or 7.02
                case 505:
                case 672:
                case 702:
                    process_name = GAME_INFO_UNIVERSAL_PROCESS_NAME;
                    section_name = GAME_INFO_UNIVERSAL_SECTION_NAME;
                    id_offset = GAME_INFO_UNIVERSAL_ID_OFFSET;
                    version_offset = GAME_INFO_UNIVERSAL_VERSION_OFFSET;
                    section_prot = GAME_INFO_UNIVERSAL_SECTION_PROT;
                    break;

                // If it's anything but the above firmwares, do nothing
                default: break;
            }

            try {
                ProcessManager processManager = new ProcessManager();
                ProcessInfo? maybeProcessInfo = processManager.GetProcessInfo(process_name);
                if (maybeProcessInfo is null)
                    return;
                ProcessInfo processInfo = (ProcessInfo)maybeProcessInfo;

                MemoryHelper memoryHelper = new MemoryHelper(false, processInfo.pid);
                MappedSectionList mappedSectionList = processManager.MappedSectionList;
                ProcessMap processMap = MemoryHelper.GetProcessMaps(processInfo.pid);
                if (processMap is null)
                    return;

                mappedSectionList.InitMemorySectionList(processMap);
                List<MappedSection> sectionList = mappedSectionList.GetMappedSectionList(section_name, section_prot);

                if (sectionList.Count != 1)
                    return;

                GameID = System.Text.Encoding.Default.GetString(memoryHelper.ReadMemory(sectionList[0].Start + id_offset, 16));
                GameID = GameID.Trim(new char[] { '\0' });
                Version = System.Text.Encoding.Default.GetString(memoryHelper.ReadMemory(sectionList[0].Start + version_offset, 16));
                Version = Version.Trim(new char[] { '\0' });
            }
            catch {

            }
        }
    }


}
