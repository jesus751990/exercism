// Translate RNA sequences into proteins.
package protein

import "errors"

var ErrInvalidBase = errors.New("ErrInvalidBase")
var ErrStop = errors.New("ErrStop")

// FromRNA Translate RNA sequences into Codon sequences and this into Proteins
func FromRNA(rna string) ([]string, error) {
	sequenceLen := 3
	var proteins []string
	for i := 0; i < len(rna); i += 3 {
		protein, err := FromCodon(rna[i:(i + sequenceLen)])
		if err == ErrInvalidBase {
			return nil, err
		} else if protein == "STOP" {
			break
		}
		proteins = append(proteins, protein)
	}
	return proteins, nil
}

// FromCodon Translate Codon sequences into proteins.
func FromCodon(codon string) (string, error) {
	protein := ""
	switch codon {
	case "AUG":
		protein = "Methionine"
	case "UUU", "UUC":
		protein = "Phenylalanine"
	case "UUA", "UUG":
		protein = "Leucine"
	case "UCU", "UCC", "UCA", "UCG":
		protein = "Serine"
	case "UAU", "UAC":
		protein = "Tyrosine"
	case "UGU", "UGC":
		protein = "Cysteine"
	case "UGG":
		protein = "Tryptophan"
	case "UAA", "UAG", "UGA":
		return "STOP", ErrStop
	default:
		return "", ErrInvalidBase
	}
	return protein, nil
}
