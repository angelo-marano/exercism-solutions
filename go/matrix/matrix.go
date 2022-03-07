package matrix

import (
	"fmt"
	"strconv"
	"strings"
)

type Matrix struct {
	rows [][]int
}

func New(s string) (*Matrix, error) {

	var m Matrix

	rows := strings.Split(s, "\n")
	m.rows = make([][]int, len(rows))
	rowLen := -1
	for i, r := range rows {
		r = strings.TrimSpace(r)
		split := strings.Split(r, " ")
		m.rows[i] = make([]int, len(split))
		if (rowLen != -1) && (rowLen != len(split)) {
			return nil, fmt.Errorf("row %d has %d columns, expected %d", i, len(split), rowLen)
		}
		rowLen = len(split)
		for i2, c := range split {
			num, err := strconv.Atoi(string(c))
			if err != nil {
				return nil, err
			}
			m.rows[i][i2] = num
		}
	}

	return &m, nil
}

// Cols and Rows must return the results without affecting the matrix.
func (m *Matrix) Cols() [][]int {
	c := make([][]int, len(m.rows[0]))
	if len(m.rows) == 0 {
		return c
	}
	for i := range m.rows[0] {
		c[i] = make([]int, len(m.rows))
		for j := range m.rows {
			c[i][j] = m.rows[j][i]
		}
	}

	return c
}

func (m *Matrix) Rows() [][]int {
	r := make([][]int, len(m.rows))
	for i := range m.rows {
		r[i] = make([]int, len(m.rows[i]))
		copy(r[i], m.rows[i])
	}
	return r
}

func (m *Matrix) Set(row, col, val int) bool {
	if (row < 0) || (col < 0) || (row >= len(m.rows) || col >= len(m.rows[row])) {
		return false
	}
	m.rows[row][col] = val
	return true
}
