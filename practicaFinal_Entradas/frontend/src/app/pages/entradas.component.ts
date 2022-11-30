import { Component, OnInit } from "@angular/core";
import { Entradas } from "../services/entradas.services";

@Component({
    selector: "entradas-page",
    templateUrl: '../views/entradaListView/entradaListView.component.html',
    styleUrls: ["../views/entradaListView/entradaListView.component.css"]
})

export class EntradasPage implements OnInit {

    title = "Entradas";
    descripcion = "Todas las entradas disponibles";

    constructor(public entrada: Entradas) {
    }

    ngOnInit() {
        this.entrada.loadEntradas()
            .subscribe(() => {
                
            });
    }
}