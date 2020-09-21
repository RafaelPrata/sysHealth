import { Perfil } from '../models/Perfil';
import { ApiService } from '../services/api.service';
import { Usuario } from '../models/Usuario';
import { Component, OnInit } from '@angular/core';
// import {NgForm} from '@angular/forms';

@Component({
    selector: 'cadastro-usuario',
    templateUrl: './cadastro-usuario.component.html',
    styleUrls: ['./cadastro-usuario.component.css'],
    providers: [ApiService]
})
export class CadastroUsuarioComponent implements OnInit {

    private usuario: Usuario;
    public modoConsulta: boolean;
    private listaUsuarios: Usuario[];
    private listaPerfil: Perfil[];

    constructor(private apiService: ApiService) {
        this.usuario = new Usuario();
        this.modoConsulta = true;
    }

    ngOnInit() {
        this.listarUsuarios();
    }

    listarUsuarios(codigoUsuario: number = null) {
        this.apiService.listarUsuarios(codigoUsuario)
            .subscribe((usuarios: Usuario[]) => {

                if (codigoUsuario) {
                    this.usuario = usuarios[0];

                    console.log(this.usuario);
                }
                else
                    this.listaUsuarios = usuarios;

            });
    }

    exibirFormularioCadastro(codigoUsuario: number = null) {

        this.modoConsulta = false;

        this.apiService.listarPerfil()
            .subscribe((listaPerfil: Perfil[]) => {
                this.listaPerfil = listaPerfil;
            });

        if (codigoUsuario) {
            this.listarUsuarios(codigoUsuario);
        }
        else
            this.limparCampos();

    }

    limparCampos() {
        this.usuario = new Usuario();
    }

    excluirCadastro(codigoUsuario: number) {
        this.apiService.deletarUsuario(codigoUsuario)
            .subscribe();
    }

    cadastrar() {
        this.apiService.cadastrarUsuario(this.usuario).subscribe(() => alert('sucesso'), error => console.log(error));
    }

    selectPerfilChange($event) {
        this.usuario.codigoPerfil = this.listaPerfil[$event - 1].codigo;
    }

}
