import { Component, OnInit } from '@angular/core';
import { LoaderService } from 'app/services/loader.service';

@Component({
  selector: 'app-central-leitos',
  templateUrl: './central-leitos.component.html',
  styleUrls: ['./central-leitos.component.css']
})
export class CentralLeitosComponent implements OnInit {

  constructor(private loaderservice: LoaderService) { }

  ngOnInit(): void {
      
  }

  load(){
    this.loaderservice.display(true);
  }

}
