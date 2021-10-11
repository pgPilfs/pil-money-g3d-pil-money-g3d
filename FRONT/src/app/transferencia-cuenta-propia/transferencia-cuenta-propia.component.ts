import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-transferencia-cuenta-propia',
  templateUrl: './transferencia-cuenta-propia.component.html',
  styleUrls: ['./transferencia-cuenta-propia.component.css']
})
export class TransferenciaCuentaPropiaComponent implements OnInit {

  constructor(private router:Router) { 
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
  }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    if(id==''){
      this.router.navigateByUrl('404');
    }
  }

}
