import { Component, OnInit } from '@angular/core';
import { DatosUsuarioService } from '../Services/datos-usuario.service';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-ver-detalles',
  templateUrl: './ver-detalles.component.html',
  styleUrls: ['./ver-detalles.component.css']
})
export class VerDetallesComponent implements OnInit {
  public usuario:any;
  public datosusuario:any;
  constructor(private datousuario:DatosUsuarioService,private router:Router) {
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
   }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    if(id!=''){
      this.datousuario.obtenercuenta(parseInt(id)).subscribe(
        data=> {
          console.log(data);
          this.usuario=data;
        }
      );
    }else{
      this.router.navigateByUrl('404');
    }
    
  }

}
