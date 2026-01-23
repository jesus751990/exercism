package strand

func ToRNA(dna string) string {    
	var rna string
    for _, dnaR := range dna {
        switch dnaR {
        case 'G':
        	rna += string('C')
        case 'C':
            rna += string('G')
        case 'T': 
            rna += string('A')
        case 'A':
            rna += string('U')
        }
    }
    return rna
}

