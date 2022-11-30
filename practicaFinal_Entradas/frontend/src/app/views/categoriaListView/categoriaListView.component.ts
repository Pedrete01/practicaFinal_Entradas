import { Component, OnInit } from "@angular/core";
import { Categorias } from "../../services/categorias.services";

@Component({
    selector: "categorias-list",
    templateUrl: './categoriaListView.component.html',
    styleUrls: ["categoriaListView.component.css"]
})

export default class CategoriaListView implements OnInit {

    constructor(public categoria: Categorias) {
    }

    ngOnInit() {
        this.categoria.loadCategorias()
            .subscribe(() => {
                // do something
            });
        this.categoria.loadEntradasDestacadas()
            .subscribe(() => {
                // do something
            });
    }
}