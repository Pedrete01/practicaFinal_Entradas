import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Entradas } from "../../services/entradas.services";

@Component({
    selector: "entrada-detalle",
    templateUrl: './entradaView.component.html',
    styleUrls: ["entradaView.component.css"]
})

export default class EntradaView implements OnInit {

    id: string | null | undefined;
    constructor(public entrada: Entradas, private activatedRoute: ActivatedRoute) {
        this.activatedRoute.params.subscribe(params => {
            this.id = params["id"];
        })
    }

    ngOnInit() {
        this.entrada.loadEntrada(this.id)
            .subscribe(() => {

            });
    }
}