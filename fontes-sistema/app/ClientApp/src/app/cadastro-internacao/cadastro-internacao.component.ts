import { ApiService } from '../services/api.service';
import { Component, OnInit } from '@angular/core';
// import {NgForm} from '@angular/forms';

@Component({
    selector: 'cadastro-internacao',
    templateUrl: './cadastro-internacao.component.html',
    styleUrls: ['./cadastro-internacao.component.css'],
    providers: [ApiService]
})
export class CadastroInternacaoComponent implements OnInit {

    constructor(private apiService: ApiService) {

    }

    ngOnInit() {

    }    

    cadastrar(){
        
    }
}
