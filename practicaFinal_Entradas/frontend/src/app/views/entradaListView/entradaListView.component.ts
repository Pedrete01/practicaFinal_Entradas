import { Component, OnInit } from "@angular/core";
import { Entradas } from "../../services/entradas.services";

@Component({
    selector: "entradas-list",
    templateUrl: './entradaListView.component.html',
    styleUrls: ["entradaListView.component.css"]
})

export default class EntradaListView implements OnInit {

    title = "Entradas";
    descripcion = "Todas las entradas disponibles";

    constructor(public entrada: Entradas) {
    }

    ngOnInit() {
        this.entrada.loadEntradas()
            .subscribe(() => {
                // do something
            });
    }
}