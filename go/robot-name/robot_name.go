package robotname

import (
	"fmt"
	"math/rand"
	"time"
)

// Define the Robot type here.

var names = make([]string, 0)
var namesInitalized = false
var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

type Robot struct {
	name string
}

func (r *Robot) Name() (string, error) {
	if r.name != "" {
		return r.name, nil
	}

	if !namesInitalized {
		for i := 0; i < 26; i++ {
			for j := 0; j < 26; j++ {
				for k := 0; k < 1000; k++ {
					names = append(names, fmt.Sprintf("%s%s%03d", string(alphabet[i]), string(alphabet[j]), k))
				}
			}
		}

		rand.Seed(time.Now().UnixNano())
		rand.Shuffle(len(names), func(i, j int) { names[i], names[j] = names[j], names[i] })
		namesInitalized = true
	}

	if len(names) == 0 {
		return "", fmt.Errorf("could not generate a unique name")
	}

	r.name = names[0]
	names = names[1:]
	return r.name, nil
}

func (r *Robot) Reset() {
	r.name = ""
}
