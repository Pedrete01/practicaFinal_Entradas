import { Component } from "@angular/core";

@Component({
    selector: "inicio-view",
    template: './inicioView.component.html',
    styleUrls: ["inicioView.component.css"]
})

export default class InicioView {

    title = "Entradas";
    descripcion = "¡Bienvenidos a la web!";
}