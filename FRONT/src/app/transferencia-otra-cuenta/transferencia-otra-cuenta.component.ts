import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-transferencia-otra-cuenta',
  templateUrl: './transferencia-otra-cuenta.component.html',
  styleUrls: ['./transferencia-otra-cuenta.component.css']
})
export class TransferenciaOtraCuentaComponent implements OnInit {

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
