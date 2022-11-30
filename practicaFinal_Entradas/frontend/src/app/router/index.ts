import { RouterModule } from "@angular/router";
import { EntradasPage } from "../pages/entradas.component";
import { InicioPage } from "../pages/inicio.component";
import { DetallesPage } from "../pages/detalles.component";
import { RegistroPage } from "../pages/registro.component";


const routes = [
    { path: '', component: InicioPage },
    { path: 'Entradas', component: EntradasPage },
    { path: 'Entradas/:id', component: DetallesPage },
    { path: 'Account/Registro', component: RegistroPage },
    { path: '**',redirectTo: '/Home', component: InicioPage }
];

const router = RouterModule.forRoot(routes, {
    useHash: false
});

export default router;