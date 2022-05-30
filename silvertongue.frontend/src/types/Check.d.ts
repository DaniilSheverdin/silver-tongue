import {  ISpellError} from "./SpellError.d";
export interface ICheck {
	checkID: number;
	date: string;
	phrase: string;
	isGrammarCorrect: boolean;
	isSpellCorect: boolean;
	errors: ISpellError[];
}

					