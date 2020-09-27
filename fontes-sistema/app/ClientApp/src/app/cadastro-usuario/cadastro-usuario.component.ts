import { Dominio } from '../models/Dominio';
import { UsuarioApiService } from '../services/usuarioApi.service';
import { Usuario } from '../models/Usuario';
import { Component, OnInit } from '@angular/core';
import { DadosTelaCadastroUsuario } from 'app/models/responseDTO/DadosTelaCadastroUsuario';
import { PesquisarUsuarioDTO } from 'app/models/requestDTO/pesquisarUsuarioDTO';
// import {NgForm} from '@angular/forms';

@Component({
    selector: 'cadastro-usuario',
    templateUrl: './cadastro-usuario.component.html',
    styleUrls: ['./cadastro-usuario.component.css'],
    providers: [UsuarioApiService]
})
export class CadastroUsuarioComponent implements OnInit {

    private usuario: Usuario;
    public modoConsulta: boolean;
    private listaUsuarios: Usuario[];
    private listaPerfil: Dominio[];

    private dadosTela: DadosTelaCadastroUsuario;

    constructor(private usuarioApiService: UsuarioApiService) {
        this.usuario = new Usuario();
        this.dadosTela = new DadosTelaCadastroUsuario();
        this.modoConsulta = true;
    }

    ngOnInit() {
        this.listarUsuarios();
    }

    pesquisar(event: any){

        let request = new PesquisarUsuarioDTO();

        request.nome = event.target.txtFiltroNome.value;
        request.login = event.target.txtFiltroLogin.value;
        request.codigoUsuario = event.target.selFiltroPerfil.value;

        this.usuarioApiService.listarUsuarios(request)
        .subscribe((usuarios: Usuario[]) => {    
            this.listaUsuarios = usuarios;
        });        

    }    

    listarUsuarios(codigoUsuario: number = null) {

        let request: PesquisarUsuarioDTO = new PesquisarUsuarioDTO();

        if(codigoUsuario){
            request.codigoUsuario = codigoUsuario.toString();
        }

        this.usuarioApiService.listarUsuarios(request)
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

        this.usuarioApiService.listarPerfil()
            .subscribe((listaPerfil: Dominio[]) => {
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
        this.usuarioApiService.deletarUsuario(codigoUsuario)
            .subscribe();
    }

    cadastrar() {
        this.usuarioApiService.cadastrarUsuario(this.usuario).subscribe(() => alert('sucesso'), error => console.log(error));
    }

    cadastrarNovo() {
        this.modoConsulta = false;
    }

    selectPerfilChange($event) {
        this.usuario.codigoPerfil = this.listaPerfil[$event - 1].codigo;
    }

}
