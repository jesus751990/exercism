package strand

import "strings"

func ToRNA(dna string) string {    
	var rna strings.Builder
    for _, r := range dna {
        switch r {
        case 'G':
        	rna.WriteRune('C')
        case 'C':
            rna.WriteRune('G')
        case 'T': 
            rna.WriteRune('A')
        case 'A':
            rna.WriteRune('U')
        }
    }
    return rna.String()
}

