package encode

import (
	"fmt"
	"strings"
	"unicode"
)

func RunLengthEncode(input string) string {
	if input == "" {
		return input
	}
	var sb strings.Builder
	currentCount := 1
	currentRune := input[0]
	for i := 1; i < len(input); i++ {
		if input[i] == currentRune {
			currentCount++
		} else {
			writeEncodedCharacter(currentCount, &sb, currentRune)
			currentRune = input[i]
			currentCount = 1
		}
	}

	writeEncodedCharacter(currentCount, &sb, currentRune)

	return sb.String()

}

func writeEncodedCharacter(currentCount int, sb *strings.Builder, currentRune byte) {
	if currentCount > 1 {
		sb.WriteString(fmt.Sprint(currentCount))
	}
	sb.WriteString(string(currentRune))
}

func RunLengthDecode(input string) string {
	if input == "" {
		return input
	}
	var sb strings.Builder
	var repeat = 0
	for _, char := range input {
		if unicode.IsDigit(char) {
			if repeat == 0 {
				repeat = int(char - '0')
			} else {
				repeat = repeat*10 + int(char-'0')
			}
		} else {
			if repeat == 0 {
				sb.WriteString(string(char))
			} else {
				sb.WriteString(strings.Repeat(string(char), repeat))
			}
			repeat = 0
		}
	}

	return sb.String()
}
