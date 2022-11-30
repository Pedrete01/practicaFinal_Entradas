import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs";
import { AccountService } from "../services/account.services";
import { User } from "../shared/Usuarios";


@Component({
    selector: "registro-page",
    templateUrl: '../views/accountView/registroView.component.html'
})
export class RegistroPage implements OnInit {
    title = "Registro";
    formRegister = this.formbuilder.group({
        Username: new FormControl('', {
            validators: [Validators.required]
        }),
        Email: new FormControl('', {
            validators: [Validators.required, Validators.email]
        }),
        Password: new FormControl('', {
            validators: [Validators.required, Validators.minLength(8)]
        }),
        conPassword: new FormControl('', {
            validators: [Validators.required, Validators.minLength(8)]
        }),
        Terms: new FormControl('', {
            validators: [Validators.required, Validators.requiredTrue]
        }),
    });

    loading: boolean | undefined;
    submitted: boolean | undefined;

    constructor(
        private formbuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private accountService: AccountService,) {

    }

    ngOnInit(): void {

    }

    send(): any {
        this.submitted = true;

        if (this.formRegister.invalid) {
            return;
        }
        const Username = this.formRegister.value.Username;
        const Email = this.formRegister.value.Email;
        const Password = this.formRegister.value.Password;
        const conPassword = this.formRegister.value.conPassword;
        const Terms = this.formRegister.value.Terms;

        if (Password != conPassword) {
            return;
        }

        if (!Terms) {
            return;
        }

        this.loading = true;
        this.accountService.register(Username, Email, Password)
            .pipe(first())
            .subscribe({
                next: () => {
                    this.router.navigate([''], { relativeTo: this.route });
                },
                error: (error: any) => {
                    this.loading = false;
                }
            });
        this.router.navigate([''], { relativeTo: this.route });
        return;
    }
}