import { Injectable, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { Entrada } from "../shared/Entrada";
import { ActivatedRoute } from "@angular/router";

@Injectable()
export class Entradas implements OnInit {

    constructor(private http: HttpClient, private route: ActivatedRoute) {

    }

    ngOnInit(): void {
        
    }

    public entrada: Entrada | any;
    public listaEntradas: Entrada[] = [] as any[];

    loadEntradas(): Observable<void> {
        return this.http.get<[]>("/api/Entrada")
            .pipe(map(data => {
                this.listaEntradas = data;
                return;
            }));
    }

    loadEntrada(id: any) {
        let path = "/api/Entrada/" + id;
        return this.http.get<Entrada>(path)
            .pipe(map(data => {
                this.entrada = data;
                return;
            }))
    }

    comprar(id: any) {
        console.log("Has comprado:" );
        console.log("Entrada id:" + id);
    }

    eliminar(id: any) {
        let path = "/api/Entrada/" + id;
        return this.http.delete(path);
    }

    modificar(id: any) {
        let path = "/api/Entrada/" + id;
        console.log("Modificar " + id);
        return;
    }
}
