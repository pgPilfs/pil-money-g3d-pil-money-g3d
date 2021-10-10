import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
import { ContactoService } from '../Services/contacto.service';

@Component({
  selector: 'app-transferencia',
  templateUrl: './transferencia.component.html',
  styleUrls: ['./transferencia.component.css']
})
export class TransferenciaComponent implements OnInit {
  public contacto:any;
  public item:any;
  constructor(private router:Router, private datoContactos: ContactoService) {
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
   }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    if(id==''){
      this.router.navigateByUrl('404');
    }

    this.datoContactos.ObtenerContactos(parseInt(id)).subscribe(datoContactos => {
      this.item = this.datoContactos;
    });
  }

}
