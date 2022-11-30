import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { EntradasPage } from './pages/entradas.component';
import { InicioPage } from './pages/inicio.component';
import { RegistroPage } from './pages/registro.component';
import router from './router';
import { Categorias } from './services/categorias.services';
import { Entradas } from './services/entradas.services';
import CategoriaListView from './views/categoriaListView/categoriaListView.component';
import EntradaListView from './views/entradaListView/entradaListView.component';

@NgModule({
    declarations: [
        AppComponent,
        CategoriaListView,
        EntradaListView,
        EntradasPage,
        InicioPage,
        RegistroPage
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        router,
        ReactiveFormsModule
    ],
    providers: [
        Categorias,
        Entradas
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
