import { Component, OnInit } from "@angular/core";
import { Entradas } from "../services/entradas.services";
import { ActivatedRoute, Router } from "@angular/router";
import { BehaviorSubject, first } from "rxjs";
import { AccountService } from "../services/account.services";

@Component({
    selector: "detalles-page",
    templateUrl: '../views/entradaView/entradaView.component.html',
    styleUrls: ["../views/entradaView/entradaView.component.css"]
})

export class DetallesPage implements OnInit {

    id: string | null | undefined;
    nombre: string | null | undefined;
    imagen: string | null | undefined;
    precio: string | null | undefined;
    descCorta: string | null | undefined;
    descLarga: string | null | undefined;
    ubicacion: string | null | undefined;
    ciudad: string | null | undefined;
    pais: string | null | undefined;


    constructor(public entrada: Entradas, private activatedRoute: ActivatedRoute, private router: Router,) {
        this.activatedRoute.params.subscribe(params => {
            this.id = params["id"];
        });
    }

    ngOnInit(): void {
        this.entrada.loadEntrada(this.id)
            .subscribe(() => {
                this.nombre = this.entrada.entrada.entradaName;
                this.imagen = this.entrada.entrada.imagen;
                this.precio = this.entrada.entrada.precio;
                this.descCorta = this.entrada.entrada.entradaDescripCorta;
                this.descLarga = this.entrada.entrada.entradaDescripLarga;
                this.ubicacion = this.entrada.entrada.ubicacion;
                this.ciudad = this.entrada.entrada.ciudad;
                this.pais = this.entrada.entrada.pais;
            });
    }

    eliminar(): any {
        this.entrada.eliminar(this.id)
            .pipe(first())
            .subscribe({
                next: () => {
                    this.router.navigate([''], { relativeTo: this.activatedRoute });
                },
                error: (error: any) => {
                    console.log("Error al eliminar entrada");
                    return;
                }
            });
        return;
    }
}