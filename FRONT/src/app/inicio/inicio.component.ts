import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DatosUsuarioService } from '../Services/datos-usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {
  public usuario:any;
  public datosusuario:any;
  constructor(private datousuario:DatosUsuarioService, private router:Router) { 
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
  }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    
      this.datousuario.obtenercuenta(parseInt(id)).subscribe(
        data=> {
          this.usuario=data;
        },err=>{
         
        }
      );
  
      this.datousuario.ObtenerDatos(parseInt(id)).subscribe(
        datos=> {
          this.datosusuario=datos;
        }
      );
    
     
    
   

    
  }
isUserAuthenticated(){
  const token: string = localStorage.getItem('jwt')||'';
  if(token)
  {
    return true;
  }
  else
  {
    return false;
  }
}
}
