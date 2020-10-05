import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Usuario } from '../models/Usuario';
import { Router, ActivatedRoute } from '@angular/router';
import { AutenticacaoService } from '../services/autenticacao.service';
import { LoaderService } from '../services/loader.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers: [AutenticacaoService]
})
export class LoginComponent implements OnInit {

    @Output()
    autenticado = new EventEmitter<boolean>();

    form: FormGroup;
    returnUrl: string;

    constructor(private autenticacaoService: AutenticacaoService,
        private loaderService: LoaderService,
        private router: Router,
        private route: ActivatedRoute) { }

    ngOnInit(): void {

        this.form = new FormGroup({
            username: new FormControl(),
            password: new FormControl()
        });

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    submit() {

        let login: string = this.form.controls.username.value;
        let senha: string = this.form.controls.password.value;

        this.autenticacaoService.autenticar(login, senha).subscribe((usuarioAutenticado: boolean) => {

            if (!usuarioAutenticado) {
                alert('Login ou senha inválidos.');

                this.form.reset();
            }

            //this.loaderService.display(autenticado);
            //this.autenticacaoService.setAutenticado(autenticado);
            this.autenticado.emit(usuarioAutenticado);

        }, (error) => console.log(error));


        //this.loaderService.display(true);
        this.autenticacaoService.setAutenticado(true);
    }

}
