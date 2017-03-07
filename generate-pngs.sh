#!/usr/bin/env bash
find Assets -type f -name "*.svg" | while read line; do
	if [[ "$line" -nt "$line.png" ]]; then
		svgexport "$line" "$line.png";
	fi
done
