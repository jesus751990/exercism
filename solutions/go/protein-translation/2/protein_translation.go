// Translate RNA sequences into proteins.
package protein

import "errors"

var (
	ErrInvalidBase = errors.New("ErrInvalidBase")
	ErrStop        = errors.New("ErrStop")
)

// FromRNA Translate RNA sequences into Codon sequences and this into Proteins
func FromRNA(rna string) ([]string, error) {
	var proteins []string
	for i := 0; i < len(rna); i += 3 {

		if protein, err := FromCodon(rna[i:(i + 3)]); err == nil {
			proteins = append(proteins, protein)
		} else if err == ErrStop {
			return proteins, nil
		} else {
			return proteins, err
		}
	}
	return proteins, nil
}

// FromCodon Translate Codon sequences into proteins.
func FromCodon(codon string) (string, error) {
	switch codon {
	case "AUG":
		return "Methionine", nil
	case "UUU", "UUC":
		return "Phenylalanine", nil
	case "UUA", "UUG":
		return "Leucine", nil
	case "UCU", "UCC", "UCA", "UCG":
		return "Serine", nil
	case "UAU", "UAC":
		return "Tyrosine", nil
	case "UGU", "UGC":
		return "Cysteine", nil
	case "UGG":
		return "Tryptophan", nil
	case "UAA", "UAG", "UGA":
		return "STOP", ErrStop
	default:
		return "", ErrInvalidBase
	}
}
