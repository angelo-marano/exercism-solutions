package etl

import (
	"strings"
)

func Transform(input map[int][]string) map[string]int {
	m := make(map[string]int)
	for points, letters := range input {
		for _, letter := range letters {
			m[strings.ToLower(letter)] = points
		}
	}

	return m

}
