import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-transferencia-contacto',
  templateUrl: './transferencia-contacto.component.html',
  styleUrls: ['./transferencia-contacto.component.css']
})
export class TransferenciaContactoComponent implements OnInit {

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
