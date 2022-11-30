import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { Categoria } from "../shared/Categoria";
import { Entrada } from "../shared/Entrada";

@Injectable()
export class Categorias {

    constructor(private http: HttpClient) {

    }

    public listaCategorias: Categoria[] = [] as any[];
    public listaDestacadas: Entrada[] = [] as any[];

    loadCategorias(): Observable<void> {
        return this.http.get<[]>("/api/Categoria")
            .pipe(map(data => {
                this.listaCategorias = data;
                return;
            }));
    }

    loadEntradasDestacadas(): Observable<void> {
        return this.http.get<[]>("/api/Entrada/Destacadas")
            .pipe(map(data => {
                this.listaDestacadas = data;
                return;
            }))
    }
}
