#!/usr/bin/env bash
adb push . /sdcard/game
adb shell am start -n "org.love2d.android/.GameActivity" -d file:///storage/emulated/0/game/main.lua
