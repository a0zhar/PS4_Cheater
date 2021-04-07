[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/X8X741UC0)

If you like my builds, please donate to help fund the development of PS4 Cheater and ps4debug.

# PS4_Cheater & ps4debug

PS4 Cheater is homebrew APP to find game cheat codes, and it is based on [ps4debug](https://github.com/jogolden/ps4debug).

Supported Firmware: 5.05, 6.72, 7.02, 7.55.

### Notable new features (v1.5.0 onwards):
  - Ported from jkpatch to ps4debug.
  - Support for 7.02 and 7.55.
  - Console scanner which does the scanning on the ps4 console.
  - Firmware agnostic ps4debug payload
    - One payload for all firmware (5.05, 6.72, 7.02, 7.55)
    - No longer required to select firmware from the drop down.
  - Performance increase over previous versions.
  - Multi-threaded scanning
  - Auto-pause function

I will be regularly updating the release pages with new releases with Changelog: https://github.com/ctn123/PS4_Cheater/releases.
Apologies, I'm not updating the source code anymore. Too much drama releasing source code, so binaries only at this point.

### Performance tips:
  - Console scanner
    - Fast but not always faster than the non-console scanner.
  - auto-pause enables scans to happen faster, for games that support it.
    - Some games will crash when auto-pause on, so experiement with it.
  - Use Unknown Initial Low Value to filter out useless high values to speed up scans.
    - Use this instead of the standard Unknown Initial Value scan.
  - You can enable console scanner for the first scan, then disable for the next scan etc.
    - Can mix and match
  - If you can't find the value you are looking for:
    - Try unchecking Alignment
    - Try unchecking Filter

### Troubleshooting:
  - Trouble connecting?
    - Try port 9020 / 9021, depends on your bin loader.
    - Send the payload with PS4 Cheater with the included embedded payload.
  - Auto-pause causing the game to drop back to xmb or experience a crash/kp?
    - Disable auto-pause - Game is not compatible with this feature
  - Pause/Resume buttons causing the game to drop back to xmb or experience a crash/kp?
    - Don't use pause/resume - Game is not compatible with this feature
  - Can't find the value you are looking for?
    - Uncheck alignment and try again
    - Uncheck filter, refresh and try again

### Upcoming release: (So you can see what I am working on)
  - @batchcode cheat support
  - Added support for 5.07.
  - Fixed missing offset for 7.50 and 7.51
  - Improvement connection reliability.
  - Bug fixes.
  - Preparing a public release of the firmware agnostic ps4debug

## Acknowledgements & Thanks!

- Countless contributors to `jkpatch`, `ps4-ksdk`, `ps4-payload-sdk`, `ps4debug` and `PS4_Cheater`.
- hejran7 for spending countless hours helping me test.
- [DeathRGH](https://github.com/DeathRGH) for the speedfix tweak for ps4debug.
- [Al-Azif](https://github.com/Al-Azif) for his [ps4-exploit-host](https://github.com/Al-Azif/ps4-exploit-host) - Very useful for local testing.

---
Discord chat site: https://discord.gg/PwBwUKf.
Please join us!
