import { Entrada } from "./Entrada";

export class Categoria {
    categoriaId: number | undefined;
    name: string | undefined;
    categoriaDescrip: string | undefined;
    entradas: Entrada[] | undefined;
}