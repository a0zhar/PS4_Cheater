# PS4_Cheater

PS4 Cheater is homebrew APP to find game cheat codes, and it is based on [ps4debug](https://github.com/jogolden/ps4debug).

This is a work in progress.

|  FW  | Status          | Comment
|------|-----------------|--------------------
| 5.05 | Working         | 5.05 `ps4debug.bin`
| 6.72 | Working         | 6.72 `ps4debug.bin`
| 7.02 | Working         | 7.02 `ps4debug.bin`
| 7.55 | Working         | 7.55 `ps4debug.bin`

Apologies, I'm not updating the source code anymore but I will continue releasing new versions.

Check here for new releases: https://github.com/ctn123/PS4_Cheater/releases

## Building

Open `PS4_Cheater.sln` with Visual Studio and build.

**Note:**
- `payloads` directory will be copied to the `debug`/`release` directory as a post-build step.
- If using `ps4debug` `payloads` directory on its own, be sure to grab `libdebug.dll`.
  - Need both for the speedfix.
- Included pre-compiled `ps4debug` binaries are built from:
  - 5.05 - https://github.com/jogolden/ps4debug.git @ b446dced06009705c6f8d70e79113637d1690210
  - 6.72 - https://github.com/jogolden/ps4debug.git @ b446dced06009705c6f8d70e79113637d1690210 (with 6.72 offsets)
  - 7.02 - https://github.com/ChendoChap/ps4debug.git @ 7c114ba1b8fe2d5bbdad0079dec442deff10c4e0
  - 7.55 - https://github.com/Joonie86/ps4debug.git @ 616a083250308b93fcb051d6782daba8520c970e

## Acknowledgements & Thanks!

- Countless contributors to `jkpatch`, `ps4-ksdk`, `ps4-payload-sdk`, `ps4debug` and `PS4_Cheater`.
- [DeathRGH](https://github.com/DeathRGH) for the speedfix tweak for ps4debug.
- [Al-Azif](https://github.com/Al-Azif) for his [ps4-exploit-host](https://github.com/Al-Azif/ps4-exploit-host) - Very useful for local testing.

---
Discord chat site: https://discord.gg/PwBwUKf.
Please join us!

---

If you like my builds or have feature requests. Please support me.

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/X8X741UC0)
